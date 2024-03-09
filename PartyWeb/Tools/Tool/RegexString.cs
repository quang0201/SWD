using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tools.Tool
{
    public class RegexString
    {
        private static RegexString instance = default!;

        public static RegexString Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RegexString();
                }
                return instance;
            }
        }

        public bool CheckStringMinMax(string pattern, int min, int max)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                return false;
            }
            if(pattern.Length < min || pattern.Length > max)
            {
                return false;
            }
            return true;
        }

        public bool ValidateInput(string input)
        {
            string pattern = @"^[a-zA-Z0-9]+$";
            return Regex.IsMatch(input, pattern);
        }
        public bool ValidateInputOnlyNumber(string input)
        {
            string pattern = @"^[0-9]+$";
            return Regex.IsMatch(input, pattern);
        }
        public bool ValidateEmail(string input)
        {
            string pattern = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
            return Regex.IsMatch(input, pattern);
        }

        public bool ValidateInputVietnamese(string input)
        {
            string pattern = @"^[a-zA-Z0-9.,\s\u00C0-\u1EF9]$";
            // Chấp nhận chữ cái, số, dấu chấm, dấu phẩy, khoảng trắng và chữ cái tiếng Việt, tối thiểu 2 ký tự
            return Regex.IsMatch(input, pattern);
        }






        public bool ValidateInput(string input, int min)
        {
            string pattern = @"^[a-zA-Z0-9\s]{" + min + ",}$";
            return Regex.IsMatch(input, pattern);
        }
        public bool ValidateInput(string input, int min, int max)
        {
            string pattern = $@"^[a-zA-Z0-9 ]{{{min},{max}}}$";
            return Regex.IsMatch(input, pattern);
        }

        

        public bool ValidateInputVietnamese(string input, int min)
        {
            string pattern = @"^[\p{{L}}\p{{M}}0-9\s]{" + min + ",}$";
            return Regex.IsMatch(input, pattern);
        }
        public bool ValidateInputVietnamese(string input, int min, int max)
        {
            string pattern = $@"^[\p{{L}}\p{{M}}0-9\s]{{{min},{max}}}$";
            return Regex.IsMatch(input, pattern);
        }
        public bool ValidateInputDigitsLengthMinMax(string input, int min, int max)
        {
            string pattern = $@"^\d{{{min},{max}}}$";
            return Regex.IsMatch(input, pattern);
        }
    }
}
