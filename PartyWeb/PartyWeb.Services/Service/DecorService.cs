using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class DecorService : IDecorService
    {
        public void CreateDecors(Decor d)
        => DecorDAO.CreateDecors(d);

        public void DeleteDecors(int decorId)
        => DecorDAO.DeleteDecors(decorId);

        public List<Decor> GetDecors()
        => DecorDAO.GetDecors();

        public Decor GetDecorsById(int decorId)
        => DecorDAO.GetDecorsById(decorId);

        public void UpdateDecors(Decor d)
        => DecorDAO.UpdateDecors(d);
    }
}
