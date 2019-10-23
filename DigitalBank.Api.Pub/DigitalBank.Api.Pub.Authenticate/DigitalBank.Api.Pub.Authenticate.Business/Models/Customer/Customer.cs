using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank.Api.Pub.Authenticate.Business.Models.Customer
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("phone")]
        public int Phone { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("document")]
        public int Document { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        public virtual List<Permission.Permission> Permissions { get; set; }
    }
}
