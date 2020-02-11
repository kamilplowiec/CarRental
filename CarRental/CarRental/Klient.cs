namespace CarRental
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klient")]
    public partial class Klient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nazwa { get; set; }

        [Required]
        [StringLength(200)]
        public string Adres { get; set; }

        [Required]
        [StringLength(20)]
        public string NrTel { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
