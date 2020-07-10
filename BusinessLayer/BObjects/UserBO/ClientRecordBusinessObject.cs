using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO.OperationResults;
using Recodme.Rd.JadeRest.DataAccessLayer.DAOObjects.MenuDAO.DAObjects.UserDAO;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO.BObjects.UserBO
{
    public class ClientRecordBusinessObject
    {
        private ClientRecordDataAccessObject _dao;

        public ClientRecordBusinessObject()
        {
            _dao = new ClientRecordDataAccessObject();

        }

        #region Create

        public OperationResult Create(ClientRecord item)
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

        public async Task<OperationResult> CreateAsync(ClientRecord item)
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

        public OperationResult<ClientRecord> Read(Guid id)
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
                return new OperationResult<ClientRecord>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<ClientRecord>() { Success = false, Exception = e };

            }


        }

        public async Task<OperationResult<ClientRecord>> ReadAsync(Guid id)
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
                return new OperationResult<ClientRecord>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<ClientRecord>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region Update

        public OperationResult Update(ClientRecord item)
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
        public async Task<OperationResult> UpdateAsync(ClientRecord item)
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

        public OperationResult Delete(ClientRecord item)
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
        public async Task<OperationResult> DeleteAsync(ClientRecord item)
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

        public OperationResult<List<ClientRecord>> List()
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
                return new OperationResult<List<ClientRecord>>() { Success = true, Result = res };

            }
            catch (Exception e)
            {
                return new OperationResult<List<ClientRecord>>() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult<List<ClientRecord>>> ListAsync()
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
                return new OperationResult<List<ClientRecord>>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<List<ClientRecord>>() { Success = false, Exception = e };

            }

        }

        #endregion
    }
}
