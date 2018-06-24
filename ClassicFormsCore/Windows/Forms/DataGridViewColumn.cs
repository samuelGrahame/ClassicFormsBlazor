﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassicFormsCore.HTML.HTMLStatic;
using ClassicFormsCore.HTML;

namespace System.Windows.Forms
{
    public class DataGridViewColumn
    {
        internal HTMLTableHeaderCellElement Element;
        public string HeaderText {
            get { return Element.textContent; }
            set
            {                
                Element.textContent = value;
            }
        }
        public string Name { get { return Element.getAttribute("Name"); } set { Element.setAttribute("Name", value); } }
        public string DataPropertyName { get; set; }

        public DataGridViewColumn()
        {
            Element = new HTMLTableHeaderCellElement();
        }

    }
}
