using DataKendaraan.Context;
using DataKendaraan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataKendaraan.Repositories
{
    public class KendaraanRepository
    {
        private readonly AppDbContext _context;

        public KendaraanRepository(AppDbContext Context)
        {
            _context = Context;
        }

        public List<Kendaraan> GetKendaraan()
        {
            return _context.Kendaraan.ToList();
        }

        public async Task<bool> CreateKendaraan(Kendaraan kendaraan)
        {
            _context.Kendaraan.Add(kendaraan);
            await _context.SaveChangesAsync();

            return true;
        }

        public Kendaraan GetKendaraanDetail(string noReg)
        {
            return _context.Kendaraan.SingleOrDefault(x => x.NoRegistrasi == noReg);
        }

        public async Task<bool> DeleteKendaraan(Kendaraan kendaraan)
        {
            _context.Kendaraan.Remove(kendaraan);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditKendaraan(Kendaraan kendaraan)
        {
            var getData = _context.Kendaraan.SingleOrDefault(x => x.NoRegistrasi == kendaraan.NoRegistrasi);

            getData.NamaPemilik = kendaraan.NamaPemilik;
            getData.Kapasitas = kendaraan.Kapasitas;
            getData.Alamat = kendaraan.Alamat;
            getData.TahunPembuatan = kendaraan.TahunPembuatan;
            getData.Merk = kendaraan.Merk;
            getData.Warna = kendaraan.Warna;
            getData.BahanBakar = kendaraan.BahanBakar;

            _context.Update(getData);
            await _context.SaveChangesAsync();

            return true;
        }

        public List<Kendaraan> Filter(Kendaraan kendaraan)
        {
            if (kendaraan.NoRegistrasi != null && kendaraan.NamaPemilik != null)
            {
                return _context.Kendaraan.Where(x => x.NoRegistrasi.Contains(kendaraan.NoRegistrasi) && x.NamaPemilik.Contains(kendaraan.NamaPemilik)).ToList();
            }
            else if (kendaraan.NoRegistrasi != null)
            {
                return _context.Kendaraan.Where(x => x.NoRegistrasi.Contains(kendaraan.NoRegistrasi)).ToList();
            }

            return _context.Kendaraan.Where(x => x.NamaPemilik.Contains(kendaraan.NamaPemilik)).ToList();
        }
    }
}
