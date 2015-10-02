using System.Collections.Generic;
using PartnerSummitDemo.Models;
using Sitecore.Analytics.Aggregation.Pipeline;
using Sitecore.ContentSearch.Analytics.Aggregators;

namespace PartnerSummitDemo.Search
{
    public class AnalyticsPartnerSummitDataAggregator : ObservableAggregator<PartnersummitDataIndexable>
    {
        protected override IEnumerable<PartnersummitDataIndexable> ResolveIndexables(AggregationPipelineArgs args)
        {
            if (args.Context.Contact == null)
            {
                yield break;
            }

            var data = args.Context.Contact.GetFacet<IPartnerSummitData>("Partnersummit Data");
            yield return new PartnersummitDataIndexable(args.Context.Contact.Id.Guid, data);
        }

        public AnalyticsPartnerSummitDataAggregator(string name) : base(name)
        {
        }
    }
}