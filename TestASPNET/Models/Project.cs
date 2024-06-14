using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestASPNET.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Project name is required.")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Project enabled is required.")]
        public bool ProjectEnabled { get; set; }
        public bool AcceptingNewVisits { get; set; }
        public int? SupportedImageTypeId { get; set; }
        [ForeignKey("SupportedImageTypeId")]
        public SupportedImageType SupportedImageType { get; set; }
    }
}
