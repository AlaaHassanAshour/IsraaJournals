namespace IsraaJournals.Services.File
{
    public class FileServises:IFileServises
    {
        private readonly IWebHostEnvironment _env;

        public FileServises(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> SaveFile(IFormFile file, string folderName)
        {
            string fileName = null;
            if (file != null && file.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, folderName);
                // Replace to format only
                fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                await using var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
        public async Task<string> UploadImageAsync(IFormFile file)
        {
            var uploadFolder = Path.Combine(_env.WebRootPath, "File");
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // await ResizeImage(filePath, uploadFolder, fileName);
            return fileName;

        }
    }
}
