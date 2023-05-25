using Microsoft.AspNetCore.Mvc.RazorPages;
using WebLab.Data;
using WebLab.Models;
using WebLab.Services;

namespace WebLab.Pages;

public class index : PageModel
{
    public JsonService JsonService;

    public IEnumerable<Feature> Features { get; private set; }
    public IEnumerable<Testimonials> Testimonials { get; private set; }
    private readonly Context context;
    public index(JsonService jsonService)
    {
        JsonService = jsonService;
    }
    public void OnGet()
    {
        Features = JsonService.GetFeatures();
        Testimonials = JsonService.GetTestimonials();
    }
}