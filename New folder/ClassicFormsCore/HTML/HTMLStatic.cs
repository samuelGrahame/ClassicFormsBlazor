using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicFormsCore.HTML
{
    public static class HTMLStatic
    {
        public static HTMLDocumentElement document;
        public static HTMLWindow window;

        static HTMLStatic()
        {
            document = new HTMLDocumentElement();
            window = new HTMLWindow();
        }

        public static string ToHtml(this Color color)
        {
            if (color.A != 255)
            {
                return string.Format("rgba({1},{2},{3},{0})", color.A, color.R, color.G, color.B);
            }
            else
            {
                return string.Format("rgb({0},{1},{2})", color.R, color.G, color.B);
            }
        }
    }
}
