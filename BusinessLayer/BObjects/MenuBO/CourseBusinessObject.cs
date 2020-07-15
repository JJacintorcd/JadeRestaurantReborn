using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO.OperationResults;
using Recodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO
{
    public class CourseBusinessObject
    {
        private CourseDataAccessObject _dao;

        public CourseBusinessObject()
        {
            _dao = new CourseDataAccessObject();
        }

        #region Create

        public OperationResult Create(Course item)
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

        public async Task<OperationResult> CreateAsync(Course item)
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

        public OperationResult<Course> Read(Guid id)
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

                return new OperationResult<Course>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<Course>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Course>> ReadAsync(Guid id)
        {
            try
            {
                var trOps = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, trOps, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ReadAsync(id);
                transactionScope.Complete();

                return new OperationResult<Course>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<Course>() { Success = false, Exception = e };
            }
        }

        #endregion

        #region Update

        public OperationResult Update(Course item)
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

        public async Task<OperationResult> UpdateAsync(Course item)
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

        public OperationResult Delete(Course item)
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

        public async Task<OperationResult> DeleteAsync(Course item)
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

        public OperationResult<List<Course>> List()
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

                return new OperationResult<List<Course>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Course>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<Course>>> ListAsync()
        {
            try
            {
                var trOps = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, trOps, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ListAsync();
                transactionScope.Complete();

                return new OperationResult<List<Course>>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Course>>() { Success = false, Exception = e };
            }
        }

        #endregion

        #region List Undeleted

        public OperationResult<List<Course>> ListUnDeleted()
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

                return new OperationResult<List<Course>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Course>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<Course>>> ListUnDeletedAsync()
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

                return new OperationResult<List<Course>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Course>>() { Success = false, Exception = e };
            }
        }

        #endregion

    }
}
