using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    public class MusicService : IMusicService
    {
        private readonly HttpClient _httpClient;

        public MusicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Music> Musics { get; set; } = new List<Music>();
        public List<Nationality> Nationalities { get; set; } = new List<Nationality>();
        public List<Gener> Geners { get; set; } = new List<Gener>();
        public List<Singer> Singers { get; set; } = new List<Singer>();

        public event Action OnChange;

        public async Task<List<Music>> CreateMusic(Music hero)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Music", hero);
            Musics = await result.Content.ReadFromJsonAsync<List<Music>>();
            OnChange.Invoke();
            return Musics;
        }

        public async Task<List<Music>> DeleteMusic(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/Music/{id}");
            Musics = await result.Content.ReadFromJsonAsync<List<Music>>();
            OnChange.Invoke();
            return Musics;
        }

        public async Task<Music> GetMusic(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Music>($"api/Music/{id}");
        }

        public async Task<List<Music>> GetMusics()
        {
            Musics = await _httpClient.GetFromJsonAsync<List<Music>>("api/Music");
            return Musics;
        }

        public async Task<List<Music>> UpdateMusic(Music hero, Guid id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Music/{id}", hero);
            Musics = await result.Content.ReadFromJsonAsync<List<Music>>();
            OnChange.Invoke();
            return Musics;
        }


        public async Task<List<Nationality>> GetNationalities()
        {
            Nationalities = await _httpClient.GetFromJsonAsync<List<Nationality>>("api/Music/Nationalities");
            return Nationalities;
        }

        public async Task<List<Gener>> GetGeners()
        {
            Geners = await _httpClient.GetFromJsonAsync<List<Gener>>("api/Music/Geners");
            return Geners;
        }

        public async Task<List<Singer>> GetSingers()
        {
            Singers = await _httpClient.GetFromJsonAsync<List<Singer>>("api/Music/Singers");
            return Singers;
        }

        public async Task<List<Gener>> CreateGener(Gener music)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Music/Geners", music);
            Geners = await result.Content.ReadFromJsonAsync<List<Gener>>();
            OnChange.Invoke();
            return Geners;
        }

        public async Task<List<Gener>> UpdateGener(Gener gener, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Music/Geners/{id}", gener);
            Geners = await result.Content.ReadFromJsonAsync<List<Gener>>();
            OnChange.Invoke();
            return Geners;
        }

        public async Task<List<Gener>> DeleteGener(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Music/Geners/{id}");
            Geners = await result.Content.ReadFromJsonAsync<List<Gener>>();
            OnChange.Invoke();
            return Geners;
        }

        public async Task<List<Singer>> CreateSinger(Singer singer)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Music/Singers", singer);
            Singers = await result.Content.ReadFromJsonAsync<List<Singer>>();
            OnChange.Invoke();
            return Singers;
        }

        public async Task<List<Singer>> UpdateSinger(Singer singer, Guid id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Music/Singers/{id}", singer);
            Singers = await result.Content.ReadFromJsonAsync<List<Singer>>();
            OnChange.Invoke();
            return Singers;
        }

        public async Task<List<Singer>> DeleteSinger(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/Music/Singers/{id}");
            Singers = await result.Content.ReadFromJsonAsync<List<Singer>>();
            OnChange.Invoke();
            return Singers;
        }

        public async Task<List<Nationality>> CreateNationality(Nationality nationality)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Music/nationalities", nationality);
            Nationalities = await result.Content.ReadFromJsonAsync<List<Nationality>>();
            OnChange.Invoke();
            return Nationalities;
        }

        public async Task<List<Nationality>> UpdateNationality(Nationality nationality, Guid id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Music/Nationalities/{id}", nationality);
            Nationalities = await result.Content.ReadFromJsonAsync<List<Nationality>>();
            OnChange.Invoke();
            return Nationalities;
        }

        public async Task<List<Nationality>> DeleteNationality(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/Music/Nationalities/{id}");
            Nationalities = await result.Content.ReadFromJsonAsync<List<Nationality>>();
            OnChange.Invoke();
            return Nationalities;
        }
    }
}
