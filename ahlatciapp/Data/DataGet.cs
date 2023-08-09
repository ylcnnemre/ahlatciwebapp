using ahlatciapp.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace ahlatciapp.Data
{
    public class DataGet
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DataGet(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<String> countries()
        {
            string dataFolderPath = "Data"; // Data klasörünün yolu, gerektiğinde düzeltin
            string jsonFileName = "Country.json"; // JSON dosya adı

            string jsonFilePath = Path.Combine(dataFolderPath, jsonFileName);

            if (System.IO.File.Exists(jsonFilePath))
            {
                // Dosyadaki JSON veriyi oku ve işlemleri gerçekleştir
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                Country[] countries = JsonConvert.DeserializeObject<Country[]>(jsonData);

               return  countries.Select(item => item.Name).ToList();

            }
            else
            {
                return null;
            }
        }

        public List<Cities> cities()
        {
            string dataFolderPath = "Data"; // Data klasörünün yolu, gerektiğinde düzeltin
            string jsonFileName = "Cities.json"; // JSON dosya adı

            string jsonFilePath = Path.Combine(dataFolderPath, jsonFileName);

            if (System.IO.File.Exists(jsonFilePath))
            {
                // Dosyadaki JSON veriyi oku ve işlemleri gerçekleştir
                string jsonData = System.IO.File.ReadAllText(jsonFilePath);
                List<Cities> city = JsonConvert.DeserializeObject<List<Cities>>(jsonData);
    
                
                return city;

            }
            else
            {
                return null;
            }

        }


        public bool saveImage(MainModel model)
        {
            if (model != null && model.Abone.KmlFoto != null && model.Abone.KmlFoto.Length > 0)
            {
                string webRootPath = _webHostEnvironment.WebRootPath; // wwwroot'un fiziksel yolu
                string fileName = Path.GetFileName(model.Abone.KmlFoto.FileName); // Dosyanın adı

                string filePath = Path.Combine(webRootPath, "uploads", fileName); // uploads altına kaydet

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Abone.KmlFoto.CopyTo(stream);
                }

                return true;
            }

            return false;
        }


    }
}
