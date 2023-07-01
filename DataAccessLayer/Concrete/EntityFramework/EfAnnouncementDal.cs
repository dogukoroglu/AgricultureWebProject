using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
	public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
	{
		public void ChangeAnnouncementStatus(int id)
		{
			using var c = new AgricultereContext();
			Announcement p = c.Announcements.Find(id);
			if(p.Status == true)
			{
				p.Status = false;
			}
			else
			{
				p.Status = true;
			}
			c.SaveChanges();
		}
	}
}
