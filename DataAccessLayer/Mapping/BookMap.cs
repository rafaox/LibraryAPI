using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryApi.DataAccessLayer.Models;

namespace LibraryApi.DataAccessLayer.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book).ToLower());
            builder.HasKey(b => b.Id).HasName("Id");

            builder.Property(b => b.Id).ValueGeneratedOnAdd().HasColumnName("Id").HasColumnType("BIGINT");
            builder.Property(b => b.Title).HasColumnName("Title").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(b => b.Summary).HasColumnName("Summary").HasColumnType("VARCHAR(2000)").IsRequired();
            builder.Property(b => b.Author).HasColumnName("Author").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(b => b.Isbn).HasColumnName("Isbn").HasColumnType("VARCHAR(13)").IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnName("CreatedAt").HasColumnType("DATETIME").IsRequired();
        }
    }
}