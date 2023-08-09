using ahlatciapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System;
using ahlatciapp.Data;
using ahlatciapp.Context;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using ahlatciapp.Models.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata;

using System.Text.Json.Serialization;
using System.Text.Json;

namespace ahlatciapp.Controllers
{
	public class HomeController : Controller
	{
		public DataGet dataget { get; set; }
		public AhlContext context { get; set; }
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
			dataget= new DataGet(webHostEnvironment);
			context = new AhlContext();

        }


        [Route("/")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("hakkimizda")]
		public IActionResult About()
		{
			return View();
		}

		[Route("hizmetler")]
		public IActionResult Hizmetler()
		{
			return View();
		}

		[Route("borcsorgulama")]
		public IActionResult BorcSorgulama()
		{
			return View();
		}

		[Route("giris")]
		public IActionResult Giris()
		{
			return View();
		}

		[Route("adres")]
		public IActionResult Adres()
		{
			return View();
		}


		[Route("KayitForm")]
		public async Task<IActionResult> KayitForm()
		{
			MainModel model = new MainModel();
			model.Ulkeler = dataget.countries();
			model.cities = dataget.cities();
			

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Kayit(MainModel model)
		{
			bool result =dataget.saveImage(model);
			
			var saveUser= await context.AboneBilgi.AddAsync(new AboneKsBilgi
			{
				Ad = model.Abone.Ad,
				SoyAd = model.Abone.SoyAd,
				Cinsiyet = model.Abone.Cinsiyet,
				AnneKizlik = model.Abone.AnneKizlik,
				Sehir = model.Abone.Sehir,
				DoyTarihi = model.Abone.DoyTarihi,
				Meslek = model.Abone.Meslek,
				Uyruk = model.Abone.Uyruk,
				SağlıkDurum = model.Abone.SağlıkDurum,
				TcNo = model.Abone.TcNo,
				Tel = model.Abone.Tel,
				KmlFoto = model.Abone.KmlFoto.FileName
			});

			await context.SaveChangesAsync();

			await context.AboneAdres.AddAsync(new AboneAdres
			{
				Bina = model.Adres.Bina,
				CaddeSok = model.Adres.CaddeSok,
				Daire= model.Adres.Daire,
				Mahalle = model.Adres.Mahalle,
				İl = model.Adres.İl,
				İlce= model.Adres.İlce,
				AboneKsBilgiId = saveUser.Entity.Id
			});

            await context.SaveChangesAsync();

	

            return Ok("asdad");
		}


        [HttpPost]
        public async Task<IActionResult> borcSorgula([FromBody] BorcSorgulaViewModel model)
        {
            var selectedUser = await context.AboneBilgi.Include(item => item.faturalar).FirstOrDefaultAsync(item => item.TcNo == model.TcNo);

            if (selectedUser != null)
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve // Referansları koruyarak döngüleri kır
                };

                string userJson = System.Text.Json.JsonSerializer.Serialize(selectedUser, options);

                return Content(userJson, "application/json");
            }

            return Content(""); // Hata durumu için view'i döndür
        }



		[HttpPost]
		public async Task<IActionResult> login(LoginViewModel model)
		{

			var response = await context.Personel.FirstOrDefaultAsync(item => item.PrAdı == model.UserName);

			if(response!=null)
			{
				if (response.PrSifre == model.Password)
				{
					return RedirectToAction("KayitForm", "Home");
				}

			}


			return Ok("asd");

		}


    }
}