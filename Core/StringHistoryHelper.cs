using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdevpopcreator
{
    internal class StringHistoryHelper
    {

        private String history;

        public void setHistory(string history) { this.history += history; }
        public void resetHistory() {  this.history = ""; }
        public String getHistory() { return this.history; } 
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
