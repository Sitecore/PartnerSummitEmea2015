using System.Data;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;

namespace PartnerSummitDemo.pipelines.contactviewpipelines
{
    public class PopulateWithPartnerSummitData : ReportProcessorBase
    {
        private DataTable queryResult;
        private DataTable resultTableForView;

        public override void Process(ReportProcessorArgs args)
        {
            InitializeArguments(args);
            if (!DatatableSupportsAttendeeData()) return;
            AddRowsToDataTable();
            SetViewDataTable(args);
        }

        private void InitializeArguments(ReportProcessorArgs args)
        {
            queryResult = args.QueryResult;
            resultTableForView = args.ResultTableForView;
        }

        private bool DatatableSupportsAttendeeData()
        {
            return resultTableForView.Columns.Contains("AttendeeId");
        }

        private void AddRowsToDataTable()
        {
            foreach (var row in queryResult.AsEnumerable())
            {
                var id = row["Partnersummit Data_AttendeeId"] as string;
                if (string.IsNullOrEmpty(id))
                {
                    continue;
                }

                var attending = (bool)row["Partnersummit Data_Attending"];

                var targetRow = resultTableForView.NewRow();
                targetRow.SetField("AttendeeId", id);
                targetRow.SetField("Attending", attending.ToString());
                resultTableForView.Rows.Add(targetRow);
            }
        }

        private void SetViewDataTable(ReportProcessorArgs args)
        {
            args.ResultSet.Data.Dataset[args.ReportParameters.ViewName] = resultTableForView;
        }
    }
}