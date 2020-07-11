using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO.OperationResults;
using Recodme.Rd.JadeRest.DataAccessLayer.DAOObjects.UserDAO;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Rd.JadeRest.BusinessLayer.BObjects.UserBO
{
    public class StaffRecordBusinessObject
    {
        private StaffRecordDataAccessObject _dao;

        public StaffRecordBusinessObject()
        {
            _dao = new StaffRecordDataAccessObject();

        }

        #region Create

        public OperationResult Create(StaffRecord item)
        {
            try
            {
                _dao.Create(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult> CreateAsync(StaffRecord item)
        {
            try
            {
                await _dao.CreateAsync(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        #endregion

        #region Read

        public OperationResult<StaffRecord> Read(Guid id)
        {
            try
            {
                var trOps = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, trOps, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<StaffRecord>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<StaffRecord>() { Success = false, Exception = e };

            }


        }

        public async Task<OperationResult<StaffRecord>> ReadAsync(Guid id)
        {
            try
            {
                var trOps = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, trOps, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<StaffRecord>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<StaffRecord>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region Update

        public OperationResult Update(StaffRecord item)
        {
            try
            {
                _dao.Update(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult> UpdateAsync(StaffRecord item)
        {
            try
            {
                await _dao.UpdateAsync(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        #endregion

        #region Delete

        public OperationResult Delete(StaffRecord item)
        {
            try
            {
                _dao.Delete(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            try
            {
                await _dao.DeleteAsync(id);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public OperationResult Delete(Guid id)
        {
            try
            {
                _dao.Delete(id);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult> DeleteAsync(StaffRecord item)
        {
            try
            {
                await _dao.DeleteAsync(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        #endregion

        #region List

        public OperationResult<List<StaffRecord>> List()
        {
            try
            {
                var trOps = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, trOps, TransactionScopeAsyncFlowOption.Enabled);
                var res = _dao.List();
                transactionScope.Complete();
                return new OperationResult<List<StaffRecord>>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffRecord>>() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult<List<StaffRecord>>> ListAsync()
        {
            try
            {
                var trOps = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, trOps, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ListAsync();
                transactionScope.Complete();
                return new OperationResult<List<StaffRecord>>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffRecord>>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region List Undeleted
        public OperationResult<List<StaffRecord>> ListUnDeleted()
        {
            try
            {
                var trOps = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, trOps, TransactionScopeAsyncFlowOption.Enabled);
                var res = _dao.List().Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();
                return new OperationResult<List<StaffRecord>>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffRecord>>() { Success = false, Exception = e };

            }
        }

        public async Task<OperationResult<List<StaffRecord>>> ListUnDeletedAsync()
        {
            try
            {
                var trOps = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, trOps, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ListAsync();
                res = res.Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();
                return new OperationResult<List<StaffRecord>>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffRecord>>() { Success = false, Exception = e };

            }
        }
        #endregion
    }
}
