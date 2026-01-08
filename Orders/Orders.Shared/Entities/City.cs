using Orders.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Orders.Shared.Entities
{
    public class City : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; } = null!;

        public int StateId { get; set; }
        public State? State { get; set; } = null!;
    }
}
