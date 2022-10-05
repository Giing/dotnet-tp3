using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3Rest.Models.EntityFramework
{
    [Table("t_j_notation_not")]
    public class Notation
    {
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("ser_id")]
        public int SerieId { get; set; }

        [Column("not_note")]
        public int Note { get; set; }

        [ForeignKey(nameof(Serie))]
        [InverseProperty("NotesSerie")]
        public virtual Serie? SerieNotee { get; set; }

        [ForeignKey(nameof(Utilisateur))]
        [InverseProperty("NotesUtilisateur")]
        public virtual Utilisateur? UtilisateurNotant { get; set; }

    }
}
