namespace webapi.Services
{
    public interface IWorkTypeService
    {
        Task<List<string>> GetWorkTypesAsync();
    }
}
