using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using OpenQA.Selenium.Appium.iOS;
using System.Runtime.InteropServices;

namespace ios.first
{
	public class BrowserStackNUnitTest
	{
		protected IOSDriver<IOSElement> driver;
		protected string profile;
		protected string device;

		public BrowserStackNUnitTest(string profile, string device)
		{
			this.profile = profile;
			this.device = device;
		}

		[SetUp]
		public void Init()
		{
			NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + profile) as NameValueCollection;
			NameValueCollection devices = ConfigurationManager.GetSection("environments/" + device) as NameValueCollection;

			DesiredCapabilities capability = new DesiredCapabilities();

			foreach (string key in caps.AllKeys)
			{
				capability.SetCapability(key, caps[key]);
			}

			foreach (string key in devices.AllKeys)
			{
				capability.SetCapability(key, devices[key]);
			}

			String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
			if (username == null)
			{
				username = ConfigurationManager.AppSettings.Get("user");
			}

			String accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
			if (accesskey == null)
			{
				accesskey = ConfigurationManager.AppSettings.Get("key");
			}

			capability.SetCapability("browserstack.user", username);
			capability.SetCapability("browserstack.key", accesskey);

			String appId = Environment.GetEnvironmentVariable("BROWSERSTACK_APP_ID");
			if (appId != null)
			{
				capability.SetCapability("app", appId);
			}

			driver = new IOSDriver<IOSElement>(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
		}

		[TearDown]
		public void Cleanup()
		{
			driver.Quit();
		}

	}
}
