namespace CarRental
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wypozyczenie")]
    public partial class Wypozyczenie
    {
        public int Id { get; set; }

        public int KlientId { get; set; }

        public int PojazdId { get; set; }

        public DateTime DataOd { get; set; }

        public DateTime? DataDo { get; set; }

        public bool Zwrot { get; set; }

        public int WypozyczajacyPracownikId { get; set; }

        [Required]
        public string Komentarz { get; set; }
    }
}
