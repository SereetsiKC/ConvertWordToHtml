using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConvertWordToHtml.Controllers
{
    public class SyncfusionController : Controller
    {
        // GET: Syncfusion
        public ActionResult Converter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Convert()
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                WordDocument document = new WordDocument(file.InputStream, FormatType.Docx);
                document.SaveOptions.HTMLExportImageAsBase64 = true;
                document.SaveOptions.HtmlExportCssStyleSheetType = CssStyleSheetType.Internal;

                var stream = new MemoryStream();
                document.Save(stream, FormatType.Html);
                document.Close();

                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                string Html = reader.ReadToEnd();

                var jsonResult = Json(new { success = true, message = "", data = Html }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }

            return Json("No files selected.");
        }
    }
}