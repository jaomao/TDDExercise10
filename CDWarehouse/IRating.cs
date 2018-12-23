using System;

namespace CDWarehouse
{
    public interface IRating
    {
        double Rate { get; }

        string Review { get; }
    }
}