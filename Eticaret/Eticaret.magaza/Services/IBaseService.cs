namespace Eticaret.Magaza.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task<List<T>?> GetAllAsync();
        Task<int> CreateAsync(T model);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T model);

    }
}
