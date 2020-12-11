using System;
using System.Collections.Generic;
using Website.Models;

namespace Website
{
    public static class Constants
    {
        public static List<LabelModel> Labels = new List<LabelModel>
            {
                new LabelModel
                {
                    Name = "ONVZ",
                    Keyword = "@Onvz",
                    Icon = "/content/icons/onvz.png"
                },
                new LabelModel
                {
                    Name = "Ohra",
                    Keyword = "@Ohra",
                    Icon = "/content/icons/Ohra.png"
                },
                new LabelModel
                {
                    Name = "CZ",
                    Keyword = "@CZ",
                    Icon = "/content/icons/CZ.png"
                },
                new LabelModel
                {
                    Name = "VGZ",
                    Keyword = "@VGZ",
                    Icon = "/content/icons/VGZ.png"
                },
                new LabelModel
                {
                    Name = "ZilverenKruis",
                    Keyword = "@ZilverenKruis",
                    Icon = "/content/icons/ZilverenKruis.png"
                }
            };

        public static List<TweetModel> MockedOnvzTweets = new List<TweetModel>
            {
                new TweetModel
                {
                    Id = "1",
                    Timestamp = DateTime.Now.AddDays(-10),
                    Message = "Nieuwe polis #onvz binnen. Krijgen iets minder vergoed en gaan €1.97 minder betalen p.m volgens de aangeboden polis. Nu gaan wij onze polis beetje veranderen en gaan in totaal €2,39 meer betalen p.m . Dat val te overzienKnipogend gezichtHand met 'oké'-gebaar Al jaren zeer te breiden over @onvz"
                },
                new TweetModel
                {
                    Id = "2",
                    Timestamp = DateTime.Now.AddDays(-10),
                    Message = "Dank jullie wel @onvz voor de snelle reactie en heb alles kunnen regelen wat er geregeld moest worden."
                },
                new TweetModel
                {
                    Id ="3",
                    Timestamp = DateTime.Now.AddDays(-10),
                    Message = "@onvz Jullie website is al vanaf donderdag uit de lucht????"
                },
                new TweetModel
                {
                    Id = "4",
                    Timestamp = DateTime.Now.AddDays(-9),
                    Message = "@onvz beste, ik wil een vergelijking maken tussen de superfit aanvullende verzekering en de topfit verzekering. Kunt u mij lagen weten hoe ik dat zo overzichtelijk mogelijk kan doen."
                },
                new TweetModel
                {
                    Id = "5",
                    Timestamp = DateTime.Now.AddDays(-8),
                    Message = "@onvz Vandaag geven we jullie een #warmedouchenamensdeergotherapeuten. Dank dat jullie het kostprijsonderzoek serieus nemen en laten zien dat jullie de waarde van #ergotherapie waarderen. #eerlijketarieven. #samenwerkenaangoedezorg"
                },
                new TweetModel
                {
                    Id = "6",
                    Timestamp = DateTime.Now.AddDays(-7),
                    Message = "100% wordt moeilijker per jaar, zelfs @onvz op b.v thuiszorg"
                },
                new TweetModel
                {
                    Id = "7",
                    Timestamp = DateTime.Now.AddDays(-6),
                    Message = "Hoe zit het als je met een chronisch ziekte overstapt van fysiotherapeut? @onvz"
                },
                new TweetModel
                {
                    Id = "8",
                    Timestamp = DateTime.Now.AddDays(-5),
                    Message = "Wil je een #PaarseKrokodil ? Die krijg je geheid als je bij #CZ #Ziektekostenverzekeringen jouw verzekering afsluit. Niet doen dus. Ga wel naar @HEMA of @onvz"
                },
                new TweetModel
                {
                    Id = "9",
                    Timestamp = DateTime.Now.AddDays(-4),
                    Message = "Klopt dit @onvz ? Ook voor de bestaande verzekerden?"
                },
                new TweetModel
                {
                    Id = "10",
                    Timestamp = DateTime.Now.AddDays(-3),
                    Message = "Bij  @onvz is dit het geval, maar er zijn nog wel andere restitutiepolissen die wel volledig vergoeden. Check een zorgvergelijker"
                },
                new TweetModel
                {
                    Id = "11",
                    Timestamp = DateTime.Now.AddDays(-2),
                    Message = "Naar mijn weten geldt dit voor alle @onvz producten, incl die van @VvAA"
                },
                new TweetModel
                {
                    Id = "12",
                    Timestamp = DateTime.Now.AddDays(-1),
                    Message = "Moet ook schamper lachen om hun reclame die ik steeds langs zie komen: 'buitengewoon veel vrijheid'. Eufeminisme voor: we hebben onze restitutiepolis in de prullenbak gegooid, maar proberen het nog enigszins iets te doen lijken"
                },
                new TweetModel
                {
                    Id = "13",
                    Timestamp = DateTime.Now,
                    Message = "Wat een ongelooflijk slechte service @onvz ! 5 minuten in de wacht en eruit gegooid worden. Nog keertje bellen. 45 minuten aan de telefoon met Saïd en nog geen antwoord! Mensen ga naar een andere zorgverzekeraar!!!"
                },
                new TweetModel
                {
                    Id = "14",
                    Timestamp = DateTime.Now,
                    Message = "Er bestaan dus wel degelijk gunstige en ongunstige verzekerden, waar meer of minder winst te halen is, ondanks verevening. ONVZ is niet voor niets gestopt met de zuivere restitutiepolis"
                },
                new TweetModel
                {
                    Id = "15",
                    Timestamp = DateTime.Now,
                    Message = "Jippie! Weer een nieuwe #zorgpolis erbij. Partying face Het gaat om 'Jaah' van  @onvz, wat overigens een #naturapolis is. Maximaal vergoeding van 75% van het gemiddelde van het gecontracteerde tarief bij ongecontracteerde #zorg."
                }
            };

