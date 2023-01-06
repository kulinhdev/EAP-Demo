using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCallAPI.Models
{
    public class Song
    {
        [DisplayName("Mã bài hát")]
        public string SongId { get; set; }
        [DisplayName("Tiêu đề")]
        public string Tittle { get; set; }
        [DisplayName("Tác giả")]
        public string Author { get; set; }
        [DisplayName("Ca sĩ")]
        public string Singer { get; set; }
        [DisplayName("Thời lượng")]
        public string Duration { get; set; }
    }
}
