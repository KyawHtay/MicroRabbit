using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.EventHandlers;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services,bool isTransfer)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp=> {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

  

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand,bool>, TransferCommandHandlers>();

          
            if (!isTransfer)
            {
                //Application Service/layer
                services.AddTransient<IAccountService, AccountService>();
                //Data layer
                services.AddTransient<IAccountRepository, AccountRepository>();
                services.AddTransient<BankingDbContext>();
            }
            else
            {
                //Subscriptions
                services.AddTransient<TransferEventHandler>();

                //Domain Events
                services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

                //Application Service/layer
                services.AddTransient<ITransferService, TransferService>();
                //Data layer
                services.AddTransient<ITransferRepository, TransferRepository>();
                services.AddTransient<TransferDbContext>();

            }
        }
    }
}

























































































































































































































