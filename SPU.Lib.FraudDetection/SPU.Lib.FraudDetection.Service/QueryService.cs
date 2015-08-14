// --------------------------------------------------------------------------
// <copyright file="QueryService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace FD.Lib.Service
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using DataAccess;
    using Fanex.Common.Helper;
    using Fanex.Data;
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;

    /// <summary>
    ///     Query Service.
    /// </summary>
    public class QueryService
    {
        private readonly IDynamicRepository _repository;

        public QueryService(IDynamicRepository repository = null)
        {
            _repository = repository ?? new DynamicRepository();
        }

        public virtual IEnumerable<T> GetData<T>(ICriteria criteria)
        {
            return _repository.Fetch<T>(criteria);
        }

        public virtual IEnumerable<T> GetData<T>(dynamic paramaters)
        {
            return _repository.Query<T>(paramaters);
        }

        public virtual T Get<T>(ICriteria criteria)
        {
            return _repository.Get<T>(criteria);
        }

        /// <summary>
        ///     Get Data by template.
        /// </summary>
        /// <typeparam name="T">Delegate object.</typeparam>
        /// <param name="criteria">Input criteria.</param>
        /// <param name="totalPages">Total Pages.</param>
        /// <returns>List of delegate objects.</returns>
        public IEnumerable<T> GetData<T>(ICriteria criteria, ref int totalPages)
        {
            using (var objectDb = new ObjectDb(criteria.GetSettingKey()))
            {
                var param = criteria.GetSpParams();
                var list = objectDb.Query<T>(param);
                totalPages = Convert.ToInt32(param["totalpages"]);

                return list;
            }
        }

        /// <summary>
        ///     Execute Non Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Command result.</returns>
        public ICommandResult ExecuteNonQueryInline(string sqlQueryString)
        {
            var baseDataAccess = new BaseDataAccess();

            return baseDataAccess.ExecuteNonQueryInline(sqlQueryString);
        }

        /// <summary>
        ///     Execute Reader Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Data table.</returns>
        public DataTable ExecuteReaderQueryInline(string sqlQueryString)
        {
            var baseDataAccess = new BaseDataAccess();

            return baseDataAccess.ExecuteReaderQueryInline(sqlQueryString);
        }

        /// <summary>
        /// Get output values.
        /// </summary>
        /// <param name="criteria">Input criteria.</param>
        public void ExecuteOutput(ICriteria criteria)
        {
            using (var objectDb = new ObjectDb(criteria.GetSettingKey()))
            {
                var param = criteria.GetSpParams();
                objectDb.ExecuteNonQuery(param);

                var outputParams = objectDb.GetOuputParams();
                var properties = criteria.GetType().GetProperties();
                foreach (string outputParam in outputParams.Keys)
                {
                    foreach (var property in properties)
                    {
                        if (property.CanWrite && property.Name.ToLower() == outputParam)
                        {
                            property.SetValue(criteria, param[outputParam] == DBNull.Value ? null : param[outputParam], null);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the list of found entities and output values.
        /// </summary>
        /// <typeparam name="T">General type.</typeparam>
        /// <param name="criteria">Input criteria.</param>
        /// <returns>The list of found entities and output values.</returns>
        public IEnumerable<T> GetDataOutput<T>(ICriteria criteria)
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            using (var objectDb = new ObjectDb(criteria.GetSettingKey()))
            {
                IEnumerable<T> list = new List<T>();

                try
                {
                    var param = criteria.GetSpParams();
                    list = objectDb.Query<T>(param);

                    var outputParams = objectDb.GetOuputParams();

                    if (outputParams != null)
                    {
                        var properties = criteria.GetType().GetProperties();

                        foreach (string outputParam in outputParams.Keys)
                        {
                            foreach (var property in properties)
                            {
                                if (property.CanWrite && property.Name.ToLower() == outputParam)
                                {
                                    property.SetValue(criteria, param[outputParam], null);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }

                return list;
            }
        }
    }
}