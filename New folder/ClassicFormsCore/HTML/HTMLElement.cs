using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicFormsCore.HTML
{
    public class HTMLElement
    {
        public string uid;

        public HTMLStyleCollection style;
        public HTMLClassList classList;
        public HTMLChildNodes childNodes;

        public string value
        {
            get =>
                RegisteredFunction.Invoke<string>("element_get", uid, nameof(value));
            set =>
                RegisteredFunction.Invoke<string>("element_set", uid, nameof(value), value);
        }

        public string innerText
        {
            get =>
                RegisteredFunction.Invoke<string>("element_get", uid, nameof(innerText));
            set =>
                RegisteredFunction.Invoke<string>("element_set", uid, nameof(innerText), value);
        }

        public Action<MouseEvent> onmousedown
        {            
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onmousedown", uid, value);
        }

        public Action<Event> onchange
        {            
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onchange", uid, value);
        }
        public Action<Event> onpaste
        {
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onpaste", uid, value);
        }

        public Action<MouseEvent> onkeydown
        {
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onkeydown", uid, value);
        }

        public Action<MouseEvent> onkeyup
        {
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onkeyup", uid, value);
        }

        public Action<Event> onclick
        {
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onclick", uid, value);
        }
        public Action<Event> onblur
        {
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onblur", uid, value);
        }
        public Action<MouseEvent> onmouseenter
        {
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onmouseenter", uid, value);
        }
        public Action<MouseEvent> onmouseleave
        {
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onmouseleave", uid, value);
        }
        public Action<MouseEvent> onmousemove
        {
            set =>
                RegisteredFunction.InvokeUnmarshalled<object>("onmousemove", uid, value);
        }
        //innerText
        public HTMLElement parentElement
        {
            get =>
                RegisteredFunction.Invoke<HTMLElement>("element_parentElement_get", uid);
            set =>
                RegisteredFunction.Invoke<string>("element_parentElement_set", uid, value);
        }

        public HTMLElement(string tag) : this()
        {
            uid = RegisteredFunction.Invoke<string>("createElement", tag);
        }

        public int tabIndex
        {
            get =>
RegisteredFunction.Invoke<int>("element_get", uid, nameof(tabIndex));
            set =>
                RegisteredFunction.Invoke<int>("element_set", uid, nameof(tabIndex), value);
        }

        public string textContent
        {
            get =>
RegisteredFunction.Invoke<string>("element_get", uid, nameof(textContent));
            set =>
                RegisteredFunction.Invoke<string>("element_set", uid, nameof(textContent), value);
        }

        public string id
        {
            get =>
RegisteredFunction.Invoke<string>("element_get", uid, nameof(id));
            set =>
                RegisteredFunction.Invoke<string>("element_set", uid, nameof(id), value);
        }

        public HTMLElement()
        {
            style = new HTMLStyleCollection(this);
            classList = new HTMLClassList(this);
            childNodes = new HTMLChildNodes(this);
        }

        public void appendChild(HTMLElement child)
        {
            RegisteredFunction.Invoke<object>("appendChild", uid, child.uid);
        }

        public void removeChild(HTMLElement child)
        {
            RegisteredFunction.Invoke<object>("removeChild", uid, child.uid);
        }

        public T As<T>() where T : HTMLElement
        {
            return this as T;
        }


        public void insertBefore(HTMLElement child, HTMLElement child2)
        {
            RegisteredFunction.Invoke<object>("insertBefore", uid, child.uid, child2.uid);
        }
        public string innerHTML { get =>
                RegisteredFunction.Invoke<string>("innerHTML_get", uid);
            set => 
                RegisteredFunction.Invoke<string>("innerHTML_set", uid, value);
        }

        public string className
        {
            get =>
RegisteredFunction.Invoke<string>("element_get", uid, nameof(className));
            set =>
                RegisteredFunction.Invoke<string>("element_set", uid, nameof(className), value);
        }


        public DomRect getBoundingClientRect()
        {
            return RegisteredFunction.Invoke<DomRect>("getBoundingClientRect", uid, nameof(getBoundingClientRect));
        }

        public void focus()
        {
            RegisteredFunction.Invoke<string>("element_call", uid, nameof(focus));
        }

        public void blur()
        {
            RegisteredFunction.Invoke<string>("element_call", uid, nameof(blur));
        }

        public string getAttribute(string name)
        {
            return RegisteredFunction.Invoke<string>("getAttribute", uid, name);
        }

        public string removeAttribute(string name)
        {
            return RegisteredFunction.Invoke<string>("removeAttribute", uid, name);
        }

        public void setAttribute(string name, string value)
        {
            RegisteredFunction.Invoke<string>("getAttribute", uid, name, value);
        }
    }
}
