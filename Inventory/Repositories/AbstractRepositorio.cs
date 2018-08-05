using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Repositories
{
    public abstract class AbstractRepositorio<T>
    {

        public abstract SqlConnection connectar();




        public void guardar(T entity)
        {
            
        }
    }
}
