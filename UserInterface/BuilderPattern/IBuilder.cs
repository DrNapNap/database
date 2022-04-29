using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{
    interface IBuilder
    {
        void BuildGameObject();

        GameObject GetResult();

    }
}
