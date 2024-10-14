using IMF.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IMF.DAL.Models.Common
{
    public static class ExtendedMethods_4_Principal
    {
        public static int GetUserId(this IIdentity _identity)
        {
            int _retVal = 0;
            try
            {
                if (_identity != null && _identity.IsAuthenticated)
                {
                    var ci = _identity as ClaimsIdentity;
                    string _userId = ci != null ? ci.FindFirstValue(ClaimTypes.NameIdentifier) : null;

                    if (!string.IsNullOrEmpty(_userId))
                    {
                        _retVal = int.Parse(_userId);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _retVal;
        }

        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            string _retVal = string.Empty;
            try
            {
                if (identity != null)
                {
                    var claim = identity.FindFirst(claimType);
                    _retVal = claim != null ? claim.Value : null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _retVal;
        }
    }
}
