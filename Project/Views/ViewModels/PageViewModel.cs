using System;

namespace Project.Helpers
{
    public class PageViewModel
    {
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
