using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime DateCreate { get; set; }

        public EntityBase()
        {
            DateCreate = DateTime.Now;
        }
    }
}