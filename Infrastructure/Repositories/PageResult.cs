using System;
using System.Collections.Generic;

namespace feed.Infrastructure.Repositories
{
    public class PageResult<T>
    {
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<T> Result { get; set; }
    }
}