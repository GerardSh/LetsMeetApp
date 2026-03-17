namespace LetsMeetApp.Web.ViewModels.Shared
{
    public class OperationResult
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty; 
        public Dictionary<string, string> Errors { get; set; } = new();
    }
}
