using MattAndBrittneyWedding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MattAndBrittneyWedding.Repository
{
    public class GuestBookRepository : BaseRepository
    {
        public async Task AddEntry (GuestBookModel GuestBook)
        {
            try
            {
                await Task.Run(() =>
                {
                    var Query = @"insert into GuestBook (Message, Email, Name) values 
                                    (@Message, @Email, @Name)";
                    var Params = new { @Message = GuestBook.Message, @Email = GuestBook.Email, @Name = GuestBook.Name };

                    SetUpRawSQL(Params, Query);
                    SqlCommand.ExecuteNonQuery();                
                });
            }
            catch (Exception Ex)
            {

            }
        }

        public async Task ApproveEntry (int ID)
        {
            try
            {
                await Task.Run(() =>
                {
                    var Query = @"update GuestBook set IsVisible = 1 where GuestBookID = @GuestBookID";
                    var Params = new { @GuestBookID = ID };

                    SetUpRawSQL(Params, Query);
                    SqlCommand.ExecuteNonQuery();                
                });
            }
            catch (Exception Ex)
            {

            }
        }

        public async Task RemoveEntry (int ID)
        {
            try
            {
                await Task.Run(() =>
                {
                    var Query = @"update GuestBook set IsDeleted = 1 where GuestBookID = @GuestBookID";
                    var Params = new { @GuestBookID = ID };

                    SetUpRawSQL(Params, Query);
                    SqlCommand.ExecuteNonQuery();                
                });
            }
            catch (Exception Ex)
            {

            }
        }

        public async Task <List<GuestBookModel>> GetEntries (bool GetAll)
        {
            var L = new List<GuestBookModel>();

            return await Task.Run(() =>
            {
                var Query = @"select * from GuestBook where (IsVisible = @GetAll or @GetAll = 0) and IsDeleted = 0 order by Injected asc";
                SetUpRawSQL(new { @GetAll = GetAll }, Query);

                var Reader = SqlCommand.ExecuteReader();
                while(Reader.Read())
                {
                    var I = new GuestBookModel();
                    MapResultsToObject<GuestBookModel>(ref Reader, ref I);
                    L.Add(I);
                }

                return L;
            });
        }
    }
}