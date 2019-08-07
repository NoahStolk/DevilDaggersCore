namespace DevilDaggersCore.CustomLeaderboards
{
	public class CustomLeaderboardCategoryBase
	{
		public string Name { get; set; }
		public string SortingPropertyName { get; set; }
		public bool Ascending { get; set; }
		public string LayoutPartialName { get; set; }
		
		public CustomLeaderboardCategoryBase(string name, string sortingPropertyName, bool ascending, string layoutPartialName)
		{
			Name = name;
			SortingPropertyName = sortingPropertyName;
			Ascending = ascending;
			LayoutPartialName = layoutPartialName;
		}
	}
}