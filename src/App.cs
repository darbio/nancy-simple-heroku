using System;
using System.Diagnostics;
using Nancy.Hosting.Self;

namespace Nancy.Simple
{
	class App
	{
		const string StagingPort = "8080";

		static readonly string HOST = Environment.GetEnvironmentVariable ("HOST");
		static readonly string PORT = Environment.GetEnvironmentVariable ("PORT");
		static readonly string DYNO = Environment.GetEnvironmentVariable ("DYNO");

		static NancyHost Host;

		enum Env { Staging, Deployment, Heroku }

		static Env CurrentEnv {
			get {
				return HOST == null ? Env.Staging : DYNO == null ? Env.Deployment : Env.Heroku;
			}
		}

		static Uri CurrentAddress {
			get {
				switch (CurrentEnv) {
				case Env.Staging:
					return new Uri ("http://localhost:" + StagingPort);
				case Env.Heroku:
					return new Uri ("http://localhost:" + PORT);
				case Env.Deployment:
					return new Uri ("http://" + HOST + ":" + PORT);
				default:
					throw new Exception ("Unexpected environment");
				}
			}
		}

		static void Main (string[] args)
		{
			Console.WriteLine ("Nancy is starting");

			Host = new NancyHost (CurrentAddress);
			Host.Start ();

			Console.WriteLine ("Nancy is started and listening on {0}...", CurrentAddress);

			while (Console.ReadLine () != "quit");

			Host.Stop ();

			Console.WriteLine ("Nancy is stopped");
		}
	}
}
