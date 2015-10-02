namespace PartnerSummitDemo.Controllers
{
    using System.Web.Mvc;
    using PartnerSummitDemo.Models;
    using Sitecore;
    using Sitecore.Analytics;
    using Sitecore.Analytics.Model;
    using Sitecore.Analytics.Model.Entities;
    using Sitecore.Analytics.Tracking;
    using Sitecore.Configuration;
    using Sitecore.Links;
    using Sitecore.Mvc.Configuration;
    using Sitecore.Mvc.Controllers;

    public class ContactController : SitecoreController
    {
        private ContactManager contactManager;
        private Contact contact;
        
        public ActionResult CreateContact(ContactModel model)
        {
            StartTrackingIfNecessary();
            InitializeContact();
            SaveFormDetailsToContact(model);
            return RedirectToHomepage();
        }

        private void StartTrackingIfNecessary()
        {
            if (!Tracker.IsActive)
            {
                Tracker.StartTracking();
            }
        }

        private void InitializeContact()
        {
            contactManager = (ContactManager)Factory.CreateObject("tracking/contactManager", true);
            contact = Tracker.Current.Contact;
        }

        private void SaveFormDetailsToContact(ContactModel model)
        {
            SavePartnerSummitDataToContact(model);
            SaveNameToContact(model);
            SaveEmailDetailsToContact(model);
            SaveContactIdentification(model);
        }

        private void SavePartnerSummitDataToContact(ContactModel model)
        {
            var employeeDataFacet = contact.GetFacet<IPartnerSummitData>("Partnersummit Data");
            employeeDataFacet.AttendeeId = model.AttendeeId;
            employeeDataFacet.Attending = true;
        }

        private void SaveNameToContact(ContactModel model)
        {
            var personalInfoFacet = contact.GetFacet<IContactPersonalInfo>("Personal");
            personalInfoFacet.FirstName = model.Firstname;
            personalInfoFacet.Surname = model.Surname;
        }

        private void SaveEmailDetailsToContact(ContactModel model)
        {
            var emailInfoFacet = contact.GetFacet<IContactEmailAddresses>("Emails");
            if (!emailInfoFacet.Entries.Contains("Work"))
            {
                var mail = emailInfoFacet.Entries.Create("Work");
                mail.SmtpAddress = model.Email;
                emailInfoFacet.Preferred = "Work";
            }
        }

        private void SaveContactIdentification(ContactModel model)
        {
            contact.Identifiers.IdentificationLevel = ContactIdentificationLevel.Known;
            contact.Identifiers.Identifier = model.Email; // Not recommended! Emails can change.
        }

        private ActionResult RedirectToHomepage()
        {
            var urloptions = new UrlOptions { AddAspxExtension = false, LanguageEmbedding = LanguageEmbedding.Never };
            var startItem = Context.Database.GetItem(Context.Site.ContentStartPath);
            var url = LinkManager.GetItemUrl(startItem, urloptions);
            return RedirectToRoute(MvcSettings.SitecoreRouteName, new { pathInfo = url.TrimStart('/') });
        }
    }
}