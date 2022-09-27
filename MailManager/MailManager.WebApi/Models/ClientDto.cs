using System.ComponentModel.DataAnnotations;

namespace MailManager.WebApi.Models
{
    public class ClientDto
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Обязательное поле")]
        [EmailAddress(ErrorMessage = "Неверный формат элетронного адреса")]
        public string Mail { get; set; }
    }
}