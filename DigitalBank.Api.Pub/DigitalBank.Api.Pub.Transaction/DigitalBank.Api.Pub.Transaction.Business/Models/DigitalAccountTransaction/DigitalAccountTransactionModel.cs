using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction
{
    [Table("digital_account")]
    public class DigitalAccountTransactionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("value")]
        public decimal Value { get; set; }

        [Column("type")]
        public TransactionTypeEnum Type { get; set; }

        [Column("operation")]
        public TransactionOperationEnum Operation { get; set; }

        [Column("status")]
        public TransactionStatusEnum Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [Column("digital_account_id")]
        public int DigitalAccountId { get; set; }

        [Column("digital_account_sender_id")]
        public int? DigitalAccountSenderId { get; set; }
    }
}
