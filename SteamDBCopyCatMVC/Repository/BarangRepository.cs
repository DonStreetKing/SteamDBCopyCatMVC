using SteamDBCopyCatMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamDBCopyCatMVC.Repository
{
    public class BarangRepository
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    }
}