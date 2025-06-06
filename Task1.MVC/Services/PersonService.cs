using System;
using System.Linq;
using Task1.MVC.Data;
using Task1.MVC.ViewModel;

namespace Task1.MVC.Services
{
    public class PersonService : IPersonService, IDisposable
    {
        private readonly AppDbContext _appDbContext;

        public PersonService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Dispose()
        {
            _appDbContext?.Dispose();
        }

        public PagedPersonViewModel GetPersons(int page, int pageSize)
        {
            if (page < 1)
                page = 1;

            if (pageSize < 10)
                pageSize = 10;

            var totalRecords = _appDbContext.Persons.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (page > totalPages)
                page = totalPages;

            var persons = _appDbContext.Persons
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedPersonViewModel
            {
                CurrentPage = page,
                TotalRecords = totalRecords,
                PageSize = pageSize,
                Persons = persons
            };
        }
    }
}