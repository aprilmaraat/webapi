namespace webapi.Utilities
{
    public class JwtSetting : IJwtSetting
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public JwtSetting() { }
        public JwtSetting(string secretKey, string issuer, string audience)
        {
            SecretKey = secretKey;
            Issuer = issuer;
            Audience = audience;
        }
    }
}
