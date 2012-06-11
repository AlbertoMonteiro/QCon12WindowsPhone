using System;
using System.Web;
using QCon12.Models;

namespace QCon12.Modules
{
    public class SessionLifeCycle : IHttpModule
    {
        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.EndRequest += ContextEndRequest;
        }

        public void Dispose() { }

        #endregion

        private static void ContextEndRequest(object sender, EventArgs e)
        {
            QCon12Context.Instance.SaveChanges();
            QCon12Context.Reload();
        }
    }
}