using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Online_Exam.Models
{
    public partial class online_examContext : DbContext
    {
        public online_examContext()
        {
        }

        public online_examContext(DbContextOptions<online_examContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.\\sqlexpress;database=online_exam;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admins");

                entity.HasIndex(e => e.Email, "UQ__admins__A9D1053415610D55")
                    .IsUnique();

                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuesId)
                    .HasName("PK__question__5BF46E9B82F5DA64");

                entity.ToTable("questions");

                entity.Property(e => e.QuesId).HasColumnName("ques_id");

                entity.Property(e => e.Answer).HasColumnName("answer");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Option1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("option1");

                entity.Property(e => e.Option2)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("option2");

                entity.Property(e => e.Option3)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("option3");

                entity.Property(e => e.Option4)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("option4");

                entity.Property(e => e.Ques)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("ques");

                entity.Property(e => e.Topicid).HasColumnName("topicid");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Topicid)
                    .HasConstraintName("FK__questions__topic__534D60F1");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("reports");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .HasColumnName("remarks");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Topicid).HasColumnName("topicid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.Topicid)
                    .HasConstraintName("FK__reports__topicid__571DF1D5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__reports__userid__5629CD9C");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic");

                entity.HasIndex(e => e.TopicId, "UQ__topic__D5DAA3E8C7EF3923")
                    .IsUnique();

                entity.Property(e => e.TopicId)
                    .ValueGeneratedNever()
                    .HasColumnName("topic_id");

                entity.Property(e => e.TopicName)
                    .HasMaxLength(50)
                    .HasColumnName("topic_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Mobile, "UQ__users__6FAE0782752B2B78")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__users__A9D1053457D755A1")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YearOfCompletion).HasColumnName("Year_of_Completion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
