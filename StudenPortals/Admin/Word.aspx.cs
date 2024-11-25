using DAL;
using MSSU;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
//using BAL;
using Microsoft.Reporting.WebForms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Web;
using System.Web.UI;

namespace StudenPortals.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        StudentLogin l = new StudentLogin();
        DALClass objdal = new DALClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearchby_Click(object sender, EventArgs e)
        {
            l.Mode = "Download";
            ds = objdal.DownloadWord(l);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ReportViewer rpt = new ReportViewer();
                ReportViewer1.Reset();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource obj1 = new ReportDataSource("DataSet1", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(obj1);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Admin/Report/Word.rdlc");
                    ReportViewer1.LocalReport.Refresh();
                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    //byte[] bytePdfRep = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings); // for PDF

                    byte[] bytePdfRep = ReportViewer1.LocalReport.Render("WORDOPENXML", null, out mimeType, out encoding, out extension, out streamids, out warnings); // for WORD

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Buffer = true;

                    //Response.ContentType = "application/pdf";  // for PDF
                    //Response.AddHeader("content-disposition", "attachment;filename=\"Application_" + ApplicationNo + "ChallanReceipt" + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".pdf\""); // for PDF

                    Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";  // for WORD
                    Response.AddHeader("content-disposition", "attachment;filename=\"WordFile_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".docx\""); // for WORD

                    Response.BinaryWrite(bytePdfRep);
                    Response.End();
                }
            }

            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Error in downloading WordFile')", true);
            }
        }
    }
}