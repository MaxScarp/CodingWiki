using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CodingWiki.DataAccess.FluentConfig
{
	public class FluentBookDetailConfig : IEntityTypeConfiguration<FluentBookDetail>
	{
		public void Configure(EntityTypeBuilder<FluentBookDetail> builder)
		{
			//TABLE NAME
			builder.ToTable("FluentBookDetailes");

			//COLUMNS NAME
			builder.Property(p => p.BookDetailId).HasColumnName("IdBookDetail");
			builder.Property(p => p.NumberOfChapters).HasColumnName("ChapterAmount");


			//PRIMARY KEY
			builder.HasKey(k => k.BookDetailId);

			//RELATIONS
			builder.HasOne(d => d.FluentBook).WithOne(b => b.BookDetail)
				.HasForeignKey<FluentBookDetail>(k => k.IdBook);
		}
	}
}
