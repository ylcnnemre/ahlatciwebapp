using ahlatciapp.Data;
using ahlatciapp.Models.ViewModel;

namespace ahlatciapp.Models
{
	public class MainModel
	{
     

        public AboneViewModel Abone { get; set; }

		public AdresViewModel Adres { get; set; }
		public List<String> Ulkeler { get; set; }

		public List<Cities> cities { get; set; }
	}
}
