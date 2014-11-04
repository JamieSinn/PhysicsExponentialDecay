﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;


namespace Exponential_Decay_Application
{
    class Program
    {
        static int atomCount = 200;
        static float decayPct = 0.1f;
        static int atomsDecayed = 0;
        static List<int> atomList = new List<int>();

          

        static void Main(string[] args)
        {

        }
        static int DecayAttoms()
        {

            return 0;
        }
        static void GenerateAtoms(int count)
        {
            for (int i = 0; i <= count; i++)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 11);
                atomList.Add(randomNumber);
                WriteToFile(randomNumber.ToString(), 1);

            }
        }
        static void GetDecayedAtoms()
        {
            foreach(int a in atomList)
            {
                if(a.Equals(1))
                {
                    atomsDecayed++;
                }
            }
        }
        static void WriteToFile(string line, int type)
        {
            string path;
            switch (type)
            {
                
                case 0:
                    path = @"C:\Users\Jamie\AppData\Roaming\Physics\DecayedAtoms.txt";
                    if (!File.Exists(path))
                    {
                        File.Create(path);
                        using (StreamWriter writer = new StreamWriter(path, true))
                        {
                            writer.WriteLine(line);
                        }
                    }
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(line);
                    }
                    break;
                case 1:
                    path = @"C:\Users\Jamie\AppData\Roaming\Physics\Atoms.txt";
                    if (!File.Exists(path))
                    {
                        File.Create(path);
                        using (StreamWriter writer = new StreamWriter(path, true))
                        {
                            writer.WriteLine(line);
                        }
                    }
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(line);
                    }
                    break;
                    
            }

        }
        

    }
}
