namespace ModelViews.ModelView.Accounts
{
    public class AddNewAccountModel
    {
        public string? Username { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public string? Email { get; set; }

        public byte? Role { get; set; }

        public byte? Status { get; set; }

        public string? Infomation { get; set; }

        public string? Address { get; set; }

        public DateTime? Dob { get; set; }

        public string? Fullname { get; set; }
    }
}
