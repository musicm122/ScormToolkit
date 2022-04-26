using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScormToolkit_Wpf.Model
{
    public class SortField
    {
        public string DisplayName { get; set; }
        public string PropertyName { get; set; }
    }

    public class SortFieldList : List<SortField>
    {
    }
}
