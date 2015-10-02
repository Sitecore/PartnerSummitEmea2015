namespace PartnerSummitDemo.sitecore.admin
{
    using System.Web;
    using System.Web.SessionState;

    public class Kill : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Session.Abandon();
            context.Response.Write("Session abandoned");
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}