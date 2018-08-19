using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1
{
    class Program
    {
        static int InsertedId;

        static void Main(string[] args)
        {
            using (var db = new ContosoUniversityEntities())
            {
                db.Database.Log = Console.WriteLine;


                //var dept = db.Department.Find(33);
                //db.Entry(dept).State = EntityState.Deleted;


                db.Entry(new Department() { DepartmentID = 33 }).State = EntityState.Deleted;
                db.SaveChanges();






                //db.Configuration.LazyLoadingEnabled = false;
                //db.Configuration.ProxyCreationEnabled = false;

                //var department = db.Department.AsNoTracking();

                //foreach (var dept in department)
                //{
                //    Console.WriteLine(dept.Name);
                //    foreach (var item in dept.Course)
                //    {
                //        Console.WriteLine("\t" + item.Title);
                //    }
                //}

                //QueryCourse(db);

                //InsertDepartment(db);

                //UpdateDepartment(db);

                //RemoveDepartment(db);
            }
        }

        private static void InsertDepartment(ContosoUniversityEntities db)
        {
            var dept = new Department()
            {
                Name = "Will",
                Budget = 100,
                StartDate = DateTime.Now
            };

            db.Department.Add(dept);
            db.SaveChanges();

            InsertedId = dept.DepartmentID;
        }

        private static void UpdateDepartment(ContosoUniversityEntities db)
        {
            var dept = db.Department.Find(InsertedId);
            dept.Name = "John";
            db.SaveChanges();
        }

        private static void RemoveDepartment(ContosoUniversityEntities db)
        {
            db.Department.Remove(db.Department.Find(InsertedId));
            db.SaveChanges();
        }

        private static void QueryCourse(ContosoUniversityEntities db)
        {
            var data = from p in db.Course select p;

            foreach (var item in data)
            {
                Console.WriteLine(item.CourseID);
                Console.WriteLine(item.Title);
                Console.WriteLine();
            }
        }
    }
}
