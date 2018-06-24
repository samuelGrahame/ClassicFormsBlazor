using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicFormsCore.HTML
{
    public class HTMLWindow
    {
        public string uid;
        public HTMLWindow()
        {
            uid = RegisteredFunction.Invoke<string>("window");
            _nav = new HTMLNavigator();

        }
        private HTMLNavigator _nav;
        public HTMLNavigator navigator => _nav;

        public Action<MouseEvent> onmousemove
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalMouseEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onmousemove", uid, hash);
            }
        }

        public Action<MouseEvent> onmouseup
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalMouseEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onmouseup", uid, hash);
            }
        }

    }
}
