// --------------------------------------------------------------------------
// <copyright file="Extentions.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.4.27">Create</change>
// </history>

namespace SPU.Lib.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Extentions
    {
        /// <summary>
        /// Break a list of items into chunks of a specific size.
        /// </summary>
        /// <typeparam name="T">Delegate object.</typeparam>
        /// <param name="source">Source object.</param>
        /// <param name="chunksize">Chunk size.</param>
        /// <returns>List of delegate object.</returns>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
}
