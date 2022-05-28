using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteamDBCopyCatMVC.EDMX;
namespace SteamDBCopyCatMVC.Models
{
    public class MultiModel
    {
        public Barang Barang { get; set; }
        public Toko Toko { get; set; }

        public TabelDaftarBarang TabelDaftarBarangs { get; set; }
        public TabelToko TabelTokos { get; set; }
        public TabelHarga TabelHargas { get; set; }

        public IEnumerable<TabelDaftarBarang> TabelDaftarBarang { get; set; }
        public IEnumerable<TabelToko> TabelToko { get; set; }
        public IEnumerable<TabelHarga> TabelHarga { get; set; }
    }
}