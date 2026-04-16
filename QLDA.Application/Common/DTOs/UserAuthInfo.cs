namespace QLDA.Application.Common.DTOs
{
    public class UserAuthInfo
    {
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Permissions { get; set; } = new List<string>();
    }
}
