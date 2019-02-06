using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
namespace MyCreateForm
{
    public partial class CreateReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    ExportOptions objExOpt;

        //    CrystalReportViewer1.ReportSource = (object)getReportDocument();
        //    CrystalReportViewer1.DataBind();
        //    // Get the report document
        //    ReportDocument repDoc = getReportDocument();

        //    repDoc.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        //    repDoc.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        //    DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
        //    objDiskOpt.DiskFileName = @"c:\crystal report\TFA.pdf";
        //    repDoc.ExportOptions.DestinationOptions = objDiskOpt;
        //    repDoc.Export();
        //}

        //private ReportDocument getReportDocument()
        //{
        //    // File Path for Crystal Report
        //    string repFilePath = Server.MapPath("~/CrystalReport1.rpt");
        //    // Declare a new Crystal Report Document object
        //    // and the report file into the report document
        //    ReportDocument repDoc = new ReportDocument();

        //    repDoc.Load(repFilePath);

        //    // Set the datasource by getting the dataset from business
        //    // layer and
        //    // In our case business layer is getCustomerData function
        //    return repDoc;
        //}
        protected void btnClick_Click(object sender, EventArgs e)
        {
            DownloadAsPDF();
        }

        public void DownloadAsPDF()
        {
            try
            {
                string strHtml = string.Empty;
                string pdfFileName = Request.PhysicalApplicationPath + "\\files\\" + "GenerateHTMLTOPDF.pdf";

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //  dvHtml.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                strHtml = sr.ReadToEnd();
                sr.Close();

                //   CreatePDFFromHTMLFile(strHtml, pdfFileName);

                Response.ContentType = "application/x-download";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", "GenerateHTMLTOPDF.pdf"));
                Response.WriteFile(pdfFileName);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }



        //public void CreatePDFFromHTMLFile(string HtmlStream, string FileName)
        //{
        //    try
        //    {
        //        object TargetFile = FileName;
        //        string ModifiedFileName = string.Empty;
        //        string FinalFileName = string.Empty;


        //        GeneratePDF.HtmlToPdfBuilder builder = new GeneratePDF.HtmlToPdfBuilder(iTextSharp.text.PageSize.A4);
        //        GeneratePDF.HtmlPdfPage first = builder.AddPage();
        //        first.AppendHtml(HtmlStream);
        //        byte[] file = builder.RenderPdf();
        //        File.WriteAllBytes(TargetFile.ToString(), file);

        //        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(TargetFile.ToString());
        //        ModifiedFileName = TargetFile.ToString();
        //        ModifiedFileName = ModifiedFileName.Insert(ModifiedFileName.Length - 4, "1");

        //        iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, new FileStream(ModifiedFileName, FileMode.Append), iTextSharp.text.pdf.PdfWriter.STRENGTH128BITS, "", "", iTextSharp.text.pdf.PdfWriter.AllowPrinting);
        //        reader.Close();
        //        if (File.Exists(TargetFile.ToString()))
        //            File.Delete(TargetFile.ToString());
        //        FinalFileName = ModifiedFileName.Remove(ModifiedFileName.Length - 5, 1);
        //        File.Copy(ModifiedFileName, FinalFileName);
        //        if (File.Exists(ModifiedFileName))
        //            File.Delete(ModifiedFileName);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}