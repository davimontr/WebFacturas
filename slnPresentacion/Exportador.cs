using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slnPresentacion
{
    public class Exportador
    {
        protected bool ocultarComandos;

        public Exportador(bool ocultarComandos = false)
        {
            this.ocultarComandos = ocultarComandos;
        }

        protected void ocultarCeldaComandos(GridView cuadricula)
        {
            //
            foreach (GridViewRow fila in cuadricula.Rows)
            {
                if (fila.RowType == DataControlRowType.DataRow)
                {
                    foreach (TableCell celda in fila.Cells)
                    {
                        DataControlField campo = ((DataControlFieldCell)celda).ContainingField;
                        if (campo.GetType().Name == "CommandField")
                        {
                            celda.Visible = false;
                        }
                    }
                }
            }
        }

        public void enPDF(GridView cuadricula, HttpResponse respuesta)
        {
            using (StringWriter escritor = new StringWriter())
            {
                using (HtmlTextWriter escritorHTML = new HtmlTextWriter(escritor))
                {

                    if(this.ocultarComandos)
                    {
                        this.ocultarCeldaComandos(cuadricula);
                    }
                    cuadricula.RenderControl(escritorHTML);
                    //cuadricula.RenderBeginTag(escritorHTML);

                    //
                    StringReader lector = new StringReader(escritor.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter escritorPDF = PdfWriter.GetInstance(pdfDoc, respuesta.OutputStream);
                    //
                    pdfDoc.Open();
                    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(escritorPDF, pdfDoc, lector);
                    pdfDoc.Close();
                    //
                    respuesta.ContentType = "application/pdf";
                    respuesta.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                    respuesta.Cache.SetCacheability(HttpCacheability.NoCache);
                    respuesta.Write(pdfDoc);
                    respuesta.End();
                }
            }
        }


        public void reportPDF(GridView cuadricula, HttpResponse respuesta)
        {
            using (StringWriter escritor = new StringWriter())
            {
                using (HtmlTextWriter escritorHTML = new HtmlTextWriter(escritor))
                {
                    if(this.ocultarComandos)
                    {
                        this.ocultarCeldaComandos(cuadricula);
                    }
                    //cuadricula.RenderControl(escritorHTML);
                    cuadricula.RenderBeginTag(escritorHTML);
                    //
                    StringReader lector = new StringReader(escritor.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                    PdfWriter escritorPDF = PdfWriter.GetInstance(pdfDoc, respuesta.OutputStream);
                    //
                    pdfDoc.Open();
                    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(escritorPDF, pdfDoc, lector);
                    pdfDoc.Close();
                    //
                    respuesta.ContentType = "application/pdf";
                    respuesta.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                    respuesta.Cache.SetCacheability(HttpCacheability.NoCache);
                    respuesta.Write(pdfDoc);
                    respuesta.End();
                }
            }
        }



    }
}