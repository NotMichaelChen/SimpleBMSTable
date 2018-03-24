using System;

namespace SimpleBMSTable.TableInfo
{
    //Contains metadata about the given table
    public struct TableHeader
    {
        //Mandatory
        public string data_url;
        public string name;
        public string symbol;
        //Optional
        public string[] level_order;
        public string tag;
    }
}
