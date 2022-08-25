using System.Collections.Generic;
using System.Linq;
using DotNet_Microservices.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Microservices.Data{
    public class PlatformRepo : IPlatFormRepo
    {
        private readonly AppDbContext _context;
        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform newPlatform)
        {
            if(newPlatform != null){
                _context.Platforms.Add(newPlatform);
            }
        }

        public IEnumerable<Platform> GetAllsPlatform()
        {
            return _context.Platforms.AsNoTracking().ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}