
using Newtonsoft.Json;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

public enum ResponseStatus
{
    Success = 1,
    Error = 0
}
public class JsonResponse
{
    public const int SUCCESS = 1;
    public const int ERROR = 0;

    private class ResponseModel
    {
        public ResponseModel(ResponseStatus status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    private class PaginatedResponseModel : ResponseModel
    {
        public PaginatedResponseModel(ResponseStatus status, string message, int page, object data) : base(status, message, data)
        {
            Page = page;
        }

        public int Page { get; set; }

    }

    private ResponseModel Model;
    private HttpStatusCode StatusCode;

    public JsonResponse(
        ResponseStatus status,
        string message,
        object data,
        HttpStatusCode statusCode = HttpStatusCode.OK
    )
    {
        Model = new ResponseModel(status, message, data);
        StatusCode = statusCode;
    }

    private JsonResponse(
       ResponseModel model,
       HttpStatusCode statusCode = HttpStatusCode.OK
    )
    {
        Model = model;
        StatusCode = statusCode;
    }

    public HttpResponseMessage GetResponse(HttpRequestMessage request)
    {
        var response = request.CreateResponse();
        response.Content = new StringContent(
            JsonConvert.SerializeObject(Model),
            Encoding.UTF8,
            "application/json"
        );
        response.StatusCode = StatusCode;

        return response;
    }

    public static HttpResponseMessage Success(HttpRequestMessage request, object data)
    {
        return new JsonResponse(ResponseStatus.Success, "Success", data).GetResponse(request);
    }

    public static HttpResponseMessage Paginated(HttpRequestMessage request,int page, object  data)
    {
        return new JsonResponse(new PaginatedResponseModel(ResponseStatus.Success, "Success", page, data)).GetResponse(request);
    }

    public static HttpResponseMessage Error(HttpRequestMessage request, string message, HttpStatusCode errorCode = HttpStatusCode.InternalServerError)
    {
        return new JsonResponse(ResponseStatus.Error, message, new ArrayList(), errorCode).GetResponse(request);
    }

    public static HttpResponseMessage DataInvalid(HttpRequestMessage request, HttpStatusCode errorCode = HttpStatusCode.BadRequest)
    {
        return new JsonResponse(ResponseStatus.Error, "Data Invalid", new ArrayList(), errorCode).GetResponse(request);
    }

    public static HttpResponseMessage ParameterIncorrect(HttpRequestMessage request, HttpStatusCode errorCode = HttpStatusCode.BadRequest)
    {
        return new JsonResponse(ResponseStatus.Error, "Parameter Incorrect", new ArrayList(), errorCode).GetResponse(request);
    }

}