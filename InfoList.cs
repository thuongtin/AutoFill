using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFill
{
    class InfoList
    {
        public List<Info> ListInfo { get; set; }
        private int colorId;
        private ColorList colorList;
        public Info this[int index]
        {
            get
            {
                return ListInfo[index];
            }
        }
        public int Count
        {
            get
            {
                return ListInfo.Count;
            }
        }
        public InfoList()
        {
            ListInfo = new List<Info>();
            colorId = 0;
            colorList = new ColorList();
        }

        public InfoList(String text)
            : this()
        {
            Set(text);
        }

        public void Set(String text)
        {
            colorId = 0;
            ListInfo.Clear();
            var arr = text.Split('\n');
            foreach (String str in arr)
            {
                var arr2 = str.Split('|');
                Info info = new Info();
                foreach (String str2 in arr2)
                {
                    if (!str2.Trim().Equals(String.Empty))
                    {
                        info.Add(str2);
                    }
                }
                if (info.Count != 0)
                {
                    Add(info);
                }
            }
        }


        public void Add(Info info)
        {
            if (colorId >= colorList.Count)
                colorId = 0;
            info.color = colorList[colorId++];
            ListInfo.Add(info);
        }


    }
}
