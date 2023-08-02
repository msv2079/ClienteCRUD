using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteCRUDModel
{
    [Table("CLIENTE")]
    public class ClienteModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string CPF { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(15)]
        public string RG { get; set; }

        [DisplayName("Data de Expedição")]
        public DateTime? DataExpedicao { get; set; }

        public int OrgaoExpedicaoId { get; set; }

        [DisplayName("Orgão de Expedição")]
        [ForeignKey("OrgaoExpedicaoId")]
        public OrgaoExpedicaoModel OrgaoExpedicao { get; set; }

        [DisplayName("UF de Expedição")]
        [MaxLength(2)]
        public string UFExpedicao { get; set; }

        [DisplayName("Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public int SexoId { get; set; }

        [ForeignKey("SexoId")]
        public SexoModel Sexo { get; set; }

        [Required]
        public int EstadoCivilId { get; set; }

        [ForeignKey("EstadoCivilId")]
        public EstadoCivilModel EstadoCivil { get; set; }

        [Required]
        public int EnderecoId { get; set; }

        [ForeignKey("EnderecoId")]
        public EnderecoModel Endereco { get; set; }

        [NotMapped]
        public int TotalClientes { get; set; }
    }
}
