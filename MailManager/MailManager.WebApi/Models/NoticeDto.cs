using System.ComponentModel.DataAnnotations;

namespace MailManager.WebApi.Models
{
    public class NoticeDto
    {
        [Required(ErrorMessage = "������������ ����")]
        [MaxLength(50)]
        public string Subject { get; set; }
        
        [Required(ErrorMessage = "������������ ����")]
        [MaxLength(250)]
        public string Text { get; set; }
    }
}