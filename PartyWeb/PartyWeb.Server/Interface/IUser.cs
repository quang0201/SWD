using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using ModelViews;

namespace Server.Interface
{
    public interface IUser
    {
        Task<bool> Register(Account account);
        Task<IActionResult> Login(LoginModel account);
        Task<IActionResult> GetAll();

    }
}
