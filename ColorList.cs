using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AutoFill
{
    class ColorList
    {
        public List<Color> colorList { get; set; }
        public Color this[int index]
        {
            get
            {
                return colorList[index];
            }
        }
        public int Count
        {
            get
            {
                return colorList.Count;
            }
        }
        public ColorList()
        {
            colorList = new List<Color>();
            colorList.Add(Color.Black);
            colorList.Add(Color.BlueViolet);
            colorList.Add(Color.Brown);
            colorList.Add(Color.Green);
            colorList.Add(Color.Blue);
            colorList.Add(Color.Red);
            colorList.Add(Color.Chocolate);
            colorList.Add(Color.DarkOliveGreen);
            colorList.Add(Color.DarkRed);
            colorList.Add(Color.LightSeaGreen);
            colorList.Add(Color.Maroon);
            colorList.Add(Color.MediumOrchid);
            colorList.Add(Color.MediumSeaGreen);
        }
    }
}
