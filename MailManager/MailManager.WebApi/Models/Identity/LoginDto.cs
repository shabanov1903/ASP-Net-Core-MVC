using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MailManager.WebApi.Models.Identity
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; } = null;
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null;

        [Display(Name = "Запомнить пароль")]
        public bool RememberMe { get; set; } = false;

        [HiddenInput(DisplayValue = false)]
        public string? ReturnUrl { get; set; }
    }
}
