
using DigitalBank.Migration.Models.CustomerPermission;
using DigitalBank.Migration.Models.DigitalAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank.Migration.Models.Customer
{
    [Table("customers")]
    public class CustomerModel
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
        public long Phone { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("document")]
        public long Document { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public virtual ICollection<CustomerPermissionModel>CustomerPermissions { get; set; }

        [NotMapped]
        public virtual ICollection<DigitalAccountModel> DigitalAccounts { get; set; }
    }
}
