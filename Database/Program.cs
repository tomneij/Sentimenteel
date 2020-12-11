using System;
using System.Threading.Tasks;
using Website.Repositories;

namespace Database
{
    class Program
    {
        private TweetRepository tweetRepository;

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Do you want to (D)elete the database, (R)eset the Sentiment of every tweet or (I)nsert test data:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input, exiting.");
                Console.ReadLine();
                return;
            }

            Program p = new Program();

            switch (input.Substring(0, 1).ToUpper())
            {
                case "D":
                    Console.WriteLine("");
                    await p.SetupDatabaseAndContainer();
                    await p.DeleteDatabase();
                    break;
                case "R":
                    Console.WriteLine("");
                    await p.SetupDatabaseAndContainer();
                    await p.ResetSentiment();
                    break;
                case "I":
                    Console.WriteLine("");
                    await p.SetupDatabaseAndContainer();
                    await p.InsertTestData();
                    break;
                default:
                    Console.WriteLine("Invalid input, exiting.");
                    Console.ReadLine();
                    return;
            }

            Console.WriteLine("End of run, press any key to exit.");
            Console.ReadLine();
        }

        private async Task SetupDatabaseAndContainer()
        {
            this.tweetRepository = new TweetRepository();
            await tweetRepository.CreateDatabaseAsync();
            await tweetRepository.CreateContainerAsync();
        }

        private async Task DeleteDatabase()
        {
            await tweetRepository.DeleteDatabaseAndCleanupAsync();
        }

        private async Task ResetSentiment()
        {
            await tweetRepository.ResetSentiment();
        }

        private async Task InsertTestData()
        {
            await tweetRepository.InsertTestTweets();
        }
    }
}
