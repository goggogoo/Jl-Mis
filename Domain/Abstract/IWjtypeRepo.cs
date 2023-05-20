using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IWjtypeRepo
    {
        IEnumerable<WJ_TYPE> Wj_types { get; }
    }
}
