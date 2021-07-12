using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SI.Meditourism.UploadDocument.Interface
{
    public interface IFormFile
    {
        string ContentType { get; }
        string ContentDisposition { get; }
        long Length { get; }
        string Name { get; }
        string FileName { get; }
        Stream OpenReadStream();
    }
}
