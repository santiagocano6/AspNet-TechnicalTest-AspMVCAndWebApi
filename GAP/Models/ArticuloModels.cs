using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAP.Models
{
    [Table("articles")]
    public class ArticuloModels
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        [Column("id")]
        public Guid ArticuloId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 2)]
        [Display(Name = "Nombre")]
        [Column("name")]
        public string Nombre { get; set; }

        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 0)]
        [Display(Name = "Descripción")]
        [Column("description")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [Column("price")]
        public double Precio { get; set; }

        [Required]
        [Display(Name = "Total en estante")]
        [Column("total_in_shelf")]
        public double TotalEnEstante { get; set; }

        [Required]
        [Display(Name = "Total en deposito")]
        [Column("total_in_vault")]
        public double TotalEnBodega { get; set; }

        [Required]
        [Display(Name = "Depósito")]
        [Column("store_id")]
        public Guid DepositoId { get; set; }
        public virtual DepositoModels DepositoModels { get; set; }
    }
}