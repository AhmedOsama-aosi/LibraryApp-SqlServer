using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Model;

public partial class DbtContext : DbContext
{
    public DbtContext()
    {
    }

    public DbtContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<_0bok> _0boks { get; set; }

    public virtual DbSet<_0cat> _0cats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
         //=> optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=db;Trusted_Connection=True;Encrypt=False;");
        // => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\\Users\\A.osama\\Desktop\\copy data\\db.mdf;", options => options.EnableRetryOnFailure());
        => optionsBuilder.UseSqlServer($"Data Source=.\\SQLEXPRESS; AttachDbFileName={Environment.CurrentDirectory}\\database\\dbt.mdf;Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.RowId).HasName("U_ROW");

            entity.ToTable("book");

            entity.HasIndex(e => e.Bookid, "bookid_index");

            entity.Property(e => e.RowId).HasColumnName("rowId");
            entity.Property(e => e.Aya).HasColumnName("aya");
            entity.Property(e => e.B1).HasColumnName("b1");
            entity.Property(e => e.Bhno).HasColumnName("bhno");
            entity.Property(e => e.Bookid).HasColumnName("bookid");
            entity.Property(e => e.Hno).HasColumnName("hno");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nass).HasColumnName("nass");
            entity.Property(e => e.Page).HasColumnName("page");
            entity.Property(e => e.Part).HasColumnName("part");
            entity.Property(e => e.Ppage1).HasColumnName("ppage1");
            entity.Property(e => e.Ppart1).HasColumnName("ppart1");
            entity.Property(e => e.Seal).HasColumnName("seal");
            entity.Property(e => e.Sora).HasColumnName("sora");

            entity.HasOne(d => d.BookNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Bookid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_book_0bok");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.RowId).HasName("PK__title__4B58DB80CE756ABE");

            entity.ToTable("title");

            entity.HasIndex(e => e.Bookid, "bookid_index");

            entity.Property(e => e.RowId).HasColumnName("rowId");
            entity.Property(e => e.Bookid).HasColumnName("bookid");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lvl).HasColumnName("lvl");
            entity.Property(e => e.Sub).HasColumnName("sub");
            entity.Property(e => e.Tit).HasColumnName("tit");

            entity.HasOne(d => d.Book).WithMany(p => p.Titles)
                .HasForeignKey(d => d.Bookid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_title_0bok");
        });

        modelBuilder.Entity<_0bok>(entity =>
        {
            entity.HasKey(e => e.Bkid);

            entity.ToTable("0bok");

            entity.Property(e => e.Bkid)
                .ValueGeneratedNever()
                .HasColumnName("bkid");
            entity.Property(e => e.Auth).HasColumnName("auth");
            entity.Property(e => e.Authno).HasColumnName("authno");
            entity.Property(e => e.BLnk).HasColumnName("bLnk");
            entity.Property(e => e.BVer).HasColumnName("bVer");
            entity.Property(e => e.Betaka).HasColumnName("betaka");
            entity.Property(e => e.Bk)
                .HasMaxLength(255)
                .HasColumnName("bk");
            entity.Property(e => e.Bkord).HasColumnName("bkord");
            entity.Property(e => e.Cat).HasColumnName("cat");
            entity.Property(e => e.Inf).HasColumnName("inf");
            entity.Property(e => e.NData)
                .HasMaxLength(24)
                .HasColumnName("nData");
            entity.Property(e => e.OAuth).HasColumnName("oAuth");
            entity.Property(e => e.ONum).HasColumnName("oNum");
            entity.Property(e => e.OVer).HasColumnName("oVer");
            entity.Property(e => e.Seal).HasColumnName("seal");
            entity.Property(e => e.VerName).HasColumnName("verName");

            entity.HasOne(d => d.CatNavigation).WithMany(p => p._0boks)
                .HasForeignKey(d => d.Cat)
                .HasConstraintName("FK_0bok_0cat");
        });

        modelBuilder.Entity<_0cat>(entity =>
        {
            entity.ToTable("0cat");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Catord).HasColumnName("catord");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
