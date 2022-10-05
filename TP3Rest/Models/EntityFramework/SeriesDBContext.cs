﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using TP3Rest.Models.EntityFramework;

namespace TP2Console.Models.EntityFramework
{
    public partial class SeriesDBContext : DbContext
    {
        public SeriesDBContext()
        {
        }

        public SeriesDBContext(DbContextOptions<SeriesDBContext> options)
            : base(options)
        {
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>builder.AddConsole());

        public virtual DbSet<Notation> Notations { get; set; } = null!;
        public virtual DbSet<Serie> Series { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
*//*                optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                    .EnableSensitiveDataLogging()
                    .UseNpgsql("Server=localhost;port=5432;Database=SeriesDB; uid=postgres; password=root;");*//*
                // optionsBuilder.UseLazyLoadingProxies();
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public")
                .Entity<Utilisateur>()
                .Property(u => u.DateCreation)
                .HasDefaultValueSql("current_date");

            modelBuilder.Entity<Notation>(e =>
                e.HasCheckConstraint("CK_not_note", "0 <= not_note AND not_note <= 5"));

            modelBuilder.Entity<Notation>().HasKey(p => new { p.SerieId, p.UtilisateurId });

            modelBuilder.Entity<Notation>()
                .HasOne(n => n.UtilisateurNotant)
                .WithMany(p => p.NotesUtilisateur)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_note_utl");

            modelBuilder.Entity<Notation>()
                .HasOne(n => n.SerieNotee)
                .WithMany(p => p.NotesSerie)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_note_ser");
            /*modelBuilder.Entity<Avi>(entity =>
            {
                entity.HasKey(e => new { e.Film, e.Utilisateur })
                    .HasName("pk_avis");

                entity.HasOne(d => d.FilmNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Film)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_film");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Utilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_utilisateur");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasOne(d => d.CategorieNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.Categorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_categorie");
            });

            OnModelCreatingPartial(modelBuilder);*/
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
