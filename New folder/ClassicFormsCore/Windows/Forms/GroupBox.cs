﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicFormsCore.HTML;
using static ClassicFormsCore.HTML.HTMLStatic;

namespace System.Windows.Forms
{
    public class GroupBox : Control
    {
        private HTMLLegendElement legend;
        private Panel panel;
        public GroupBox() : base(new HTMLFieldSetElement())
        {
            panel = new Panel();

            Element.setAttribute("scope", "groupbox");

            Element.appendChild(legend = new HTMLLegendElement());

            legend.setAttribute("scope", "groupboxlegend");

            Element.appendChild(panel.Element);
            panel.Element.style.position = "relative";
            Controls._owner = panel;
        }

        public override string Text
        {
            get { return legend.textContent; }
            set
            {
                base.Text = value;
                legend.textContent = value;
            }
        }

        public override object Tag
        {
            get { return _tag; }
            set
            {
                _tag = value;
                if (_tag is string)
                {
                    var str = (_tag + "");
                    if (str.Contains(","))
                    {
                        var arry = str.Split(',');
                        Element.className = arry[0];
                        if (arry.Length == 3)
                        {
                            legend.className = arry[1];
                            panel.Element.className = arry[2];
                        }
                        else
                        {
                            legend.className = "";
                            panel.Element.className = "";
                        }
                    }
                    else
                    {
                        Element.className = str;
                        legend.className = "";
                        panel.Element.className = "";
                    }
                }
                else
                {
                    Element.className = "";
                    legend.className = "";
                    panel.Element.className = "";
                }
            }
        }
    }
}
