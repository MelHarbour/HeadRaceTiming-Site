using HeadRaceTimingSite.Api.Links;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Api.Resources
{
    public abstract class Resource
    {
        private readonly List<Link> links = new List<Link>();

        [JsonProperty(Order = 100)]
        public IEnumerable<Link> Links { get { return links; } }

        public void AddLink(Link link)
        {
            links.Add(link);
        }

        public void AddLinks(params Link[] links)
        {
            foreach (Link link in links)
            {
                AddLink(link);
            }
        }
    }
}
