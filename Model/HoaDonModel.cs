using System;
using System.Collections.Generic;

namespace Model
{
    public class HoaDonModel
    {
        public string madonhang { get; set; }
        public string hoten { get; set; }
        public string diachigh { get; set; }
        public string sdtgh { get; set; }
        public List<ChiTietHoaDonModel> listjson_chitiet { get; set; }
    }
}
