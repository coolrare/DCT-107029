﻿using ConsoleApp1.Models;
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

                var c = new Course()
                {
                    Title = "Entity Framework 6.2",
                    Credits = CourseCredits.Awesome,
                    DepartmentID = 1
                };

                db.Course.Add(c);
                db.SaveChanges();

                var a = db.Course.Find(c.CourseID);

                Console.WriteLine(a.Credits.ToString());


                //var dept = db.Department.Find(32);
                //dept.Name = "John"+DateTime.Now;
                //Console.ReadLine();
                //db.SaveChanges();

                //var items = db.GetDepartment(1);

                //foreach (var item in items)
                //{
                //    Console.WriteLine(item.Name);
                //}


                //var dept = db.Department.Find(33);
                //db.Entry(dept).State = EntityState.Deleted;


                //db.Entry(new Department() { DepartmentID = 33 }).State = EntityState.Deleted;
                //db.SaveChanges();






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
