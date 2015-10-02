using Sitecore.Analytics.Model.Framework;
using Sitecore.ContentSearch;

namespace PartnerSummitDemo.Models
{
    public class PartnerSummitData : Facet, IPartnerSummitData
    {
        private const string FieldAttendeeId = "AttendeeId";
        private const string FieldAttending = "Attending";

        public PartnerSummitData()
        {
            EnsureAttribute<string>(FieldAttendeeId);
            EnsureAttribute<bool>(FieldAttending);
        }

        [IndexField("attendee.attending")]
        public bool Attending
        {
            get
            {
                return GetAttribute<bool>(FieldAttending);
            }

            set
            {
                SetAttribute(FieldAttending, value);
            }
        }

        [IndexField("attendee.id")]
        public string AttendeeId
        {
            get
            {
                return GetAttribute<string>(FieldAttendeeId);
            }

            set
            {
                SetAttribute(FieldAttendeeId, value);
            }
        }
    }
}