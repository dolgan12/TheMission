using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheMission.API.Data;
using TheMission.API.Models.Dtos;

namespace TheMission.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMissionRepository _repo;
        private readonly IMapper _mapper;
        public SkillsController(IMissionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            var skillsFromRepo = await _repo.GetSkills();

            var skillsToReturn = _mapper.Map<IEnumerable<SkillForListDto>>(skillsFromRepo);

            return Ok(skillsToReturn);
        }


        [HttpGet("{skillId}")]
        public async Task<IActionResult> GetSkill(int skillId)
        {
            var skillFromRepo = await _repo.GetSkill(skillId);

            //var skillToReturn = _mapper.Map<SkillForListDto>(skillFromRepo);

            return Ok(skillFromRepo);
        }


    }
}