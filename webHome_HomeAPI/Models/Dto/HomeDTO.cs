using System.ComponentModel.DataAnnotations;

namespace webHome_HomeAPI.Models.Dto
{
    public class HomeDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
