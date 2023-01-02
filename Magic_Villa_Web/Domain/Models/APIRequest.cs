using static Magic_Villa_Utility.StaticDetail;

namespace Magic_Villa_Web.Domain.Models;

public class APIRequest
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public HttpMethod HttpMethod { get; set; }
    public string Url { get; set; }
    public object Data { get; set; }
}
