using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate=0;");
    }

    public Keep GetById(int id)
    {
      string query = "SELECT * FROM keeps WHERE id=@id";
      Keep keep = _db.QueryFirstOrDefault<Keep>(query, new { id });
      if (keep == null) throw new Exception("Invalid Id"); //needs to prompt user to login?
      return keep;
    }

    public IEnumerable<Keep> GetByUser(string CurrentUser)
    {
      IEnumerable<Keep> keeps = _db.Query<Keep>("SELECT * FROM keeps WHERE userId=@CurrentUser", new { CurrentUser });
      if (keeps == null) throw new Exception("Invalid User");
      return keeps;

    }

    public Keep Create(Keep value)
    {
      string test = value.UserId;
      string query = @"
      INSERT INTO keeps(name,description,userId,img,isPrivate)
      VALUES (@Name,@Description,@userId,@Img,@IsPrivate);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public Keep Update(Keep value)
    {
      string query = @"
      UPDATE keeps
      SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @isPrivate
        WHERE id =@Id;
        SELECT * FROM keeps WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Keep>(query, value);
    }

    public string Delete(int id, string userId)
    {
      string query = "DELETE FROM keeps WHERE id=@Id AND userId=@userId;";
      int changedRows = _db.Execute(query, new { id, userId });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted Keep";

    }
  }
}