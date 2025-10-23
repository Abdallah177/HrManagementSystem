namespace HrManagementSystem.Common.Authntication.Jwt
{
    public class JwtSettings
    {
        public static string SectionName = "Jwt";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
