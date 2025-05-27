namespace webapi.EF.Models
{
    public class WebApi : IAppCache
    {
        public string AppSecret { get; set; } = string.Empty;
    }
}
