using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteCRUDModel
{
    [Table("ENDERECO")]
    public class EnderecoModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string CEP { get; set; }

        [MaxLength(100)]
        [Required]
        public string Rua { get; set; }

        [MaxLength(20)]
        [Required]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }

        [MaxLength(100)]
        [Required]
        public string Bairro { get; set; }

        [MaxLength(100)]
        [Required]
        public string Cidade { get; set; }

        [MaxLength(2)]
        [Required]
        public string UF { get; set; }
    }
}
