using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    public interface IMusicService
    {
        event Action OnChange;

        List<Music> Musics { get; set; }
        List<Nationality> Nationalities { get; set; }
        List<Gener> Geners { get; set; }
        List<Singer> Singers { get; set; }

        Task<Music> GetMusic(Guid id);

        //music
        Task<List<Music>> GetMusics();
        Task<List<Music>> CreateMusic(Music hero);
        Task<List<Music>> UpdateMusic(Music hero, Guid id);
        Task<List<Music>> DeleteMusic(Guid id);

        //geners
        Task<List<Gener>> GetGeners();
        Task<List<Gener>> CreateGener(Gener music);
        Task<List<Gener>> UpdateGener(Gener music, int id);
        Task<List<Gener>> DeleteGener(int id);


        //singers
        Task<List<Singer>> GetSingers();
        Task<List<Singer>> CreateSinger(Singer singer);
        Task<List<Singer>> UpdateSinger(Singer singer, Guid id);
        Task<List<Singer>> DeleteSinger(Guid id);


        //nationalities
        Task<List<Nationality>> GetNationalities();
        Task<List<Nationality>> CreateNationality(Nationality nationality);
        Task<List<Nationality>> UpdateNationality(Nationality nationality, Guid id);
        Task<List<Nationality>> DeleteNationality(Guid id);
    }

}
