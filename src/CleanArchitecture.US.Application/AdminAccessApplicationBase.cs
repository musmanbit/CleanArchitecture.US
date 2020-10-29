/*File generated by custome templates
Important: Do not modify this file.Edit the file AdminAccessApplication.cs instead.
*/
#region using directives
using System;
using System.Transactions;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.US.Domain;
using CleanArchitecture.US.Common;
using CleanArchitecture.US.Common.Serilog;
using CleanArchitecture.US.Application.Interface;
using CleanArchitecture.US.Infrastructure.Interface;

#endregion

namespace CleanArchitecture.US.Application
{
     public class AdminAccessApplicationBase:BaseApplication, IBaseApplication<AdminAccess>
    {
      #region Properties
         private IAdminAccessInfrastructure _adminaccessInfrastructure { get; }
      #endregion

      #region Constructor
       public AdminAccessApplicationBase(IAdminAccessInfrastructure adminaccessInfrastructure, IConfiguration configuration, ILoggerManager logger) : base(configuration, logger)
      {
        this._adminaccessInfrastructure = adminaccessInfrastructure;
      }
      #endregion

      #region Methods
       public async Task<AdminAccess> Save(AdminAccess entity, bool createTransaction) 
      {
        Logger.LogEnter();
        TransactionScope scope = null;
          try
         { 
         if (createTransaction)
         {
             scope = new TransactionScope(TransactionScopeOption.Required,
             TransactionScopeAsyncFlowOption.Enabled);
         }
          await Save(entity);
          scope?.Complete();
         } 
          finally 
         { 
          scope?.Dispose();
         Logger.LogExit();
         } 
          return entity; 
      }
      [DataObjectMethod(DataObjectMethodType.Update)]
       internal async Task<AdminAccess> Save(AdminAccess entity ) 
      {
        Logger.LogEnter();
           switch (entity.RowState) 
           { 
           case EntityState.New: 
            await _adminaccessInfrastructure.Insert(entity); 
           break; 
            case EntityState.Modified: 
            await _adminaccessInfrastructure.Update(entity); 
            break; 
           case EntityState.Deleted: 
           await _adminaccessInfrastructure.Delete(entity); 
            break; 
           } 
         Logger.LogExit();
          return entity; 
      }
       public async Task<IList<AdminAccess>> Save(IList<AdminAccess> entityCollection, bool createTransaction) 
      {
        Logger.LogEnter();
        TransactionScope scope = null;
          try
         { 
         if (createTransaction) 
         {
             scope = new TransactionScope(TransactionScopeOption.Required,
             TransactionScopeAsyncFlowOption.Enabled);
         }
          await Save(entityCollection);
          scope?.Complete();
         } 
          finally 
         { 
          scope?.Dispose();
         Logger.LogExit();
         } 
          return entityCollection; 
      }
      [DataObjectMethod(DataObjectMethodType.Update)]
       internal async Task<IList<AdminAccess>>  Save( IList<AdminAccess> entityCollection) 
      {
        Logger.LogEnter();
          try
         { 
          foreach (var entity in entityCollection) 
        {
           await _adminaccessInfrastructure.Update(entityCollection);  
         } 
         } 
          finally 
         { 
         Logger.LogExit();
         } 
          return entityCollection; 
      }
      [DataObjectMethod(DataObjectMethodType.Select)]
       public async Task<AdminAccess> GetById(Int32  adminAccessId) 
      {
        Logger.LogEnter();
          try
         { 
         var entity = await _adminaccessInfrastructure.GetById(adminAccessId); 
         if(entity == null) return  new AdminAccess();
           return entity; 
         } 
          finally 
         { 
         Logger.LogExit();
         } 
      }
      [DataObjectMethod(DataObjectMethodType.Select)]
       public async Task<IList<AdminAccess>> GetListByForeignKeyAdminId(Int32 adminId) 
      {
        Logger.LogEnter();
          try
         { 
         return await _adminaccessInfrastructure.GetListByForeignKeyAdminId(adminId); 
         } 
          finally 
         { 
         Logger.LogExit();
         } 
      }
      [DataObjectMethod(DataObjectMethodType.Select)]
       public async Task<IList<AdminAccess>> GetListByForeignKeyUserId(Int32 userId) 
      {
        Logger.LogEnter();
          try
         { 
         return await _adminaccessInfrastructure.GetListByForeignKeyUserId(userId); 
         } 
          finally 
         { 
         Logger.LogExit();
         } 
      }
      [DataObjectMethod(DataObjectMethodType.Select)]
       public async Task<IList<AdminAccess>> GetAll() 
      {
        Logger.LogEnter();
          try
         { 
         var collection = await _adminaccessInfrastructure.GetAll();
          return collection; 
         } 
          finally 
         { 
         Logger.LogExit();
         } 
      }
      #endregion
    }
    }
