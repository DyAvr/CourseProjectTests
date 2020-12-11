using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CourseProjectTests.Models
{
    public class FileTest : IFormFile
    {
        public void CopyTo(Stream target)
        {
            throw new NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            return stream;
        }

        public string ContentDisposition { get; }
        public string ContentType { get; }
        public string FileName { get; }
        public IHeaderDictionary Headers { get; }
        public long Length { get; }
        public string Name { get; }

        public Stream stream;

        public FileTest(Stream stream, string fileName)
        {
            this.stream = stream;
            FileName = fileName;
        }
    }
}
