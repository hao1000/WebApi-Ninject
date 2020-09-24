using System;
using System.Collections.Generic;
using System.Linq;

// Add reference -> Framework
using System.Web;

using System.ComponentModel.DataAnnotations;
using QLBHRepository.DAL;

namespace QLBHRepository.DTO
{
    public class HangHoa1Output
    {
        public int ID { get; set; }
        public string MaSo { get; set; }
        public string Ten { get; set; }
        public string DonViTinh { get; set; }
        public string MoTa { get; set; }
        public string ThongSoKyThuat { get; set; }          
        public int GiaBan { get; set; }
        public Nullable<int> ChungLoaiID { get; set; }
        public System.DateTime NgayTao { get; set; }
        public System.DateTime NgayCapNhat { get; set; }

        public string StrNgayTao => NgayTao.ToString("dd-MM-yyyy");
        public string StrNgayCapNhat => NgayCapNhat.ToString("dd-MM-yyyy");

        public ChungLoaiDTO ChungLoai { get; set; }

        public string TenHinh { private get; set; }
        public List<string> HinhURLs
        {
            get
            {
                string Authority = HttpContext.Current.Request.Url.Authority;
                string ApplicationPath = HttpContext.Current.Request.ApplicationPath;
                if (ApplicationPath.Length > 1) ApplicationPath += "/";
                List<string> urls = new List<string>();
                if (!string.IsNullOrEmpty(TenHinh))
                {
                    var arrTenHinh = TenHinh.Split(',');
                    foreach (var tenHinh in arrTenHinh)
                    {
                        urls.Add($"https://{Authority}{ApplicationPath}Photos/{tenHinh}");
                    }
                }
                else
                    urls.Add($"https://{Authority}{ApplicationPath}Photos/noImage.jpg");
                return urls;
            }
            /*
                Ví dụ:
                    Khi start trực tiếp trên IIS Express
                      + Authority:-->> "localhost:1553"
                      + ApplicationPath:-->> "/"
                    Khi host trên IIS (Web server) 
                      + Authority:-->> "localhost"
                      + ApplicationPath:-->> "/QLBHWebAPI2"
                */
        }
    }
    public class HangHoaOutput
    {
        internal HangHoaOutput() //contructer
        {
            hangHoaEntity = new HangHoa();
            chungLoaiEntity = new ChungLoai();
        }
        // Thuộc tính chỉ ghi - Write Only property
        internal HangHoa hangHoaEntity { private get; set; }
        internal ChungLoai chungLoaiEntity { private get; set; }

        // Thuộc tính chỉ đọc - Read Only property (C#6 (4.6) Expression-bodied members )
        public int ID => hangHoaEntity.ID;
        public string MaSo => hangHoaEntity.MaSo;
        //C#5
        //public string MaSo
        //{
        //    get { return hangHoaEntity.MaSo; }
        //}

        public string Ten => hangHoaEntity.Ten;
        public string DonViTinh => hangHoaEntity.DonViTinh;
        public string MoTa => hangHoaEntity.MoTa;

        public string ThongSoKyThuat => hangHoaEntity.ThongSoKyThuat;
        public int GiaBan => hangHoaEntity.GiaBan;
        public int ChungLoaiID => hangHoaEntity.ChungLoaiID.Value;
        public string NgayTao => hangHoaEntity.NgayTao.ToString("yyyy-MM-dd");
        public string NgayCapNhat => hangHoaEntity.NgayCapNhat.ToString("yyyy-MM-dd");
        public ChungLoaiDTO ChungLoai => new ChungLoaiDTO
        {
            ID = chungLoaiEntity.ID,
            MaSo = chungLoaiEntity.MaSo,
            Ten = chungLoaiEntity.Ten
        };
        public List<string> HinhURLs
        {
            get
            {
                string Authority = HttpContext.Current.Request.Url.Authority;
                string ApplicationPath = HttpContext.Current.Request.ApplicationPath;
                if (ApplicationPath.Length > 1) ApplicationPath += "/";
                List<string> urls = new List<string>();
                if (!string.IsNullOrEmpty(hangHoaEntity.TenHinh))
                {
                    var arrTenHinh = hangHoaEntity.TenHinh.Split(',');
                    foreach (var tenHinh in arrTenHinh)
                    {
                        urls.Add($"https://{Authority}{ApplicationPath}Photos/{tenHinh}");
                    }
                }
                else
                    urls.Add($"https://{Authority}{ApplicationPath}Photos/noImage.jpg");
                return urls;
            }
            /*
                Ví dụ:
                    Khi start trực tiếp trên IIS Express
                      + Authority:-->> "localhost:1553"
                      + ApplicationPath:-->> "/"
                    Khi host trên IIS (Web server) 
                      + Authority:-->> "localhost"
                      + ApplicationPath:-->> "/QLBHWebAPI2"
                */
        }
    }

    public class HangHoaInput
    {
        public int ID { get; set; }

        [Display(Name = "Mã số")]
        [Required(ErrorMessage = "{0} không được để trống.")]
        [MaxLength(10, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        public string MaSo { get; set; }

        [Display(Name = "Tên hàng")]
        [Required(ErrorMessage = "{0} không được để trống.")]
        [MaxLength(100, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        public string Ten { get; set; }

        [Display(Name = "Đơn vị tính")]
        [MaxLength(20, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        public string DonViTinh { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Thông số kỹ thuật")]
        public string ThongSoKyThuat { get; set; }

        [Display(Name = "Giá bán")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} phải từ {1} đến {2}")]
        [RegularExpression(@"\d*", ErrorMessage = "{0} phải là số nguyên")]
        public int GiaBan { get; set; }

        [Display(Name = "Chủng loại")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} phải >=1")]
        [RegularExpression(@"\d*", ErrorMessage = "{0} phải là số nguyên")]
        public int ChungLoaiID { get; set; }

        //[Display(Name = "Ngày tạo")]
        //[Required(ErrorMessage = "{0} không được để trống.")]
        //public DateTime NgayTao { get; set; }

        //[Display(Name = "Ngày cập nhật")]
        //[Required(ErrorMessage = "{0} không được để trống.")]
        //public DateTime NgayCapNhat { get; set; }


    }
}