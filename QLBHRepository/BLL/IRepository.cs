using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBHRepository.BLL
{
    public interface IRepository:IDisposable
    {
        IChungLoaiRepository ChungLoai { get; }
        IHangHoaRepository HangHoa { get; }
    }
}
