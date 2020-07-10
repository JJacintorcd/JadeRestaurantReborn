using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO.OperationResults;
using Recodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO
{
    public class DietaryRestrictionBusinessObject
    {
        private DietaryRestrictionDataAccessObject _dao;

        public DietaryRestrictionBusinessObject()
        {
            _dao = new DietaryRestrictionDataAccessObject();
        }

        #region Create
        public OperationResult Create (DietaryRestriction item)
        {
            try
            {
                _dao.Create(item);
                return new OperationResult { Success = true};
            }
            catch (Exception e)
            {
                return new OperationResult { Success = true, Exception = e};
            }
        }

        public async Task<OperationResult> CreateAsync(DietaryRestriction item)
        {
            try
            {
                await _dao.CreateAsync(item);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult { Success = true, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<DietaryRestriction> Read(Guid id)
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
                return new OperationResult<DietaryRestriction>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<DietaryRestriction>() { Success = false, Exception = e };

            }
        }

        public async Task<OperationResult<DietaryRestriction>> ReadAsync(Guid id)
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
                return new OperationResult<DietaryRestriction>() { Success = true, Result = res};

            }
            catch (Exception e)
            {
                return new OperationResult<DietaryRestriction>() { Success = false, Exception = e };

            }
        }
        #endregion

        #region Update
        public OperationResult Update(DietaryRestriction item)
        {
            try
            {
                _dao.Update(item);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> UpdateAsync(DietaryRestriction item)
        {
            try
            {
                await _dao.UpdateAsync(item);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult { Success = true, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(DietaryRestriction item) 
        {
            try
            {
                _dao.Delete(item);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult { Success = false, Exception = e };
            }
        }

        public OperationResult Delete(Guid id)
        {
            try
            {
                _dao.Delete(id);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> DeleteAsync(DietaryRestriction item)
        {
            try
            {
                await _dao.DeleteAsync(item);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            try
            {
                await _dao.DeleteAsync(id);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult { Success = false, Exception = e };
            }
        }
        #endregion

        #region List
        public OperationResult<List<DietaryRestriction>> List()
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
                return new OperationResult<List<DietaryRestriction>>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<List<DietaryRestriction>>() { Success = false, Exception = e };

            }
        }

        public async Task<OperationResult<List<DietaryRestriction>>> ListAsync()
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
                return new OperationResult<List<DietaryRestriction>>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<List<DietaryRestriction>>() { Success = false, Exception = e };

            }
        }
        #endregion

    }
}
