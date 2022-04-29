using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{
    public interface IGameListner
    {
        void Notify(GameEvent gameEvent);
    }
}
