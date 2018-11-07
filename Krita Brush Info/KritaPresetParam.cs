using System;
using System.Collections;
using System.Text;
using System.Xml.Linq;

namespace KritaBrushInfo {
    class KritaPresetParam : IComparer {
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
            } catch (Exception ex) {
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

        public bool equalsExceptType(KritaPresetParam param) {
            if (this.name.Equals(param.name) && this.value.Equals(param.value)) {
                return true;
            }
            return false;
        }

        public bool equals(KritaPresetParam param) {
            if (this.name.Equals(param.name) && this.type.Equals(param.type)
                && this.value.Equals(param.value)) {
                return true;
            }
            return false;
        }

        public int Compare(KritaPresetParam x, KritaPresetParam y) {
            return ((KritaPresetParam)x).name.CompareTo(((KritaPresetParam)y).name);
        }

        public int Compare(object x, object y) {
            throw new NotImplementedException();
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Value { get => value; set => this.value = value; }
        public bool Err { get => err; set => err = value; }
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
    }
}
