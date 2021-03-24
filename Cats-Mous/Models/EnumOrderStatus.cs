using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cats_Mous.Models
{
    public enum EnumOrderStatus
    {
        RegisteredButNotPaid = 0,
        SuccessfullyPaid = 2,
        AuthorizationCanceled,
        OrderIsBeingProcessed = 7
    }
}
