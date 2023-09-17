using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beqom.Domain.Aggregate.Option
{
    public interface IOption<out T>
    {
        T FromValue();
    }
}
