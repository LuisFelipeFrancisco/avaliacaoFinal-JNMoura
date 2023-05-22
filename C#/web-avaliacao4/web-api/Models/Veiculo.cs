using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo marca é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo marca deve ter no máximo 50 caracteres")]
        public string Marca { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo ano modelo é obrigatório")]
        [Range(1900, 2100, ErrorMessage = "O campo ano modelo deve estar entre 1900 e 2100")]
        public int AnoModelo { get; set; }
        [Required(ErrorMessage = "O campo data de fabricação é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "O campo data de fabricação deve ser uma data válida")]
        public DateTime DataFabricacao { get; set; }
        [Required(ErrorMessage = "O campo valor é obrigatório")]
        [Range(0, 99999999.99, ErrorMessage = "O campo valor deve estar entre 0 e 99999999.99")]
        public decimal Valor { get; set; }
        [StringLength(500, ErrorMessage = "O campo opcionais deve ter no máximo 500 caracteres")]
        public string Opcionais { get; set; }

        public Veiculo()
        {
            this.Id = 0;
            this.Marca = "";
            this.Nome = "";
            this.AnoModelo = 0;
            this.DataFabricacao = DateTime.Now;
            this.Valor = 0;
            this.Opcionais = null;
        }

    }
}