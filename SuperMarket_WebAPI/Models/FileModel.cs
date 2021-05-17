using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Supermarket_WebAPI.Models
{
    public class FileModel
    {
        public IFormFile ImageFile { get; set; }
    }

}
