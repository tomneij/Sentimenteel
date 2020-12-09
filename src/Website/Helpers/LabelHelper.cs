using System.Linq;
using Website.Models;

namespace Website.Helpers
{
    public static class LabelHelper
    {
        public static LabelModel GetLabel(string id)
        {
            return Constants.Labels.FirstOrDefault(l => l.Name.Equals(id));
        }
    }
}