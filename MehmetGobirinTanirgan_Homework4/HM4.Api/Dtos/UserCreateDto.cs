using System.ComponentModel.DataAnnotations;

namespace HM4.Api.Dtos
{
    public class UserCreateDto
    {
        [Required, MaxLength(50)]
        public string Firstname { get; set; }
        [Required, MaxLength(50)]
        public string Lastname { get; set; }
    }
}
