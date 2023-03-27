using System;
using System.Net;

namespace EFTemplate.CustomExceptions
{
    /// <summary>
    /// This is just a marker class. We will return HttpResponseException when we know what's wrong and we want to return an HTTP 200
    /// but the HttpErrorResponse has the Error in it.
    /// </summary>
    public class HttpResponseException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        public HttpResponseException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
        public HttpResponseException(int httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = (HttpStatusCode)httpStatusCode;
        }
        public HttpResponseException(HttpStatusCode httpStatusCode, Exception innerException) : base(innerException?.Message, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }

        public HttpResponseException() : base()
        {
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}