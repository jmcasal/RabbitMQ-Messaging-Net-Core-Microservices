﻿using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {

        private readonly TransferDbContext _dbContext;

        public TransferRepository(TransferDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _dbContext.TransferLogs;
        }
    }
}
