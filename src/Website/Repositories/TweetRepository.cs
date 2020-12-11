using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using Website.Models;
using System.Linq;

namespace Website.Repositories
{
    public class TweetRepository
    {
        private static readonly string EndpointUri = ConfigurationManager.AppSettings["Sentimenteel.Database.Endpoint"];
        private static readonly string PrimaryKey = ConfigurationManager.AppSettings["Sentimenteel.Database.Key"];
        private CosmosClient cosmosClient;
        private Database database;
        private Container container;
        private string databaseId = "TweetDatabase";
        private string containerId = "TweetContainer";

        public TweetRepository()
        {
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
            this.database = cosmosClient.GetDatabase(databaseId);
            this.container = database.GetContainer(containerId);
        }

        public async Task CreateDatabaseAsync()
        {
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Console.WriteLine("Created Database: {0}\n", this.database.Id);
        }

        public async Task CreateContainerAsync()
        {
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/Guid");
            Console.WriteLine("Created Container: {0}\n", this.container.Id);
        }

        public async Task InsertTestTweets()
        {
            foreach (TweetSentimentModel tweet in Constants.MockedOnvzTweetSentiments)
            {
                await this.AddTweetIfNotExists(tweet);
            }
        }

        public async Task AddTweetIfNotExists(TweetSentimentModel tweet)
        {
            try
            {
                // Read the item to see if it exists.  
                ItemResponse<TweetSentimentModel> tweetResponse = await this.container.ReadItemAsync<TweetSentimentModel>(tweet.Id, new PartitionKey(tweet.Guid));
                Console.WriteLine("Item in database with id: {0} already exists\n", tweetResponse.Resource.Id);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Create an item in the container representing tweet1. Note we provide the value of the partition key for this item, which is "abcde123"
                ItemResponse<TweetSentimentModel> tweet1Response = await this.container.CreateItemAsync<TweetSentimentModel>(tweet, new PartitionKey(tweet.Guid));

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
                Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", tweet1Response.Resource.Id, tweet1Response.RequestCharge);
            }
        }

        public async Task ResetSentiment()
        {
            List<TweetSentimentModel> allTweets = await this.RetrieveAllTweets();

            List<TweetSentimentModel> tweetsToUpdate = allTweets
                .Where(t => t.Sentiment != Sentiment.Unknown)
                .Select(t => new TweetSentimentModel
                {
                    Id = t.Id,
                    Guid = t.Guid,
                    Message = t.Message,
                    Sentiment = Sentiment.Unknown,
                    Timestamp = t.Timestamp
                }).ToList();

            foreach (TweetSentimentModel tweet in tweetsToUpdate)
            {
                await this.UpdateTweetAsync(tweet);
            }
        }

        public async Task<List<TweetSentimentModel>> RetrieveAllTweets()
        {
            var sqlQueryText = "SELECT * FROM c";
            Console.WriteLine("Running query: {0}\n", sqlQueryText);
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<TweetSentimentModel> queryResultSetIterator = this.container.GetItemQueryIterator<TweetSentimentModel>(queryDefinition);

            List<TweetSentimentModel> tweets = new List<TweetSentimentModel>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<TweetSentimentModel> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (TweetSentimentModel tweet in currentResultSet)
                {
                    tweets.Add(tweet);
                    Console.WriteLine("\tRead {0}\n", tweet);
                }
            }

            return tweets;
        }

        public async Task UpdateTweetAsync(TweetSentimentModel tweet)
        {
            await this.container.ReplaceItemAsync<TweetSentimentModel>(tweet, tweet.Id, new PartitionKey(tweet.Guid));
        }

        public async Task DeleteTweetAsync(string id, string guid)
        {
            await this.container.DeleteItemAsync<TweetSentimentModel>(id, new PartitionKey(guid));
        }

        public async Task DeleteDatabaseAndCleanupAsync()
        {
            await this.database.DeleteAsync();
            this.cosmosClient.Dispose();
        }
    }
}