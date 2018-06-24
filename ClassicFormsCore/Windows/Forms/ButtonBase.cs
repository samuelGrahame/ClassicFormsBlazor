using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicFormsCore.HTML;
using static ClassicFormsCore.HTML.HTMLStatic;

namespace System.Windows.Forms
{
    public class ButtonBase : Control
    {
        protected ButtonBase(HTMLElement element) : base(element)
        {

        }
        public override bool AutoSize { get; set; }
        public override string Text { get { return base.Text; } set {
                base.Text = value;
                Element.textContent = value;
            } }
        public bool UseVisualStyleBackColor { get; set; }        
    }
}
