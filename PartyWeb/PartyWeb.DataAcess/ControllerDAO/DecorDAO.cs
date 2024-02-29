using BusinessObjects.Models;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.ControllerDAO
{
    public class DecorDAO
    {
        public static List<Decor> GetDecors()
        {
            var decors = new List<Decor>();
            try
            {
                using (var context = new SwdContext())
                {
                    decors = context.Decors.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return decors;

        }

        public static Decor GetDecorsById(int id)
        {
            var decors = new Decor();
            try
            {
                using (var context = new SwdContext())
                {
                    decors = context.Decors
                    .SingleOrDefault(c => c.Id == id);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return decors;

        }

        public static void CreateDecors(Decor d)
        {
            try
            {
                using (var context = new SwdContext())
                {
                    context.Decors.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void UpdateDecors(Decor d)
        {
            try
            {
                using (var context = new SwdContext())
                {
                    context.Entry<Decor>(d).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void DeleteDecors(int decorId)
        {
            try
            {
                using (var context = new SwdContext())
                {
                    var DecorToDelete = context.Decors
                    .SingleOrDefault(c => c.Id == decorId);
                    DecorToDelete.Status = "0";
                    context.Entry<Decor>(DecorToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
