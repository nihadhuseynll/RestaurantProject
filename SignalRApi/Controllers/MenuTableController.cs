using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;

		public MenuTableController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}
		[HttpGet]
		public IActionResult MenuTableList()
		{
			return Ok(_menuTableService.TGetListAll());
		}
		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			_menuTableService.TAdd(new MenuTable()
			{
				Name = createMenuTableDto.Name,
				Status = false
			}) ;
			return Ok("Menu Table eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);
			return Ok("Menu Table başarıyla silindi.");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			_menuTableService.TUpdate(new MenuTable()
			{
				MenuTableId= updateMenuTableDto.MenuTableId,
				Name=updateMenuTableDto.Name,
				Status=updateMenuTableDto.Status
			});
			return Ok("Menu Table başarıyla güncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(value);
		}
	}
}
