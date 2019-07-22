using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public KeepsController(KeepRepository repo)
    {
      _repo = repo;
    }

    // GET api/keeps

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_repo.GetALL());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // GET api/keeps/5

    [HttpGet("{id}")]
    [Authorize]
    public ActionResult<Keep> Get(int id)
    {
      try
      {

        return Ok(_repo.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // //GET api/keeps/User
    [HttpGet("user")]
    [Authorize]
    public ActionResult<IEnumerable<Keep>> GetByUser()
    {
      try
      {
        string currentUser = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetByUser(currentUser));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    // POST api/keeps

    [HttpPost]
    [Authorize]
    public ActionResult<Keep> Post([FromBody] Keep value)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        value.UserId = userId;
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT api/Keep/5
    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    {
      try
      {
        value.Id = id;
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/Keep/5
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}