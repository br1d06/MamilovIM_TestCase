using Teledok.DAL;

namespace Teledok.Models;

public class Founder : BaseEntity
{
	public string FullName { get; private set; }
	public Client Client { get; private set; }
	
	public Founder(string taxpayerNumber, string fullName, Client client) : base (taxpayerNumber)
	{ 
		FullName = fullName;
		Client = client;
	}
	public Founder() { }

	public void FullUpdate(string newTaxpayerNumber, string newFullName, Client newClient)
	{
		UpdateTaxpayerNumber(newTaxpayerNumber);
		FullName = newFullName;
		Client = newClient;
	}

	public void UpdateFullName(string newFullName)=> FullName = newFullName;

	public void UpdateClient(Client newClient)=> Client= newClient;
}
