namespace IsraaJournals.Services.File
{
    public interface IFileServises
    {
        Task<string> UploadImageAsync(IFormFile file);
        Task<string> SaveFile(IFormFile file, string folderName);
    }
}
