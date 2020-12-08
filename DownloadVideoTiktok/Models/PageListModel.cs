using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadVideoTiktok.Models
{
    public class PageListModel<T>
    {
        public List<T> List { get; set; }
        public long Total { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPage => Convert.ToInt32(Total / PageSize) + (Total % PageSize > 0 ? 1 : 0);
        public PagingModel Paging => new PagingModel() { CurrentPage = CurrentPage, PageSize = PageSize, Total = Total };
    }
}
