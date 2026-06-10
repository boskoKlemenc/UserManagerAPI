namespace UserManagerAPI.DTOs
{
    public class ValidatePasswordRequest
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
