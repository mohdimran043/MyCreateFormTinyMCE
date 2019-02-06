using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyCreateForm.Services
{
    /// <summary>
    /// Summary description for ReportService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ReportService : System.Web.Services.WebService
    {

        [WebMethod]
        public string FileUploader(HttpPostedFileBase file)
        {
            return "path";
        }
        [WebMethod]
        public string ConvertImageToBase64()
        {
            string base64String = "";
          //  string response = new string();

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["file"];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(httpPostedFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(httpPostedFile.ContentLength);
                        base64String = System.Convert.ToBase64String(fileData, 0, fileData.Length);
                    }
                }
            }

            //response.Content = new StringContent(base64String);
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            return "";
        }
    }
}
