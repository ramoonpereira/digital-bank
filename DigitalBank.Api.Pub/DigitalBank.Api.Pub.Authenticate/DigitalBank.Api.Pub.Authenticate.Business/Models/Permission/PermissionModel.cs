using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank.Api.Pub.Authenticate.Business.Models.Permission
{
    [Table("customer_permissions")]
    public class PermissionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("permissions")]
        public string Permissions { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [Column("customer_id")]
        public int CustomerId{ get; set; }
    }
}
