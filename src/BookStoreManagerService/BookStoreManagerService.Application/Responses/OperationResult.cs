using System;
using System.Net;

namespace BookStoreManagerService.Application.Responses;

public class OperationResult
{
    public HttpStatusCode StatusCode { get; set; }
    public int ResourceId { get; set; }
    public dynamic? Data { get; set; }
    public List<OperationErrorMessage> Errors { get; set; }
    public class OperationErrorMessage
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }  
}
