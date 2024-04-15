using Microsoft.AspNetCore.Mvc;

namespace Reddit.Requests;

public class GetPostsRequest
{
    [FromQuery] public int PageNumber { get; set; } = 1;
    [FromQuery] public int PageSize { get; set; } = 10;
    [FromQuery] public string SearchKey { get; set; } = "";
    [FromQuery] public string SortKey { get; set; } = "";
    [FromQuery] public bool IsAscending { get; set; } = true;
}