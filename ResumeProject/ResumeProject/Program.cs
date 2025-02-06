using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ResumeProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\All Resumes"; // Path to folder containing resumes
            string outputExcelPath = @"C:\ExcelOutput\ParsedResults.rtf";

            List<PersonDetails> parsedResults = new List<PersonDetails>();

            // Process all PDF and Word files
            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                if (filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    string text = ExtractTextFromPdf(filePath);
                    parsedResults.Add(ParsePersonDetails(text));
                }
                else if (filePath.EndsWith(".docx", StringComparison.OrdinalIgnoreCase))
                {
                    string text = ExtractTextFromWord(filePath);
                    parsedResults.Add(ParsePersonDetails(text));
                }
            }

            // Generate Excel output
            WriteToExcel(parsedResults, outputExcelPath);
            Console.WriteLine("Data extraction completed! Results saved to Excel.");
        }

        // Extract text from PDF using iTextSharp
        static string ExtractTextFromPdf(string pdfPath)
        {
            using (PdfReader reader = new PdfReader(pdfPath))
            {
                string text = "";
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text += PdfTextExtractor.GetTextFromPage(reader, i);
                }
                return text;
            }
        }

        // Extract text from Word document using Open XML SDK
        static string ExtractTextFromWord(string wordPath)
        {
            StringBuilder text = new StringBuilder();

            // Open the .docx file
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(wordPath, false))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;
                text.Append(body.InnerText);
            }

            return text.ToString();
        }

        // Parse person's name and company names (Simple parsing logic)
        static PersonDetails ParsePersonDetails(string text)
        {
            // Simplified parsing: Modify logic based on actual resume format
            string name = "Unknown";
            List<string> companies = new List<string>();

            string[] lines = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Assume name is the first non-empty line
            name = lines.Length > 0 ? lines[0] : "Unknown";

            // Search for company keywords (e.g., Ltd, Inc, Company)
            foreach (string line in lines)
            {
                if (line.Contains("Ltd") || line.Contains("Inc") || line.Contains("Company") || line.Contains("Pvt") || line.Contains("Systems") || line.Contains("Technologies")
                    || line.Contains("Software") || line.Contains("Solutions") || line.Contains("Services") || line.Contains("com")
                    || line.Contains("Bank") || line.Contains("IT") || line.Contains("Infotech"))
                {
                    companies.Add(line.Trim());
                }
            }

            return new PersonDetails
            {
                Name = name,
                Companies = string.Join(", ", companies)
            };
        }

        // Write results to Excel using EPPlus
        static void WriteToExcel(List<PersonDetails> results, string outputPath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Parsed Results");
                worksheet.Cells[1, 1].Value = "Person Name";
                worksheet.Cells[1, 2].Value = "Companies";

                int row = 2;
                foreach (var result in results)
                {
                    worksheet.Cells[row, 1].Value = result.Name;
                    worksheet.Cells[row, 2].Value = result.Companies;
                    row++;
                }

                FileInfo fileInfo = new FileInfo(outputPath);
                package.SaveAs(fileInfo);
            }
        }

        class PersonDetails
        {
            public string Name { get; set; }
            public string Companies { get; set; }
        }
    }
}

