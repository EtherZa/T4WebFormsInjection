using System;
using System.Web;
using T4WFI.App.Code;

namespace T4WFI.App.Modules
{
    public partial class MyModule1 : IHttpModule
    {
        public MyModule1(IDummyInterface dummyInterface)
        {
        }

        public void OnLogRequest(object source, EventArgs e)
        {
            // custom logging logic can go here
        }

        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>

        #region IHttpModule Members
        public void Dispose()
        {
            // clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.LogRequest += new EventHandler(this.OnLogRequest);
        }

        #endregion
    }
}