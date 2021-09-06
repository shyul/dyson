﻿/// ***************************************************************************
/// Shared Libraries and Utilities
/// Copyright 2001-2008, 2014-2021 Dyson Project - me@xuli.us
/// 
/// ***************************************************************************

using System.Drawing;

namespace Nitride
{
    public interface IStackable : IOrdered, ICoordinatable
    {
        Point DropMenuOriginPoint { get; }

        bool IsSectionEnd { get; set; }

        bool IsLineEnd { get; set; }

        int StackedY { get; set; }

        int SectionIndex { get; set; }
    }
}
