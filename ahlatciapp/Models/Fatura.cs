namespace ahlatciapp.Models
{
	public class Fatura
	{
		public int  Id { get; set; }

		public string? M3 { get; set; }

		public decimal? Fiyat { get; set; }

		public DateTime? FaturaKesimTarih { get; set; }

		public int AboneKsBilgiId { get; set; }
		public  AboneKsBilgi? Abone { get; set; } 
	}
}
