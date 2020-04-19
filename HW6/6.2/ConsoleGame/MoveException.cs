using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    /// <summary>
    /// Throws when user is trying move @ to wall or edge of the map
    /// </summary>
    class MoveException: SystemException
    {
    }
}
