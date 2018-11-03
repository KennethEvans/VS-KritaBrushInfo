using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KritaBrushInfo {
    class KritaPresetParam {
        public readonly String NL = Environment.NewLine;
        private string name;
        private string type;
        private string value;
        private bool err;
        private string errorMessage;

        public KritaPresetParam(XElement element) {
            err = false;
            errorMessage = "No error";
            if (element == null) {
                err = true;
                errorMessage = "Element is null";
                return;
            }
            try {
                name = element.Attribute("name").Value.ToString();
                type = element.Attribute("type").Value.ToString();
                value = element.Value.ToString();
            } catch(Exception ex) {
                err = true;
                errorMessage = ex.Message;
                return;
            }
        }

        public String info() {
            StringBuilder info;
            info = new StringBuilder();
            info.Append(name);
            info.Append(" [").Append(type).Append("]");
            info.Append(NL);
            info.Append("   ").Append(value);
            info.Append(NL);
            return info.ToString();
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public bool Err { get => err; set => err = value; }
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
    }
}
