using Task1.MVC.ViewModel;

namespace Task1.MVC.Services
{
    public interface IPersonService
    {
        PagedPersonViewModel GetPersons(int page, int pageSize);
    }
}
