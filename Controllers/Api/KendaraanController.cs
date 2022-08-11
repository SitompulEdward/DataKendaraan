using DataKendaraan.Models;
using DataKendaraan.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataKendaraan.Api.Controllers
{
    [Route("api/[controller]")]
    public class KendaraanController : Controller
    {
        private readonly KendaraanRepository _repo;
        public KendaraanController(KendaraanRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("GetKendaraan")]
        public IActionResult GetKendaraan()
        {
            var data = _repo.GetKendaraan().ToList();

            return Ok(data);
        }

        [HttpPost]
        [Route("PostKendaraan")]
        public async Task<IActionResult> PostKendaraan(Kendaraan kendaraan)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateKendaraan(kendaraan);

                return Ok(kendaraan);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("DetailKendaraan/{noReg}")]
        public IActionResult DetailKendaraan(string noReg)
        {
            var val = _repo.GetKendaraanDetail(noReg);
            if (val != null)
            {
                return Ok(val);
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("DeleteKendaraan/{noReg}")]
        public async Task<IActionResult> DeleteKendaraan(string noReg)
        {
            var getData = _repo.GetKendaraanDetail(noReg);

            if (getData != null)
            {
                await _repo.DeleteKendaraan(getData);
                return Ok(getData);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("PutKendaraan/{noReg}")]
        public async Task<IActionResult> EditKendaraan(string noReg, Kendaraan kendaraan)
        {
            if (ModelState.IsValid)
            {
                var getData = _repo.GetKendaraanDetail(kendaraan.NoRegistrasi);

                if (getData != null)
                {
                    await _repo.EditKendaraan(kendaraan);

                    return Ok(kendaraan);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [Route("SearchKendaraan")]
        public IActionResult SearchKendaraan(Kendaraan kendaraan)
        {
            var getData = _repo.Filter(kendaraan);

            if (getData != null)
            {
                return Ok(getData);
            }

            return NotFound();
        }
    }
}
