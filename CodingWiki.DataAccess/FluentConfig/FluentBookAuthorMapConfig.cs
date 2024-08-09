using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki.DataAccess.FluentConfig
{
	public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<FluentBookAuthorMap>
	{
		public void Configure(EntityTypeBuilder<FluentBookAuthorMap> builder)
		{
			//TABLE NAME
			builder.ToTable("FluentBookAuthorMap");

			//COLUMNS PRIMARY KEY
			builder.HasKey(k => new { k.IdBook, k.AuthorId });

			//RELATIONS
			builder.HasOne(b => b.FluentBook).WithMany(b => b.FluentBookAuthorMapList)
				.HasForeignKey(k => k.IdBook);
			builder.HasOne(a => a.FluentAuthor).WithMany(a => a.FluentBookAuthorMapList)
				.HasForeignKey(k => k.AuthorId);
		}
	}
}
