using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHarpSocialNetworkManager.Utilitis._Log
{
    public interface ILogs<T>
    {
        void saveLog(T action);

    }
}
