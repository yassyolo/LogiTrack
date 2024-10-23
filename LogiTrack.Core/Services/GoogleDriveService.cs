using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using LogiTrack.Core.Contracts;

namespace LogiTrack.Core.Services
{
    public class GoogleDriveService : IGoogleDriveService
    {
        private readonly string serviceAccountJson = @"{
 test
}";


        public async Task<DriveService> GetDriveServiceAsync()
        {
            GoogleCredential credentials = GoogleCredential.FromJson(serviceAccountJson)
                                                           .CreateScoped(DriveService.Scope.DriveFile);

            return new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credentials,
                ApplicationName = "LogiTrack"
            });
        }

        public async Task<string> UploadFileAsync(string filePath, string mimeType, string folderId = null)
        {
            var driveService = await GetDriveServiceAsync();

            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = Path.GetFileName(filePath),
                MimeType = mimeType,
                Parents = folderId != null ? new List<string> { folderId } : null
            };

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var request = driveService.Files.Create(fileMetadata, fileStream, mimeType);
                request.Fields = "id";

                var uploadProgress = await request.UploadAsync();

                if (uploadProgress.Status == Google.Apis.Upload.UploadStatus.Completed)
                {
                    return request.ResponseBody.Id;
                }
                else
                {
                    throw new Exception($"Error while uploading file: {uploadProgress.Exception}");
                }
            }
        }

        public async Task<IList<Google.Apis.Drive.v3.Data.File>> ListFilesAsync(int pageSize = 10)
        {
            var driveService = await GetDriveServiceAsync();
            var request = driveService.Files.List();
            request.PageSize = pageSize;
            request.Fields = "nextPageToken, files(id, name)";

            var result = await request.ExecuteAsync();
            return result.Files;
        }
    }
}
