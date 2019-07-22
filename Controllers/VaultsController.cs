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
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public VaultsController(VaultRepository repo)
    {
      _repo = repo;
    }

    // //GET api/Vaults

    [HttpGet]
    public ActionResult<IEnumerable<Vault>> GetByUser()
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

    //GET BY VAULT ID

    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        string currentUser = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetById(id, currentUser));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    // POST api/Vaults
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault value)
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

    // PUT api/Vault/5
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault value)
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

    // DELETE api/Vault/5
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        string currentUser = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.Delete(id, currentUser));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}