using RestWithASPNET.Model;
using RestWithASPNET.Model.Base;
using RestWithASPNET.Utils;

namespace RestWithASPNET.Repository.Generic
{
    public interface IRepository<T> where T: BaseEntity
    {
        List<T> FindAll(ParamsPagination paramsPagination);
        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);
    }
}
