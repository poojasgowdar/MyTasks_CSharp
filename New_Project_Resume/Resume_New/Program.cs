using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using LicenseContext = OfficeOpenXml.LicenseContext;


namespace Resume_New
{
    public class EmployerExtractor
    {
        // Regex patterns for extracting email and work experience
        private static readonly Regex EmailPattern = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
        private static readonly Regex WorkExperiencePattern = new Regex(@"(?i)(work\s*experience|professional\s*experience|employment\s*history)", RegexOptions.Multiline);

        public class EmployerInfo
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public List<string> PreviousCompanies { get; set; } = new List<string>();
        }

        public static EmployerInfo ExtractEmployerDetailsFromPdf(string filePath)
        {
            var employerInfo = new EmployerInfo();

            try
            {
                // Extract the name from the file name (without extension)
                employerInfo.Name = Path.GetFileNameWithoutExtension(filePath);
                StringBuilder sb = new StringBuilder(employerInfo.Name);
                String[] exclude = { "Resume", "Naukari", "_", "-", "[", "]", "(", ")", "Final", "Updated", "Java", "Developer", "CV", "Software", "Engineer", "Immediate", "Joiner", "Business", "Analyst", "Product", "Owner", "Exp", "DevOps", "Devops", "ML", "Ops", "EXP", "Professional", "New", "yrs", "iOS", "Naukri", "Indeed", "LinkedIn", "Linkedin", "ym" };
                foreach (string excludeStr in exclude)
                {
                    string lower = excludeStr.ToLower();
                    string upper = excludeStr.ToUpper();
                    employerInfo.Name = employerInfo.Name.Replace(excludeStr, "");
                    employerInfo.Name = employerInfo.Name.Replace(lower, "");
                    employerInfo.Name = employerInfo.Name.Replace(upper, "");
                    for (int i = 0; i <= 20; i++)
                    {
                        for (int j = 0; j <= 12; j++)
                        {
                            employerInfo.Name = employerInfo.Name.Replace(i + "y" + j + "m", "");
                        }
                    }

                    for (
                        int i = 0; i <= 9; i++)
                    {
                        employerInfo.Name = employerInfo.Name.Replace("" + i + "", "");
                        employerInfo.Name = employerInfo.Name.Replace(" " + i + " ", "");
                        employerInfo.Name = employerInfo.Name.Replace(" " + i.ToString(), "");
                    }

                    //employerInfo.Name = Regex.Replace(excludeStr, @"\d+", "");
                    Console.WriteLine(employerInfo.Name);
                }

                // Optionally, you can split the name if needed
                // Example: Split the name into first and last name if the name is in the format "First Last"
                //var nameParts = employerInfo.Name.Split(' ');
                //if (nameParts.Length > 1)
                //{
                //    employerInfo.Name = nameParts[0] + " " + nameParts[1]; // Adjust based on how you want the name
                //}

                using (PdfDocument document = PdfDocument.Open(filePath))
                {
                    string fullText = "";
                    foreach (var page in document.GetPages())
                    {
                        fullText += page.Text;
                    }

                    // Extract Email
                    var emailMatch = EmailPattern.Match(fullText);
                    if (emailMatch.Success)
                    {
                        employerInfo.Email = emailMatch.Value;
                    }

                    // Extract Companies
                    employerInfo.PreviousCompanies = ExtractCompanies(fullText);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting details from {filePath}: {ex.Message}");
            }

            return employerInfo;
        }

        private static List<string> ExtractCompanies(string text)
        {
            var companies = new HashSet<string>();

            // Keywords that might precede company names
            string[] companyIndicators = new string[]
            {
                "worked at", "employed by", "company:", "employer:",
                "organization:", "workplace:", "corporation:",
                "previous employer", "works at"
            };

            foreach (string indicator in companyIndicators)
            {
                // Regex to find company names after indicators
                var companyMatches = Regex.Matches(text,
                    $@"(?i){Regex.Escape(indicator)}\s*([A-Z][a-zA-Z\s&\.,'-]+)(?=\n|\.|\s|$)",
                    RegexOptions.Multiline);

                foreach (Match match in companyMatches)
                {
                    if (match.Groups.Count > 1)
                    {
                        string companyName = match.Groups[1].Value.Trim();

                        // Filter out invalid or too short company names
                        if (!string.IsNullOrEmpty(companyName) &&
                            companyName.Length > 3 &&
                            !companyName.Contains("Position") &&
                            !companyName.Contains("Responsibilities"))
                        {
                            companies.Add(companyName);
                        }
                    }
                }
            }

            return new List<string>(companies);
        }

        public static void ExportToExcel(List<EmployerInfo> employerInfoList, string outputPath)
        {
            // Set license context for EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                using (var package = new ExcelPackage(new FileInfo(outputPath)))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Employer Details");

                    // Add headers
                    worksheet.Cells[1, 1].Value = "Name";
                    worksheet.Cells[1, 2].Value = "Email";
                    worksheet.Cells[1, 3].Value = "Previous Companies";

                    // Add employer information
                    for (int i = 0; i < employerInfoList.Count; i++)
                    {
                        var employer = employerInfoList[i];
                        worksheet.Cells[i + 2, 1].Value = employer.Name;
                        worksheet.Cells[i + 2, 2].Value = employer.Email;

                        // Join companies into a single cell
                        worksheet.Cells[i + 2, 3].Value =
                            employer.PreviousCompanies.Count > 0
                            ? string.Join(", ", employer.PreviousCompanies)
                            : "No companies found";
                    }

                    // Auto-fit columns
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    package.Save();
                    Console.WriteLine($"Employer details exported to {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting to Excel: {ex.Message}");
            }
        }

        public static void ProcessResumesInDirectory(string inputDirectory, string outputExcelPath)
        {
            var allEmployerInfo = new List<EmployerInfo>();

            // Process PDF files
            string[] pdfFiles = Directory.GetFiles(inputDirectory, "*.pdf");
            foreach (string pdfFile in pdfFiles)
            {
                var employerInfo = ExtractEmployerDetailsFromPdf(pdfFile);
                if (!string.IsNullOrEmpty(employerInfo.Name) ||
                    !string.IsNullOrEmpty(employerInfo.Email) ||
                    employerInfo.PreviousCompanies.Count > 0)
                {
                    allEmployerInfo.Add(employerInfo);
                }
            }

            // Export to Excel
            ExportToExcel(allEmployerInfo, outputExcelPath);
        }

        static void Main(string[] args)
        {
            string inputDirectory = @"C:\Users\SumedhNaidu\Downloads\OneDrive_2024-12-17\All Resumes"; // Directory containing PDF resumes
            string outputPath = @"C:\Users\SumedhNaidu\Desktop\EmployerDetails4.xlsx";

            ProcessResumesInDirectory(inputDirectory, outputPath);
        }
    }
}
