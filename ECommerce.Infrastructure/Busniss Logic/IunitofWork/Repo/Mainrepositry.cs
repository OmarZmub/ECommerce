using ECommerce.Busniss_Logic.IunitofWork.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using ECommerce.Data;

namespace ECommerce.Busniss_Logic.IunitofWork.Repo
{
    public class Mainrepositry<mdl> : IMainrepositry<mdl> where mdl : class
    {

        public Mainrepositry(database db)
        {
            this.db = db;
        }

        protected database db;

        public mdl FindById(int id)
        {
            return db.Set<mdl>().Find(id);
        }

        public mdl SelectOne(Expression<Func<mdl, bool>> match)
        {
            return db.Set<mdl>().SingleOrDefault(match);
        }

        public IEnumerable<mdl> GetAll()
        {
            return db.Set<mdl>().ToList();
        }

        public async Task<mdl> FindByIdAsync(int id)
        {
            return await db.Set<mdl>().FindAsync(id);
        }

        public async Task<IEnumerable<mdl>> GetAllAsync()
        {
            foreach (var item in typeof(mdl).GetProperties().Where(p => p.GetType() == typeof(string)))
            {
                var value = item.GetValue(this);
                //my action
            }
            return await db.Set<mdl>().ToListAsync();
        }



        async Task<IEnumerable<mdl>> IMainrepositry<mdl>.GetAllAsync(Expression<Func<mdl, bool>> expression)
        {
            return await db.Set<mdl>().Where(expression).AsNoTracking().ToListAsync();
        }

        //=========================================================================//

        public void AddOne(mdl myItem)
        {
            db.Set<mdl>().Add(myItem);
            db.SaveChanges();
        }

        public void UpdateOne(mdl myItem)
        {
            db.Set<mdl>().Update(myItem);
            db.SaveChanges();
        }

        public void DeleteOne(mdl myItem)
        {
            db.Set<mdl>().Remove(myItem);
            db.SaveChanges();
        }

        public void AddList(IEnumerable<mdl> myList)
        {
            db.Set<mdl>().AddRange(myList);
            db.SaveChanges();
        }

        public void UpdateList(IEnumerable<mdl> myList)
        {
            db.Set<mdl>().UpdateRange(myList);
            db.SaveChanges();
        }

        public void DeleteList(IEnumerable<mdl> myList)
        {
            db.Set<mdl>().RemoveRange(myList);
            db.SaveChanges();
        }

        
    }
}
