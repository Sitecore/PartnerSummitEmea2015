using PartnerSummitDemo.Models;
using Sitecore.Analytics;

namespace PartnerSummitDemo.Conditions
{
    using Sitecore.Rules;
    using Sitecore.Rules.Conditions;

    public class PartnerSummitAttendingCondition<T> : WhenCondition<T> where T : RuleContext
    {
        protected override bool Execute(T ruleContext)
        {
            var contact = Tracker.Current.Contact;

            var employeeDataFacet = contact.GetFacet<IPartnerSummitData>("Partnersummit Data");
            return employeeDataFacet.Attending == bool.Parse(Value);
        }

        public string Value { get; set; }
    }
}