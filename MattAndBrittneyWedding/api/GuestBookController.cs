using MattAndBrittneyWedding.Models;
using MattAndBrittneyWedding.Repository;
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
            //if (GRepo == null)
            //    GRepo = new GuestBookRepository();
        }

        //public async Task<IHttpActionResult> Post ([FromBody]GuestBookModel Model)
        //{
        //    await GRepo.AddEntry(Model);
        //    return Ok();
        //}

        //public async Task<IEnumerable> Get()
        //{
        //    return await GRepo.GetEntries(true);
        //}

        //[Route("api/guestbook/GetAll")]
        //public async Task<IEnumerable> GetAll()
        //{
        //    return await GRepo.GetEntries(false);
        //}
    }
}