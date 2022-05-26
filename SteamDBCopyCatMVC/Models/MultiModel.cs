using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteamDBCopyCatMVC.EDMX;
namespace SteamDBCopyCatMVC.Models
{
    public class MultiModel
    {
        public IEnumerable<TabelBarang> TabelBarangs { get; set; }
        public IEnumerable<Akun> Akuns { get; set; }
    }
}