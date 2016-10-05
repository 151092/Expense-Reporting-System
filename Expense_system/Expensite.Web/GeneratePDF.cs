using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;



namespace Expensite.Web
{
    public class GeneratePDF
    {
        public static void htmltopdf(string HTMLCode, string filePath, StyleSheet Css)
        {


            Document document = new Document();

            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(HTMLCode), Css);
            for (int k = 0; k < htmlarraylist.Count; k++)
            {
                document.Add((IElement)htmlarraylist[k]);
            }
            document.Close();
        }
        public static void htmltopdfWithHTML(string HTMLCode, string filePath, StyleSheet Css)
        {
            //StyleSheet styles = new StyleSheet();
            //styles.LoadStyle("seperator", "border-top", "#a9a9a9 2px solid");



            TextReader reader = new StringReader(HTMLCode);

            Document document = new Document(PageSize.A4, 10, 10, 10, 10);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

            HTMLWorker worker = new HTMLWorker(document);


            document.Open();
            worker.StartDocument();

            worker.Parse(reader);

            worker.EndDocument();
            worker.Close();
            document.Close();

        }
    }
}
