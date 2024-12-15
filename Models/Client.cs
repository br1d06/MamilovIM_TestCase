namespace Teledok.Models;
public class Client : BaseEntity
{
	public string Name { get; private set; }
	public ICollection<Founder> Founders { get; private set; }

	public Client(string taxpayerNumber, string name, ICollection<Founder> founders) : base(taxpayerNumber)
	{
		Name = name;
		Founders = founders;
	}

	public Client() { }

	public void FullUpdate(string taxpayerNumber, string name, ICollection<Founder> founders)
	{
		Name = name;
		Founders = founders;
		UpdateTaxpayerNumber(taxpayerNumber);
	}

	public void NameUpdate(string newName)=> Name = newName;
}

