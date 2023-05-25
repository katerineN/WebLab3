using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLab.Models;
using WebLab.Services;

namespace WebLab.Pages;

public class features : PageModel
{
    public JsonService JsonService;

    public IEnumerable<Feature> FeaturesList { get; private set; }
    public IEnumerable<Testimonials> Testimonials { get; private set; }

    public features(JsonService jsonService)
    {
        JsonService = jsonService;
    }
    public void OnGet()
    {
        FeaturesList = JsonService.GetFeatures();
        Testimonials = JsonService.GetTestimonials();
    }
}