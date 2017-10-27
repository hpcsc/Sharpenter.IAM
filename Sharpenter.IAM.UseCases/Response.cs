using System.Collections.Generic;

namespace Sharpenter.IAM.UseCases
{
    public class Response
    {
        public bool Success { get; private set; }
        public IList<string> Messages { get; private set; }

        public Response(bool success, IList<string> messages)
        {
            Success = success;
            Messages = messages;
        }
        
        public static Response Succeed()
        {
            return new Response(true, new List<string>());
        }
        
        public static Response Fail(params string[] messages)
        {
            return new Response(false, new List<string>(messages));
        }
    }
    
    public class Response<TData> : Response
    {
        public TData Data { get; private set; }

        public Response(bool success, IList<string> messages, TData data) : base(success, messages)
        {
            Data = data;
        }

        public static Response<T> Succeed<T>(T data = default(T))
        {
            return new Response<T>(true, new List<string>(), data);
        }
        
        public static Response<T> Fail<T>(params string[] messages)
        {
            return new Response<T>(false, new List<string>(messages), default(T));
        }
    }
}