using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eZone.DAL.Repositories
{
   public abstract class BaseRepo
    {
        protected readonly eZoneDbContext _context;
       

        protected BaseRepo(eZoneDbContext context)
        {
            _context = context;
            
        }

        
    }
}
