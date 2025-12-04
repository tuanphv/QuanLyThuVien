using System;
using System.Collections.Generic;

namespace QuanLyThuVien.DTO
{
    public class LoSach
    {
        public int ID { get; set; }
        public int IDTuaSach { get; set; }
        public string NXB { get; set; }
        public int NamXB { get; set; }
        public decimal DonGia { get; set; }
    }

    public class CuonSach
    {
        public int ID { get; set; }
        public int IDLoSach { get; set; }
        public string TinhTrang { get; set; } // "SanSang", "DangMuon", "Hong"
    }
}