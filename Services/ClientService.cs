using Teledok.DAL;
using Teledok.Models;

namespace Teledok.Services
{
	public class ClientService : ILegalTypeService<Client>
	{
		private readonly ClientRepository _clientRepository;

		public ClientService(ClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}

		public ClientService() { }

		public async Task<Client> Create(Client client)
		{
			_clientRepository.Create(client);
			await _clientRepository.SaveAsync();

			return client;
		}

		public async Task Delete(Client client)
		{
			await _clientRepository.Delete(client.Id);
			await _clientRepository.SaveAsync();
		}

		public async Task<Client> Update(Client client)
		{
			_clientRepository.Update(client);
			await _clientRepository.SaveAsync();

			return client;
		}

		public List<Client> GetList()
		{
			return _clientRepository.GetList();
		}

		public Task<Client> Get(Client client) 
		{ 
			return _clientRepository.Get(client.Id);
		}
	}
}
