using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;
using System.Threading.Tasks;

namespace MattAndBrittneyWedding.Api
{    
    public class GalleryController : ApiController
    {
        public async Task<IEnumerable<string>> Get ()
        {
            return await Task.Run(() =>
            {
                var Images = new List<string>();
                foreach (var Item in Directory.EnumerateFiles(HostingEnvironment.MapPath("~/app/assets/img/gallery"), "*.jpg").ToList())
                {
                    Images.Add(Item.Substring(Item.IndexOf("\\app")));
                }

                return Images;
            });            
        }
    }
}