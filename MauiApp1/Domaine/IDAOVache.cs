using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Domaine
{
    public interface IDAOVache
    {
        public Task<Vache> GetVache(int id);
        public Task<Vache> GetAllVaches();
        public Task<Vache> AddVache (Vache v);
        public Task<Vache> UpdateVache(Vache vache);
        public Task DeleteVache(int id);
    }
}
