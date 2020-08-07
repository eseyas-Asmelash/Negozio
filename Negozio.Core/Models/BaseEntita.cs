using System;
using System.Collections.Generic;
using System.Text;

namespace Negozio.Core.Models
{
    public abstract class BaseEntita
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public BaseEntita()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }
    }
}
