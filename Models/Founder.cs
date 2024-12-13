namespace Teledok.Models;

public class Founder : BaseEntity
{
	public Founder() 
	{ 

	}

	public string FullName { get; set; }

	public virtual Client Client { get; set; }
}
