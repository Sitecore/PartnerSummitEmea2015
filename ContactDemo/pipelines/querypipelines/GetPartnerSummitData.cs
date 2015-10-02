using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;
using Sitecore.Cintel.Reporting.ReportingServerDatasource;

namespace PartnerSummitDemo.pipelines.querypipelines
{
    public class GetPartnerSummitData : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            var queryExpression = this.CreateQuery().Build();
            var table = GetTableFromContactQueryExpression(queryExpression, args.ReportParameters.ContactId, null);
            args.QueryResult = table;
        }

        protected virtual QueryBuilder CreateQuery()
        {
            var builder = new QueryBuilder { collectionName = "Contacts" };

            builder.Fields.Add("_id");
            builder.Fields.Add("Partnersummit Data_Attending");
            builder.Fields.Add("Partnersummit Data_AttendeeId");
            builder.QueryParms.Add("_id", "@contactid");
            return builder;
        }
    }
}