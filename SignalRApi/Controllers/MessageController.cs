using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.MessageSendDate = DateTime.Now;
			createMessageDto.Status = false;
			_messageService.TAdd(new Message
			{
				Mail = createMessageDto.Mail,
				MessageContent = createMessageDto.MessageContent,
				MessageSendDate =createMessageDto.MessageSendDate,
				NameSurname = createMessageDto.NameSurname,
				Phone=createMessageDto.Phone,
				Subject = createMessageDto.Subject,
				Status =createMessageDto.Status
			});
			return Ok("Message kısmı başarılı bir şekilde eklendi.");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);
			return Ok("Message alanı silindi.");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			updateMessageDto.MessageSendDate = DateTime.Now;
			_messageService.TUpdate(new Message
			{
				MessageId = updateMessageDto.MessageId,
				Mail = updateMessageDto.Mail,
				MessageContent = updateMessageDto.MessageContent,
				MessageSendDate=updateMessageDto.MessageSendDate,
				NameSurname=updateMessageDto.NameSurname,
				Phone=updateMessageDto.Phone,
				Subject = updateMessageDto.Subject,
				Status =updateMessageDto.Status
			});
			return Ok("Message alanı güncellendi.");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetById(id);
			return Ok(value);
		}
	}
}
