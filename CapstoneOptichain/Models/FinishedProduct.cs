using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneOptichain.Models
{
	public class FinishedProduct
	{
		public int ID { get; set; }
		public string name { get; set; }
		public int QuantityProduced { get; set; }

		[ForeignKey("productionID")]
		public int productionID { get; set; } 
		Production production { get; set; }
	}
}
