using System.ComponentModel.DataAnnotations;

namespace Teledok.Models;
public class BaseEntity
{
	[Key]
	public string TaxPayerId { 
		get 
		{
			return TaxPayerId;
		}
		set 
		{
			if (TaxPayerId.Length != 10)
				throw new ArgumentException("ИНН для Юр. лиц и ИП состоит из 10 символов");
			else
				try
				{
					Int32.Parse(TaxPayerId);
				}
				catch (FormatException)
				{
					throw new ArgumentException("ИНН должен состоять из цифр"); 
				}

		} 
	} 
	public DateTime DateAdded { get; set; }
	public DateTime DateUpdated { get; set; }
}
