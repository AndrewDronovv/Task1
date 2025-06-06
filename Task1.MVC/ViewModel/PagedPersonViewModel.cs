using System;
using System.Collections.Generic;
using Task1.MVC.Models;

namespace Task1.MVC.ViewModel
{
    public class PagedPersonViewModel
    {
        public List<Person> Persons { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public string Elapsed { get; set; }
    }
}