﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassicFormsCore.HTML.HTMLStatic;
using ClassicFormsCore.HTML;

namespace System.Windows.Forms
{
    public class TabPageHeader : Control
    {
        //li
        public TabPageHeader() : base(new HTMLAnchorElement())
        {
            Element.setAttribute("scope", "tabpageheader");
            Element.style.padding = null;
        }

        public override string Text
        {
            get
            {
                return Element.innerText;
            }

            set
            {
                if(Element.innerText != value)
                {
                    Element.innerText = value;
                }
            }
        }
    }
}
