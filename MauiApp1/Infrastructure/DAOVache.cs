using MauiApp1.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Infrastructure
{
    internal class DAOVache : IDAOVache
    {
        
        public readonly DAOVache _dbVache;

        public DAOVache(DAOVache dbVache)
        {
            _dbVache = dbVache ;
        }
        public Task<Vache> AddVache(Vache v)
        {
            return _dbVache.AddVache(v);
            
        }

        public Task DeleteVache(int id)
        {
            var vache = _dbVache.GetVache(id);
            if (vache != null)
            {
                return _dbVache.DeleteVache(id);
                
            }  throw new ArgumentException($"Vache with ID {id} not found.") ;
        }

        public Task<Vache> GetAllVaches()
        {
            return _dbVache.GetAllVaches();
        }

        public Task<Vache> GetVache(int id)
        { 
            return _dbVache.GetVache(id) ; 
        }

        public Task<Vache> UpdateVache(Vache vache)
        {
            return _dbVache.UpdateVache(vache);
            
        }
    }
}
