namespace MusicApi.Attributes
{
    public class MaxFileSizeAttribute(int maxFileSize) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            var length = file?.Length ?? 0;

            return length > maxFileSize ?
                new ValidationResult($"File size is too large, max allowed size is {Constants.MaxAllowedSizeInMB} MB ") : ValidationResult.Success;
        }
    }
}
