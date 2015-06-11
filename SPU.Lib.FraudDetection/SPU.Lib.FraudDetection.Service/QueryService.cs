// --------------------------------------------------------------------------
// <copyright file="QueryService.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Service
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Data;
    using Fanex.NAP.Framework.Command;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.DataAccess;

    /// <summary>
    /// Query Service.
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
        /// Execute Non Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Command result.</returns>
        public ICommandResult ExecuteNonQueryInline(string sqlQueryString)
        {
            var baseDataAccess = new BaseDataAccess();

            return baseDataAccess.ExecuteNonQueryInline(sqlQueryString);
        }

        /// <summary>
        /// Execute Reader Query Inline.
        /// </summary>
        /// <param name="sqlQueryString">Query string.</param>
        /// <returns>Data table.</returns>
        public DataTable ExecuteReaderQueryInline(string sqlQueryString)
        {
            var baseDataAccess = new BaseDataAccess();

            return baseDataAccess.ExecuteReaderQueryInline(sqlQueryString);
        }
    }
}