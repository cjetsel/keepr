using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetALL()
    {
      return _db.Query<Vault>("SELECT * FROM vaults;");
    }

    public Vault GetById(int id, string user)
    {
      string query = "SELECT * FROM vaults WHERE id=@id AND userId =@user";
      Vault vault = _db.QueryFirstOrDefault<Vault>(query, new { id, user });
      if (vault == null) throw new Exception("Invalid Id");
      return vault;
    }

    public IEnumerable<Vault> GetByUser(string CurrentUser)
    {
      IEnumerable<Vault> vaults = _db.Query<Vault>("SELECT * FROM vaults WHERE userId=@CurrentUser", new { CurrentUser });
      if (vaults == null) throw new Exception("Invalid User");
      return vaults;

    }

    public Vault Create(Vault value)
    {
      string test = value.UserId;
      string query = @"
      INSERT INTO vaults(name,description,userId)
      VALUES (@Name,@Description,@UserId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public Vault Update(Vault value)
    {
      string query = @"
      UPDATE vaults
      SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @isPrivate
        WHERE id =@Id;
        SELECT * FROM vaults WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Vault>(query, value);
    }

    public string Delete(int id, string user)
    {
      string query = "DELETE FROM vaults WHERE id=@Id AND userId=@user;";
      int changedRows = _db.Execute(query, new { id, user });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Vault";

    }
  }
}