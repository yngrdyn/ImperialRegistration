using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImperialRegister.Startup))]
namespace ImperialRegister
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
