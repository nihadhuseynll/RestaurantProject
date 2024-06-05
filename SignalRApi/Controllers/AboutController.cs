﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values= _aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Description = createAboutDto.Description,
                Title = createAboutDto.Title,
                ImageUrl= createAboutDto.ImageUrl
            };
            _aboutService.TAdd(about);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value=_aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda alanı silindi.");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutId=updateAboutDto.AboutId,
                Description= updateAboutDto.Description,
                Title = updateAboutDto.Title,
                ImageUrl= updateAboutDto.ImageUrl
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda alanı güncellendi.");
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value= _aboutService.TGetById(id);  
            return Ok(value);
        }
    }
}