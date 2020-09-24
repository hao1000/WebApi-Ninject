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
    class HangHoaRepository : IHangHoaRepository
    {
        private QLBanHangDbContext _db;
        // Phuong thuc khoi tao :
        internal HangHoaRepository(QLBanHangDbContext db)
        {
            _db = db;
        }
        public Task<HangHoaInput> Create(HangHoaInput input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HangHoaOutput> Get(int id)
        {
            try
            {
                var item = await _db.HangHoas
                    .Where(p => p.ID == id)
                    .Include(p => p.ChungLoai)
                    .Select(p => new HangHoaOutput
                    {
                        hangHoaEntity = p,
                        chungLoaiEntity = p.ChungLoai
                    })
                    .SingleOrDefaultAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception ($"Loi khong truy cap duoc du lieu. Ly do : {ex.Message}");
            }
        }
        public async Task<HangHoaInput> GetById(int id)
        {
            try
            {
                var item = await _db.HangHoas
                    .Where(p => p.ID == id)
                    .Include(p => p.ChungLoai)
                    .Select(p => new HangHoaInput
                    {
                        ID = p.ID,
                        MaSo = p.MaSo,
                        Ten = p.Ten,
                        GiaBan = p.GiaBan,
                        DonViTinh = p.DonViTinh,
                        MoTa = p.MoTa,
                        ThongSoKyThuat = p.ThongSoKyThuat,
                        ChungLoaiID = p.ChungLoaiID.HasValue?p.ChungLoaiID.Value:0
                    })
                    .SingleOrDefaultAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi khong truy cap duoc du lieu. Ly do : {ex.Message}");
            }
        }

        public async Task<List<HangHoaOutput>> GetAll()
        {
            try
            {
                var items = await _db.HangHoas
                    .OrderByDescending(p => p.ID)
                    .Include(p => p.ChungLoai)
                    .Select(p => new HangHoaOutput

                    {
                        hangHoaEntity = p,
                        chungLoaiEntity = p.ChungLoai
                    })
                    .ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi khong truy cap duoc du lieu. Ly do : {ex.Message}");
            }
        }

        public async Task<PagedOutput<HangHoaOutput>> GetOnePage(PagedInput input)
        {
            try
            {
                int n = (input.PageIndex - 1) * input.PageSize;
                int totalItems = await _db.HangHoas.CountAsync();
                var hangHoaItems = await _db.HangHoas
                    .OrderByDescending(p => p.ID)
                    .Skip(n)
                    .Take(input.PageSize)
                    .Include(p => p.ChungLoai)
                    .Select(p => new HangHoaOutput

                    {
                        hangHoaEntity = p,
                        chungLoaiEntity = p.ChungLoai
                    })
                    .ToListAsync();
                var onePageOfData = new PagedOutput<HangHoaOutput>
                {
                    Items = hangHoaItems,
                    TotalItemCount = totalItems
                };

                return onePageOfData;
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi khong truy cap duoc du lieu. Ly do : {ex.Message}");
            }
        }

        public Task Update(HangHoaInput input)
        {
            throw new NotImplementedException();
        }
    }
}
