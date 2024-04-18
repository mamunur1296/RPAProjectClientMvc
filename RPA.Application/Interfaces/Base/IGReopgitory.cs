namespace RPA.Application.Interfaces.Base
{
    public interface IGReopgitory<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id, string EndPoint);
        Task<List<T>> GetAllAsync(string EndPoint);
        Task<bool> AddAsync(T model, string EndPoint);
        Task<bool> UpdateAsync(Guid id, T model, string EndPoint);
        Task<bool> DeleteAsync(Guid id, string EndPoint);
    }
}
