using System.ComponentModel.DataAnnotations;

namespace MailManager.WebApi.Models
{
    public class NoticeDto
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(50)]
        public string Subject { get; set; }
        
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(250)]
        public string Text { get; set; }
    }
}