using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicFormsCore.HTML;
using static ClassicFormsCore.HTML.HTMLStatic;

namespace System.Windows.Forms
{
    public class TextBox : Control
    {                
        

        public TextBox() : base(new HTMLInputElement() { type = "text" })
        {
            //TextChanged
            Action<Event> workOutEvent = (ev) =>
            {
                if(Text != prevString)
                {
                    prevString = Text;
                    OnTextChanged(EventArgs.Empty);
                }                
            };

            Element.onchange = workOutEvent;
            Element.onpaste = workOutEvent;
            Element.onkeydown = workOutEvent;
            Element.onkeyup = workOutEvent;
            Element.onblur = workOutEvent;
        }
        private string prevString;
        public override string Text { get { return (Element as HTMLInputElement).value; } set
            {
                base.Text = value;                
                (Element as  HTMLInputElement).value = value;
            }
        }

        private bool _useSystemPasswordChar;

        public bool UseSystemPasswordChar
        {
            get { return _useSystemPasswordChar; }
            set {
                _useSystemPasswordChar = value;
                if(_useSystemPasswordChar)
                {
                    this.Element.As<HTMLInputElement>().type = "password";
                }
                else
                {
                    this.Element.As<HTMLInputElement>().type = "text";
                }
            }
        }


        protected virtual void OnTextChanged(EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(this, e);
        }

        public event EventHandler TextChanged;
    }
}
