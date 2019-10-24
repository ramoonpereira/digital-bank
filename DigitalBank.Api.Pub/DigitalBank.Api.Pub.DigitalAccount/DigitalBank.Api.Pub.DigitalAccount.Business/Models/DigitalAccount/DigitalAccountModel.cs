﻿
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount
{
    [Table("digital_account")]
    public class DigitalAccountModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("number")]
        public string Number { get; set; }

        [Column("digit")]
        public char Digit { get; set; }

        [Column("balance")]
        public decimal Balance { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("customer_id")]
        public int CustomerId { get; set; }
    }
}
