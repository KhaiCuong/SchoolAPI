namespace WebAPI.IFile
{
    public class FileServiceImp : IFileService
    {   
        private readonly string _uploadFolder;
        public FileServiceImp(IWebHostEnvironment webHostEnvironment)
        {
            _uploadFolder = Path.Combine(webHostEnvironment.ContentRootPath, "uploads");
            if(!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string fileName = Path.GetFileName(_uploadFolder);
            string filePath = Path.Combine(_uploadFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
