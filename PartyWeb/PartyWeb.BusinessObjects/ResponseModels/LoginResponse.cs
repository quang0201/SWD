﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessObjects.ResponseModels
{
    public class LoginResponse<TEntity> where TEntity : class
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public TEntity Data { get; set; }
        public string Token { get; set; }
        public LoginResponse(int code, string message, TEntity data, string token)
        {
            Message = message;
            Data = data;
            Code = code;
            Token = token;
        }
    }
}
