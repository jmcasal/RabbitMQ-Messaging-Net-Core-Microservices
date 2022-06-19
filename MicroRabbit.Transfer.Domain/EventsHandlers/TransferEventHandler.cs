
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.EventsHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        public TransferEventHandler()
        {
        }

        public void Handle(TransferCreatedEvent @event)
        {
            // empty
        }

    }
}
