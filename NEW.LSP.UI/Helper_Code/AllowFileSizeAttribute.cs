using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NEW.LSP.UI.Helper_Code
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowFileSizeAttribute : ValidationAttribute
    {
        #region Public / Protected Properties  

        /// <summary>  
        /// Gets or sets file size property. Default is 1GB (the value is in Bytes).  
        /// </summary>  
        public int FileSize { get; set; } = 1 * 1024 * 1024 * 1024;

        #endregion

        #region Is valid method  

        /// <summary>  
        /// Is valid method.  
        /// </summary>  
        /// <param name="value">Value parameter</param>  
        /// <returns>Returns - true is specify extension matches.</returns>  
        public override bool IsValid(object value)
        {
            // Initialization  
            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = true;

            // Settings.  
            int allowedFileSize = this.FileSize;

            // Verification.  
            if (file != null)
            {
                // Initialization.  
                var fileSize = file.ContentLength;

                // Settings.  
                isValid = fileSize <= allowedFileSize;
            }

            // Info  
            return isValid;
        }
        #endregion
    }
}