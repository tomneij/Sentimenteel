using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Website;
using Website.Services;

namespace Sentimenteel.Tests.Services
{
    [TestClass]
    public class SentimentServiceTests
    {
        private SentimentService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new SentimentService();
        }

        [TestMethod]
        public void Analyze_PositiveText_SentimentPositive()
        {
            //string text = "ONVZ is echt goed!";
            string text = "ONVZ is very good!";

            Sentiment result = _service.Analyze(text, "en", "us");
            result.Should().Be(Sentiment.Positive);
        }

        [TestMethod]
        public void Analyze_NegativeText_SentimentNegative()
        {
            //string text = "ONVZ is echt slecht!";
            string text = "ONVZ is very bad!";

            Sentiment result = _service.Analyze(text, "en", "us");
            result.Should().Be(Sentiment.Negative);
        }

        [TestMethod]
        public void Analyze_NeutralText_SentimentNeutral()
        {
            //string text = "ONVZ is echt gewoon!";
            string text = "ONVZ is very average!";

            Sentiment result = _service.Analyze(text, "en", "us");
            result.Should().Be(Sentiment.Neutral);
        }
    }
}
