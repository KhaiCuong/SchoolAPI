namespace WebAPI.IFile
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file);
         
    }
}
