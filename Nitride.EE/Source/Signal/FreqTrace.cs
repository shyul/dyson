﻿/// ***************************************************************************
/// Nitride Shared Libraries and Utilities
/// Copyright 2001-2008, 2014-2021 Xu Li - me@xuli.us
/// 
/// SampleBuffer
/// 
/// ***************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Nitride.EE
{
    public class FreqPoint
    {
        public double Frequency { get; set; }

        public Complex Value { get; set; }

        public double Magnitude => Value.Magnitude;


        // Calculate these after Detection!!
        // public double MagOffset { get; set; } = 0;


        // public double DbMag => (20 * Math.Log10(Value.Magnitude)) - MagOffset;
    }

    public class FreqTrace
    {

        // public 

        public List<FreqPoint> Data { get; }
    }

    public enum SweepMode
    {
        FFT, // FFT Frame Length
        DDC, // DDC FFT Detector Length x Points (A.k.a Multi FFT frame merged)
        Analog, // Points (dewelling time), FFT Detector Length
    }
}