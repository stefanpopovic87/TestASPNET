using System.ComponentModel.DataAnnotations;

namespace TestASPNET.Models
{
    public class SupportedImageType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
