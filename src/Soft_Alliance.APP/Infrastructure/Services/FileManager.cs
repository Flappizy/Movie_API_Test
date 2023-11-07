using Microsoft.AspNetCore.Http;
using Soft_Alliance.APP.Domain.Enums;
using Soft_Alliance.APP.Domain.Services;

namespace Soft_Alliance.APP.Infrastructure.Services;
public class FileManager : IFileManager
{
    public async Task<(byte[], string)> GetFileByteDataAsync(IFormFile file, FileSize size)
    {
        byte[] fileData;

        if (!IsValidFileSize(size, file)) return (null, null);

        using (var uploadedFileData = new MemoryStream())
        {
            await file.CopyToAsync(uploadedFileData);
            uploadedFileData.Position = 0;
            fileData = uploadedFileData.ToArray();

            if (!IsValidFileExtension(file, uploadedFileData))
                return (null, null);
        }

        return (fileData, Path.GetExtension(file.FileName));
    }

    private bool IsValidFileExtension(IFormFile file, MemoryStream uploadedFileData)
    {
        var ext = Path.GetExtension(file.FileName).ToUpperInvariant();

        if (string.IsNullOrEmpty(ext) || !_fileSignature.ContainsKey(ext))
            return false;

        var signatures = _fileSignature[ext];
        var headerBytes = uploadedFileData.ToArray();

        return signatures.Any(signature =>
            headerBytes.Take(signature.Length).SequenceEqual(signature));
    }

    private bool IsValidFileSize(FileSize size, IFormFile file)
    {
        var fileSize = file.Length;
        var kilobyte = new decimal(1024);
        var megabyte = new decimal(1024 * 1024);
        var flag = false;

        switch (size)
        {
            case FileSize.KB:
                flag = fileSize <= kilobyte;
                break;
            case FileSize.MB:
                flag = fileSize <= megabyte;
                break;
            default:
                break;
        }
        return flag;
    }

    private readonly Dictionary<string, List<byte[]>> _fileSignature = new()
    {
        { ".PNG", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
        {
            ".JPG",
            new List<byte[]>
                            {
                                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                                new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                                new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 }
                            }
        },
        {
            ".JPEG",
            new List<byte[]>
                            {
                                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                                new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                                new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
                            }
        }
    };
}
