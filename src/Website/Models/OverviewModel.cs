using System.Collections.Generic;

namespace Website.Models
{
    public class OverviewModel
    {
        public List<OverviewItemModel> Items { get; set; }


        public OverviewModel()
        {
            this.Items = new List<OverviewItemModel>();
        }
    }
}