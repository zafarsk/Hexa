using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
        {
            var users = await _unitOfWork.UserRepository.GetMembersAsync(userParams);
            Response.AddingPagingHeader(users.CurrentPage, users.TotalPages,
                    users.PageSize, users.TotalCount);
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<ActionResult<MemberDto>> Register(RegisterDto registerDto)
        {
            var user = _mapper.Map<AppUser>(registerDto);
            
            _unitOfWork.UserRepository.Add(user);

            if(!await _unitOfWork.Complete()) return BadRequest("Error while creating a user");
            
            return Ok(_mapper.Map<MemberDto>(user));

            
        }

        

        

        
    }
}
