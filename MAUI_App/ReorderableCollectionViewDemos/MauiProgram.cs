﻿using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using ReorderableCollectionView.Maui;

namespace ReorderableCollectionViewDemos
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.RegisterReorderableCollectionView()
#if WINDOWS
				.ConfigureImageSources(services =>
				{
					services.Clear();
					services.AddService<IUriImageSource>(svcs => new CustomUriImageSourceService());
				})
#endif
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			return builder.Build();
		}
	}
}