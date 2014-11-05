using System;
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
        static int time = 0;
        static List<int> atomList = new List<int>();

          

        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Exponential Decay Model - Made by Jamie Sinn");
            while (true)
            {
                string input;
                int atoms;
                Console.WriteLine("Please enter the number of atoms that you will be decaying");
                input = Console.ReadLine();
                if(input.Equals("auto"))
                {
                    Console.WriteLine("Enter the starting value for the automatic processing: ");
                    input = Console.ReadLine();
                    atoms = Convert.ToInt32(input);
                    AutomaticProcessing(atoms);
                }
                atoms = Convert.ToInt32(input);
                GenerateAtoms(atoms);
                DecayAtoms();
                Console.WriteLine("In this batch, there were {0} atoms decayed.", GetDecayedAtoms());
                Console.WriteLine("Simulation over, please press enter to continue");
                ResetAllAtoms();
            }
            
        }

        static void AutomaticProcessing(int atoms)
        {
            int currentatoms = atoms;
            while(currentatoms > 0)
            {
                
                GenerateAtoms(currentatoms);
                DecayAtoms();
                currentatoms = currentatoms - GetDecayedAtoms();
                time++;
                Console.WriteLine("Atoms: {0} Decayed: {1} Hour: {2}", currentatoms, atomsDecayed, time);
                ResetAllAtoms();
                
            }
            
        }
        static void ResetAllAtoms()
        {
            atomsDecayed = 0;
            atomList.Clear();
            atomCount = 0;
            
        }
        static void DecayAtoms()
        {
            for (int i = 0; i < atomList.Count; i++)
            {
                if (i != null)
                {
                    float a = atomList.ElementAt(i) * 0.1f;
                    if (a.Equals(1))
                    {
                        atomsDecayed++;
                    }
                }


            }
               
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
        static int GetDecayedAtoms()
        {
            return atomsDecayed;
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
