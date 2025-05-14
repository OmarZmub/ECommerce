using System.Linq.Expressions;

namespace ECommerce.Busniss_Logic.IunitofWork.IRepo
{
    
    public interface IMainrepositry<T> where T : class
    {
        T FindById(int id);

        T SelectOne(Expression<Func<T, bool>> match);

        

        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> expression);

        void AddOne(T myItem);

        void UpdateOne(T myItem);

        void DeleteOne(T myItem);

        void AddList(IEnumerable<T> myList);

        void UpdateList(IEnumerable<T> myList);

        void DeleteList(IEnumerable<T> myList);
    }
}
