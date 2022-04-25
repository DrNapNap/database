using System;

namespace database
{
    public interface IReading
    {

        event Action<int> OnActualUpdate;
        int Actluel { get; set; }


        int GetVariance();

        VarianceCategory GetVarianceCategory();

    }
}