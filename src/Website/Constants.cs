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
                    Keyword = "Onvz"
                },
                new LabelModel
                {
                    Name = "Ohra",
                    Keyword = "Ohra"
                },
                new LabelModel
                {
                    Name = "CZ",
                    Keyword = "CZ"
                },
                new LabelModel
                {
                    Name = "VGZ",
                    Keyword = "VGZ"
                },
                new LabelModel
                {
                    Name = "ZilverenKruis",
                    Keyword = "ZilverenKruis"
                }
            };
    }
}