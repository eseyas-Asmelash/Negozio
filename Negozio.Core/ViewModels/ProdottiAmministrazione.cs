using Negozio.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negozio.Core.ViewModels
{
     public class ProdottiAmministrazione
    {
        public Prodotti Prodotti { get; set; }
        public IEnumerable<CategoriaProdotti> CategoriaProdotti { get; set; }
    }
}
