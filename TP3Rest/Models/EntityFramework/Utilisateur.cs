using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TP3Rest.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    [Index(nameof(Mail), IsUnique = true)]
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom", TypeName = "varchar(50)")]
        public string? Nom { get; set; }

        [Column("utl_prenom", TypeName = "varchar(50)")]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Le numéro de téléphone n'est pas valide")]
        public string? Mobile { get; set; }

        [Column("utl_mail", TypeName = "varchar(100)")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d'un email doit etre comprise entre 6 et 100 caractères.")]
        [NotNull]
        public string? Mail { get; set; }

        [Column("utl_pwd", TypeName = "varchar(64)")]
        [NotNull]
        public string? Pwd { get; set; }

        [Column("utl_rue", TypeName = "varchar(200)")]
        [StringLength(200, ErrorMessage = "La longueur de la rue ne doit pas dépassé 200 caractères.")]
        public string? Rue { get; set; }

        [Column("utl_cp", TypeName = "char(5)")]
        [StringLength(5, ErrorMessage = "Le code postal doit contenir 5 chiffres.")]
        public string? CodePostal { get; set; }

        [Column("utl_ville", TypeName = "varchar(50)")]
        public string? Ville { get; set; }

        [Column("utl_pays", TypeName = "varchar(50)")]
        [DefaultValue("France")]
        public string? Pays { get; set; }

        [Column("utl_latitude", TypeName = "real")]
        public float? Latitude { get; set; }

        [Column("utl_longitude", TypeName = "real")]
        public float? Longitude { get; set; }

        [Column("utl_datecreation")]
        [NotNull]
        public DateTime DateCreation { get; set; }

        [InverseProperty("UtilisateurNotant")]
        public virtual ICollection<Notation> NotesUtilisateur { get; set; }
    }
}
