using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Net;

namespace MusicApi.Services
{
    public class CloudinaryUtility
    {
        private readonly Cloudinary _cloudinary;
        private readonly ILogger _logger;

        public CloudinaryUtility(IConfiguration _config, ILogger<CloudinaryUtility> logger)
        {
            var account = new Account()
            {
                Cloud = _config["Cloudnairy:CloudName"],
                ApiKey = _config["Cloudnairy:ApiKey"],
                ApiSecret = _config["Cloudnairy:ApiSecret"]

            };

            _cloudinary = new Cloudinary(account);
            _logger = logger;
        }

        public async Task<string> UploadImageAsync(IFormFile image, string savePath)
        {
            try
            {
                await using var memoryStream = new MemoryStream();
                await image.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, memoryStream),
                    Folder = $"MusicApi/{savePath}",
                    UniqueFilename = true,
                    Overwrite = true,
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.StatusCode != HttpStatusCode.OK)
                    throw new InvalidOperationException("Failed to upload image to Cloudinary.");


                return uploadResult.SecureUrl.AbsoluteUri;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Failed to upload image: {ex.Message}", ex);
                throw new InvalidOperationException($"Failed to upload image: {ex.Message}", ex);
            }
        }



    }
}
