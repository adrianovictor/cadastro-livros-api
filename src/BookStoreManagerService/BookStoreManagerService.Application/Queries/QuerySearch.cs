using System;

namespace BookStoreManagerService.Application.Queries;

public class QuerySearch
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public string? Q { get; set;}

    public QuerySearch()
    {
        Offset = 1;
        Limit = 20;
    }
}
