using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroDB.Shared
{
    public class Nationality
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
    }
}
