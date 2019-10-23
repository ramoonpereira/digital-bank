using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank.Api.Pub.Authenticate.Business.Models.Permission
{
    [Table("customer_permissions")]
    public class Permission
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("permissions")]
        public string Permissions { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }


        [Column("customer_id")]
        public virtual Customer.Customer Customer { get; set; }
    }
}
