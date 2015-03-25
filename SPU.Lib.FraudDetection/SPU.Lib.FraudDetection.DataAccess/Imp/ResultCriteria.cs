using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fanex.NAP.Framework.Data;

namespace SPU.Lib.FraudDetection.DataAccess.Imp
{
    /// <summary>
    /// Class ResultCriteria.
    /// </summary>
    public class ResultCriteria : CriteriaBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultCriteria"/> class.
        /// </summary>
        public ResultCriteria()
        {
            ErrCode = 0;
            ErrMsg = string.Empty;
        }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }
    }
}
