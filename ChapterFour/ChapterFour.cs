using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ChapterFour
{
	public class App : Application
	{
		public App()
		{
			Random rnd = new Random();
			//double first, second;
			var options = new List<string> { "Die Today", "Die Tomorrow", "Died Yesterday", "Just Die" };
			var demise = new List<string> { "Are You Sure ?","Worms Might \n Love You" ,"Did SomeOne \n care for you ?", "Mama wont \n like it","Have Some \n Respect","Internet will \n miss your sarcasm","No one \n really cares \n No One","Do it ...\n your helping \n Earth's Demography"};
			Label lbl = new Label
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Text = "Welcome to Xamarin Forms!"
			};

			Label lbl1 = new Label
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Start,

			};
			Label lbl2 = new Label
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Start,

			};
			Label lbl3 = new Label
			{
				VerticalOptions = LayoutOptions.End,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.Center,

			};

			Picker picker = new Picker
			{
				Title = "Destiny",
				HorizontalOptions = LayoutOptions.Start
			};

			DatePicker datePicker = new DatePicker
			{
				Format = "D",
				HorizontalOptions = LayoutOptions.Start
			};

			TimePicker timePicker = new TimePicker
			{
				Format = "T",
				VerticalOptions = LayoutOptions.Start
			};

			Stepper stepper = new Stepper
			{
				Minimum = -5,
				Maximum = 5,
				Increment = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Slider slider = new Slider
			{
				Minimum = 0,
				Maximum = 100,
				Value = lbl1.FontSize,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 300
			};

			timePicker.PropertyChanged += (sender, e) =>
			 {
				 if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
				 {
					lbl1.Text = timePicker.Time.ToString();
				 }
			 };

			datePicker.DateSelected += (object sender, DateChangedEventArgs e) =>
			 {
				 try
				 {
					 lbl2.Text = picker.Items[picker.SelectedIndex] + "\n" + datePicker.Date.ToString();
					 lbl3.Text = demise[rnd.Next(demise.Count)];
				 }
				 catch (System.ArgumentOutOfRangeException) { 
					lbl2.Text =  datePicker.Date.ToString();
					lbl3.Text = demise[rnd.Next(demise.Count)];
				}


			 };
		
			stepper.ValueChanged += (sender, e) =>
			 {
				double x = lbl1.FontSize + e.NewValue;
				lbl1.FontSize = x;
				lbl1.Text = String.Format("Stepper value is {0:F1}", x);
				lbl2.Text = stepper.Value.ToString();


			 };

			slider.ValueChanged += (sender, e) =>
			 {
				
				lbl1.Text = String.Format("Slider value is {0:F1}", e.NewValue);
				lbl1.FontSize = e.NewValue;
				lbl2.Text = slider.Value.ToString();
			 };


			foreach (string optionName in options)
			{
				picker.Items.Add(optionName);
			}

			StackLayout stackOne = new StackLayout
			{
				Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5),
				Spacing=20,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions= LayoutOptions.CenterAndExpand,
				Children = { 
					picker,datePicker
				}

			};	
			StackLayout stackTwo = new StackLayout
			{
				Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5),
				Spacing = 20,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					lbl1,lbl2,lbl3
				}

			};

			Switch switcher = new Switch
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			switcher.Toggled += (sender, e) =>
			 {
				 if (e.Value == true)
				 {
					 timePicker.IsEnabled = true;
					 picker.IsEnabled = true;
					 datePicker.IsEnabled = true;
					 stepper.IsEnabled = true;
					 slider.IsEnabled = true;

				 }
				 else
				 {
					timePicker.IsEnabled = false;
					picker.IsEnabled = false;
					datePicker.IsEnabled = false;
					stepper.IsEnabled = false;
					slider.IsEnabled = false;

				 }

			 };
			timePicker.IsEnabled = false;
			picker.IsEnabled = false;
			datePicker.IsEnabled = false;
			stepper.IsEnabled = false;
			slider.IsEnabled = false;
			// The root page of your application
			var content = new ContentPage
			{
				Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5),
				Title = "ChapterFour",
				Content = new StackLayout
				{
					Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5),
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.Start,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Children = {
						lbl,switcher,stackOne,stackTwo,timePicker,stepper,slider
					}
				}
			};

			MainPage = new NavigationPage(content);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

