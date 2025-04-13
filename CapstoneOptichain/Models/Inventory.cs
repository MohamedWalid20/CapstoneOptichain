using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneOptichain.Models
{
	public class Inventory
	{
		public int ID { get; set; }
		public int CurrentStock { get; set; }
		public string LastUpdated { get; set; }

		[ForeignKey("rawmaterialID")]
		public int rawmaterialID { get; set; }
		RawMaterial rawmaterial { get; set; }
	}
}
