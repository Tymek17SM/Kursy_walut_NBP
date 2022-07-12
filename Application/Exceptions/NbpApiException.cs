using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NbpApiException : Exception
    {
        public HttpResponseMessage HttpResponseMessage { get; }

        public NbpApiException(HttpResponseMessage httpResponseMessage)
        {
            HttpResponseMessage = httpResponseMessage;
        }

    }
}
