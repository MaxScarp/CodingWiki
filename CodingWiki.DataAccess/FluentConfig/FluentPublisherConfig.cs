using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki.DataAccess.FluentConfig
{
	public class FluentPublisherConfig : IEntityTypeConfiguration<FluentPublisher>
	{
		public void Configure(EntityTypeBuilder<FluentPublisher> builder)
		{
			//TABLE NAME
			builder.ToTable("FluentPublishers");

			//COLUMNS NAME
			builder.Property(p => p.PublisherId).HasColumnName("IdPublisher");

			//PRIMARY KEY
			builder.HasKey(k => k.PublisherId);

			//VALIDATIONS
			builder.Property(p => p.Name).IsRequired();
		}
	}
}
