using Supermarket_WebAPI.Models;
using System.Threading.Tasks;

namespace Supermarket_WebAPI.Service
{
    public interface IFileManager
    {
        Task Upload(FileModel model);
    }
}
