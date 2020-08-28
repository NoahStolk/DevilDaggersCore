﻿using DevilDaggersCore.Wpf.Models;
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
				SolidColorBrush color = new SolidColorBrush(isLocalCurrentVersion ? Color.FromRgb(207, 239, 207) : i++ % 2 == 0 ? Color.FromRgb(207, 207, 207) : Color.FromRgb(223, 223, 223));
				Border border = new Border { Padding = new Thickness(8, 16, 8, 16), Background = color };
				StackPanel entryStackPanel = new StackPanel { Background = color };
				if (isLocalCurrentVersion)
					entryStackPanel.Children.Add(new TextBlock { Text = "Currently running", FontSize = 12, FontWeight = FontWeights.Bold, Padding = new Thickness(6, 0, 0, 6), Foreground = new SolidColorBrush(Color.FromRgb(0, 127, 0)) });
				entryStackPanel.Children.Add(new TextBlock { Text = $"{entry.VersionNumber} - {entry.Date:MMMM dd, yyyy}", FontSize = 16, FontWeight = FontWeights.Bold, Padding = new Thickness(6, 0, 0, 6) });
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
			Grid changeGrid = new Grid();
			changeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(level++ * 32) });
			changeGrid.ColumnDefinitions.Add(new ColumnDefinition());

			changeGrid.Children.Add(new TextBlock { Text = "• ", TextAlignment = TextAlignment.Right });

			TextBlock descriptionTextBlock = new TextBlock { Text = change.Description, TextWrapping = TextWrapping.WrapWithOverflow };
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