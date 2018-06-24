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
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onmousemove", uid, value);
        }

        public Action<MouseEvent> onmouseup
        {
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onmouseup", uid, value);
        }

    }
}
