<%@ Application Language="C#" %>
<%@ Import Namespace="gs_newsletter" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        RouteTable.Routes.MapPageRoute("admin", "admin", "~/admin/");

        //RouteTable.Routes.MapPageRoute("post", "{archive}/{slug}", "~/Default.aspx");
        // RouteTable.Routes.MapPageRoute("Archive", "{ArchivesSlug}/{page}/", "~/Archive.aspx");
        //RouteTable.Routes.MapPageRoute("Page", "{PageSlug}", "~/Pages.aspx");
        RouteTable.Routes.MapPageRoute("Pages", "{Param1}", "~/Default.aspx");
        RouteTable.Routes.MapPageRoute("HomePage", "{Param1}/{page}/", "~/Default.aspx");
    }

    protected void Session_Start() { }
</script>
