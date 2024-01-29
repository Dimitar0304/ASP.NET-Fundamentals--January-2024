using ForumApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Core.Contracts
{
    public interface IPostService
    {
        public Task<IEnumerable<PostViewModel>> AllPostAsync();
        public Task<PostViewModel> GetByIdAsync(int id);
        public Task DeleteAsync(int id);
        public Task AddAsync(PostViewModel model);
        public Task UpdateAsync(PostViewModel model);

    }
}
