using System.ComponentModel.DataAnnotations;

namespace Teledok.Models;
public abstract class BaseEntity
{
	[Key]
	public int Id { get; private set; }
	public string TaxpayerNumber { get; private set; }
	public DateTime DateAdded { get; private set; }
	public DateTime DateUpdated { get; private set; }
	public LegalTypeEnum LegalType { get; set; }

	public enum LegalTypeEnum
	{
		LegalEntity,
		IndividualEntrepreneur
	}

	public BaseEntity(string taxpayerNumber) 
	{
		DateTime dateTime = DateTime.UtcNow;

		DateAdded = dateTime;
		DateUpdated = dateTime;
		TaxpayerNumber = taxpayerNumber;

		try
		{
			int.Parse(taxpayerNumber);
		}
		catch
		{
			throw new ArgumentException("ИНН должен состоять из цифр.");
		}
		if (taxpayerNumber.Length == 10)
			LegalType = LegalTypeEnum.LegalEntity;
		else if (taxpayerNumber.Length == 12)
			LegalType = LegalTypeEnum.IndividualEntrepreneur;
		else
			throw new ArgumentException("ИНН состоит из 10 или 12 символов.");

	}

	public BaseEntity() { }

	public void UpdateTaxpayerNumber(string newTaxpayerNumber)
	{
		TaxpayerNumber = newTaxpayerNumber;
	}
}
