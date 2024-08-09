using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki.DataAccess.FluentConfig
{
	public class FluentBookConfig : IEntityTypeConfiguration<FluentBook>
	{
		public void Configure(EntityTypeBuilder<FluentBook> builder)
		{
			//TABLE NAME
			builder.ToTable("FluentBooks");

			//PRIMARY KEY
			builder.HasKey(k => k.IdBook);

			//VALIDATIONS
			builder.Property(p => p.ISBN).HasMaxLength(20);
			builder.Property(p => p.ISBN).IsRequired();
			builder.Property(b => b.Price).HasPrecision(10, 5);
			builder.Ignore(p => p.PriceRange);

			//RELATIONS
			builder.HasOne(b => b.FluentPublisher).WithMany(p => p.FluentBookList)
				.HasForeignKey(k => k.PublshiderId);
		}
	}
}
