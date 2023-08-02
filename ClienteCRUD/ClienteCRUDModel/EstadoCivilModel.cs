using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteCRUDModel
{
    [Table("ESTADOCIVIL")]
    public class EstadoCivilModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

    }
}
