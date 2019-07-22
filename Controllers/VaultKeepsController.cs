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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;

    public VaultKeepsController(VaultKeepRepository repo)
    {
      _repo = repo;
    }

    // //GET api/vaultkeeps/:vaultId

    //GET BY VAULT ID

    [HttpGet("{vault}")]
    [Authorize]
    public ActionResult<IEnumerable<Keep>> GetKeepByVaultId(int vault)
    {
      try
      {
        string currentUser = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetKeepByVaultId(vault, currentUser));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    // POST api/VaultKeeps
    [HttpPost]
    [Authorize]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep value)
    {
      try
      {
        var currentUser = HttpContext.User.FindFirstValue("Id");
        value.UserId = currentUser;
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    [Authorize]
    [HttpPut]
    public ActionResult<String> Delete([FromBody] VaultKeep value)
    {
      try
      {
        string currentUser = HttpContext.User.FindFirstValue("Id");
        value.UserId = currentUser;
        return Ok(_repo.Delete(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

  }
}