﻿using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

		public SignalRHub(ICategoryService categoryService, IProductService productService,
			IOrderService orderService, IMoneyCaseService moneyCaseService, 
			IMenuTableService menuTableService,IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}
		public static int ClientCount { get; set; } = 0;
		public async Task SendStatistiks()
		{
			var value1=_categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value1);

			var value2=_productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

			var value4 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

			var value5 = _productService.TProductCountByHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByHamburger", value5);

			var value6 = _productService.TProductCountByIcecek();
			await Clients.All.SendAsync("ReceiveProductCountByIcecek", value6);

			var value7 = _productService.TProductPriceByAvg();
			await Clients.All.SendAsync("ReceiveProductPriceByAvg", value7.ToString("0.00" + "$"));

			var value8 = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

			var value9 = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

			var value10 = _productService.TProductAvgPriceByHamburger();
			await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10.ToString("0.00" + "$"));

			var value11 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

			var value12 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

			var value13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00" + "$"));

			var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00" + "$"));

			var value15 = _orderService.TTodayOrderEarning();
			await Clients.All.SendAsync("ReceiveTodayOrderEarning", value15.ToString("0.00" + "$"));

			var value16 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
		}
		public async Task SendProgressBar()
		{
			var value1=_moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value1.ToString("0.00" + "$"));

			var value2 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

			var value3 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value3);
		}
		public async Task GetBookingList()
		{
			var values = _bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);
		}
		public async Task SendNotification()
		{
			var value = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", value);

			var notficicationlistbyfalse=_notificationService.TGetAllNotificationsByFalse();
			await Clients.All.SendAsync("ReceiveGetAllNotificationsByFalse", notficicationlistbyfalse);
		}
		public async Task GetMenuTableStatus()
		{
			var value = _menuTableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
		}
		public async Task SendMessage(string user,string message)
		{
			await Clients.All.SendAsync("ReceiveMessage",user,message);
		}
        public override async Task OnConnectedAsync()
        {
			ClientCount++;
			await Clients.All.SendAsync("ClientCountMessage", ClientCount);
			await base.OnConnectedAsync();	
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ClientCount--;
			await Clients.All.SendAsync("ClientCountMessage", ClientCount);
			await base.OnDisconnectedAsync(exception);
        }
    }
}
