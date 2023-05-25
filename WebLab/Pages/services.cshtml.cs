using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLab.Models;
using WebLab.Services;

namespace WebLab.Pages;

public class services : PageModel
{
    public JsonService JsonService;

    public IEnumerable<Feature> Features { get; private set; }
    public IEnumerable<Testimonials> Testimonials { get; private set; }

    public services(JsonService jsonService)
    {
        JsonService = jsonService;
    }
    public void OnGet()
    {
        Features = JsonService.GetFeatures();
        Testimonials = JsonService.GetTestimonials();
    }
}