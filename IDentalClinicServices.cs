using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DentalConsoleApp

{
    public enum DentalServicesEnum
    {
        NONE = 0,
        [Description("General : Cleaning")]
        CLEARNING,
        [Description("General : Cavity Filling")]
        CAVITY_FILL,
        [Description("General : Check Up")]
        CHECK_UP,
        [Description("General : X ray")]
        X_RAY,
        [Description("Special : Fittings (Children - braces, Adult - Veneers,Seniors - dentures )")]
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
