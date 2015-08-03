using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MattAndBrittneyWedding.Repository
{
    public abstract class BaseRepository : IDisposable
    {
        private String ConnectionString { get; set; }

        public SqlConnection SqlConn { get; set; }

        protected SqlCommand SqlCommand { get; set; }

        public BaseRepository ()
        {
            ConnectionString = WebConfigurationManager.AppSettings["ConnectionString"].ToString();

            CheckConnection();

            //This is potentially dangerous, as this will allow the webserver to potentially wait indefinitely for a SPROC to execute
            //SqlCommand.CommandTimeout = 0;
        }

        /// <summary>
        /// Check the SQL Command object connection state and set it up for use by inherited repositories
        /// </summary>
        private void CheckConnection ()
        {
            if (SqlConn == null)
                SqlConn = new SqlConnection(ConnectionString);

            if (SqlCommand == null)
                SqlCommand = new SqlCommand();

            if (SqlConn.State != ConnectionState.Open)
                SqlConn.Open();
        }

        /// <summary>
        /// Set up SqlCommand object for stored procedure execution
        /// </summary>
        /// <param name="Params"></param>
        /// <param name="CommandText"></param>
        protected void SetupSproc (dynamic Params, String CommandText)
        {
            //Clear any existing parameters
            SqlCommand.Parameters.Clear();

            if (Params != null)
            {
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.CommandText = CommandText;
                SqlCommand.Connection = SqlConn;

                foreach (var prop in Params.GetType().GetProperties())
                {
                    SqlCommand.Parameters.Add(new SqlParameter(prop.Name, prop.GetValue(Params, null)));
                }
            }
        }

        /// <summary>
        /// Set up SqlCommand object for raw sql execution
        /// </summary>
        /// <param name="Params"></param>
        /// <param name="SQL"></param>
        protected void SetUpRawSQL (dynamic Params, String SQL)
        {
            //Clear any existing parameters
            SqlCommand.Parameters.Clear();

            SqlCommand.CommandText = SQL;
            SqlCommand.Connection = SqlConn;
            SqlCommand.CommandType = CommandType.Text;

            foreach (var prop in Params.GetType().GetProperties())
            {
                SqlCommand.Parameters.Add(new SqlParameter(prop.Name, prop.GetValue(Params, null)));
            }
        }

        /// <summary>
        /// Map a SqlDataReader to a given type object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Source"></param>
        /// <param name="Target"></param>
        protected void MapResultsToObject<T> (ref SqlDataReader Source, ref T Target)
        {
            var Columns = new List<string>();
            for (int i = 0; i < Source.FieldCount; i++)
            {
                Columns.Add(Source.GetName(i));
            }

            foreach (var Column in Columns)
            {
                if (Target.GetType().GetProperties().FirstOrDefault(x => x.Name == Column) != null)
                {
                    Type TargetType = Target.GetType().GetProperty(Column).PropertyType;

                    switch (TargetType.ToString())
                    {
                        case "System.Decimal":
                            Target.GetType().GetProperty(Column).SetValue(Target, Convert.ChangeType((Source[Column] == DBNull.Value ? 0 : Source[Column]), TargetType), null);
                            break;

                        case "System.String":
                            Target.GetType().GetProperty(Column).SetValue(Target, Convert.ChangeType((Source[Column] == DBNull.Value ? String.Empty : Source[Column]), TargetType), null);
                            break;

                        case "System.DateTime":
                            Target.GetType().GetProperty(Column).SetValue(Target, Convert.ChangeType((Source[Column] == DBNull.Value ? new DateTime(2000, 1, 1) : Source[Column]), TargetType), null);
                            break;

                        case "System.Int32":
                            Target.GetType().GetProperty(Column).SetValue(Target, Convert.ChangeType((Source[Column] == DBNull.Value ? 0 : Source[Column]), TargetType), null);
                            break;

                        case "System.Boolean":
                            Target.GetType().GetProperty(Column).SetValue(Target, Convert.ChangeType((Source[Column] == DBNull.Value ? false : Source[Column]), TargetType), null);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// IDisposable Dispose() method --> IDisposeable Finalizer pattern
        /// </summary>
        private bool Disposed = false;
        public void Dispose ()
        {
            Dispose(true);

            //Once we have manually closed SQL and cleared objects, this line tells the GC this object doesn't need to be marked for GC, as we've already done it
            GC.SuppressFinalize(this);
        }

        ~BaseRepository () //finalizer, called by the GC
        {
            Dispose(false);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose (bool Disposing)
        {
            if (Disposed)
                return;

            if (Disposing)
            { //clear managed resources
                //Close SQL Connection stuffs
                SqlCommand.Dispose();
                SqlConn.Close();
            }

            //Free any unmanaged objects here. 
            //Currently we aren't using any unmanaged resources

            Disposed = true;
        }
    }
}