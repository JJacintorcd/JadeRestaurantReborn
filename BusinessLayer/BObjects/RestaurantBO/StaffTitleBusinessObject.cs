using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO.OperationResults;
using Recodme.Rd.JadeRest.DataAccessLayer.DAOObjects.RestaurantDAO;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO
{
    public class StaffTitleBusinessObject
    {
        private StaffTitleDataAccessObject _dao;

        public StaffTitleBusinessObject()
        {
            _dao = new StaffTitleDataAccessObject();

        }

        #region C

        public OperationResult Create(StaffTitle item)
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
        public async Task<OperationResult> CreateAsync(StaffTitle item)
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

        #region R

        public OperationResult<StaffTitle> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<StaffTitle>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<StaffTitle>() { Success = false, Exception = e };

            }


        }

        public async Task<OperationResult<StaffTitle>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<StaffTitle>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<StaffTitle>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region U

        public OperationResult Update(StaffTitle item)
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
        public async Task<OperationResult> UpdateAsync(StaffTitle item)
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

        #region D

        public OperationResult Delete(StaffTitle item)
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
        public async Task<OperationResult> DeleteAsync(StaffTitle item)
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

        #region L

        public OperationResult<List<StaffTitle>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();
                transactionScope.Complete();

                return new OperationResult<List<StaffTitle>>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffTitle>>() { Success = false, Exception = e };
            }

        }
        public async Task<OperationResult<List<StaffTitle>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ListAsync();
                transactionScope.Complete();

                return new OperationResult<List<StaffTitle>>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffTitle>>() { Success = false, Exception = e };
            }
        }

        #endregion

        #region LUD

        public OperationResult<List<StaffTitle>> ListUnDeleted()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List().Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();

                return new OperationResult<List<StaffTitle>>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffTitle>>() { Success = false, Exception = e };
            }

        }
        public async Task<OperationResult<List<StaffTitle>>> ListUnDeletedAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ListAsync();
                result = result.Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();

                return new OperationResult<List<StaffTitle>>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffTitle>>() { Success = false, Exception = e };
            }
        }

        #endregion
    }
}
