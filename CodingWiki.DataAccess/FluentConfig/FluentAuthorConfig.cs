using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki.DataAccess.FluentConfig
{
	public class FluentAuthorConfig : IEntityTypeConfiguration<FluentAuthor>
	{
		public void Configure(EntityTypeBuilder<FluentAuthor> builder)
		{
			//TABLE NAME
			builder.ToTable("FluentAuthors");

			//COLUMNS NAME
			builder.Property(p => p.AuthorId).HasColumnName("IdAuthor");

			//PRIMARY KEY
			builder.HasKey(k => k.AuthorId);

			//VALIDATIONS
			builder.Property(p => p.FirstName).HasMaxLength(50);
			builder.Property(p => p.FirstName).IsRequired();
			builder.Property(p => p.LastName).IsRequired();
			builder.Ignore(p => p.FullName);
		}
	}
}
