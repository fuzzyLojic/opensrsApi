// necessary to change default encoding of StringWriter from utf-16
using System;
using System.IO;
using System.Text;

namespace OpenSRSLib
{
    public class Utf8StringWriter : StringWriter {
        public override Encoding Encoding{ get { return Encoding.UTF8; } }
    }
}

