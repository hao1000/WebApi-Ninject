using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using QLBHRepository.DAL;
using QLBHRepository.DTO;

namespace QLBHRepository.BLL
{
    // Create Concreate class
    class ChungLoaiRepository : IChungLoaiRepository
    {
        // Bien thanh vien (Field) , deafult private
      private  QLBanHangDbContext _db;
        // Phuong thuc khoi tao :
        internal ChungLoaiRepository(QLBanHangDbContext db)
        {
            _db = db;
        }
        public async Task<ChungLoaiDTO> Create(ChungLoaiDTO input)
        {
            try
            {
                int d1 = await _db.ChungLoais.CountAsync(p => p.MaSo == input.MaSo);
                if (d1 > 0) throw new Exception();

                var entity = new ChungLoai();
                entity.MaSo = input.MaSo;
                entity.Ten = input.Ten;

                _db.ChungLoais.Add(entity);
                await _db.SaveChangesAsync();

                input.ID = entity.ID;
                return input;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task Update(ChungLoaiDTO input)
        {
           
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ChungLoaiDTO>> GetAll()
        {
            try
            {
                var items = await _db.ChungLoais
                    .Select(p => new ChungLoaiDTO
                    {
                        ID = p.ID,
                        MaSo = p.MaSo,
                        Ten = p.Ten
                    })
                    .ToListAsync();
                return items;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
           
        }

        public async Task<ChungLoaiDTO> GetById(int id)
        {
            try
            {
                var item = await _db.ChungLoais
                    .Where(p=>p.ID ==id)
                    .Select(p => new ChungLoaiDTO
                    {
                        ID = p.ID,
                        MaSo = p.MaSo,
                        Ten = p.Ten
                    })
                    .SingleOrDefaultAsync();
                return item;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
