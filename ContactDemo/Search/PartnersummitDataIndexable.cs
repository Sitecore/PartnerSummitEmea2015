using System;
using System.Collections.Generic;
using PartnerSummitDemo.Models;
using Sitecore.ContentSearch;

namespace PartnerSummitDemo.Search
{
    public class PartnersummitDataIndexable : AbstractIndexable
    {
        public PartnersummitDataIndexable(Guid contactGuid, IPartnerSummitData data)
        {
            var str = contactGuid + "partnersummitdata";
            Id = new IndexableId<string>(str);
            UniqueId = new IndexableUniqueId<string>(string.Format("{0}|{1}", "partnersummitattendee", str));
            DataSource = "sitecore_aggregation";
            AbsolutePath = string.Empty;
            Culture = System.Globalization.CultureInfo.CurrentCulture;
            LoadFields(contactGuid, data);
        }

        protected virtual void LoadFields(Guid contactGuid, IPartnerSummitData data)
        {
            var list = new List<IIndexableDataField>
            {
                new IndexableDataField<string>("type", "attendee"),
                new IndexableDataField<Guid>("contact.ContactId", contactGuid),
                new IndexableDataField<string>("attendee.id", data.AttendeeId),
                new IndexableDataField<string>("attendee.attending", data.Attending.ToString())
            };

            Fields = list;
        }

        public override void LoadAllFields()
        {
        }
    }
}