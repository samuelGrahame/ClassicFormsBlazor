using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicFormsCore.HTML
{
    public class MouseEvent : Event
    {
        public double x;
        public double y;

        public double layerX;
        public double layerY;

        public double clientX;
        public double clientY;

        public HTMLElement currentTarget;

        public double button;
    }

    public class MouseEventJson
    {
        public double x;
        public double y;

        public double layerX;
        public double layerY;

        public double clientX;
        public double clientY;

        public string currentTarget;

        public double button;
    }
}
