﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using FSISSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace FSISSystem.DAL;

public partial class FSIS_2018Context : DbContext
{
    public FSIS_2018Context(DbContextOptions<FSIS_2018Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Guardian> Guardians { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerStat> PlayerStats { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameID).HasName("PK_Games_GameID");

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.GameHomeTeams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GamesTeams_HomeTeamID");

            entity.HasOne(d => d.VisitingTeam).WithMany(p => p.GameVisitingTeams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GamesTeams_VisitingTeamID");
        });

        modelBuilder.Entity<Guardian>(entity =>
        {
            entity.HasKey(e => e.GuardianID).HasName("PK_Guardian");

            entity.Property(e => e.EmergencyPhoneNumber).IsFixedLength();
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerID).HasName("PK_Players_PlayerID");

            entity.Property(e => e.Gender).IsFixedLength();

            entity.HasOne(d => d.Guardian).WithMany(p => p.Players)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayersGuardians_GuardianID");

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayersTeams_TeamID");
        });

        modelBuilder.Entity<PlayerStat>(entity =>
        {
            entity.HasKey(e => e.PlayerStatsID).HasName("PK_PlayerStats_PlayerStatsID");

            entity.HasOne(d => d.Game).WithMany(p => p.PlayerStats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerStatsGames_GameID");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerStats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerStatusPlayers_PlayerID");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamID).HasName("PK_Teams_TeamID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}