namespace ahlatciapp.Models
{
	public class AboneKsBilgi
	{
        public AboneKsBilgi()
        {
			faturalar = new List<Fatura>();
        }
        public int	Id { get; set; }

		public string? Ad { get; set; }

		public string? SoyAd { get; set; }

		public string? TcNo { get; set; }

		public string? Tel { get; set; }

		public string? Cinsiyet { get; set; }

		public string? Meslek { get; set; }

		public string? Uyruk { get; set; }

		public string? Sehir { get; set; }

		public string? DoyTarihi { get; set; }

		public string? KmlFoto { get; set; }

		public string? AnneKizlik { get; set; }

		public string? SağlıkDurum { get; set; }

		public AboneAdres adresler { get; set; } 

		public List<Fatura> faturalar { get; set; } 
		
	}
}
