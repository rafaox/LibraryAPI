using System;
using LibraryApi.Services.Base;

namespace LibraryApi.Services.Filter
{
    public class BookFilter : BaseFilter
    {
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
    }
}