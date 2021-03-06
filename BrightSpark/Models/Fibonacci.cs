﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrightSpark.Models
{
    public class Fibonacci
    {

        /// <summary>
        /// Return the fibonachi object consisting of the number requested and nth number in the sequence 
        /// based on n (iterative approach).
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public FibonacciStruct GetNthFibonacciNumberIterative(uint n)
        {
            FibonacciStruct fb = new FibonacciStruct();
            fb.numberRequested = n;

            if (n == 1 || n == 2)
            {
                fb.nthNumberOfFibonacciSequence = 1;
            }

            uint firstNumber = 1;
            uint secondNumber = 1;
            uint result = 0;

            for (uint i = 3; i <= n; i++)
            {
                result = secondNumber + firstNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            }

            fb.nthNumberOfFibonacciSequence = result;
            return fb;
        }


    }

    /// <summary>
    /// Structure containing the value of n that we are requesting, and the nth number in the Fibonacci sequence
    /// </summary>
    public struct FibonacciStruct
    {
        public uint numberRequested;
        public uint nthNumberOfFibonacciSequence;
    }
}
