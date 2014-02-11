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

        //public interface IMacroData
        //{
        //}
        public class MacroData //: IMacroData
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
        }
        public class ListMacroData
        {
            private List<MacroData> macroDataList;

            public ListMacroData()
            {
                macroDataList = new List<MacroData>();
            }

            public bool SaveData(MacroData _macroData)
            {
                int position = 0;
                for (position = 0; position < macroDataList.Count; position++)
                {
                    if (macroDataList[position] == null)
                    {
                        macroDataList[position] = _macroData;
                        return true;
                    }
                }
                return false;
            }

            public MacroData LoadData(int _id)
            {
                int position = 0;
                for (position = 0; position < macroDataList.Count; position++)
                {
                    if (macroDataList[position] == null)
                    {
                        continue;
                    }
                    if (macroDataList[position].id == _id)
                    {
                        return macroDataList[position];
                    }
                }
                return null;
            }

            public void PrintAccountList()
            {
                int position = 0;
                for (position = 0; position < macroDataList.Count; position++)
                {
                    if (macroDataList[position] == null)
                    {
                        continue;
                    }
                    Console.WriteLine(macroDataList[position].ToString());
                }
            }
        }

        static void Main(string[] args)
        {
            ListMacroData listMacroData = new ListMacroData();

            listMacroData.SaveData(new MacroData(1, 'A', "Pass1", MacroType.Type1, "Dette er mit hemmelige password 1"));
            listMacroData.SaveData(new MacroData(2, 'S', "Pass2", MacroType.Type1, "Dette er mit hemmelige password 2"));
            listMacroData.SaveData(new MacroData(3, 'B', "Kommentar", MacroType.Type1, "// Obtain RSH Opgave 1.101"));

            listMacroData.PrintAccountList();
            Console.ReadKey();
        }
    }
}
