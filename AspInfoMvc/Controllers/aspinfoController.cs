using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AspInfoMvc.Controllers
{
    public class InfoClass
    {
        public string OperatingSystem
        {
            get { return Environment.OSVersion.ToString(); }
        }

        public string[] ServerSoftware
        {
            get { return HttpContext.Current.Request.ServerVariables.GetValues("SERVER_SOFTWARE"); }
        }

        public System.Reflection.Assembly[] LoadedAssemblies
        {
            get { return AppDomain.CurrentDomain.GetAssemblies().Concat(AppDomain.CurrentDomain.GetAssemblies()).Distinct().OrderBy(o => o.FullName).ToArray(); }
        }

        public System.Reflection.Assembly MvcDll
        {
            get { return AppDomain.CurrentDomain.Load("System.Web.Mvc"); }
        }

        public NameValueCollection ServerVariables
        {
            get { return HttpContext.Current.Request.ServerVariables; }
        }

        public string NetVersion
        {
            get { return Environment.Version.ToString(); }
        }

        public int NetBitness
        {
            get { return IntPtr.Size * 8; }
        }               
    }

    public class AspInfoController : Controller
    {
        //
        // GET: /AspInfo/
        public InfoClass MyInfo = new InfoClass();

        public ActionResult Index()
        {

            return View(MyInfo);
        }

    }
}


