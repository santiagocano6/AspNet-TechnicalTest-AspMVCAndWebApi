using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comunes.Models
{
    [Table("stores")]
    public class DepositoModels
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        [Column("id")]
        public Guid DepositoId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [Display(Name = "Nombre")]
        [Column("name")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 10)]
        [Display(Name = "Dirección")]
        [Column("address")]
        public string Direccion { get; set; }

        public virtual ICollection<ArticuloModels> ArticuloModels { get; set; }
    }
}
