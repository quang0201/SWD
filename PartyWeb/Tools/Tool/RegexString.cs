using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tools.Tool
{
    public class RegexString
    {
        private static RegexString instance;

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
        public bool ValidateInput(string input)
        {
            string pattern = @"^[a-zA-Z0-9@]{4,50}$";
            return Regex.IsMatch(input, pattern);
        }
        public bool ValidateInput(string input, int min)
        {
            string pattern = @"^[a-zA-Z0-9\s]{" + min + ",}$";
            return Regex.IsMatch(input, pattern);
        }
        public bool ValidateInput(string input, int min,int max)
        {
            string pattern = $@"^[a-zA-Z0-9 ]{{{min},{max}}}$";
            return Regex.IsMatch(input, pattern);
        }
        public bool ValidateInputVietnamese(string input)
        {
            string pattern = @"^[a-zA-Z0-9.,\s\u00C0-\u1EF9]$";
            // Chấp nhận chữ cái, số, dấu chấm, dấu phẩy, khoảng trắng và chữ cái tiếng Việt, tối thiểu 2 ký tự
            return Regex.IsMatch(input, pattern);
        }
        public bool ValidateInputVietnamese(string input, int min)
        {
            string pattern = @"^[\p{{L}}\p{{M}}0-9\s]{"+min+",}$";
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
