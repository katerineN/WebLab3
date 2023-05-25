using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebLab.Pages;

public class DefaultModel : PageModel
{
    public string _pageName;
    public DefaultModel(string name)
    {
        _pageName = name;
    }
}