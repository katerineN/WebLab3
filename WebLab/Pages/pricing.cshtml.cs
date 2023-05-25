using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLab.Models;
using WebLab.Services;

namespace WebLab.Pages;

public class pricing : PageModel
{
    public JsonService JsonService;

    public IEnumerable<Feature> Features { get; private set; }
    public IEnumerable<Testimonials> Testimonials { get; private set; }

    public pricing(JsonService jsonService)
    {
        JsonService = jsonService;
    }
    public void OnGet()
    {
        Features = JsonService.GetFeatures();
        Testimonials = JsonService.GetTestimonials();
    }
}