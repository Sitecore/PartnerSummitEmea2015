using Sitecore.Analytics.Model.Framework;

namespace PartnerSummitDemo.Models
{
    public interface IPartnerSummitData : IFacet
    {
        bool Attending { get; set; }

        string AttendeeId { get; set; } 
    }
}