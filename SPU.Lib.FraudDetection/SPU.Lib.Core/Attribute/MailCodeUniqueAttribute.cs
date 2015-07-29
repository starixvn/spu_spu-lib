// --------------------------------------------------------------------------
// <copyright file="MailCodeUniqueAttribute.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Aaron.Cao" date="2015.06.16">Created</change>
// </history>

namespace FD.Lib.Core.Attribute
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fanex.Data;

    /// <summary>
    ///     This class is to create a custom validation.
    /// </summary>
    public class MailCodeUniqueAttribute : ValidationAttribute
    {
        /// <summary>
        ///     The override method.
        /// </summary>
        /// <param name="value">Value to be validated.</param>
        /// <param name="validationContext">The validationContext.</param>
        /// <returns>The ValidationResult.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var mailCode = value != null ? value.ToString() : string.Empty;

            using (var db = new ObjectDb("FD_MailMasterGetAll"))
            {
                var result = db.Query<dynamic>();

                var count = result.Count(x => x.MailCode.Equals(mailCode));

                if (count != 0)
                {
                    return new ValidationResult("This mail code has already existed.");
                }
            }

            return ValidationResult.Success;
        }
    }
}