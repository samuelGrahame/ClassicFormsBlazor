using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicFormsCore.HTML
{
    public static class HTMLStatic
    {
        public static HTMLDocumentElement document;
        public static HTMLWindow window;

        static HTMLStatic()
        {
            document = new HTMLDocumentElement();
            window = new HTMLWindow();
        }

        public static string ToHtml(this Color color)
        {
            if (color.A != 255)
            {
                return string.Format("rgba({1},{2},{3},{0})", color.A, color.R, color.G, color.B);
            }
            else
            {
                return string.Format("rgb({0},{1},{2})", color.R, color.G, color.B);
            }
        }
        public static Dictionary<string, Action<Event>> normalEvent = new Dictionary<string, Action<Event>>();
        public static Dictionary<string, Action<MouseEvent>> normalMouseEvent = new Dictionary<string, Action<MouseEvent>>();

        public static void InvokeEvent(string uid)
        {
            try
            {
                normalEvent[uid](null);
            }
            catch (Exception)
            {

            }
        }

        public static void InvokeMouseEvent(string uid, string ev)
        {
            try
            {
                //Console.WriteLine(ev);
                MouseEvent mev = null;
                try
                {
                    JObject obj = (JObject)JsonConvert.DeserializeObject(ev);

                   // Console.WriteLine(obj.GetType());
                  //  Console.WriteLine(JsonConvert.SerializeObject(obj));

                    mev = new MouseEvent()
                    {
                        clientX = (double)obj["clientX"]
                      //  }
                    };

                //clientY = obj["clientY"].Value<double>(),
                //        x = obj["x"].Value<double>(),
                //        y = obj["y"].Value<double>(),
                //        layerX = obj["layerX"].Value<double>(),
                //        layerY = obj["layerY"].Value<double>(),
                //        button = obj["button"].Value<double>(),
                //        currentTarget = new HTMLElement()
                //        {
                //            uid = obj["currentTarget"].Value<string>()

                    Console.WriteLine(JsonConvert.SerializeObject(mev));
                }
                catch (Exception)
                {
                }
                normalMouseEvent[uid](mev);
            }
            catch (Exception)
            {

            }
        }
    }
}
