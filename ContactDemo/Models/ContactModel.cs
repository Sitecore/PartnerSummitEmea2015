using Sitecore.Mvc.Presentation;

namespace PartnerSummitDemo.Models
{
    public class ContactModel : RenderingModel
    {
        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string AttendeeId { get; set; }

        public string Email { get; set; }
    }
}