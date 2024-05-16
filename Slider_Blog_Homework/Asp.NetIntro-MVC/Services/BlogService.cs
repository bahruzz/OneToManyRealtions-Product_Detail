using Asp.NetIntro_MVC.Data;
using Asp.NetIntro_MVC.Models;
using Asp.NetIntro_MVC.Services.Interface;
using Asp.NetIntro_MVC.ViewModels.Blog;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Asp.NetIntro_MVC.Services
{
    public class BlogService : IBlogService

    {
        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BlogVM>> GetAllAsync(int? take=null)
        {
            IEnumerable<Blog> blogs;
            if (take is null)
            {
                blogs=await _context.Blogs.ToListAsync();
            }
            else
            {
                blogs=await _context.Blogs.Take((int) take).ToListAsync();  
            }

            return blogs.Select(m => new BlogVM { Title = m.Title, Description = m.Description, Image = m.Image, CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy") });


        }
    }
}
