using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Model {
    public class AlunoModel {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? AlunoID { get; set; }
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        [Required(ErrorMessage ="Data de nascimento é obrigatória")]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime? DataNascimento {get; set; }
        public string? Diagnostico { get; set; }
    }
}