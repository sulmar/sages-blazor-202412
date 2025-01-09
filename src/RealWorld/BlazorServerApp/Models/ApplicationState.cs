namespace BlazorServerApp.Models;

public class ApplicationState
{
    public string LoggedUser { get; set; } = "user1";
    public DateTime LoggedOn { get; set; } = DateTime.Now;
    public string Theme { get; set; } = "Dark";
}