using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankManagementSystem.Data;
using BankManagementSystem.Models;

namespace BankManagementSystem.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly AppDbContext _context;

        public NhanVienController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.NhanViens.Include(n => n.MaChiNhanhNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.MaChiNhanhNavigation)
                .Include(n => n.GiaoDiches.OrderByDescending(x => x.ThoiGianGiaoDich))
                .Include(n => n.TaiKhoans.OrderByDescending(x => x.NgayMo))
                .Include(n => n.BangLuongMaNhanVienNavigations.OrderByDescending(x=>x.NgayTinh))
                .ThenInclude(b => b.MaKyLuongNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            ViewData["MaChiNhanh"] = new SelectList(_context.ChiNhanhs, "MaChiNhanh", "MaChiNhanh");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,HoTen,DienThoai,Email,ChucVu,MaChiNhanh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChiNhanh"] = new SelectList(_context.ChiNhanhs, "MaChiNhanh", "MaChiNhanh", nhanVien.MaChiNhanh);
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["MaChiNhanh"] = new SelectList(_context.ChiNhanhs, "MaChiNhanh", "TenChiNhanh", nhanVien.MaChiNhanh);
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhanVien,HoTen,DienThoai,Email,ChucVu,MaChiNhanh")] NhanVien nhanVien)
        {
            if (id != nhanVien.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.MaNhanVien))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChiNhanh"] = new SelectList(_context.ChiNhanhs, "MaChiNhanh", "MaChiNhanh", nhanVien.MaChiNhanh);
            return View(nhanVien);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.MaChiNhanhNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var nhanVien = await _context.NhanViens
                    .Include(x => x.GiaoDiches)
                    .Include(x => x.BangLuongMaNhanVienNavigations)
                    .Include(x => x.TaiKhoans)
                    .FirstOrDefaultAsync(x => x.MaNhanVien == id);

                if (nhanVien == null)
                {
                    TempData["Error"] = "Không tìm thấy nhân viên!";
                    return RedirectToAction(nameof(Index));
                }

                _context.NhanViens.Remove(nhanVien);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Xóa nhân viên thành công!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Không thể xóa nhân viên vì đang có dữ liệu liên quan!";
                // Nếu muốn ghi log
                // _logger.LogError(ex, "Lỗi xóa nhân viên");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(string id)
        {
            return _context.NhanViens.Any(e => e.MaNhanVien == id);
        }

        [HttpPost]
        public async Task<IActionResult> LoadData()
        {
            // DataTables parameters
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            // Paging values
            int pageSize = length != null ? Convert.ToInt32(length) : 10;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            // Base query
            var query = _context.NhanViens
                .Include(x => x.MaChiNhanhNavigation)
                .AsQueryable();

            // Search
            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(x =>
                    x.MaNhanVien.Contains(searchValue) ||
                    x.HoTen.Contains(searchValue) ||
                    x.Email.Contains(searchValue) ||
                    x.DienThoai.Contains(searchValue) ||
                    x.ChucVu.Contains(searchValue) ||
                    x.MaChiNhanhNavigation.TenChiNhanh.Contains(searchValue)
                );
            }

            // Sorting
            var sortColumnIndex = Request.Form["order[0][column]"].FirstOrDefault();
            var sortColumn = Request.Form[$"columns[{sortColumnIndex}][name]"].FirstOrDefault();
            var sortDir = Request.Form["order[0][dir]"].FirstOrDefault(); // asc / desc

            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = sortDir == "asc"
                    ? query.OrderBy(x => EF.Property<object>(x, sortColumn))
                    : query.OrderByDescending(x => EF.Property<object>(x, sortColumn));
            }
            else
            {
                query = query.OrderBy(x => x.MaNhanVien); // default sort
            }

            int recordsTotal = await query.CountAsync();
            var data = await query.Skip(skip).Take(pageSize).ToListAsync();

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data.Select(x => new
                {
                    x.MaNhanVien,
                    x.HoTen,
                    x.DienThoai,
                    x.Email,
                    x.ChucVu,
                    ChiNhanh = x.MaChiNhanhNavigation != null ? x.MaChiNhanhNavigation.TenChiNhanh : ""
                })
            });
        }
    }
}
