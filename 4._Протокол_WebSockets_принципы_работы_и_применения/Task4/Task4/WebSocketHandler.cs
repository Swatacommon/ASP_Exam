using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace Task4
{
    public class WebSocketHandler : IHttpHandler
    {
        public bool IsReusable => false;
        private WebSocket webSocket;
        public void ProcessRequest(HttpContext context)
        {
            if(context.Request.HttpMethod == "GET" && context.IsWebSocketRequest != true)
            {
                string textFromFile = File.ReadAllText(HttpContext.Current.Server.MapPath("~/getpost.html"));
                context.Response.ContentType = "text/html";
                context.Response.Write(textFromFile);
            }
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
        }

        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            webSocket = context.WebSocket;
            while (true)
            {
                var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(DateTime.Now.ToLongDateString()));
                Thread.Sleep(2500);
                try
                {
                    if (webSocket.State == WebSocketState.Open)
                    {
                        await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
                catch (ObjectDisposedException)
                {
                    webSocket.Abort();
                }
            }
        }
    }
}