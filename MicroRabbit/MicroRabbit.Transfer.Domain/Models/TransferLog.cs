namespace MicroRabbit.Transfer.Domain.Models
{
	public class TransferLog
	{
		public int Id { set; get; }
		public int FromAccount { set; get; }
		public int ToAccount { set; get; }
		public decimal TransferAmount { get; set; }
	}
}