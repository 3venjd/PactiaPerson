namespace PactiaPerson.API.Services
{
    public interface IFirebaseApiConsume
    {
        Task<List<T>> GetAllRecordsAsync<T>();

        Task<T> GetRecordAsync<T>(int id);

        Task<string> AddRecordAsync<T>(T record, int id);

        Task<string> UpdateRecordAsync<T>(T record, int id);

        Task<string> DeleteRecordAsync<T>(int id);
    }
}
