using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeMacroData
{
    class MacroDataClass
    {
        public enum MacroType
        {
            Type1,
            Type2,
            Type3
        };

        public class MacroData
        {
            public int id;
            public char key;
            public string desctiption;
            public MacroType type;
            public string code;

            public MacroData(int _id, char _key, string _desctiption,MacroType _type,string _code)
            {
                this.id = _id;
                this.key = _key;
                this.desctiption = _desctiption;
                this.type = _type;
                this.code = _code;
            }
            public override string ToString()
            {
                return "ID: " + this.id +
                       "Key: " + this.key +
                       "Description: " + this.desctiption +
                       "Type: " + this.type +
                       "Code: " + this.code;
            }
            public string ToCvrString()
            {
                return this.id + ";" +
                       this.key + ";" +
                       this.desctiption + ";" +
                       this.type + ";" +
                       this.code;
            }
        }

        static void Main(string[] args)
        {
            List<MacroData> listMacroData = new List<MacroData>();

            listMacroData.Add(new MacroData(1, 'A', "Pass1", MacroType.Type1, "Dette er mit hemmelige password 1"));
            listMacroData.Add(new MacroData(2, 'S', "Pass2", MacroType.Type1, "Dette er mit hemmelige password 2"));
            listMacroData.Add(new MacroData(3, 'B', "Kommentar", MacroType.Type1, "// Obtain RSH Opgave 1.101"));

            WriteListMacroDataToConsole(listMacroData);
            SaveListMacroDataToFile(listMacroData);

        }

        private static void SaveListMacroDataToFile(List<MacroData> listMacroData)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\MactoData.txt"))
                foreach (MacroData aMacroData in listMacroData)
                {
                    file.WriteLine(aMacroData);
                }
        }

        private static void WriteListMacroDataToConsole(List<MacroData> listMacroData)
        {
            Console.WriteLine();
            foreach (MacroData aMacroData in listMacroData)
            {
                Console.WriteLine(aMacroData);
            }
            Console.ReadKey();
        }
    }
}
