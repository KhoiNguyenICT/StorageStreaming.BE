using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Storage.Model
{
    public class BaseResponse<T> : IActionResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }

        public BaseResponse(string message, int statusCode, T data=default(T))
        {
            this.Message = message;
            this.StatusCode = statusCode;
            this.Data = data;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
