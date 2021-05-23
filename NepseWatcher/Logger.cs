using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NepseWatcher
{
    public class Logger
    {
        private TextBox output;
        public Logger(TextBox textbox)
        {
            output = textbox;
        }

        public void Log(string text)
        {
            output.AppendText( DateTime.Now.ToString("hh:mm:ss tt") + " : " + text + "\r\n");
        }

        public void WriteLine(string text)
        {
            output.AppendText(text+"\r\n");
        }
    }
}
