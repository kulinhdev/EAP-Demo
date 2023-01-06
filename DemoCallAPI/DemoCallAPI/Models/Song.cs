using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCallAPI.Models
{
    [Table("Song")]
    public class Song
    {
        [Key]
        public string SongId { get; set; }
        public string Tittle { get; set; }
        public string Author { get; set; }
        public string Singer { get; set; }
        public string Duration { get; set; }
    }
}
