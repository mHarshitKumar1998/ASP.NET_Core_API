using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebAPIRoutingCode.Customresultype
{
    public class TestResult : IHttpActionResult
    {
        string value;
        HttpRequestMessage request;
        public TestResult(string _value,HttpRequestMessage _request)
        {
            value = _value;
            request = _request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage reponse = new HttpResponseMessage
            {
                Content = new StringContent(value),
                RequestMessage = request
            };
            return Task.FromResult(reponse);
        }
    }
}