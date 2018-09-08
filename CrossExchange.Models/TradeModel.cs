using System.ComponentModel.DataAnnotations;

namespace CrossExchange.Models
{
    public class TradeModel
    {
        [Required]
        public string Symbol { get; set; }

        [Required]
        public int NoOfShares { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        [Required]
        [RegularExpression("BUY|SELL")]
        public string Action { get; set; }
        //public TradeAction Action { get; set; }
    }
}