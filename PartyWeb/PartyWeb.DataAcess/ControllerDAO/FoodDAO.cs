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
    public class FoodDAO
    {
        public static List<Food> GetFoods()
        {
            var Foods = new List<Food>();
            try
            {
                using (var context = new SwdContext())
                {
                    Foods = context.Foods.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Foods;

        }

        public static Food GetFoodsById(int id)
        {
            var Foods = new Food();
            try
            {
                using (var context = new SwdContext())
                {
                    Foods = context.Foods
                    .SingleOrDefault(c => c.Id == id);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Foods;

        }

        public static void CreateFoods(Food d)
        {
            try
            {
                using (var context = new SwdContext())
                {
                    context.Foods.Add(d);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void UpdateFoods(Food d)
        {
            try
            {
                using (var context = new SwdContext())
                {
                    context.Entry<Food>(d).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void DeleteFoods(int FoodId)
        {
            try
            {
                using (var context = new SwdContext())
                {
                    var cusSkillsToDelete = context.Foods.Where(js => js.Id == FoodId).ToList();
                    context.Foods.RemoveRange(cusSkillsToDelete);
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
