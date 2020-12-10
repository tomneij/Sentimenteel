using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class TrendModel
    {
        public string Label { get; set; }

        public List<DataPoint> PositiveDataPoints { get; set; } = new List<DataPoint>();
        
        public List<DataPoint> NeutralDataPoints { get; set; } = new List<DataPoint>();
        
        public List<DataPoint> NegativeDataPoints { get; set; } = new List<DataPoint>();

    }
}