using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SharePoint.Client
{
    public class SPHttpClientHandler : HttpClientHandler
    {
        string accessToken;

        public SPHttpClientHandler(Uri webUri, string accessToken)
        {
            FormatType = FormatType.JsonVerbose;
            this.accessToken = accessToken;

        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);
            if (FormatType == FormatType.JsonVerbose)
            {
                request.Headers.Add("Accept", "application/json;odata=verbose");
            }
            return base.SendAsync(request, cancellationToken);
        }


        public FormatType FormatType { get; set; }
    }

    public enum FormatType
    {
        JsonVerbose,
        Xml
    }
}