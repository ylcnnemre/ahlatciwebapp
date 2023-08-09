namespace ahlatciapp.Models
{
	public class AboneAdres
	{
		public int Id { get; set; }

		public string? İl { get; set; }

		public string? İlce { get; set; }

		public string? Mahalle { get; set; }

		public string? CaddeSok { get; set; }

		public string? Bina { get; set; }

		public string? Daire { get; set; }

		public int AboneKsBilgiId { get; set; }
		public AboneKsBilgi abone { get; set; }
	}
}
