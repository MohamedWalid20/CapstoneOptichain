using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneOptichain.Models
{
	public class Production
	{
		public int ID { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string Status { get; set; }


		[ForeignKey("managerID")]
		public int managerID { get; set; }
		public Manager manager { get; set; }


		[ForeignKey("workerID")]
		public int workerID { get; set; }
		public Worker worker { get; set; }
	}
}
