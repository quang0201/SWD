using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IDecorService
    {
        List<Decor> GetDecors();
        Decor GetDecorsById(int decorId);
        void CreateDecors(Decor d);

        void UpdateDecors(Decor d);

        void DeleteDecors(int decorId);
    }
}
