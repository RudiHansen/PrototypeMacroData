using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeMacroData
{
    class MacroDataClass
    {
        enum MacroType
        {
            Type1,
            Type2,
            Type3
        };

        // Skal lige se om jeg kan klare mig uden interface.
        /*
        public interface IMacroData
        {
            int id { get; }
            char key { get; set; }
            string description { get; set; }
            MacroType type { get; set; }
            string code { get; set; }

        }
         */
        public class MacroData //: IMacroData
        {
            int id;
            char key;
            string desctiption;
            MacroType type;
            string code;

            public MacroData(int _id, char _key, string _desctiption,MacroType _type,string _code)
            {
                this.id = _id;
                this.key = _key;
                this.desctiption = _desctiption;
                this.type = _type;
                this.code = _code;
            }
        }


        static void Main(string[] args)
        {
            MacroData macroData = new MacroData(1, 'A', "Pass1", MacroType.Type1, "Dette er mit hemmelige password 1");

        }
    }
}
