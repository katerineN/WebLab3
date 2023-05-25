using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using WebLab.Models;

namespace WebLab.Services;

public class CsvService
{
    public CsvService(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
    }

    public static IWebHostEnvironment WebHostEnvironment { get; set; }

    private static string CsvFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "form_data.csv");

    public static void WriteToCsv(ContactForm contact)
    {
        Console.WriteLine(CsvFileName);
        using (var fs = new StreamWriter(CsvFileName, true))
        using (var csv = new CsvWriter(fs,CultureInfo.InvariantCulture))
        {
            if (fs.BaseStream.Length == 0)
            {
                csv.WriteHeader<ContactForm>();
            }
            csv.NextRecord();
            csv.WriteRecord(contact);
        }
    }

}