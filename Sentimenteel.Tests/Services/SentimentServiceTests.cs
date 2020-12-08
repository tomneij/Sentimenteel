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
            string text = "ONVZ is echt fijn!";
            Sentiment result = _service.Analyze(text);
            result.Should().Be(Sentiment.Positive);
        }
    }
}
