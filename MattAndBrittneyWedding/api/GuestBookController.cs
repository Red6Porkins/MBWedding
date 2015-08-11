using MattAndBrittneyWedding.Models;
using MattAndBrittneyWedding.Repository;
using MattAndBrittneyWedding.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MattAndBrittneyWedding.Api
{
    public class GuestBookController : ApiController
    {
        private GuestBookRepository GRepo { get; set; }

        public GuestBookController ()
        {
            if (GRepo == null)
                GRepo = new GuestBookRepository();
        }

        public async Task<IHttpActionResult> Post ([FromBody]GuestBookModel Model)
        {
            await GRepo.AddEntry(Model);

            try
            {
                using (var Email = new EmailService())
                {
                    Email.EmailTo = "mituw16@gmail.com";
                    Email.CarbonCopy.Add("brittney.pugh@gmail.com");
                    Email.EmailFrom = "no-reply@mattandbrittney.com";
                    Email.Subject = "New Guestbook Signing: " + Model.Name;
                    Email.Message = Model.Name + " has signed your guestbook.";
                    Email.Send();
                }
            }
            catch (Exception Ex)
            {
                GRepo.WriteLog(Ex, "From Controller");
            }

            return Ok();
        }

        public async Task<IEnumerable> Get ()
        {
            return await GRepo.GetEntries(true);
        }

        [Route("api/guestbook/GetAll")]
        [Authorize]
        public async Task<IEnumerable> GetAll ()
        {
            return await GRepo.GetEntries(false);
        }

        [Authorize]
        public async Task<IHttpActionResult> Put (int ID) //approve
        {
            await GRepo.ApproveEntry(ID);
            return Ok();
        }

        [Authorize]
        public async Task<IHttpActionResult> Delete (int ID)
        {
            await GRepo.RemoveEntry(ID);
            return Ok();
        }
    }
} 