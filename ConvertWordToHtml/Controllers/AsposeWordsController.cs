using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspose.Words;
using Aspose.Words.Saving;


namespace ConvertWordToHtml.Controllers
{
    public class AsposeWordsController : Controller
    {
        // GET: Aspose
        public ActionResult AsposeWords()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Convert()
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                var _options = new LoadOptions(LoadFormat.Docx, string.Empty, string.Empty);
                Document doc = new Document(file.InputStream, _options);

                HtmlSaveOptions options = new HtmlSaveOptions();
                options.SaveFormat = SaveFormat.Html;
                options.CssStyleSheetType = CssStyleSheetType.Embedded;
                options.ExportImagesAsBase64 = true;

                var stream = new MemoryStream();
                doc.Save(stream, options);

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