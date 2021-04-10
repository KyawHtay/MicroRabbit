using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Application.Models
{
    public class AccountTransfer
    {
        public int FromAccount { set; get; }
        public int ToAccount { set; get; }
        public decimal TransferAmount { get; set; }

    }
}
