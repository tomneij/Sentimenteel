using System.Collections.Generic;

namespace Website.Models
{
    public class OverviewViewModel
    {
        public List<OverviewItemViewModel> Items { get; set; }



        public OverviewViewModel()
        {
            this.Items = new List<OverviewItemViewModel>();
        }
    }
}