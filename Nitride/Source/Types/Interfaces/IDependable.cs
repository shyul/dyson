﻿/// ***************************************************************************
/// Shared Libraries and Utilities
/// Copyright 2001-2008, 2014-2021 Dyson Project - me@xuli.us
/// 
/// ***************************************************************************

using System.Collections.Generic;

namespace Nitride
{
    public interface IDependable
    {
        /// <summary>
        /// For Identification
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Enabled
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Dispose itself
        /// </summary>
        void Remove(bool recursive);

        /// <summary>
        /// Downstream objects, objects depend on this objects.
        /// </summary>
        ICollection<IDependable> Children { get; }

        /// <summary>
        /// Upstream objects, objects depending to...
        /// </summary>
        ICollection<IDependable> Parents { get; }
    }
}
