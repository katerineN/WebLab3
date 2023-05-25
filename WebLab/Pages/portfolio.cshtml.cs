using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLab.Models;
using WebLab.Services;

namespace WebLab.Pages;

public class portfolio : PageModel
{
    public JsonService JsonService;

    public IEnumerable<Feature> Features { get; private set; }
    public IEnumerable<Testimonials> Testimonials { get; private set; }

    public portfolio(JsonService jsonService)
    {
        JsonService = jsonService;
    }
    public void OnGet()
    {
        Features = JsonService.GetFeatures();
        Testimonials = JsonService.GetTestimonials();
    }
}