using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ForumAppDbContext context;
        public PostService(ForumAppDbContext _context)
        {
            context = _context;
        }
        public async Task AddAsync(PostViewModel model)
        {
           
           Post entity = new Post()
           {
               Id = model.Id,
               Title = model.Title,
               Content = model.Content,
           };
           await context.Posts.AddAsync(entity);
           await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostViewModel>> AllPostAsync()
        {
            return await context.Posts.AsNoTracking().Select(p=>new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
            }).
            ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (entity != null)
            {
                context.Posts.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<PostViewModel> GetByIdAsync(int id)
        {
            return await context.Posts.AsNoTracking().Select(p=>new PostViewModel()
            {
                Id = id,
                Title = p.Title,
                Content = p.Content,

            }).FirstAsync(p=>p.Id==id);
        }

        public async Task UpdateAsync(PostViewModel model)
        {
            var entity = await context.Posts.FindAsync(model.Id);
            if (entity != null)
            {
                entity.Title = model.Title;
                entity.Content = model.Content;
                context.Posts.Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
