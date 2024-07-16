namespace MusicApi.Attributes
{
    public class AllowedExtentionsAttribute(string allowedExtensions) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {
                var extention = Path.GetExtension(file.FileName).TrimStart('.');
                var isAllowed = allowedExtensions.Split(",").Contains(extention, StringComparer.OrdinalIgnoreCase);

                if (!isAllowed)
                    return new ValidationResult($"Invalid image format, only [{allowedExtensions}] are allowed");

            }
            return ValidationResult.Success;
        }
    }
}
