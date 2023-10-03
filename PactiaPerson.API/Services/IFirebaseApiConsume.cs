namespace PactiaPerson.API.Services
{
    public interface IFirebaseApiConsume
    {
        Task<string> GetAllRecordsAsync();

        Task<string> GetRecordAsync<T>(int id);

        Task<string> AddRecordAsync<T>(T record, int id);

        Task<string> UpdateRecordAsync<T>(T record, int id);

        Task<string> DeleteRecordAsync<T>(int id);
    }
}
