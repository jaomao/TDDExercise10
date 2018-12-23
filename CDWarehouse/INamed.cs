using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDWarehouse
{
    public interface INamed
    {
        string Title { get; }

        string Author { get; }
    }
}
