namespace Teledok.Models;
public class Client : BaseEntity
{
	public Client() 
	{
		Founders = new HashSet<Founder>();
	}
	public string Name { get; set; }
	public bool IsLegalEntity { get; set; }
	public virtual ICollection<Founder> Founders { get; set; }
}

