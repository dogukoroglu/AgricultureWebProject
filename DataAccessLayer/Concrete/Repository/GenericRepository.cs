using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
	public class GenericRepository<T> : IGenericDal<T> where T : class, new()
	{
		public void Delete(T t)
		{
			using var context = new AgricultereContext();
			context.Remove(t);
			context.SaveChanges();
		}

		public T GetByID(int id)
		{
			using var context = new AgricultereContext();
			return context.Set<T>().Find(id);
		}

		public List<T> GetListAll()
		{
			using var context = new AgricultereContext();
			return context.Set<T>().ToList();
		}

		public void Insert(T t)
		{
			using var context = new AgricultereContext();
			context.Add(t);
			context.SaveChanges();
		}

		public void Update(T t)
		{
			using var context = new AgricultereContext();
			context.Update(t);
			context.SaveChanges();
		}
	}
}
