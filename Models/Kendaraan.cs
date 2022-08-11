using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataKendaraan.Models
{
    public class Kendaraan
    {
        [Key]
        public  string NoRegistrasi { get; set; }

        [Required(ErrorMessage = "Silahkan Masukkan Nama!")]
        public string NamaPemilik { get; set; }

        [Required(ErrorMessage = "Silahkan Masukkan Alamat!")]
        public string Alamat { get; set; }

        [Required(ErrorMessage = "Silahkan Masukkan Merk!")]
        public string Merk { get; set; }

        [Required(ErrorMessage = "Silahkan Masukkan Tahun Pembuatan")]
        public int TahunPembuatan { get; set; }

        [Required(ErrorMessage = "Silahkan Masukkan Kapasitas!")]
        public int Kapasitas { get; set; }

        [Required(ErrorMessage = "Silahkan Masukkan Warna Kendaraan!")]
        public string Warna { get; set; }

        [Required(ErrorMessage = "Silahkan Pilih Bahan Bakar!")]
        public string BahanBakar { get; set; }

    }
}
