using AutoParts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Core.Constants
{
    public interface IFileService
    {
        Task SaveFileAsync(ApplicationFile file);
    }
}
