using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;

namespace MattAndBrittneyWedding.api
{    
    public class GalleryController : ApiController
    {
        public IEnumerable<string> Get ()
        {
            //Return JSON list of images in app/img/gallery
            //var Images = Directory.EnumerateFiles(HostingEnvironment.MapPath("~/app/assets/img/gallery"))
            //                  .Select(fn => "~/app/assets/img/gallery" + Path.GetFileName(fn));

            var Images = new List<string>();
            foreach (var Item in Directory.EnumerateFiles(HostingEnvironment.MapPath("~/app/assets/img/gallery"), "*.jpg").ToList())
            {
                Images.Add(Item.Substring(Item.IndexOf("\\app")));
            }
           
            return Images;
        }
    }
}