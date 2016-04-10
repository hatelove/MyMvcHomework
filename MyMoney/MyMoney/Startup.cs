using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMoney.Startup))]
namespace MyMoney
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
