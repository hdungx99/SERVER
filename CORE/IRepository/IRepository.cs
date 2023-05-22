namespace CORE
{
    public interface IRepository<TEntity, TModel> where TEntity : BaseEntity, new() where TModel : BaseEntity, new()
    {
        Task Add(TModel model);
        Task Update(TModel model);
        Task Delete(Guid id);
        Task<TModel> GetById(Guid id);
        Task<List<TModel>> GetAll();
    }
}
