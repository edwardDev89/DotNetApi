using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberInfoController : ControllerBase
    {
        private readonly MemberInfoContext _context;

        public MemberInfoController(MemberInfoContext context)
        {
            _context = context;
        }

        // GET: api/MemberInfo
        [HttpGet]
        public IEnumerable<MemberInfo> GetMemberInfos()
        {
            return _context.MemberInfos;
        }

        // GET: api/MemberInfo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var memberInfo = await _context.MemberInfos.FindAsync(id);

            if (memberInfo == null)
            {
                return NotFound();
            }

            return Ok(memberInfo);
        }

        // PUT: api/MemberInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberInfo([FromRoute] int id, [FromBody] MemberInfo memberInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memberInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(memberInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MemberInfo
        [HttpPost]
        public async Task<IActionResult> PostMemberInfo([FromBody] MemberInfo memberInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MemberInfos.Add(memberInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberInfo", new { id = memberInfo.Id }, memberInfo);
        }

        // DELETE: api/MemberInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var memberInfo = await _context.MemberInfos.FindAsync(id);
            if (memberInfo == null)
            {
                return NotFound();
            }

            _context.MemberInfos.Remove(memberInfo);
            await _context.SaveChangesAsync();

            return Ok(memberInfo);
        }

        private bool MemberInfoExists(int id)
        {
            return _context.MemberInfos.Any(e => e.Id == id);
        }
    }
}