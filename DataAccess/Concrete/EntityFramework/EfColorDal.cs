using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (AracContext context=new AracContext())
            { 
                var addedEntity=context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            } 
        }

        public void Delete(Color entity)
        {
            using (AracContext context = new AracContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (AracContext context = new AracContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
                
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (AracContext context = new AracContext())
            {
                return filter == null ? context.Set<Color>().ToList():context.Set<Color>().Where(filter).ToList();
            }
        }

        public List<Color> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Color entity)
        {
            using (AracContext context = new AracContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
