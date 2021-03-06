﻿using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Authorize(Policy = Policy.All)]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _subjectService.GetAll();
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetSubjectPagingRequest request)
        {
            var result = await _subjectService.GetQuestionPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var result = await _subjectService.GetByID(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SubjectCURequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _subjectService.Create(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SubjectCURequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _subjectService.Update(id, request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _subjectService.Delete(id);
            return Ok(result);
        }

        [HttpGet("accounts/{accountID}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSubjectsByAccountID(Guid accountID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _subjectService.GetSubjectsByAccountID(accountID);
            return Ok(result);
        }

        [HttpGet("/api/subjects-not-joined/accounts/{accountID}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSubjectsNotJoinedByAccountID(Guid accountID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _subjectService.GetSubjectsNotJoinedByAccountID(accountID);
            return Ok(result);
        }

        [HttpPost("{subjectID}/assign")]
        public async Task<IActionResult> SubjectAssign(string subjectID, [FromBody]Guid accountID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _subjectService.SubjectAssign(subjectID, accountID);
            return Ok(result);
        }

        [HttpPut("teachers/{teacherID}")]
        public async Task<IActionResult> EditTeacherSubjects(Guid teacherID, List<string> subjectIDs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _subjectService.EditTeacherSubjects(teacherID, subjectIDs);
            return Ok(result);
        }
    }
}
