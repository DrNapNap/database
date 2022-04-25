using System;

namespace database
{
    public class Reading : IReading
    {

        public event Action <int> OnActualUpdate;
        private int actluel;


        public int Actluel { get { return actluel; } set { actluel = value; PostActuaalUdated(); } }




        private void PostActuaalUdated ()
        {
            OnActualUpdate?.Invoke(GetVariance());
        }


        public int GetVariance()
        {
            if (Actluel % 2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public VarianceCategory GetVarianceCategory()
        {
            if (GetVariance() == 0)
            {
                return VarianceCategory.Normal;
            }
           else
            {
                return VarianceCategory.Severe;
            }

        }

    }
}
