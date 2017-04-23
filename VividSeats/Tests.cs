using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Net.Configuration;

namespace VividSeats
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void AppLaunches()
		{
			app.Repl();
		}

		[Test]
		public void BrowseAndCheckoutTest()
		{
			app.Tap(x => x.Class("android.widget.ImageButton").Index(0));
			app.Screenshot("Let's start by Tapping on the 'Hamburger' Button ");
			app.Tap("Browse");
			app.Screenshot("We Tapped the 'Browse' Button");

			app.Tap("item_name");
			app.Screenshot("Next we Tapped on the first result");
			app.Tap("item_ticket_line1");
			app.Screenshot("Then we Tapped on the 'Ticket'");

			app.Tap("ticket_details_checkout_button");
			app.Screenshot("We Tapped on the 'Checkout' Button");
			app.Tap("2");
			app.Screenshot("Next we Tapped on '2 Tickets'");
			app.Tap("ticket_details_checkout_button");
			app.Screenshot("Then we Tapped on the 'Checkout' Button again");
		}
	}
}