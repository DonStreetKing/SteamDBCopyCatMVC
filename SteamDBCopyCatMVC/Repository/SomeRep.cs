using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SteamDBCopyCatMVC.EDMX;

namespace SteamDBCopyCatMVC.Repository
{
    public class SomeRep : IDisposable
    {
        private SteamDBCopyCatEntities steamDBCopyCatEntities = new SteamDBCopyCatEntities();

        public IRep1<Tbl_EntityType> GetRepositoryInstance<Tbl_EntityType>() where Tbl_EntityType : class
        {
            return new GRep<Tbl_EntityType>(steamDBCopyCatEntities);
        }

        public void SaveChange()
        {
            steamDBCopyCatEntities.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    steamDBCopyCatEntities.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
    }
}