using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class BaseRepository
    {
        protected readonly DbContextMysql _dbContext;

        public BaseRepository(DbContextMysql dbContext) {
            _dbContext = dbContext;
        }
    }
}
