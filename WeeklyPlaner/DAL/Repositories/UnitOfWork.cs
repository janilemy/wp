using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        WeeklyPlanerContext context = new WeeklyPlanerContext();
        private MealRepository mealRepository;
        private GenericRepository<Item> itemRepository;
        private GenericRepository<Unit> unitRepository;
        private GenericRepository<Planer> planerRepository;
        private GenericRepository<Course> courseRepository;

        public MealRepository MealRepository
        {
            get
            {
                if (this.mealRepository == null)
                {
                    this.mealRepository = new MealRepository(context);
                }
                return mealRepository;
            }            
        }

        public GenericRepository<Item> ItemRepository
        {
            get
            {
                if(this.itemRepository == null)
                {
                    this.itemRepository = new GenericRepository<Item>(context);
                }
                return itemRepository;
            }
        }

        public GenericRepository<Unit> UnitRepository
        {
            get
            {
                if (this.unitRepository == null)
                {
                    this.unitRepository = new GenericRepository<Unit>(context);
                }
                return unitRepository;
            }
        }

        public GenericRepository<Planer> PlanerRepository
        {
            get
            {
                if(this.planerRepository == null)
                {
                    this.planerRepository = new GenericRepository<Planer>(context);
                }
                return planerRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {
                if(this.courseRepository == null)
                {
                    this.courseRepository = new GenericRepository<Course>(context);
                }
                return courseRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}