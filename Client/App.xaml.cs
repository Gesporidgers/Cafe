﻿namespace Client
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new MainPage());
		}

		//protected override NavigationPage CreateWindow(IActivationState? activationState)
		//{
		//	return new NavigationPage(new MainPage());
		//}
	}
}