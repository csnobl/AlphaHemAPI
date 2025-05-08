
using System.Net;

namespace AlphaHemAPI.Data.DTO
{
    // Author: Conny

    // Use this if you want to return an object along with the response
    public class Response<T>
    {
        public bool Success { get; set; } = false;
        public T? Data { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = [];
        public HttpStatusCode StatusCode { get; set; }
    }

    // Use this if you want to return a response without an object
    public class Response
    {
        public bool Success { get; set; } = false;
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = [];
        public HttpStatusCode StatusCode { get; set; }
    }
}
