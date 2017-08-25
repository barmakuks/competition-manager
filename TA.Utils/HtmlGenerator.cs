using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TA.Utils
{
    public class HtmlGenerator
    {
        public const string DefaultMeta = "<meta http-equiv='Content-Type' content='text/html; charset=windows-1521'>";
        public string Meta = DefaultMeta;
        public const string DefaultStyle = @"h1 { font: bold 10pt  verdana; }
                            h2 { font: bold 9pt  verdana; }
                            h3 { font: normal 8pt  verdana; }
                            table { font-size : small; border: 1px solid #800; border-collapse: collapse;}
                            tr{height : 12px;}
                            th{border: 1px solid #800; text-align : center;font-weight : bold;border-right-width : 0px; color : black;background: #ddd;}
                            td{border: 1px solid #800; padding-right: 4px; padding-left: 4px;color : black;border-left-width: 0px;background:white;}
                            img{border: 1px solid #800; }
                            ";
        public string Style = DefaultStyle;
        public string Title = "";
        public string Body = "";
        public void Clear() 
        {
            Title = "";
            Body = "";
            Style = "";
        }
        public string TagString(string tag, string text) 
        {
            return String.Format("<{0}>{1}</{0}>", tag, text);
        }
        public override string ToString()
        {
            string style = "";
            if (Style != "")
                style = String.Format("<style type='text/css'>{0}</style>", Style);
            string meta = "";
            if (Meta != "")
                meta = Meta;
            return String.Format("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 3.2 Final//EN'><html><head>{0}<title>{1}</title>{2}</head><body>{3}</body></html>", meta, Title, style, Body); 
        }
        public void SaveTo(string filename) 
        {
            FileStream stream = File.Create(filename);
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
            writer.WriteLine(ToString());
            writer.Close();
        }
    }
}
