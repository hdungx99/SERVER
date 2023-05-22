using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Repository
{
    public class BulkRepositorty<TEntity, TModel> : IRepository<TEntity, TModel> where TEntity : BaseEntity, new() where TModel : BaseEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;
        public BulkRepositorty(DbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _mapper = mapper;
        }
        public async Task Add(TModel model)
        {
            var entity = _mapper.Map<List<TEntity>>(model);
            await _dbSet.BulkInsertAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var model = await _dbSet.FindAsync(id);
            var entity = _mapper.Map<List<TEntity>>(model);
            await _dbSet.BulkDeleteAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TModel>> GetAll()
        {
            var data = await _dbSet.ToListAsync();
            return _mapper.Map<List<TModel>>(data);
        }

        public async Task<TModel> GetById(Guid id)
        {
            return _mapper.Map<TModel>(await _dbSet.FindAsync(id));
        }

        public async Task Update(TModel model)
        {
            var entity = _mapper.Map<List<TEntity>>(model);
            await _dbSet.BulkUpdateAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
