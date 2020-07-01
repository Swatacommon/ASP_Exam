using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Task7
{
    public class SimpleServerHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            if(context.Request.HttpMethod == "GET")
            {
                string HTML = File.ReadAllText(HttpContext.Current.Server.MapPath("~/html.html"));
                context.Response.ContentType = "text/html";
                context.Response.Write(HTML);
            }
            if (context.Request.HttpMethod == "POST")
            {
                int ParmA;
                int ParmB;
                if (Int32.TryParse(context.Request.Params.Get("x"), out ParmA) && Int32.TryParse(context.Request.Params.Get("y"), out ParmB))
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write($"{ParmA} + {ParmB} = {ParmA + ParmB}");
                }
                else
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Введите ЧИСЛО!");
                }
            }
        }
    }
}