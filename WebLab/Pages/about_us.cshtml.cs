using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLab.Models;
using WebLab.Services;

namespace WebLab.Pages;

public class about_us : PageModel
{
    public JsonService JsonService;

    public IEnumerable<Feature> Features { get; private set; }
    public IEnumerable<Testimonials> Testimonials { get; private set; }

    public about_us(JsonService jsonService)
    {
        JsonService = jsonService;
    }
    public void OnGet()
    {
        Features = JsonService.GetFeatures();
        Testimonials = JsonService.GetTestimonials();
    }
}