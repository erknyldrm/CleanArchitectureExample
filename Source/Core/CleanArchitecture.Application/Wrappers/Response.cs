using System.Collections.Generic;

namespace CleanArchitecture.Application.Wrappers
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Response()
        {

        }

        public Response(string message = null)
        {
            Succeeded = false;
            Message = message;
        }

        public Response(T data, string message = null)
        {
            Succeeded = false;
            Message = message;
            Data = data;
        }
    }
}
