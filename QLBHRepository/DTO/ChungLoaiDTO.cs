using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace QLBHRepository.DTO
{
    //Data Transfer Object (Complex type)
    public class ChungLoaiDTO
    {
        public int ID { get; set; }

        [Display(Name = "Mã số")]
        [Required(ErrorMessage ="{0} không được để trống.")]
        [MaxLength(10, ErrorMessage ="{0} tối đa là {1} ký tự.")]
        public string MaSo { get; set; }

        [Display(Name = "tên chủng loại")]
        [Required(ErrorMessage = "{0} không được để trống.")]
        [MaxLength(100, ErrorMessage = "{0} tối đa là {1} ký tự.")]
        public string Ten { get; set; }
    }
}