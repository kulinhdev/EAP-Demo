using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClientDemoCallApi.Models;
using DemoCallAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ClientDemoCallApi.Controllers
{
    public class SongsController : Controller
    {
        string host_api = "http://localhost:61303/";
        HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.GetStringAsync("api/Songs");
            List<SongModel> songs = JsonConvert.DeserializeObject<List<SongModel>>(result);
            return View(songs);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Song song)
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.PostAsJsonAsync<Song>("api/Songs", song);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string songId)
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.DeleteAsync("api/Songs/" + songId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string songId)
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.GetStringAsync("api/Songs/" + songId);
            SongModel sm = JsonConvert.DeserializeObject<List<SongModel>>(result)[0];
            return View(sm);
        }


        public async Task<IActionResult> Edit(string songId)
        {
            client.BaseAddress = new Uri(host_api);

            var data_emp = await client.GetStringAsync("api/Songs/" + songId);
            SongModel songModel = JsonConvert.DeserializeObject<List<SongModel>>(data_emp)[0];
            Song s = new Song {
                                        SongId = songModel.SongId,
                                        Tittle = songModel.Tittle,
                                        Author = songModel.Author,
                                        Duration = songModel.Duration,
                                        Singer = songModel.Singer
                                    };
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Song song)
        {
            client.BaseAddress = new Uri(host_api);
            var result = await client.PutAsJsonAsync<Song>("api/Songs/" + song.SongId, song);

            return RedirectToAction("Index");
        }
    }
}