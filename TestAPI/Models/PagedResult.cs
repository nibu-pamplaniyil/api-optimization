﻿namespace TestAPI.Models
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; } = 0;
    }
}
