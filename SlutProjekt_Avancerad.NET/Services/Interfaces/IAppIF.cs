namespace SlutProjekt_Avancerad.NET.Services.Interfaces
{
    public interface IAppIF<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
