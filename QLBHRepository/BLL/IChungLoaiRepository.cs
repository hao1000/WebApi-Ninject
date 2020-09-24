using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//----------------------
using QLBHRepository.DTO;

namespace QLBHRepository.BLL
{
    // Add Public 
    public interface IChungLoaiRepository
    {
        Task<List<ChungLoaiDTO>> GetAll();
        Task<ChungLoaiDTO> GetById(int id);
        Task<ChungLoaiDTO> Create(ChungLoaiDTO input);
        Task Update(ChungLoaiDTO input);
        Task Delete(int id);
    }
}
