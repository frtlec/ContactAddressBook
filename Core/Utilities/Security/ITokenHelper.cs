using Core.Entities.Concrete;
using IFSE.Business.Utilities.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
        AccessToken CreateToken(EsitUser esitUser);
    }
}
