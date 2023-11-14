namespace PurpleBuzz_homework.Helpers
{
    public interface IFileService
    {
        Task<string> UploadSync(string webRootPath,IFormFile file);

        void Delete(string webRootPath, string fileName );

        bool IsImage(IFormFile file);
        bool SizeCheck(IFormFile file);
    }
}
