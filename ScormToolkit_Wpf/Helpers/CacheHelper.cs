using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ScormToolkit_Wpf.Helpers
{
    //todo:add cache https://msdn.microsoft.com/library/dd997362(v=vs.100).aspx
    public class CacheHelper
    {
        void Init()
        {
            ObjectCache cache = MemoryCache.Default;
        }
    }
    
}
