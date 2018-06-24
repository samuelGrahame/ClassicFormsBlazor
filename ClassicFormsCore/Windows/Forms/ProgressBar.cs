﻿using ClassicFormsCore.HTML;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassicFormsCore.HTML.HTMLStatic;

namespace System.Windows.Forms
{
    public class ProgressBar : Control
    {
        internal HTMLDivElement progressBar;
        public ProgressBar() : base(new HTMLDivElement())
        {
            Element.appendChild(progressBar = new HTMLDivElement());
            TabStop = false;
            Element.setAttribute("scope", "progress");            
        }
        
        public override Color ForeColor { get { return base.ForeColor; } set {
                base.ForeColor = value;
                if(_init)
                    progressBar.style.backgroundColor = value.ToHtml();
            } }

        private int _value;
        public int Value { get { return _value; }  set {
                if (value < 0)
                    value = 0;
                if (value > 100)
                    value = 100;
                _value = value;
                if(_init)
                    progressBar.style.width = _value + "%";
            } }

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
                        if (arry.Length == 2)
                        {
                            progressBar.className = arry[1];                            
                        }
                        else
                        {
                            progressBar.className = "";                            
                        }
                    }
                    else
                    {
                        Element.className = str;
                        progressBar.className = "";
                    }
                }
                else
                {
                    Element.className = "";
                    progressBar.className = "";
                }
            }
        }
    }
}
