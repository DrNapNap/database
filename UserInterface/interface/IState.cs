using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{
    public interface IState
    {
        void Execute();

        void Exit();

    }
}
