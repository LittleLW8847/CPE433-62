using System;
using System.Text;

namespace DNWS
{
    public class ClientInfoPlugin : IPlugin
    {
        public HTTPResponse GetResponse(HTTPRequest request)
        {
            StringBuilder StringBuild = new StringBuilder();
            string[] ClientEndPoint = request.getPropertyByKey("RemoteEndPoint").Split(':');
            string temp;

            StringBuild.Append("<html><body>");
            StringBuild.Append("Client IP: ").Append(ClientEndPoint[0]).Append("<br />\n");
            StringBuild.Append("Client Port: ").Append(ClientEndPoint[1]).Append("<br />\n");

            if((temp = request.getPropertyByKey("User-agent")) != null){
                StringBuild.Append("Browser Information: ").Append(temp).Append("<br />\n");
            }
            if((temp = request.getPropertyByKey("accept-language")) != null)
            {
                StringBuild.Append("Accept Language: ").Append(temp).Append("<br />\n");
            }
            if((temp = request.getPropertyByKey("accept-encoding") != null){
                StringBuild.Append("Accept Encoding: ").Append(temp).Append("<br />\n");
            }

            StringBuild.Append("</body></html>");
            HTTPResponse Response = new HTTPResponse(200);
            Response.body = Encoding.UTF8.GetBytes(sb.ToString());
            return Response;

        }

        public HTTPResponse PostProcessing(HTTPResponse response)
        {
            throw new NotImplementedException();
        }

        public void PreProcessing(HTTPRequest request)
        {
            throw new NotImplementedException();
        }
    }
}