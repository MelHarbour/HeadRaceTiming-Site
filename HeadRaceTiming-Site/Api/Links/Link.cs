using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Api.Links
{
    /// <summary>
    /// A base class for relation links
    /// </summary>
    public abstract class Link
    {
        public string Rel { get; private set; }
        public string Href { get; private set; }
        public string Title { get; private set; }

        public Link(string relation, string href, string title = null)
        {
            Rel = relation;
            Href = href;
            Title = title;
        }
    }
}
