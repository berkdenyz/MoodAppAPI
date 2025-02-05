using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MoodApp.DAL.Abstract;
using MoodApp.DAL.Entities;
using MoodApp.API.DTOs;
using System.Security.Claims;

namespace MoodApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MoodEntriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MoodEntriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoodEntryDto>>> GetMoodEntries()
        {
            var moodEntries = await _unitOfWork.Repository<MoodEntry>()
                .GetAllAsync();

            var moodEntryDtos = _mapper.Map<IEnumerable<MoodEntryDto>>(moodEntries);
            return Ok(moodEntryDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoodEntryDto>> GetMoodEntry(string id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var moodEntry = await _unitOfWork.Repository<MoodEntry>()
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

            if (moodEntry == null)
                return NotFound();

            return Ok(_mapper.Map<MoodEntryDto>(moodEntry));
        }

        [HttpPost]
        public async Task<ActionResult<MoodEntryDto>> CreateMoodEntry(CreateMoodEntryDto createMoodEntryDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var moodEntry = _mapper.Map<MoodEntry>(createMoodEntryDto);
            moodEntry.Id = Guid.NewGuid().ToString();
            moodEntry.UserId = userId;
            moodEntry.CreatedAt = DateTime.UtcNow;
            moodEntry.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<MoodEntry>().AddAsync(moodEntry);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetMoodEntry), new { id = moodEntry.Id }, _mapper.Map<MoodEntryDto>(moodEntry));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMoodEntry(string id, UpdateMoodEntryDto updateMoodEntryDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var moodEntry = await _unitOfWork.Repository<MoodEntry>()
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

            if (moodEntry == null)
                return NotFound();

            _mapper.Map(updateMoodEntryDto, moodEntry);
            moodEntry.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Repository<MoodEntry>().Update(moodEntry);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoodEntry(string id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var moodEntry = await _unitOfWork.Repository<MoodEntry>()
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

            if (moodEntry == null)
                return NotFound();

            _unitOfWork.Repository<MoodEntry>().Remove(moodEntry);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet("region")]
        public async Task<ActionResult<IEnumerable<MoodEntryDto>>> GetRegionMoodEntries(
            [FromQuery] double latitude,
            [FromQuery] double longitude,
            [FromQuery] double radius = 10)
        {
            // Basit bir mesafe hesaplama (km cinsinden)
            var moodEntries = await _unitOfWork.Repository<MoodEntry>()
                .GetAllAsync(m =>
                    Math.Acos(Math.Sin(latitude * Math.PI / 180) * Math.Sin(m.Latitude * Math.PI / 180) +
                    Math.Cos(latitude * Math.PI / 180) * Math.Cos(m.Latitude * Math.PI / 180) *
                    Math.Cos((longitude - m.Longitude) * Math.PI / 180)) * 6371 <= radius);

            // Hassas bilgileri filtrele
            var moodEntryDtos = _mapper.Map<IEnumerable<MoodEntryDto>>(moodEntries);
            foreach (var dto in moodEntryDtos)
            {
                dto.UserId = null; // Kullanıcı kimliğini gizle
                dto.Note = null;   // Özel notları gizle
            }

            return Ok(moodEntryDtos);
        }
    }
} 