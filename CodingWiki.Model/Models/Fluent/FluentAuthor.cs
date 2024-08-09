namespace CodingWiki.Model.Models
{
	public class FluentAuthor
	{
		public int AuthorId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string Location { get; set; }

		public string FullName
		{
			get => $"{FirstName} {LastName}";
		}

		public List<FluentBookAuthorMap> FluentBookAuthorMapList { get; set; }
	}
}
