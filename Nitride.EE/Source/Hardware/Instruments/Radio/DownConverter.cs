﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nitride.EE
{
    public class DownConverter //: WaveFormReceiver
    {


        public bool IsUpSide { get; set; }

        public LocalOscillator LocalOscillator { get; set; }

        public WaveFormReceiver Receiver { get; set; }

        public double RF_Frequency { get; set; }


        // public override double Bandwidth { get; set; }

        // public override double CenterFrequency { get; set; }
    }
}
