using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Alliance.APP.Domain.Abstractions;
public interface IEntity
{
    int Id { get; set; }
    DateTime Created { get; set; }
}
