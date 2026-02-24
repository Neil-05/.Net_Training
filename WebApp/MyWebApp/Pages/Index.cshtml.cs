using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string MobileNumber { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string Message { get; set; }

    public void OnPost()
    {
        if (!string.IsNullOrEmpty(Name) &&
            !string.IsNullOrEmpty(Email) &&
            !string.IsNullOrEmpty(MobileNumber) &&
            !string.IsNullOrEmpty(Password))
        {
            Message = "Registration Successful!";
        }
        else
        {
            Message = "Please fill all fields.";
        }
    }
}