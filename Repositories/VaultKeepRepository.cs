using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetKeepByVaultId(int vaultId, string userId)
    {

      string query = @"SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE (vaultId = @vaultId AND vk.userId = @userId);";
      return _db.Query<Keep>(query, new { vaultId, userId });
    }

    public VaultKeep Create(VaultKeep value)
    {
      string query = @"
            INSERT INTO vaultkeeps (vaultId, keepId, userId)
            VALUES (@vaultId, @keepId, @userId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }


    public string Delete(VaultKeep value)
    {
      string query = @"
 DELETE FROM vaultkeeps
WHERE (keepId=@KeepId AND userId=@UserId AND vaultId=@VaultId);
";
      int changedRow = _db.QueryFirstOrDefault<int>(query, value);
      if (changedRow < 0) throw new Exception("Not able to remove");
      return "Deleted!";
    }
  }
}


// public Vault Update(Vault value)
// {
//   string query = @"
//   UPDATE vaults
//   SET
//     name = @Name,
//     description = @Description,
//     img = @Img,
//     isPrivate = @isPrivate
//     WHERE id =@Id;
//     SELECT * FROM vaults WHERE id = @Id;";
//   return _db.QueryFirstOrDefault<Vault>(query, value);
// }