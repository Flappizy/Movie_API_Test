using Microsoft.AspNetCore.Http;
using Soft_Alliance.APP.Domain.Enums;

namespace Soft_Alliance.APP.Domain.Services;

public interface IFileManager
{
    Task<(byte[], string)> GetFileByteDataAsync(IFormFile file, FileSize size);
}
