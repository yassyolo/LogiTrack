using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;


namespace LogiTrack.Core.Services
{
    public class GoogleDriveService
    {
        private readonly string serviceAccountJson = @"
        {
            ""type"": ""service_account"",
            ""project_id"": ""logitrack-439221"",
            ""private_key_id"": ""e3e0fd75c857f07836b73bc0483fe040af97c9e4"",
            ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCPmIHCerzVSUC6\neDW9UGk+2ilDQxEXyCqsGHk/aoXO9c0p4BotHSvY9et5LCjTDCdXAEmhjh2R//uX\ni/Rogb3ePpYInrUuJZqk7p3eahx1n0FxU0x6kneVG2GSW3M1/49uxbHQqdzHxqv4\nbLjYcuWfRA0gwUrLdAXPOJSL3YILax798sBRyGDuZ+volNgex97YUs2icB8kfsTb\nh6EpQ9rPZNYil4tBbakOcNBIemZTVtdIJ7zCcPhP5rc+mkXQVM2iSSQsZkzfyrQW\nGoN44QmJGpP18jYWij7lY8PIosVmCZYJPkZy9NBMI176H0vYizihg2ik0SoiNbfj\ndhdBcM07AgMBAAECggEAG8ZnfvsnsGe5ZfgfiO1XVilzpsd/tGZq3pvjRAFyPWxt\nEUcAOS61zwMOV4NTqDLnHxx2oZGwJY/qlc8j6N0DoUvg0G0GZZUveuyOy7khpRy3\nV1jB58mR6N0BfAJFYDH9B/OkZ9SbWGcU13oMLQ3YXXyXv3iz43OfNgxfK0iewV9e\nO6DJpb9m3W/76sU7cyra+/9De5flVVapLo4gbPuh8Ea/IGPl874N1B3nCo+yfZES\nBKleHm3DiNEpcrPRc4y9UxphaFC5LUVbp+Hb7iaAXc1FsjVruaDxzKxzgIEauLnj\nPM50OMvtdN5PgdazXMtX0h+LKbzNYQgvXQiZYxhcjQKBgQDJ2Qf/sFqo6eVDSWkm\nKDKDlRWy93Q90X/CThekeY+ZtNnWFNRi9IDjLnkZra4UgzHipL4Y2DnYuZytIL2Q\neDxEj9HHkt7vUXt+X2rpXHQa6iRGh0oUjWWUx2mO7oY2NyFPr85M9Hkuzk3ikd1q\nSgrRxbf/Mkel9KAXu57uvGzvLwKBgQC2HrToTXpEhDSZMqaQ94QtfncVgDveeNTP\n+vASwdFWI3H15zCOXMcZGCpMVxHjyURL2u4758tYHvQyKnArBa1DT+zVvqJYjssb\nUGipSYrMydfUF4YS3421oDLjzQXtKdN8JP9jQnDNIGrRvNGvPcS9JElm21bLazKa\nLwKo2psftQKBgEymTQJMvvC7+WLG4tYpl50eJSJUE+FRyBlKPHIp810kL0C7ojd9\nr+AVisk0ihGiDHSLqOCYY8coHRYlg7bz4bcLglcuL9hjcej4ZQn/INwDpAjgYUJS\nu4t2+l/btj2qS80N7uKMR+R9VVg/mfw958PnOEsBlfGwZob8qYrxJNDjAoGBAJxt\n2639fpwDgrpkCzZRpDL/gYHyV3pMB19th3BVEl4OrAAvyEE/57PiUdKopzEk24jc\nT+0cuEjErbO5SAdsJNrAeAlQaVnvrP2VH5DpHlOwu7XtTrg/VRVAuPV6UTDY0FK9\n5K95jjJjOd1VdjYztB1SYcn7dJ3dQeW1o28t9jhRAoGBAIpJSqTlkUmAenlI7pXN\nu2XV5oR8Au2MsJ1RxF6m4zoEj8J4HuKxTwwLNhxRE9yckAZoGiCeGn+ROob4Nkn2\nQi9Kn3+8rGpQfXd8lMv3yB07s4eX0OG0QAtYSQBrt4cMge1Gje4FEwU0YNKaCoiU\nvllvLT19ECYN7GCcln8VRxEU\n-----END PRIVATE KEY-----\n"",
            ""client_email"": ""drive-access@logitrack-439221.iam.gserviceaccount.com"",
            ""client_id"": ""114024770281108717557"",
            ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
            ""token_uri"": ""https://oauth2.googleapis.com/token"",
            ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
            ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/drive-access%40logitrack-439221.iam.gserviceaccount.com"",
            ""universe_domain"": ""googleapis.com""
        }";

        public async Task<DriveService> GetDriveServiceAsync()
        {
            var credentials = GoogleCredential.FromJson(serviceAccountJson).CreateScoped(DriveService.Scope.Drive);

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
