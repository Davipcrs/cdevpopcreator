using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// @DOCSTART
// ### StringHistoryHelper.cs (StringHistoryHelper) @NL
// File is used to be a single data repository for the KeyboardMouseClickManager Threads @NL
// @DOCEND

namespace cdevpopcreator
{
    internal class StringHistoryHelper
    {

        private String history;

        public void setHistory(string history) { this.history += history; }
        public void resetHistory() {  this.history = ""; }
        public String getHistory() { return this.history; } 

        public void backspace()
        {
            this.history = this.history.Remove(this.history.Length - 1);
        }
        private StringHistoryHelper() { }

        private static StringHistoryHelper _instance;
        public static StringHistoryHelper getInstance()
        {
            if (_instance == null)
            {
                _instance = new StringHistoryHelper();

            }
            return _instance;
        }
    }
}
