using System.Net;

namespace PresentationLayer.Models
{
    public class ResponseObject<T>
    {
        private T _data;
        private bool _success = false;
        private string _message;
        private HttpStatusCode _statusCode;

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        public bool IsSuccess
        {
            get { return _success; }
            set { _success = value; }
        }


        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }


        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
