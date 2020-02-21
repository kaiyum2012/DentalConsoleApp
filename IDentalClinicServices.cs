using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp

{
    public enum DentalServicesEnum
    {
        NONE = 0,
        CLEARNING,
        CAVITY_FILL,
        CHECK_UP,
        X_RAY,
        FITTING
    }

    interface IDentalClinicServices
    {
        public void Cleaning();
        public void CavityFill();
        public void CheckUp();
        public void XRay();

        public void Fittings();

    }
}
