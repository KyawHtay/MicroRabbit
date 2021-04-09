using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Domain.Models
{
	public class Account
	{
		public int Id { set; get; }
		public string AccountType { set; get; }
		public decimal AccountBalance { get; set; }
	}
}