        public static List<TweetSentimentModel> MockedOnvzTweetSentiments = new List<TweetSentimentModel>
        {
            new TweetSentimentModel
            {
                Id = "1",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-10),
                Message = "Nieuwe polis #onvz binnen. Krijgen iets minder vergoed en gaan €1.97 minder betalen p.m volgens de aangeboden polis. Nu gaan wij onze polis beetje veranderen en gaan in totaal €2,39 meer betalen p.m . Dat val te overzienKnipogend gezichtHand met 'oké'-gebaar Al jaren zeer te breiden over @onvz"
            },

            new TweetSentimentModel
            {
                Id = "2",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-10),
                Message = "Dank jullie wel @onvz voor de snelle reactie en heb alles kunnen regelen wat er geregeld moest worden."
            },
            new TweetSentimentModel
            {
                Id = "3",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-10),
                Message = "@onvz Jullie website is al vanaf donderdag uit de lucht????"
            },
            new TweetSentimentModel
            {
                Id = "4",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-9),
                Message = "@onvz beste, ik wil een vergelijking maken tussen de superfit aanvullende verzekering en de topfit verzekering. Kunt u mij lagen weten hoe ik dat zo overzichtelijk mogelijk kan doen."
            },
            new TweetSentimentModel
            {
                Id = "5",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-8),
                Message = "@onvz Vandaag geven we jullie een #warmedouchenamensdeergotherapeuten. Dank dat jullie het kostprijsonderzoek serieus nemen en laten zien dat jullie de waarde van #ergotherapie waarderen. #eerlijketarieven. #samenwerkenaangoedezorg"
            },
            new TweetSentimentModel
            {
                Id = "6",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-7),
                Message = "100% wordt moeilijker per jaar, zelfs @onvz op b.v thuiszorg"
            },
            new TweetSentimentModel
            {
                Id = "7",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-6),
                Message = "Hoe zit het als je met een chronisch ziekte overstapt van fysiotherapeut? @onvz"
            },
            new TweetSentimentModel
            {
                Id = "8",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-5),
                Message = "Wil je een #PaarseKrokodil ? Die krijg je geheid als je bij #CZ #Ziektekostenverzekeringen jouw verzekering afsluit. Niet doen dus. Ga wel naar @HEMA of @onvz"
            },
            new TweetSentimentModel
            {
                Id = "9",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-4),
                Message = "Klopt dit @onvz ? Ook voor de bestaande verzekerden?"
            },
            new TweetSentimentModel
            {
                Id = "10",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-3),
                Message = "Bij  @onvz is dit het geval, maar er zijn nog wel andere restitutiepolissen die wel volledig vergoeden. Check een zorgvergelijker"
            },
            new TweetSentimentModel
            {
                Id = "11",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-2),
                Message = "Naar mijn weten geldt dit voor alle @onvz producten, incl die van @VvAA"
            },
            new TweetSentimentModel
            {
                Id = "12",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now.AddDays(-1),
                Message = "Moet ook schamper lachen om hun reclame die ik steeds langs zie komen: 'buitengewoon veel vrijheid'. Eufeminisme voor: we hebben onze restitutiepolis in de prullenbak gegooid, maar proberen het nog enigszins iets te doen lijken"
            },
            new TweetSentimentModel
            {
                Id = "13",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now,
                Message = "Wat een ongelooflijk slechte service @onvz ! 5 minuten in de wacht en eruit gegooid worden. Nog keertje bellen. 45 minuten aan de telefoon met Saïd en nog geen antwoord! Mensen ga naar een andere zorgverzekeraar!!!"
            },
            new TweetSentimentModel
            {
                Id = "14",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now,
                Message = "Er bestaan dus wel degelijk gunstige en ongunstige verzekerden, waar meer of minder winst te halen is, ondanks verevening. ONVZ is niet voor niets gestopt met de zuivere restitutiepolis"
            },
            new TweetSentimentModel
            {
                Id = "15",
                Label = "onvz",
                Sentiment = Sentiment.Unknown,
                Timestamp = DateTime.Now,
                Message = "Jippie! Weer een nieuwe #zorgpolis erbij. Partying face Het gaat om 'Jaah' van  @onvz, wat overigens een #naturapolis is. Maximaal vergoeding van 75% van het gemiddelde van het gecontracteerde tarief bij ongecontracteerde #zorg."
            }
        };
    }
}