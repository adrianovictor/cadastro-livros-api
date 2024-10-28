using System.Dynamic;
using System.Net;
using BookStoreManagerService.Application.Responses;
using BookStoreManagerService.Common.Extensions;

namespace BookStoreManagerService.Api.Extensions;

public static class OperationResultExtensions
{
    public static IResult ToResult(this OperationResult operationResult)
    {
        var resultHandler = new Dictionary<int, Func<IResult>>()
        {
            { (int)HttpStatusCode.Created, CreatedResult(operationResult) },
            { (int)HttpStatusCode.OK, OkResult(operationResult) },
            { (int)HttpStatusCode.BadRequest, BadRequestResult(operationResult) },
            { (int)HttpStatusCode.Conflict, ConflictResult(operationResult) }
        };

        return resultHandler[(int)operationResult.StatusCode].Invoke();
    }

    private static Func<IResult> CreatedResult(OperationResult operationResult)
    {
        return () =>
        {
            if (operationResult.Data is not null && ObjectExtensions.HasProperty(operationResult.Data, "Id"))
            {
                var routerParameters = new { operationResult?.Data?.Id };

                IDictionary<string, object> data = null;
                IDictionary<string, object> tempDataResult = operationResult.Data;

                if (tempDataResult.Count() > 1)
                {
                    data = new ExpandoObject();
                    foreach (var kvp in tempDataResult)
                    {
                        if (!kvp.Key.Equals("Id"))
                            data.Add(kvp);
                    }
                }

                return Results.Created(string.Empty, new { resourceId = routerParameters, data });
            }

            return Results.Created(string.Empty, operationResult.Data);
        };
    }

    private static Func<IResult> OkResult(OperationResult operationResult)
    {
        return () =>
        {
            return Results.Ok(operationResult.Data);
        };
    }

    private static Func<IResult> BadRequestResult(OperationResult operationResult)
    {
        return () =>
        {
            return Results.BadRequest(operationResult);
        };
    }

    private static Func<IResult> ConflictResult(OperationResult operationResult)
    {
        return () =>
        {
            return Results.Conflict(operationResult);
        };
    }

}
