using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamDBCopyCatMVC.Models
{
    public class Barang
    {
        public int ID { get; set; }
        public string Images { get; set; }
        public string Nama_Barang { get; set; }
        public string Tipe_Barang { get; set; }
        public string Ukuran { get; set; }
        public int Harga { get; set; }
        public string Tanggal_Muncul { get; set; }
    }
}