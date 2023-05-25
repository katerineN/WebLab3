namespace WebLab.Models;

public class ContactForm
{
    public int ID { get; set; }
    public string? First_Name { get; set; }
    public string? Last_Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Select_Service { get; set; }
    public string? Select_Price { get; set; }
    public string? Comments { get; set; }
}