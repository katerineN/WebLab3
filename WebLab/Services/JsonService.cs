using System.Text.Json;
using WebLab.Models;

namespace WebLab.Services;

public class JsonService
{
    public JsonService(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
    }

    public IWebHostEnvironment WebHostEnvironment { get; }

    private string GetJsonFileName(string filename)
    {
        return Path.Combine(WebHostEnvironment.WebRootPath, "data", filename);
    }

    public IEnumerable<Feature> GetFeatures()
    {
        using (var jsonReader = File.OpenText(GetJsonFileName("Features.json")))
        {
            return JsonSerializer.Deserialize<Feature[]>(jsonReader.ReadToEnd(), 
                new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                })!;
        }
    }

    public IEnumerable<Testimonials> GetTestimonials()
    {
        using (var jsonReader = File.OpenText(GetJsonFileName("Testimonial.json")))
        {
            return JsonSerializer.Deserialize<Testimonials[]>(jsonReader.ReadToEnd(), 
                new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                })!;
        }
    }
}