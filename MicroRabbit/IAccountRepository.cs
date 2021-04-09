using System;


namespace MicroRabbit.Banking.Domain.Interfaces 
{ 
	public interface IAccountRepository
	{
		IEnumrable<Account> GetAccount();
	}
}
