using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Negozio.Core.Models
{
    public class Prodotti : BaseEntita
    {
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, 1000)]
        public double Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

    }
}
