using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFloraWPF.Model
{
    public class Normalized
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Revision
    {
        public string content { get; set; }
    }

    public class Pages
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public List<Revision> revisions { get; set; }
    }

    public class Query
    {
        public List<Normalized> normalized { get; set; }
        public List<Pages> pages { get; set; }
    }

    public class RootObject
    {
        public bool batchcomplete { get; set; }
        public Query query { get; set; }
    }
}
