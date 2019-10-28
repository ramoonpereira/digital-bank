using DigitalBank.Worker.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Worker.Transaction.Business.Models.DigitalAccountTransaction.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalBank.Worker.Transaction.Business.Models.DigitalAccountTransaction
{
    [Table("digital_account_transactions")]
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

        [Column("release_at")]
        public DateTime ReleaseDate { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [Column("digital_account_id")]
        public int DigitalAccountId { get; set; }

        [Column("digital_account_sender_id")]
        public int? DigitalAccountSenderId { get; set; }

        [ForeignKey("DigitalAccountId")]
        public virtual DigitalAccountModel DigitalAccount { get; set; }

        [ForeignKey("DigitalAccountSenderId")]
        public virtual DigitalAccountModel DigitalAccountSender { get; set; }
    }
}
