using System.Text.Json.Serialization;

namespace WebLab.Models;

public class Testimonials
{
    public  int ID { get; set; }
    public string Headline { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    [JsonPropertyName("avatar_path")]
    public string AvatarPath { get; set; }
}