using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesApp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Column("First Name")]
        public string First_name { get; set; }

        [Column("Last Name")]
        public string Last_name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Column("Selected Service")]
        public string Select_service { get; set; }

        [Column("Selected Price")]
        public string Select_price { get; set; }

        public string Comments { get; set; }
    }
}
