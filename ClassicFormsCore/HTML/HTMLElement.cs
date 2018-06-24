﻿using Microsoft.AspNetCore.Blazor.Browser.Interop;
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
            set {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalMouseEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onmousedown", uid, hash);
            }                
        }

        public Action<Event> onchange
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onchange", uid, hash);
            }
        }
        public Action<Event> onpaste
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onpaste", uid, hash);
            }
        }

        public Action<Event> onkeydown
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onkeydown", uid, hash);
            }
        }

        public Action<Event> onkeyup
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onkeyup", uid, hash);
            }
        }

        public Action<Event> onclick
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onclick", uid, hash);
            }
        }
        public Action<Event> onblur
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onblur", uid, hash);
            }
        }
        public Action<MouseEvent> onmouseenter
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalMouseEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onmouseenter", uid, hash);
            }
        }
        public Action<MouseEvent> onmouseleave
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalMouseEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onmouseleave", uid, hash);
            }
        }
        public Action<MouseEvent> onmousemove
        {
            set
            {
                string hash = value.GetHashCode().ToString();
                HTMLStatic.normalMouseEvent.Add(value.GetHashCode().ToString(), value);
                RegisteredFunction.Invoke<object>("onmousemove", uid, hash);
            }
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
            RegisteredFunction.Invoke<string>("setAttribute", uid, name, value);
        }
    }
}
