namespace UserManagerAPI.DTOs
{
    public class UpdateUserRequest
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Language { get; set; }

        public string Culture { get; set; }

        public string Password { get; set; }
    }
}
