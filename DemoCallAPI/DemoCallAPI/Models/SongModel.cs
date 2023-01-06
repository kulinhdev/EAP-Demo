using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCallAPI.Models
{
    public class SongModel
    {
        public string SongId { get; set; }
        public string Tittle { get; set; }
        public string Author { get; set; }
        public string Singer { get; set; }
        public string Duration { get; set; }
    }
}
