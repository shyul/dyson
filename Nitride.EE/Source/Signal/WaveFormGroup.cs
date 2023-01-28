﻿/// ***************************************************************************
/// Nitride Shared Libraries and Utilities
/// Copyright 2001-2008, 2014-2023 Xu Li - me@xuli.us
/// 
/// SampleBuffer
/// 
/// ***************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Nitride.EE
{
    public class WaveFormGroup
    {
        public WaveFormGroup(int numOfCh, int maxLength)
        {
            WaveForms = new WaveForm[numOfCh];

            for (int i = 0; i < numOfCh; i++)
            {
                WaveForms[i] = new WaveForm(maxLength);
            }

            Length = maxLength;
        }

        public bool HasUpdatedItem
        {
            get => WaveForms.Where(n => n.IsUpdated).Count() > 0;
            set => WaveForms.RunEach(n => n.IsUpdated = value);
        }

        public int NumOfCh => WaveForms.Length;

        public int Length { get; set; }

        public double SampleRate
        {
            get => WaveForms.First().SampleRate;
            
            set
            {
                WaveForms.RunEach(n => n.Configure(value));
            }
        }

        public WaveForm[] WaveForms { get; }

        /// <summary>
        /// Copy from DataBuffer
        /// </summary>
        /// <param name="source"></param>
        /// <param name="format"></param>
        /// <param name="offset"></param>
        /// <returns>Samples Copied</returns>
        public int CopyData(DataBuffer source, DataBufferFormat format, double gain, double shift, int offset = 0)
        {
            int i, j;
            int pt = 0;
            int num = NumOfCh;
            int count = (Length * NumOfCh) + offset; // R16 = 1, C32 = 2, C32 Dual = 4

            switch (format)
            {
                default:
                case DataBufferFormat.S16:
                    for (i = offset; i < count; i += num)
                    {
                        for (j = 0; j < num; j++)
                        {
                            WaveForms[j].Data[pt] = (new Complex((source.S16[i + j] * gain) + shift, 0)) ;
                        }
                        pt++;
                    }
                    break;
                case DataBufferFormat.DS16:
                    for (i = offset; i < count; i += num)
                    {
                        for (j = 0; j < num; j++)
                        {
                            WaveForms[j].Data[pt] = new Complex((source.DS16[i + j].D1 * gain) + shift, (source.DS16[i + j].D2 * gain) + shift);
                        }
                        pt++;
                    }
                    break;
                case DataBufferFormat.S32:
                    for (i = offset; i < count; i += num)
                    {
                        for (j = 0; j < num; j++)
                        {
                            WaveForms[j].Data[pt] = new Complex((source.S32[i + j] * gain) + shift, 0);
                        }
                        pt++;
                    }
                    break;
                case DataBufferFormat.DS32:
                    for (i = offset; i < count; i += num)
                    {
                        for (j = 0; j < num; j++)
                        {
                            WaveForms[j].Data[pt] = new Complex((source.DS32[i + j].D1 * gain) + shift, (source.DS32[i + j].D2 * gain) + shift);
                        }
                        pt++;
                    }
                    break;
                case DataBufferFormat.S64:
                    for (i = offset; i < count; i += num)
                    {
                        for (j = 0; j < num; j++)
                        {
                            WaveForms[j].Data[pt] = new Complex((source.S64[i + j] * gain) + shift, 0);
                        }
                        pt++;
                    }
                    break;
                case DataBufferFormat.DS64:
                    for (i = offset; i < count; i += num)
                    {
                        for (j = 0; j < num; j++)
                        {
                            WaveForms[j].Data[pt] = new Complex((source.DS64[i + j].D1 * gain) + shift, (source.DS64[i + j].D2 * gain) + shift);
                        }
                        pt++;
                    }
                    break;
            }

            for (j = 0; j < num; j++)
            {
                WaveForms[j].IsUpdated = true;
            }

            return pt;
        }
    }
}
