using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class BasketballGameDBContext : DbContext
    {
        public BasketballGameDBContext()
        {
        }

        public BasketballGameDBContext(DbContextOptions<BasketballGameDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameStat> GameStats { get; set; }
        public virtual DbSet<GameStatus> GameStatuses { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<RequestGame> RequestGames { get; set; }
        public virtual DbSet<RequestGameStatus> RequestGameStatuses { get; set; }
        public virtual DbSet<RequestToJoinTeam> RequestToJoinTeams { get; set; }
        public virtual DbSet<RequestToJoinTeamStatus> RequestToJoinTeamStatuses { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=BasketballGameDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.ToTable("Coach");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TeamId).HasColumnName("teamId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Coaches)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("coach_teamid_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Coaches)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coach_userid_foreign");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AwayTeamId).HasColumnName("awayTeamId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.GameStatusId).HasColumnName("gameStatusId");

                entity.Property(e => e.HomeTeamId).HasColumnName("homeTeamId");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("position");

                entity.Property(e => e.ScoreAwayTeam).HasColumnName("scoreAwayTeam");

                entity.Property(e => e.ScoreHomeTeam).HasColumnName("scoreHomeTeam");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.GameAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_awayteamid_foreign");

                entity.HasOne(d => d.GameStatus)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.GameStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_gamestatusid_foreign");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.GameHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_hometeamid_foreign");
            });

            modelBuilder.Entity<GameStat>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.PlayerShots).HasColumnName("playerShots");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameStats)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gamestats_gameid_foreign");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.GameStats)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gamestats_playerid_foreign");
            });

            modelBuilder.Entity<GameStatus>(entity =>
            {
                entity.ToTable("GameStatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.TeamId).HasColumnName("teamId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("player_teamid_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("player_userid_foreign");
            });

            modelBuilder.Entity<RequestGame>(entity =>
            {
                entity.ToTable("RequestGame");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AwayTeamId).HasColumnName("awayTeamId");

                entity.Property(e => e.CoachHomeTeamId).HasColumnName("coachHomeTeamId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("position");

                entity.Property(e => e.RequestGameStatusId).HasColumnName("requestGameStatusId");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.RequestGames)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("requestgame_awayteamid_foreign");

                entity.HasOne(d => d.CoachHomeTeam)
                    .WithMany(p => p.RequestGames)
                    .HasForeignKey(d => d.CoachHomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("requestgame_coachhometeamid_foreign");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.RequestGames)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("requestgame_gameid_foreign");

                entity.HasOne(d => d.RequestGameStatus)
                    .WithMany(p => p.RequestGames)
                    .HasForeignKey(d => d.RequestGameStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("requestgame_requestgamestatusid_foreign");
            });

            modelBuilder.Entity<RequestGameStatus>(entity =>
            {
                entity.ToTable("RequestGameStatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RequestToJoinTeam>(entity =>
            {
                entity.ToTable("RequestToJoinTeam");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.RequestToJoinTeamStatusId).HasColumnName("requestToJoinTeamStatusId");

                entity.Property(e => e.TeamId).HasColumnName("teamId");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.RequestToJoinTeams)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("requesttojointeam_playerid_foreign");

                entity.HasOne(d => d.RequestToJoinTeamStatus)
                    .WithMany(p => p.RequestToJoinTeams)
                    .HasForeignKey(d => d.RequestToJoinTeamStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("requesttojointeam_requesttojointeamstatusid_foreign");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.RequestToJoinTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("requesttojointeam_teamid_foreign");
            });

            modelBuilder.Entity<RequestToJoinTeamStatus>(entity =>
            {
                entity.ToTable("RequestToJoinTeamStatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CoachId).HasColumnName("coachId");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("team_coachid_foreign");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "user_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("birthDate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("gender");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pass");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
