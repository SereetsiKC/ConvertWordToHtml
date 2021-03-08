using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Mammoth;

namespace ConvertWordToHtml.Controllers
{
    public class MammothConverterController : Controller
    {
        // GET: MammothConverter
        public ActionResult Converter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConvertToHtml()
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                var converter = new DocumentConverter(); 
                
                converter.ImageConverter(image =>
                {
                    using (var stream = image.GetStream())
                    {
                        var base64 = ConvertToBase64(stream);
                        var src = "data:" + image.ContentType + ";base64," + base64;
                        return new Dictionary<string, string> { { "src", src } };
                    }
                });
                var result = converter.ConvertToHtml(file.InputStream);
                string Html = result.Value;

                //if (result.Warnings.Any())
                //{
                //    var reponse = Json(new { success = true, message = "", data = result.Warnings.ToList() }, JsonRequestBehavior.AllowGet);
                //    reponse.MaxJsonLength = int.MaxValue;
                //    return reponse;
                //}

                var jsonResult = Json(new { success = true, message = "", data = Html }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }

            return Json("No files selected.");
        }

        private Stream ConvertToBase64(Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {

                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);
            return new MemoryStream(Encoding.UTF8.GetBytes(base64));
        }
    }
}