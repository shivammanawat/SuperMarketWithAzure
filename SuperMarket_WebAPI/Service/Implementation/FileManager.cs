using Azure.Storage.Blobs;
using Supermarket_WebAPI.Models;
using System.Threading.Tasks;

namespace Supermarket_WebAPI.Service
{
    public class FileManager : IFileManager
    { 
        private readonly BlobServiceClient _blobServiceClient;
        public FileManager(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload(FileModel model)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("uploadfile");

            var blobClient = blobContainer.GetBlobClient(model.ImageFile.FileName);

            await blobClient.UploadAsync(model.ImageFile.OpenReadStream());
        }



    }
}
