using System.Text.Json.Serialization;

namespace WebLab.Models;

public class Feature
{
    public string Headline { get; set; }
    
    public string Description { get; set; }
    [JsonPropertyName("img_path")] 
    
    public string ImgPath { get; set; }
}