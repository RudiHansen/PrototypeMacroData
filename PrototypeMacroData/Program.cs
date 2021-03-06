﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeMacroData
{
    class MacroDataClass
    {
        const string fileName = @"C:\Temp\MactoData.txt";
        const string fieldSeperator = ";";
        public enum MacroType
        {
            Type1,
            Type2,
            Type3
        };

        public class MacroData
        {
            public int id;
            public string key;
            public string description;
            public MacroType type;
            public string code;

            public MacroData(int _id, string _key, string _description,MacroType _type,string _code)
            {
                this.id = _id;
                this.key = _key;
                this.description = _description;
                this.type = _type;
                this.code = _code;
            }
            public MacroData(string _csvString)
            {
                string[] fields = _csvString.Split(char.Parse(fieldSeperator));
                this.id = int.Parse(fields[0]);
                this.key = fields[1];
                this.description = fields[2];
                this.type = (MacroType)Enum.Parse(typeof(MacroType), fields[3]);
                this.code = fields[4];
            }

            public override string ToString()
            {
                return "ID: " + this.id +
                       "Key: " + this.key +
                       "Description: " + this.description +
                       "Type: " + this.type +
                       "Code: " + this.code;
            }
            public string ToCsvString()
            {
                return this.id + fieldSeperator +
                       this.key + fieldSeperator +
                       this.description + fieldSeperator +
                       this.type + fieldSeperator +
                       this.code;
            }
        }

        static void Main(string[] args)
        {
            List<MacroData> listMacroData = new List<MacroData>();

            LoadListMacroDataFromFile(listMacroData);
            
            //listMacroData.Add(new MacroData(1, "A", "Pass1", MacroType.Type1, "Dette er mit hemmelige password 1"));
            //listMacroData.Add(new MacroData(2, "S", "Pass2", MacroType.Type1, "Dette er mit hemmelige password 2"));
            //listMacroData.Add(new MacroData(3, "B", "Kommentar", MacroType.Type1, "// Obtain RSH Opgave 1.101"));

            WriteListMacroDataToConsole(listMacroData);
            SaveListMacroDataToFile(listMacroData);

        }

        private static void LoadListMacroDataFromFile(List<MacroData> listMacroData)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    listMacroData.Add(new MacroData(line));
                }
            }
        }

        private static void SaveListMacroDataToFile(List<MacroData> listMacroData)
        {
            using (StreamWriter file = new StreamWriter(fileName))
                foreach (MacroData aMacroData in listMacroData)
                {
                    file.WriteLine(aMacroData.ToCsvString());
                }
        }

        private static void WriteListMacroDataToConsole(List<MacroData> listMacroData)
        {
            Console.WriteLine();
            foreach (MacroData aMacroData in listMacroData)
            {
                Console.WriteLine(aMacroData.ToCsvString());
            }
            Console.ReadKey();
        }
    }
}
