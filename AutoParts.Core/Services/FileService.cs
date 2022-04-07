using AutoParts.Core.Constants;
using AutoParts.Infrastructure.Data;
using AutoParts.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Core.Services
{
    public class FileService : IFileService
    {
        private readonly IApplicationDbRepository repo;

        public FileService(IApplicationDbRepository _repo)
        {
            repo = _repo;   
        }

        public async Task SaveFileAsync(ApplicationFile file)
        {
            await repo.AddAsync(file);
            await repo.SaveChangesAsync();
        }
    }
}
