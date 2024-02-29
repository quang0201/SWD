using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.ResponseModels
{
    public class AccountForm
    {
        public int Id { get; set; }

        public string IdNumber { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Email { get; set; }

        public byte Role { get; set; }

        public byte Status { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public DateTime? Dob { get; set; }

        public string? Infomation { get; set; }
    }
}
