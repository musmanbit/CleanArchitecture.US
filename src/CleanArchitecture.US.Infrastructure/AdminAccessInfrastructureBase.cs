/*
File generated by custome templates
Important: Do not modify this file. Edit the file AdminAccessInfrastructure.cs instead.
*/
#region using directives
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Infrastructure.Interface;
using CleanArchitecture.US.Domain;
using CleanArchitecture.US.Common.NLog;
#endregion

namespace CleanArchitecture.US.Infrastructure
{
    /// <summary>
    /// This class handles the CRUD operations of the <table></table> 
    /// It is generated using the Generic ORM framework 
     /// </summary> 
     public class AdminAccessInfrastructureBase: SqlBaseInfrastructure, IBaseInfrastructure<AdminAccess>
    {
    public AdminAccessInfrastructureBase(IConfiguration configuration, ILoggerManager logger) : base(configuration, logger)
    {}
    public AdminAccessInfrastructureBase(IConfiguration configuration) : base(configuration)
    {}
             public enum AdminAccessColumn
           {
              AdminAccessId=1,AdminId=2,CreatedBy=3,FirstName=4,UserId=5
           }
     protected static IList<AdminAccess> Fill(IDataReader reader, IList<AdminAccess> rows, int start, int pageLength) 
    {
      // advance to the starting row
      for (int i = 0; i < start; i++)
      {
       if (!reader.Read()) 
       return rows; // not enough rows, just return
      }
      if (pageLength <= 0) pageLength = 99999999; //100 million by default  
       for (int i = 0; i < pageLength; i++) 
      {
       if (!reader.Read()) 
        {break;} // we are done

        var c = new AdminAccess();
         c.AdminAccessId = (Int32)reader[((int)AdminAccessColumn.AdminAccessId - 1)]; 
         c.AdminId = (Int32)reader[((int)AdminAccessColumn.AdminId - 1)]; 
         c.CreatedBy = (Int32)reader[((int)AdminAccessColumn.CreatedBy - 1)]; 
         c.FirstName = (string)reader[((int)AdminAccessColumn.FirstName - 1)]; 
         c.UserId = (Int32)reader[((int)AdminAccessColumn.UserId - 1)]; 
        c.AcceptChanges();
        rows.Add(c); 
      }
         return rows; 
      }
     public async Task<AdminAccess> GetById(Int32 adminAccessId) 
    {
      SqlConnection conn = null;
      SqlCommand cmd = null;
      try
      {
      conn =  GetConnection();
      cmd = GetSqlCommand(conn, "dbo.gen_AdminAccess_GetByadmin_access_id", true); 
       cmd.Parameters.Add(GetInParameter("@AdminAccessId", SqlDbType.Int, adminAccessId)); 
       IList<AdminAccess> tmp = new List<AdminAccess>();
      IDataReader reader = await ExecuteReaderAsync(cmd);
      Fill(reader, tmp, 0, 0);
       if ( !reader.IsClosed) reader.Close(); 
       return tmp.Count > 0 ? tmp[0] : null;
      }
      finally
      {
       conn?.Dispose();
       cmd?.Dispose(); 
      }
    }
     public async Task<bool> Delete(AdminAccess entity ) 
    {
      SqlConnection conn = null;
      try
      {
      conn =  GetConnection();
      return await Delete(entity, conn);
      }
      finally
      {
        conn?.Dispose();
      }
    }
     public async Task<bool> Delete(AdminAccess entity, SqlConnection conn) 
    {
      SqlCommand cmd = null;
      try
      {
      cmd = GetSqlCommand(conn, "dbo.gen_AdminAccess_Delete", true);
       cmd.Parameters.Add(GetInParameter("@AdminAccessId", SqlDbType.Int, entity.AdminAccessId)); 
       await cmd.ExecuteNonQueryAsync();
      return true;
      }
      finally
      {
        cmd?.Dispose(); 
      }
    }
     public async Task<IList<AdminAccess>> GetListByForeignKeyAdminId(Int32 adminId) 
    {
      SqlConnection conn = null;
      SqlCommand cmd = null;
      try
      {
      conn = GetConnection();
      cmd = GetSqlCommand(conn, "dbo.gen_AdminAccess_GetListByForeignKey_AdminId", true);
      cmd.Parameters.Add(GetInParameter("@AdminId", SqlDbType.Int, adminId)); 
       IList<AdminAccess> tmp = new List<AdminAccess>();
      IDataReader reader = await ExecuteReaderAsync(cmd);
      Fill(reader, tmp, 0, 0);
       if (!reader.IsClosed) reader.Close(); 
      return tmp;
      }
      finally
      {
       conn?.Dispose();
       cmd?.Dispose(); 
      }
    }
     public async Task<IList<AdminAccess>> GetListByForeignKeyUserId(Int32 userId) 
    {
      SqlConnection conn = null;
      SqlCommand cmd = null;
      try
      {
      conn = GetConnection();
      cmd = GetSqlCommand(conn, "dbo.gen_AdminAccess_GetListByForeignKey_UserId", true);
      cmd.Parameters.Add(GetInParameter("@UserId", SqlDbType.Int, userId)); 
       IList<AdminAccess> tmp = new List<AdminAccess>();
      IDataReader reader = await ExecuteReaderAsync(cmd);
      Fill(reader, tmp, 0, 0);
       if (!reader.IsClosed) reader.Close(); 
      return tmp;
      }
      finally
      {
       conn?.Dispose();
       cmd?.Dispose(); 
      }
    }
     public async Task<IList<AdminAccess>> GetAll() 
    {
      SqlConnection conn = null;
      SqlCommand cmd = null;
      try
      {
      conn = GetConnection();
      cmd = GetSqlCommand(conn, "dbo.gen_AdminAccess_GetAll", true);
       IList<AdminAccess> tmp = new List<AdminAccess>();
      IDataReader reader = await ExecuteReaderAsync(cmd);
      Fill(reader, tmp, 0, 0);
       if (!reader.IsClosed) reader.Close(); 
      return tmp;
      }
      finally
      {
       conn?.Dispose();
       cmd?.Dispose(); 
      }
    }
    public async Task<bool>  Insert(AdminAccess entity) 
    {
      SqlConnection conn = null;
      try
      {
        conn = GetConnection();
        return await Insert(entity, conn);
      }
        finally 
       { 
        conn?.Dispose();
       } 
    }
    public async Task<bool>  Insert(AdminAccess entity, SqlConnection conn) 
    {
      SqlCommand cmd = null;
      try
      {
      cmd = GetSqlCommand(conn, "dbo.gen_AdminAccess_Insert", true);
      cmd.Parameters.Add(GetOutParameter("@AdminAccessId", SqlDbType.Int)); 
       cmd.Parameters.Add(GetInParameter("@AdminId", SqlDbType.Int, entity.AdminId)); 
       cmd.Parameters.Add(GetInParameter("@CreatedBy", SqlDbType.Int, entity.CreatedBy)); 
       cmd.Parameters.Add(GetInParameter("@FirstName", SqlDbType.NVarChar, entity.FirstName)); 
       cmd.Parameters.Add(GetInParameter("@UserId", SqlDbType.Int, entity.UserId)); 
       await cmd.ExecuteNonQueryAsync();
       entity.AdminAccessId = (Int32) cmd.Parameters["@AdminAccessId"].Value; 
       entity.AcceptChanges();
       return true; 
      }
      finally
      {
       cmd?.Dispose(); 
      }
    }
    public async Task<bool>  Update(AdminAccess entity) 
    {
      SqlConnection conn = null;
      try
      {
        conn = GetConnection();
        return await Update(entity, conn);
      }
        finally 
       { 
        conn?.Dispose();
       } 
    }
    public async Task<bool> Update(AdminAccess entity, SqlConnection conn) 
    {
      SqlCommand cmd = null;
      try
      {
      cmd = GetSqlCommand(conn, "dbo.gen_AdminAccess_Update", true);
       cmd.Parameters.Add(GetInParameter("@AdminAccessId", SqlDbType.Int, entity.AdminAccessId)); 
       cmd.Parameters.Add(GetInParameter("@AdminId", SqlDbType.Int, entity.AdminId)); 
       cmd.Parameters.Add(GetInParameter("@CreatedBy", SqlDbType.Int, entity.CreatedBy)); 
       cmd.Parameters.Add(GetInParameter("@FirstName", SqlDbType.NVarChar, entity.FirstName)); 
       cmd.Parameters.Add(GetInParameter("@UserId", SqlDbType.Int, entity.UserId)); 
       await cmd.ExecuteNonQueryAsync();
       entity.AcceptChanges();
       return true;
      }
      finally
      {
       cmd?.Dispose(); 
      }
    }
     public async Task<int> Update(IList<AdminAccess> entities) 
    {
      SqlConnection conn = null;
      try
      {
        conn = GetConnection();
       int count = 0;
       foreach (var entity in entities)
      {
        if (entity.RowState == EntityState.Modified) 
       {
       if (await Update(entity, conn)) 
       {
       count++;

       }
       }
        else if (entity.RowState == EntityState.New) 
       {
        if (await Insert(entity, conn))
       {
       count++;

       }
       }
        else if (entity.RowState == EntityState.Deleted) 
       {
        if (await Delete(entity, conn))
       {
       count++;

       }
       }
      }
         return count; 
      }
        finally 
       { 
        conn?.Dispose();
       }       }
    }
}

