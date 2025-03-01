using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using OfficeOpenXml;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using Aspose.Words;
using System.Text;
using System.Linq;

namespace New_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string resumeFolderPath = @"C:\All Resumes";
            string excelFilePath = @"C:\Users\Pooja S\Desktop\ResumeData.xlsx";

            if (!Directory.Exists(resumeFolderPath))
            {
                Console.WriteLine($"The folder path {resumeFolderPath} does not exist.");
                return;
            }

            HashSet<(string Name, string Company)> extractedData = new HashSet<(string, string)>();

            foreach (var file in Directory.GetFiles(resumeFolderPath))
            {
                string fileContent = string.Empty;

                if (file.EndsWith(".txt"))
                {
                    fileContent = File.ReadAllText(file);
                }
                else if (file.EndsWith(".pdf"))
                {
                    fileContent = ExtractTextFromPdf(file);
                }
                else if (file.EndsWith(".docx"))
                {
                    fileContent = ExtractTextFromWord(file);
                }

                if (!string.IsNullOrWhiteSpace(fileContent))
                {
                    (string name, string company) = ExtractEmployerDetailsFromPdf(fileContent); // Extract name and company details

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(company))
                    {
                        extractedData.Add((name, company)); // HashSet prevents duplicates
                    }
                }
            }

          
            if (extractedData.Count > 0)
            {
                ExportToExcel(extractedData, excelFilePath);
                Console.WriteLine("Data has been successfully exported to ResumeData.xlsx.");
            }
            else
            {
                Console.WriteLine("No data was extracted.");
            }
        }

        private static string ExtractTextFromPdf(string file)
        {
            StringBuilder extractedText = new StringBuilder();
            using (PdfDocument pdf = PdfDocument.Open(file))
            {
                foreach (var page in pdf.GetPages())
                {
                    extractedText.AppendLine(ContentOrderTextExtractor.GetText(page));
                }
            }
            return extractedText.ToString();
        }

       
        static (string Name, string Company) ExtractEmployerDetailsFromPdf(string text)
        {
            string name = "Unknown";
            string company = "Unknown";

            
            Match nameMatch = Regex.Match(text, @"(?i)\b(Name|Full\sName|Applicant\sName|Contact)\s*[:\-\s]*([A-Za-z\s]+)", RegexOptions.IgnoreCase);
            if (nameMatch.Success)
            {
                name = nameMatch.Groups[2].Value.Trim();
            }
            else
            {
               
                Match firstLastNameMatch = Regex.Match(text, @"(?i)\b([A-Za-z]+)\s+([A-Za-z]+)\b");
                if (firstLastNameMatch.Success)
                {
                    name = firstLastNameMatch.Groups[1].Value.Trim() + " " + firstLastNameMatch.Groups[2].Value.Trim();
                }
                else
                {
                    name = "Unknown";
                }
            }

            
            string[] companyKeywords = {
        "Systems", "Technologies", "Pvt.Ltd", "Software",
        "Solutions", "Services", ".com", "IT", "Infotech",
        "Ltd", "Corporation", "Inc", "Group", "Consulting", "Enterprises", "Limited"
    };

            HashSet<string> companies = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

           
            foreach (var keyword in companyKeywords)
            {
                
                MatchCollection matches = Regex.Matches(text, $@"\b\w*{Regex.Escape(keyword)}\w*\b", RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    string companyName = match.Value.Trim();

         
                    if (!string.IsNullOrWhiteSpace(companyName) &&
                        companyName.Length > 3 &&  
                        companyName.IndexOf("Position", StringComparison.OrdinalIgnoreCase) == -1 &&
                        companyName.IndexOf("Responsibilities", StringComparison.OrdinalIgnoreCase) == -1 &&
                        companyName.IndexOf("gmail", StringComparison.OrdinalIgnoreCase) == -1 &&
                        companyName.IndexOf("github", StringComparison.OrdinalIgnoreCase) == -1 &&
                        companyName.IndexOf("accomplishments", StringComparison.OrdinalIgnoreCase) == -1 &&
                        companyName.IndexOf("communication", StringComparison.OrdinalIgnoreCase) == -1 &&
                        companyName.IndexOf("IT", StringComparison.OrdinalIgnoreCase) == -1)
                    {
                        companies.Add(companyName);
                    }
                }
            }

            if (companies.Count > 0)
            {
                company = string.Join(", ", companies); 
            }

            return (name, company);
        }


        static string ExtractTextFromWord(string filePath)
        {
            try
            {
                Document doc = new Document(filePath);
                return doc.ToString(SaveFormat.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting text from Word document: {ex.Message}");
                return string.Empty;
            }
        }

        static void ExportToExcel(HashSet<(string Name, string Company)> data, string excelFilePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Resume Data");

                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Company";
                worksheet.Cells[1, 1, 1, 2].Style.Font.Bold = true;

             
                int row = 2;
                foreach (var entry in data)
                {
                    worksheet.Cells[row, 1].Value = entry.Name;
                    worksheet.Cells[row, 2].Value = entry.Company;
                    row++;
                }

             
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                FileInfo fileInfo = new FileInfo(excelFilePath);
                package.SaveAs(fileInfo);

                Console.WriteLine($"Excel file saved successfully at: {fileInfo.FullName}");
            }
        }
    }
}
