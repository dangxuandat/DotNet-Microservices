using System.Collections.Generic;
using DotNet_Microservices.Models;
namespace DotNet_Microservices.Data{
    public interface IPlatFormRepo{
        
        IEnumerable<Platform> GetAllsPlatform();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform newPlatform);
        bool SaveChanges();
    }
}