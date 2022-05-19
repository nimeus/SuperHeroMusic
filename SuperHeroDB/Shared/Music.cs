using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroDB.Shared
{
    public class Music
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string PictureAddress { get; set; }
        public string MusicAddress { get; set; }
        public MusicInformation MusicInformation { get; set;} 

    }
}
