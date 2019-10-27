using DigitalBank.Worker.Transaction.Business.Interfaces;
using DigitalBank.Worker.Transaction.Eventbus.Contracts;
using MassTransit;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Eventbus.EventHandlers
{
    public class TransactionEventHandler : IConsumer<ITransactionEvent>
    {
        private IServiceProvider _serviceProvider;
        public TransactionEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Consume(ConsumeContext<ITransactionEvent> context)
        {
            var transactionBusiness = _serviceProvider.GetRequiredService<IDigitalAccountTransactionBusiness>();
            await transactionBusiness.ConsistQueueAsync(context.Message.Id);
        }
    }
}
