using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MattAndBrittneyWedding.Repository
{
    public class MemberRepository : BaseRepository
    {
        public async Task<bool> GetMember(String Username, String Password)
        {
            return await Task.Run(() =>
            {
                var Query = @"select * from Member where Username = @Username and Password = @Password";
                SetUpRawSQL(new { @Username = Username, @Password = Password }, Query);

                var Rows = SqlCommand.ExecuteScalar();

                if (Rows != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }
    }
}