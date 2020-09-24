using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QLBHRepository.DTO;

namespace QLBHRepository.BLL
{
   public interface IHangHoaRepository
    {
        Task<List<HangHoaOutput>> GetAll();
        Task<HangHoaOutput> Get(int id);
        Task<HangHoaInput> GetById(int id);
        Task<PagedOutput<HangHoaOutput>> GetOnePage(PagedInput input);
        Task<HangHoaInput> Create(HangHoaInput input);
        Task Update(HangHoaInput input);
        Task Delete(int id);
    }
}
