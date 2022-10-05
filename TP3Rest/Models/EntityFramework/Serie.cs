﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TP3Rest.Models.EntityFramework
{
    [Table("t_e_serie_ser")]
    public class Serie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ser_id")]
        public int SerieId { get; set; }

        [Required]
        [Column("ser_titre", TypeName = "varchar(100)")]
        [NotNull]
        public string Titre { get; set; }

        [Column("ser_resume", TypeName = "text")]
        public string? Resume { get; set; }

        [Column("ser_nbsaisons")]
        public int? NbSaisons { get; set;}

        [Column("ser_nbepisodes")]
        public int? NbEpisodes { get; set; }

        [Column("ser_anneecreation")]
        public int? AnneeCreation { get; set; }

        [Column("ser_network", TypeName = "varchar(50)")]
        public string? Network { get; set; }

        [InverseProperty("SerieNotee")]
        public virtual ICollection<Notation> NotesSerie { get; set; }
    }
}
