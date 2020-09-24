using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBHRepository.DTO
{
    //Data transfer Object (Complex type) 
    public class PagedInput
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }

    //<T> gennerics class Kiểu đại diện cho kiểu data chuyển vào: hàng hóa, chủng loại,...
    public class PagedOutput<T>
    {
        public List<T> Items { get; set; }
        public int TotalItemCount { get; set; }
    }
}