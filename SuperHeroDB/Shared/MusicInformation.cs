using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroDB.Shared
{
    public class MusicInformation
    {
        public Guid Id { get; set; } = new Guid();
        public List<Singer> Singers { get; set; }
        public List<Nationality> Nationalities { get; set; }
        public List<Gener> Geners { get; set; }
    }
}
