﻿/*
    Copyright 2017 University of Toronto

    This file is part of TMG-Framework for XTMF2.

    TMG-Framework for XTMF2 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    TMG-Framework for XTMF2 is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with TMG-Framework for XTMF2.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;

namespace TMG
{
    public sealed class Vector
    {
        public Map Map { get; private set; }
        public float[] Data { get; private set; }

        public Vector(Map map)
        {
            Map = map;
            Data = new float[Map.Count];
        }

        public Vector(Vector vector)
        {
            Map = vector.Map;
            Data = new float[Map.Count];
        }

        public float this[int sparseIndex]
        {
            get
            {
                var index = Map.GetFlatIndex(sparseIndex);
                if(index >= 0)
                {
                    return Data[index];
                }
                return 0.0f;
            }

            set
            {
                var index = Map.GetFlatIndex(sparseIndex);
                if (index >= 0)
                {
                    Data[index] = value;
                }
                throw new ArgumentOutOfRangeException(nameof(sparseIndex));
            }
        }
    }
}