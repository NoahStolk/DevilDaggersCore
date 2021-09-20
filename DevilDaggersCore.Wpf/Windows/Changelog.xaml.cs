using DevilDaggersCore.Wpf.Models;
using DevilDaggersCore.Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DevilDaggersCore.Wpf.Windows
{
	public partial class ChangelogWindow : Window
	{
		public ChangelogWindow(List<ChangelogEntry> changes, Version localVersion)
		{
			InitializeComponent();

			int i = 0;
			foreach (ChangelogEntry entry in changes)
			{
				bool isLocalCurrentVersion = entry.VersionNumber == localVersion;
				SolidColorBrush color = isLocalCurrentVersion ? new(Color.FromRgb(63, 95, 63)) : i++ % 2 == 0 ? ColorUtils.ThemeColors["Gray2"] : ColorUtils.ThemeColors["Gray4"];
				Border border = new() { Padding = new(8, 16, 8, 16), Background = color };
				StackPanel entryStackPanel = new() { Background = color };
				if (isLocalCurrentVersion)
					entryStackPanel.Children.Add(new TextBlock { Text = "Currently running", FontSize = 12, FontWeight = FontWeights.Bold, Padding = new(6, 0, 0, 6), Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 127)) });
				entryStackPanel.Children.Add(new TextBlock { Text = $"{entry.VersionNumber} - {entry.Date:MMMM dd, yyyy}", FontSize = 16, FontWeight = FontWeights.Bold, Padding = new(6, 0, 0, 6) });
				foreach (Change change in entry.Changes)
				{
					foreach (Grid stackPanel in GetGrids(change, 1))
						entryStackPanel.Children.Add(stackPanel);
				}

				border.Child = entryStackPanel;
				Main.Children.Add(border);
			}
		}

		private IEnumerable<Grid> GetGrids(Change change, int level)
		{
			Grid changeGrid = new();
			changeGrid.ColumnDefinitions.Add(new() { Width = new(level++ * 32) });
			changeGrid.ColumnDefinitions.Add(new());

			changeGrid.Children.Add(new TextBlock { Text = "• ", TextAlignment = TextAlignment.Right });

			TextBlock descriptionTextBlock = new() { Text = change.Description, TextWrapping = TextWrapping.WrapWithOverflow };
			Grid.SetColumn(descriptionTextBlock, 1);
			changeGrid.Children.Add(descriptionTextBlock);

			yield return changeGrid;

			if (change.SubChanges != null)
			{
				foreach (Change subChange in change.SubChanges)
				{
					foreach (Grid stackPanel in GetGrids(subChange, level))
						yield return stackPanel;
				}
			}
		}
	}
}
