using System.Collections.Generic;
using AutoMapper;
using DotNet_Microservices.Data;
using DotNet_Microservices.Dtos;
using DotNet_Microservices.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatFormRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatFormRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPlatforms()
        {
            IEnumerable<Platform> platforms = _repository.GetAllsPlatform();
            IEnumerable<PlatformReadDto> platformDtos = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
            return Ok(platformDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlatformsById(int id)
        {
            Platform platform = _repository.GetPlatformById(id);
            if (platform != null)
            {
                PlatformReadDto platformReadDto = _mapper.Map<PlatformReadDto>(platform);
                return Ok(platformReadDto);
            }
            return Ok($"Can not find platform with id {id}");
        }

        [HttpPost]
        public IActionResult CreatePlatform(PlatformCreateDto newPlatformDto)
        {
            Platform newPlatform = _mapper.Map<Platform>(newPlatformDto);
            _repository.CreatePlatform(newPlatform);
            _repository.SaveChanges();

            PlatformReadDto platformReadDto = _mapper.Map<PlatformReadDto>(newPlatform);
            return Ok(nameof(GetPlatformsById), new { Id = platformReadDto.Id}, platformReadDto); 
        }
    }
}