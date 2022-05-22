using System.ComponentModel.DataAnnotations;

namespace MailManager.WebApi.Models.Identity
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; } = null;
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null;
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Подтверждение пароля")]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; } = null;
    }
}
