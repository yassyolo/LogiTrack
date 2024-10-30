using Google.Apis.Drive.v3;

namespace LogiTrack.Core.Contracts
{
    public interface IGoogleDriveService
    {
        DriveService GetDriveServiceAsync();
        Task<string> UploadFileAsync(string filePath, string mimeType, string? folderId = null);
        Task<IList<Google.Apis.Drive.v3.Data.File>> ListFilesAsync(int pageSize = 10);
        Task<string> GetFileUrlAsync(string fileId);
    }
}
