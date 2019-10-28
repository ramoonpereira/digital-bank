using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.Models.DigitalAccountTransaction
{
    public enum TransactionStatusEnum
    {
        Pending = 0,
        Effected = 1,
        Denied = 2
    }
}
