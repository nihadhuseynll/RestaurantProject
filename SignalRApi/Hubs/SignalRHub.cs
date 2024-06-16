using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		SignalRContext signalRContext=new SignalRContext();	
		public async Task SendCategoryCount()
		{
			var value=signalRContext.Categories.Count();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);
		}
	}
}
