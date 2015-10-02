using System.Data;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;

namespace PartnerSummitDemo.pipelines.contactviewpipelines
{
    public class ConstructPartnerSummitDataTable : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            args.ResultTableForView = new DataTable();
            args.ResultTableForView.Columns.Add(new ViewField<bool>("Attending").ToColumn());
            args.ResultTableForView.Columns.Add(new ViewField<string>("AttendeeId").ToColumn());
        }
    }
}