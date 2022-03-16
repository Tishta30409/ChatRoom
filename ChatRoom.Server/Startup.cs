[assembly: Microsoft.Owin.OwinStartup(typeof(ChatRoom.Server.Startup))]

namespace ChatRoom.Server
{
    using Autofac.Integration.WebApi;
    using ChatRoom.Server.Applibs;
    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Cors;
    using Owin;
    using System.Web.Http;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //短連結建置
            var webApiConfiguration = ConfigureWebApi();
            app.UseWebApi(webApiConfiguration);

            app.UseCors(CorsOptions.AllowAll);

            //長連結設置
            // 解除限制WS傳輸量q
            GlobalHost.Configuration.MaxIncomingWebSocketMessageSize = null;
            GlobalHost.Configuration.DefaultMessageBufferSize = 100; // 每個集線器緩存保留的消息，留存過多會造成緩存變高
            app.MapSignalR();
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            //// API DI設定
            config.DependencyResolver = new AutofacWebApiDependencyResolver(AutofacConfig.Container);

            return config;
        }
    }
}
