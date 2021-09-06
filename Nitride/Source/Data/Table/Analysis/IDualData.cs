﻿/// ***************************************************************************
/// Shared Libraries and Utilities
/// Copyright 2001-2008, 2014-2021 Dyson Project - me@xuli.us
/// 
/// ***************************************************************************
/// 
using System.Drawing;

namespace Nitride
{
    public interface IDualData : IDependable
    {
        NumericColumn Column_High { get; }

        NumericColumn Column_Low { get; }

        Color UpperColor { get; }

        Color LowerColor { get; }
    }
}
