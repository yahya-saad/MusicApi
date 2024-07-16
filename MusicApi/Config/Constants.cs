namespace MusicApi.Config
{
    public static class Constants
    {
        public const string AllowedExtensions = "jpg,jpeg,png,wepb";
        public const int MaxAllowedSizeInMB = 3;
        public const int MaxAllowedSizeInBytes = MaxAllowedSizeInMB * 1024 * 1024;
    }
}
