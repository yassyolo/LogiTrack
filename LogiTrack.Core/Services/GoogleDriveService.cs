using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using LogiTrack.Core.Contracts;

namespace LogiTrack.Core.Services
{
    public class GoogleDriveService : IGoogleDriveService
    {
        private readonly string serviceAccountJson = @"{
  ""type"": ""service_account"",
  ""project_id"": ""logitrack-439221"",
  ""private_key_id"": ""e315de1645ae9ff4990c0c223dacfae85df221ca"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCuK3oBQLxH7MCm\nk357kaO5QEC7RIBwFxkFSk0yWV0YWeKiSKUEHvttCk1xqfd4OFsVm0StFoXD52du\ntNRKKbIjTQXNqSnrPf/fFavDzHAaygXg4oo05eeZTLynpfWSzp49E8tzYmD394Wg\nYgIqhVvUbjPhtnczjuODBpq+YcgOwHqsK6fpn70OeVDsbLNZ/sSR/UrltW9gIv9F\nVMUxOFCci/5yYckHjTdnEOPRsU5l0o5sFbJcqAuHg/AmduVNYi3M9Td9ILa8VwyQ\n4OFohNrjL7CpmzeYDO26kGCQFqG0MaJEg9RIsk44vkKHCwYmwwuD0SJj5bEs9tiT\n8S1I8PtdAgMBAAECggEAGLfY39alIfwKt1lVaQoZV1A0H5+wLrhId8S8wfmGyc7v\n6CIxMS2Id0gwB4KcuXYeDynzDDGXGF9+AWsuebwDKRlkSnTImzc4WhvEPcyE2Hh1\nbx4XiTxbqxkF6TEXchdaw8ZMaHq80lRRpZpjPk+g4bwmJtFzh2CvD0hfq8dK0jTo\nn9GZVuuqfwbAh9eorjEHN4uVW7Rebe5YypiEQ/gVZB4j8qPaDNP2Q6jkuJ2MMLqV\n1l4MyQ6xDVK4wO/sH5TCha+j1o4pIbTi7VhAINIEEr4whawIenQIl2906cwHs5Io\nixxfeQPQFetl+JIe2g3e3cQ/+dKTgJ3/LN32VQrXoQKBgQDsxOHV1K2l3Jf/i8XQ\nO4EkbL2zLL5u9y72Xuo5SwhgPYScMv6s62fHC1yjPP4qfQdktaRQt5sv1BXfCTBV\nsDN6eB/3FlNVtv+igWpko7nzNeGdgFUF1XuRRnkHXPTMMQKyS4LpHiVwko2iTMdN\nQ0itMfN5bkt3wWPygVWmzvoMqQKBgQC8UPldJVmKo333/bK8UIJ8bmKM+vJ75sx9\nk1csZ8KhrL3komx5+a+bQDsb561Pf+f3A9DUhtDaYRy0OwKoZjFeE9g1sHvcm1+1\nhk5mR5weBA2bRVVUEahQmvQiwBx7DWKDmoQqBSo3odr5dgQ2gMHgtemAm3lTAxtX\nLBdEckfVlQKBgC7qTD2MqOPmtA+k6It8XviSu3wXb5yZSirzX8H+hihbyD0TNbeZ\n5bRhIfgOi+ZrY92myGpeF1gA1Fyfe35fLbQkvWC+gcDIRBs1PZm3f48brBsDZNWF\nGbkNl8nHt5IGXBxsLgJ3QL/vqjTwtcUvgeUfsrjrC/Us0tsomYo2FQIRAoGAfT9N\n2smwmCjM61dsvRq+7otsOF/fTtDeSNbqL7qDFIyTb7EnfKi4RwWdSp34AtwLJ5r+\nFZvk5JmaQbTNu7rcMrn4Hx1WBA/CxDSjiBswljYT5qVibxufWpz0qvgi+SSZ1PW7\n2Ua+IWog/bGkc6uHRzE2MDc3piJ22K+WeguYA1ECgYEA2KzgvSk+yV13yh+WNoRo\nKR5Y1B+mWDNoprN61nOUB+RfkjnGC7u6lp2/bypA1QWHcBcgHi9ieuFp8MvWRpZ7\nWWs87kf50xty5y6X4NhN22yf4Jo5bHaYjkjsahxyWf1IOiMchR7+MhRauL35cm6K\nUIUvBRLq5UQZZ3+eCbQbNhs=\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""drive-access@logitrack-439221.iam.gserviceaccount.com"",
  ""client_id"": ""114024770281108717557"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/drive-access%40logitrack-439221.iam.gserviceaccount.com"",
  ""universe_domain"": ""googleapis.com""
}";

        public DriveService GetDriveServiceAsync()
        {
            GoogleCredential credentials = GoogleCredential.FromJson(serviceAccountJson)
                                                           .CreateScoped(DriveService.Scope.DriveFile);

            return new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credentials,
                ApplicationName = "LogiTrack"
            });
        }

        public async Task<string> UploadFileAsync(string filePath, string mimeType, string? folderId = null)
        {
            var driveService = GetDriveServiceAsync();

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
            var driveService = GetDriveServiceAsync();
            var request = driveService.Files.List();
            request.PageSize = pageSize;
            request.Fields = "nextPageToken, files(id, name)";

            var result = await request.ExecuteAsync();
            return result.Files;
        }

        public async Task<string> GetFileUrlAsync(string fileId)
        {
            var driveService = GetDriveServiceAsync();    
            var request = driveService.Files.Get(fileId);
            request.Fields = "webViewLink, webContentLink";

            var file = await request.ExecuteAsync();
            return file.WebViewLink ?? file.WebContentLink;
        }
    }
}
