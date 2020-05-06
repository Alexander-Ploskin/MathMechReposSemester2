using System;

namespace ConsoleGame
{
    /// <summary>
    /// Throws when user is trying move @ to wall or edge of the map
    /// </summary>
    class MoveException : SystemException
    {
    }
}
