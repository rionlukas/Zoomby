using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Zoomby.Data;
using Zoomby.Models;
using Zoomby.Models.Transaction;
using Dapper;


namespace Zoomby.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly SqlConnection _conn;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context,
            IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
            _conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetById(int id)
        {
            var data = _context.ZoomScheduler
                .Where(x => x.Id == id).FirstOrDefault();
            return Ok(data);
        }
        public IActionResult GetAll()
        {
            var data = _context.ZoomScheduler
                .Include(y=>y.ZoomAccount)
                .Include(x=>x.Pic)
                .Where(x=>x.IsDelete == false)
                .ToList();
            var listZoomSch = _conn.Query<ZoomScheduler>("SELECT * FROM T_ZoomScheduler where IsDelete = 'false'").ToList();
            return Ok(new { data = data });
        }

        public IActionResult DateRange(DateTime StartDate, DateTime EndDate)
        {
            var data = _context.ZoomScheduler
                .Include(x => x.Pic)
                .Include(y => y.ZoomAccount)
                .Where(x => x.IsDelete == false && (x.StartDate.Date >= StartDate.Date
                && x.EndDate.Date <= EndDate.Date))
                .ToList();
            return Ok(new {data = data});
        }
        public IActionResult GetPic()
        {
            return Ok(_context.Pic.ToList());
        }

        public IActionResult Save(ZoomScheduler data)
        {
            if (data.Id == 0)
            {
                //var result = _context.ZoomScheduler.Where(
                //    x => x.ZoomAccountId == data.ZoomAccountId && (x.StartDate <= data.StartDate && x.EndDate >= data.EndDate)).Count();
                //if(result > 0)
                //{
                //    return StatusCode(400);
                //}
                //else
                //{
                //    _context.ZoomScheduler.Add(data);
                //    _context.SaveChanges();
                //    return Ok(data);
                //}
                _context.ZoomScheduler.Add(data);
                _context.SaveChanges();
                return Ok(data);
            }
            else
            {
                var result = _context.ZoomScheduler.Where(x => x.Id == data.Id).FirstOrDefault();
                result.PicId = data.PicId;
                result.ZoomAccountId = data.ZoomAccountId;
                result.StartDate = data.StartDate;
                result.EndDate = data.EndDate;
                result.Agenda = data.Agenda;
                result.LinkAddress= data.LinkAddress;
                _context.Entry(result).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(data);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = _context.ZoomScheduler
                .Where(x => x.Id == id).FirstOrDefault();
            try
            {
                if (data != null)
                {
                    data.IsDelete = true;
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult GetZoom()
        {
            return Ok(_context.ZoomAccounts.ToList());
        }
    }
}