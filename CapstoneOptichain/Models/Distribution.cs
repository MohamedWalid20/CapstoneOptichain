using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneOptichain.Models
{
	public class Distribution
	{
		public int ID { get; set; }
		public int QuantityDistributed { get; set; }
		public string DeliveryDate { get; set; }
		public string Destination { get; set; }

		[ForeignKey("workerID")]
		public int workerID { get; set; }
		Worker worker { get; set; }

		[ForeignKey("productID")]
		public int productID { get; set; }
		FinishedProduct Finishedproduct { get; set; }
	}
}
