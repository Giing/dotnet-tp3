﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TP2Console.Models.EntityFramework;

#nullable disable

namespace TP3Rest.Migrations
{
    [DbContext(typeof(SeriesDBContext))]
    [Migration("20221003093355_CreationBDSeries_update_foreign_keys")]
    partial class CreationBDSeries_update_foreign_keys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TP3Rest.Models.EntityFramework.Notation", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UtilisateurId"));

                    b.Property<int>("Note")
                        .HasColumnType("integer")
                        .HasColumnName("not_note");

                    b.Property<int?>("Serie")
                        .HasColumnType("integer");

                    b.Property<int>("SerieId")
                        .HasColumnType("integer")
                        .HasColumnName("ser_id");

                    b.Property<int?>("Utilisateur")
                        .HasColumnType("integer");

                    b.HasKey("UtilisateurId");

                    b.HasIndex("Serie");

                    b.HasIndex("Utilisateur");

                    b.ToTable("t_j_notation_not", "public");

                    b.HasCheckConstraint("CK_not_note", "0 <= not_note AND not_note <= 5");
                });

            modelBuilder.Entity("TP3Rest.Models.EntityFramework.Serie", b =>
                {
                    b.Property<int>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ser_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SerieId"));

                    b.Property<int?>("AnneeCreation")
                        .HasColumnType("integer")
                        .HasColumnName("ser_anneecreation");

                    b.Property<int?>("NbEpisodes")
                        .HasColumnType("integer")
                        .HasColumnName("ser_nbepisodes");

                    b.Property<int?>("NbSaisons")
                        .HasColumnType("integer")
                        .HasColumnName("ser_nbsaisons");

                    b.Property<string>("Network")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ser_network");

                    b.Property<string>("Resume")
                        .HasColumnType("text")
                        .HasColumnName("ser_resume");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ser_titre");

                    b.HasKey("SerieId");

                    b.ToTable("t_e_serie_ser", "public");
                });

            modelBuilder.Entity("TP3Rest.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UtilisateurId"));

                    b.Property<string>("CodePostal")
                        .HasColumnType("char(5)")
                        .HasColumnName("utl_cp");

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("utl_datecreation")
                        .HasDefaultValueSql("current_date");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_latitude");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_longitude");

                    b.Property<string>("Mail")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("utl_mail");

                    b.Property<string>("Mobile")
                        .HasColumnType("char(10)")
                        .HasColumnName("utl_mobile");

                    b.Property<string>("Nom")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("utl_nom");

                    b.Property<string>("Pays")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("utl_pays");

                    b.Property<string>("Prenom")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("utl_prenom");

                    b.Property<string>("Pwd")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("utl_pwd");

                    b.Property<string>("Rue")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("utl_rue");

                    b.Property<string>("Ville")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("utl_ville");

                    b.HasKey("UtilisateurId");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.ToTable("t_e_utilisateur_utl", "public");
                });

            modelBuilder.Entity("TP3Rest.Models.EntityFramework.Notation", b =>
                {
                    b.HasOne("TP3Rest.Models.EntityFramework.Serie", "SerieNotee")
                        .WithMany("NotesSerie")
                        .HasForeignKey("Serie")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_note_ser");

                    b.HasOne("TP3Rest.Models.EntityFramework.Utilisateur", "UtilisateurNotant")
                        .WithMany("NotesUtilisateur")
                        .HasForeignKey("Utilisateur")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_note_utl");

                    b.Navigation("SerieNotee");

                    b.Navigation("UtilisateurNotant");
                });

            modelBuilder.Entity("TP3Rest.Models.EntityFramework.Serie", b =>
                {
                    b.Navigation("NotesSerie");
                });

            modelBuilder.Entity("TP3Rest.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Navigation("NotesUtilisateur");
                });
#pragma warning restore 612, 618
        }
    }
}