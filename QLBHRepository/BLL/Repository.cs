using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBHRepository.DAL;

namespace QLBHRepository.BLL
{
  public  class Repository : IRepository
    {
        QLBanHangDbContext _db;
        public Repository()
        {
            _db = new QLBanHangDbContext();
        }
        public IChungLoaiRepository ChungLoai => new ChungLoaiRepository(_db);

        public IHangHoaRepository HangHoa =>  new HangHoaRepository(_db);

        #region Giai phong bien
        private bool disposed =false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
