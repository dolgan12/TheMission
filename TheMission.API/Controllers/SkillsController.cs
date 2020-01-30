using System.Collections.Generic;
using System.Security.Claims;
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

        [HttpPost]
        public async Task<IActionResult> AddSkill(SkillToAddDto skillToAdd)
        {
            if (skillToAdd.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            var result = await _repo.AddSkill(skillToAdd);

            if (!result)
            {
                return BadRequest("Failed to save skill");
            }
            
            return Ok(skillToAdd);
        }


        [HttpGet("{skillId}")]
        public async Task<IActionResult> GetSkill(int skillId)
        {
            var skillFromRepo = await _repo.GetSkill(skillId);

            //var skillToReturn = _mapper.Map<SkillForListDto>(skillFromRepo);

            return Ok(skillFromRepo);
        }
        [HttpGet("all/{skillId}")]
        public async Task<IActionResult> GetUsersForSkill(int skillId) 
        {
            var userList = await _repo.GetUsersWithSkill(skillId);

            if (userList == null)
            {
                return BadRequest("No user has that skill yet");
            }

            return Ok(userList);
        }

        [HttpPost("remove")]
        public async Task<IActionResult> DeleteUserSkill(UserSkillToRemoveDto userSkilltoRemove)
        {
            if (userSkilltoRemove.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var userSkill = await _repo.GetUserSkill(userSkilltoRemove.UserId, userSkilltoRemove.SkillName);

            if (userSkill == null)
            {
                return BadRequest();
            }

            _repo.Delete(userSkill);

            if (await _repo.SaveAll())
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable to remove the skill");
            }


        }

    }
}