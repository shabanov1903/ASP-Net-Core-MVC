using System.ComponentModel.DataAnnotations;

namespace MailManager.WebApi.Models
{
    public class ClientDto
    {
        [Required(ErrorMessage = "������������ ����")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "������������ ����")]
        [EmailAddress(ErrorMessage = "�������� ������ ����������� ������")]
        public string Mail { get; set; }
    }
}