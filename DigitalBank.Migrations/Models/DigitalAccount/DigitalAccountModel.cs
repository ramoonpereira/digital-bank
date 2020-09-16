using DigitalBank.Migrations.Models.Customer;
using DigitalBank.Migrations.Models.DigitalAccountTransaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.Models.DigitalAccount
{
    [Table("digital_account")]
    public class DigitalAccountModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("number")]
        public int Number { get; set; }

        [Column("digit")]
        public char Digit { get; set; }

        [Column("balance")]
        public decimal Balance { get; set; }

        [Column("transfer_limit_transaction")]
        public decimal TransferLimitTransaction { get; set; }

        [Column("transfer_limit_transaction_day")]
        public decimal TransferLimitTransactionDay { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [Column("customer_id")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual CustomerModel Customer { get; set; }

        [NotMapped]
        public virtual ICollection<DigitalAccountTransactionModel> DigitalAccountTransactions { get; set; }
    }
}
