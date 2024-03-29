﻿using System;
using System.Collections.Generic;
using System.Linq;
using Glamry.BusinessLogic.Domains;
using Glamry.BusinessLogic.Services;
using NHibernate;

namespace Glamry.BusinessLogic.Helpers
{
    public partial class NHibernateRepository<T, TId> : IRepository<T, TId>
        where T : BaseEntity<TId>
        where TId : struct
    {
        ISession currentSession = NHibernateHelper.GetCurrentSession();
        public NHibernateRepository()
        {

        }
        public T GetById(object id)
        {

            return currentSession.Get<T>(id);
        }

        public void ExecuteStoredProcedureUpdate(string StoredName, params object[] parameters)
        {
            var str = new List<string>();
            for (int j = 0; j < parameters.Length; j++)
                str.Add("?");
            var St = String.Join(" , ", str);

            var query = currentSession.CreateSQLQuery("exec " + StoredName + " " + St);
            int i = 0;
            foreach (object obj in parameters)
            {
                query.SetParameter(i, obj);
                ++i;
            }
            query.ExecuteUpdate();

        }

        public void StartTransaction()
        {
            currentSession.Transaction.Begin();
        }

        public void CommitTransaction()
        {
            currentSession.Transaction.Commit();
        }
        public void RollBackTransaction()
        {
            currentSession.Transaction.Rollback();
        }

        public void SaveOrUpdate(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("Invalid Object " + entity.GetType().Name);
                currentSession.SaveOrUpdate(entity);
                currentSession.Flush();
                currentSession.Refresh(entity);
            }
            catch (Exception ex)
            {
                NHibernateHelper.CloseSession();
                //throw new GlamryException("Unable to save Entity of type : " + entity.GetType().Name + " REASON::: " + ex.Message);

            }
        }

        public void Flush()
        {
            currentSession.Clear();
            currentSession.Flush();
        }
        public void Delete(T entity)
        {
            using (ITransaction trans = currentSession.BeginTransaction())
            {
                try
                {
                    if (entity == null)
                        throw new ArgumentNullException("Invalid Object " + entity.GetType().Name);
                    currentSession.Delete(entity);

                    currentSession.Flush();

                    trans.Commit();
                }
                catch (Exception ex)
                {

                    trans.Rollback();
                    NHibernateHelper.CloseSession();
                    //throw new GlamryException("Unable to Delete Entity of type : " + entity.GetType().Name + " REASON::: " + ex.Message);

                }
            }
        }
        /// <summary>
        /// This returns all the Entities in a particular Type and transform to IQueryable
        /// </summary>
        public IQueryable<T> Table
        {

            //using (ITransaction trans = currentSession.BeginTransaction())
            // {

            //try
            //{
            get
            {
                ICriteria icrit = currentSession.CreateCriteria<T>();
                return icrit.Future<T>().AsQueryable<T>();

            }
        }
        public void Refresh(T entity)
        {
            currentSession.Refresh(entity);
        }
    }
}
