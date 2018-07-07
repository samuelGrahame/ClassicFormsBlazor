﻿using ClassicFormsCore.HTML;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassicFormsCore.HTML.HTMLStatic;

namespace System.Windows.Forms
{
    //
    // Summary:
    //     Provides data for the System.Windows.Forms.Control.MouseUp, System.Windows.Forms.Control.MouseDown,
    //     and System.Windows.Forms.Control.MouseMove events.
    public class MouseEventArgs : EventArgs
    {
        public MouseEvent Original;

        private static Point GetOffsetPoint(HTMLElement element)
        {
#if !BRIDGE
            var rev = RegisteredFunction.Invoke<string>("getOffsetPoint", element.uid, IsFF).Split(',');
            return new Point(Convert.ToInt32(rev[0]), Convert.ToInt32(rev[1]));
#else
            double top = 0;
            double left = 0;

            do
            {
                dynamic dym = element;
                if(Settings.IsFF)
                {
                    var rec = element.getBoundingClientRect().As<ClientRect>();
                    top += rec.top;
                    left += rec.left;
                    //element = dym.offsetParent;
                    element = element.parentElement;
                }
                else
                {
                    top += dym.offsetTop;
                    left += dym.offsetLeft;
                    element = dym.offsetParent;
                }
                

            } while (element != null);

            return new Point((int)left, (int)top);
#endif
        }

        static bool IsEdge;
        static bool IsFF;
        static bool IsIE;
        static MouseEventArgs()
        {
            var userAgent = window.navigator.userAgent.ToLower();
            IsEdge = userAgent.IndexOf("edge") > -1;
            IsFF = userAgent.IndexOf("firefox") > -1;
            IsIE = userAgent.IndexOf("msie") > -1;
        }

        public static PointF GetClientMouseLocation(object e)
        {
            var x = 0;
            var y = 0;
            /*@
			  if (!e) var e = window.event;

			  if (e.pageX || e.pageY) {
				x = e.pageX;
				y = e.pageY;
			  } else if (e.clientX || e.clientY) {
				x = e.clientX + document.body.scrollLeft +
								   document.documentElement.scrollLeft;
				y = e.clientY + document.body.scrollTop +
								   document.documentElement.scrollTop;
			  }
			*/
            return new PointF(x, y);
        }

        public static MouseEventArgs CreateFromMouseEvent(MouseEvent original, Control target)
        {            
            // what we need to do is get the local x, y off from the target.            
            Point mousePoint;
        
            if(!IsFF && original.currentTarget.uid == target.Element.uid)
            {
                if(IsIE || IsEdge)                  // Browser.IsIE ||   
                {
                    var offset = GetOffsetPoint(target.Element);
                    mousePoint = new Point((int)(original.clientX - offset.X), (int)(original.clientY - offset.Y));
                }                
                else
                {
                    mousePoint = new Point((int)original.layerX, (int)original.layerY);
                }
            }
            else
            {               
                if (IsFF)
                {
                    var vect = GetClientMouseLocation(original);
                    var rec = target.Element.getBoundingClientRect();
                    mousePoint = new Point((int)(vect.X - rec.left), (int)(vect.Y - rec.top));
                }
                else
                {
                    var offset = GetOffsetPoint(target.Element);
                    mousePoint = new Point((int)(original.x - offset.X), (int)(original.y - offset.Y));
                }                
            }

            var button = (int)original.button;
            MouseButtons mb;

            if (button == 1)
                mb = MouseButtons.Left;
            else if (button == 2)
                mb = MouseButtons.Right;
            else if (button == 4)
                mb = MouseButtons.Middle;
            else if (button == 8)
                mb = MouseButtons.XButton1;
            else
                mb = MouseButtons.XButton2;

            var returnMouseEvent = new MouseEventArgs(mb, 1, mousePoint.X, mousePoint.Y, 0);
            returnMouseEvent.Original = original;
            
            return returnMouseEvent;
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.MouseEventArgs class.
        //
        // Parameters:
        //   button:
        //     One of the System.Windows.Forms.MouseButtons values that indicate which mouse
        //     button was pressed.
        //
        //   clicks:
        //     The number of times a mouse button was pressed.
        //
        //   x:
        //     The x-coordinate of a mouse click, in pixels.
        //
        //   y:
        //     The y-coordinate of a mouse click, in pixels.
        //
        //   delta:
        //     A signed count of the number of detents the wheel has rotated.
        public MouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta)
        {
            this.Button = button;
            this.Clicks = clicks;
            this.X = x;
            this.Y = y;
            this.Delta = delta;
            this.Location = new Point(X, Y);
        }

        //
        // Summary:
        //     Gets which mouse button was pressed.
        //
        // Returns:
        //     One of the System.Windows.Forms.MouseButtons values.
        public MouseButtons Button { get; }
        //
        // Summary:
        //     Gets the number of times the mouse button was pressed and released.
        //
        // Returns:
        //     An System.Int32 that contains the number of times the mouse button was pressed
        //     and released.
        public int Clicks { get; }
        //
        // Summary:
        //     Gets the x-coordinate of the mouse during the generating mouse event.
        //
        // Returns:
        //     The x-coordinate of the mouse, in pixels.
        public int X { get; }
        //
        // Summary:
        //     Gets the y-coordinate of the mouse during the generating mouse event.
        //
        // Returns:
        //     The y-coordinate of the mouse, in pixels.
        public int Y { get; }
        //
        // Summary:
        //     Gets a signed count of the number of detents the mouse wheel has rotated, multiplied
        //     by the WHEEL_DELTA constant. A detent is one notch of the mouse wheel.
        //
        // Returns:
        //     A signed count of the number of detents the mouse wheel has rotated, multiplied
        //     by the WHEEL_DELTA constant.
        public int Delta { get; }
        //
        // Summary:
        //     Gets the location of the mouse during the generating mouse event.
        //
        // Returns:
        //     A System.Drawing.Point that contains the x- and y- mouse coordinates, in pixels,
        //     relative to the upper-left corner of the form.
        public Point Location { get; }
    }
}
