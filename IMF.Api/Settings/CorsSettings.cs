namespace IMF.Api.Settings
{
    public class CorsSettings
    {
        public bool AllowAnyMethod { get; set; }
        public string[] AllowedOrigins { get; set; }
        public string[] AllowedMethods { get; set; }
        public string[] AllowedHeaders { get; set; }
        public bool AllowCredentials { get; set; }
    }

}
