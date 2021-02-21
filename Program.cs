﻿using System;
using System.Threading.Tasks;       // needed for Task object for PostAsync
using OpenSRSLib;                   // needed to change encoding for StringWriter from utf-16

namespace opensrsApi
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Lookup Domain   
            Lookup req = new Lookup("weomedia.com");
            Task.Run((Func<Task>)(() => req.Post()));
            Console.Read();

        }   
    }
}