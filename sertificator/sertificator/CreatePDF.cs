using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Crypto.Tls;


namespace sertificator
{
    class CreatePDF
    {
        private Sertificat sertificat;
        private Services service;
        public CreatePDF(Sertificat sertificatCur, Services serviceCur)
        {

            sertificat = sertificatCur;
            service = serviceCur;

        }

        public void Create()
        {
            string company = service._company;
            int number = Sertificat.CurrentNumber;
            string clientName = sertificat.Person;
            DateTime date = sertificat.DateOrder;
            string adminName = sertificat.Administrator;
            string textService; //about proc
            service.ReadTextService(sertificat.CodOfOrder, out textService);
            string filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string imagePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string font = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            const string str1 = "Сертификат";
            string str2 = "#" + number;
            string addadm = "Администратор: "+adminName;
            string numString = number.ToString();
            string dateString = date.ToShortDateString();
            using (FileStream fs = new FileStream(filePath + @"/results/" + numString +"_ww_"+dateString+".pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Rectangle pagesize = new Rectangle(PageSize.A5.Rotate()); //size of document
                Document doc = new Document(pagesize, 0f, 0f, 0f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                Image jpg = Image.GetInstance(imagePath + @"/resourses/image.jpg");
                jpg.ScaleToFit(610f, 420f); // size of image
                jpg.Alignment = Image.UNDERLYING; //image like background
                doc.Add(jpg);
                PdfPTable table = new PdfPTable(1);
                //first cell - Name of company
                FontSelector selector = new FontSelector();
                Font f = FontFactory.GetFont(font+@"/resourses/constantine.ttf", BaseFont.IDENTITY_H, true);
                f.SetColor(255, 250, 250);
                selector.AddFont(f);
                var ph = selector.Process(company);
                Paragraph companyPh = new Paragraph(ph);
                PdfPCell cell = new PdfPCell(new Phrase(companyPh));
                cell.FixedHeight = 30.0f;  // Give rows some height
                cell.BorderWidthBottom = 0f;
                cell.BorderWidthLeft = 0f;
                cell.BorderWidthTop = 0f;
                cell.BorderWidthRight = 0f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cell);
                //second cell - Const certificate title
                FontSelector selector1 = new FontSelector();
                Font f1 = FontFactory.GetFont(font+@"/resourses/constantine.ttf", BaseFont.IDENTITY_H, true, 39);
                f1.SetColor(255, 250, 250);
                selector1.AddFont(f1);
                var ph1 = selector1.Process(str1);
                Paragraph title = new Paragraph(ph1);
                PdfPCell cell1 = new PdfPCell(new Phrase(title));
                cell1.FixedHeight = 45.0f;
                cell1.BorderWidthBottom = 0f;
                cell1.BorderWidthLeft = 0f;
                cell1.BorderWidthTop = 0f;
                cell1.BorderWidthRight = 0f;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cell1);
                //third cell - Certificate number
                FontSelector selector2 = new FontSelector();
                Font f2 = FontFactory.GetFont(font+@"/resourses/constantine.ttf", BaseFont.IDENTITY_H, true, 12);
                f2.SetColor(255, 228, 196);
                selector2.AddFont(f2);
                Phrase ph2 = selector2.Process(str2);
                Paragraph num = new Paragraph(ph2);
                PdfPCell cell2 = new PdfPCell(new Phrase(num));
                cell2.FixedHeight = 20.0f;
                cell2.BorderWidthBottom = 0f;
                cell2.BorderWidthLeft = 0f;
                cell2.BorderWidthTop = 0f;
                cell2.BorderWidthRight = 0f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cell2);
                //4 cell - Title massage
                FontSelector selector3 = new FontSelector();
                Font f3 = FontFactory.GetFont(font+@"/resourses/constantine.ttf", BaseFont.IDENTITY_H, true, 20);
                f3.SetColor(255, 228, 196);
                selector3.AddFont(f3);
                Phrase ph3 = selector3.Process(textService);
                Paragraph usluga = new Paragraph(ph3);
                PdfPCell cell3 = new PdfPCell(new Phrase(usluga));
                cell3.FixedHeight = 45.0f;
                cell3.BorderWidthBottom = 0f;
                cell3.BorderWidthLeft = 0f;
                cell3.BorderWidthTop = 0f;
                cell3.BorderWidthRight = 0f;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                cell3.VerticalAlignment = Element.ALIGN_BASELINE;
                table.AddCell(cell3);
                //5 cell - Description of massage
                FontSelector selector4 = new FontSelector();
                Font f4 = FontFactory.GetFont(font+@"/resourses/constantine.ttf", BaseFont.IDENTITY_H, true, 9);
                selector4.AddFont(f4);
                Phrase ph4 = selector4.Process(textService);
                Paragraph about = new Paragraph(ph4);
                PdfPCell cell4 = new PdfPCell(new Phrase(about));
                cell4.FixedHeight = 40.0f;
                cell4.BorderWidthBottom = 0f;
                cell4.BorderWidthLeft = 0f;
                cell4.BorderWidthTop = 0f;
                cell4.BorderWidthRight = 0f;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.VerticalAlignment = Element.ALIGN_TOP;
                table.AddCell(cell4);
                //6 cell - Name of client 
                FontSelector selector5 = new FontSelector();
                Font f5 = FontFactory.GetFont(font+@"/resourses/constantine.ttf", BaseFont.IDENTITY_H, true, 30);
                selector5.AddFont(f5);
                Phrase ph5 = selector5.Process(clientName);
                Paragraph name = new Paragraph(ph5);
                PdfPCell cell5 = new PdfPCell(new Phrase(name));
                cell5.FixedHeight = 100.0f;
                cell5.BorderWidthBottom = 0f;
                cell5.BorderWidthLeft = 0f;
                cell5.BorderWidthTop = 0f;
                cell5.BorderWidthRight = 0f;
                cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                cell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cell5);
                //7 cell - Name of admin 
                FontSelector selector6 = new FontSelector();
                Font f6 = FontFactory.GetFont(font+@"/resourses/constantine.ttf", BaseFont.IDENTITY_H, true, 10);
                f6.SetColor(30, 144, 255);
                selector6.AddFont(f6);
                Phrase ph6 = selector6.Process(addadm);
                Paragraph admin = new Paragraph(ph6);
                PdfPCell cell6 = new PdfPCell(new Phrase(admin));
                cell6.FixedHeight = 115.0f;
                cell6.BorderWidthBottom = 0f;
                cell6.BorderWidthLeft = 0f;
                cell6.BorderWidthTop = 0f;
                cell6.BorderWidthRight = 0f;
                cell6.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cell6);
                doc.Add(table);
                doc.Close();
            }

        }
    }
}