using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrossExchange.Models
{
    public class Portfolio
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public virtual List<Trade> Trade { get; set; }

        
    }
}
