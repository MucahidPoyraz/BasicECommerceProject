﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PageModels
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; private set; }   // Şu anki sayfa
        public int TotalPages { get; private set; }  // Toplam sayfa sayısı
        public int TotalCount { get; private set; }  // Toplam veri sayısı

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            TotalCount = count;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public List<T> Items { get; private set; }   // Sayfadaki veriler
    }
}
