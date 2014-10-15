using System;
using System.Threading.Tasks;
using PowerArgs;
using Octokit;

namespace pullrequest_commenter_cli
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var parsedArgs = Args.Parse<ProgramArguments>(args);
				SubmitCommentsAsync(parsedArgs).Wait();
				Environment.Exit(0);
			}
			catch (ArgException ex)
			{
				Console.WriteLine(ex.Message);
				ArgUsage.GetStyledUsage<ProgramArguments>().Write();
				Environment.Exit(-2);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Environment.Exit(-1);
			}
		}

		private static async Task SubmitCommentsAsync(ProgramArguments args)
		{
			var github = new GitHubClient(new ProductHeaderValue("Q42.PullRequestCommenter"))
			{
				Credentials = new Credentials(args.PersonalGithubAccessToken)
			};

			await github.Issue.Comment.Create(args.Owner, args.Repository, args.PullRequestId, args.Message);
		}
	}

	public sealed class ProgramArguments
	{
		[ArgRequired]
		[ArgPosition(0)]
		[ArgDescription("Owner of repository to which we are going to send the message")]
		[ArgExample("Crunchie84", "o")]
		[ArgShortcut("o")]
		public string Owner { get; set; }

		/// <summary>
		/// :owner/:repo thus Crunchie84/PullRequestCommenter
		/// </summary>
		[ArgRequired]
		[ArgPosition(1)]
		[ArgDescription("Repository to which we are going to send the message")]
		[ArgExample("PullRequestCommenter", "r")]
		[ArgShortcut("r")]
		public string Repository { get; set; }

		[ArgRequired]
		[ArgPosition(2)]
		[ArgDescription("The pull request / issue to which we are going to add this comment")]
		[ArgExample("123", "i")]
		[ArgShortcut("i")]
		public int PullRequestId { get; set; }

		[ArgRequired]
		[ArgPosition(3)]
		[ArgDescription("The github personal access token, retrieved @https://help.github.com/articles/creating-an-access-token-for-command-line-use")]
		[ArgExample("34asdf4a5sdf34a5sdf6asdf45asdf5asdfsafd", "t")]
		[ArgShortcut("t")]
		public string PersonalGithubAccessToken { get;set; }

		[ArgRequired]
		[ArgPosition(4)]
		[ArgDescription("The commit message to append")]
		[ArgExample("foo bar baz", "m")]
		[ArgShortcut("m")]
		public string Message { get; set; }

	}
}
