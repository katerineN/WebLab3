using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLab.Data;
using WebLab.Models;
using WebLab.Services;

namespace WebLab.Pages;
[IgnoreAntiforgeryToken]
public class contact : DefaultModel
{
    [BindProperty] 
    public ContactForm SelectedFormContact { get; set; } 

    private readonly ILogger<index> logger;
    public CsvService CsvService0 { get; set; }
    private readonly Context _context;

    public contact(Context context, CsvService csvService, ILogger<index> log): base("contact")
    {
        logger = log;
        CsvService0 = csvService;
        _context = context;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        foreach (var key in Request.Form.Keys)
        {
            logger.LogInformation($"{key}:{Request.Form[key]}");
        }


        if (SelectedFormContact.First_Name == null || SelectedFormContact.First_Name == "")
        {
            return Content("<div class=\"error_message\">Attention! You must enter your name.</div>");
        }

        _context.FormContacts.Add(new ContactForm()
        {
            First_Name = SelectedFormContact.First_Name, Email = SelectedFormContact.Email, Last_Name = SelectedFormContact.Last_Name, Phone = SelectedFormContact.Phone
        });
        CsvService.WriteToCsv(SelectedFormContact!);
        ContactsInsert(SelectedFormContact);
        return Content($@"<fieldset>
                        <div id='success_page'> 
                        <h1>Email Sent Successfully.</h1>
                        <p>Thank you <strong>{SelectedFormContact!.First_Name}<strong>, your message has been submitted to us.<p>
                        </div>
                    <fieldset>");
    }
    
    public static void ContactsInsert(ContactForm cnt)
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        var options = new DbContextOptionsBuilder<Context>()
            .UseSqlite(config.GetConnectionString("Default"))
            .Options;

        using (var context = new Context(options))
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();

            context.FormContacts.Add(cnt);
            context.SaveChanges();
        }
    }
}