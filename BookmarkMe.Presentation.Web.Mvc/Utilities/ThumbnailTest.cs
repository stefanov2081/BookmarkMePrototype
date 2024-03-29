﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BookmarkMe.Presentation.Web.Mvc.Utilities
{
    public class ThumbnailTest
    {
        public static Bitmap GetWebSiteThumbnail(string Url, int BrowserWidth, int BrowserHeight, int ThumbnailWidth, int ThumbnailHeight)
        {
            WebsiteThumbnailImage thumbnailGenerator = new WebsiteThumbnailImage(Url, BrowserWidth, BrowserHeight, ThumbnailWidth, ThumbnailHeight);
            return thumbnailGenerator.GenerateWebSiteThumbnailImage();
        }

        private class WebsiteThumbnailImage
        {
            public WebsiteThumbnailImage(string Url, int BrowserWidth, int BrowserHeight, int ThumbnailWidth, int ThumbnailHeight)
            {
                this.m_Url = Url;
                this.m_BrowserWidth = BrowserWidth;
                this.m_BrowserHeight = BrowserHeight;
                this.m_ThumbnailHeight = ThumbnailHeight;
                this.m_ThumbnailWidth = ThumbnailWidth;
            }

            private string m_Url = null;
            public string Url
            {
                get
                {
                    return m_Url;
                }
                set
                {
                    m_Url = value;
                }
            }

            private Bitmap m_Bitmap = null;
            public Bitmap ThumbnailImage
            {
                get
                {
                    return m_Bitmap;
                }
            }

            private int m_ThumbnailWidth;
            public int ThumbnailWidth
            {
                get
                {
                    return m_ThumbnailWidth;
                }
                set
                {
                    m_ThumbnailWidth = value;
                }
            }

            private int m_ThumbnailHeight;
            public int ThumbnailHeight
            {
                get
                {
                    return m_ThumbnailHeight;
                }
                set
                {
                    m_ThumbnailHeight = value;
                }
            }

            private int m_BrowserWidth;
            public int BrowserWidth
            {
                get
                {
                    return m_BrowserWidth;
                }
                set
                {
                    m_BrowserWidth = value;
                }
            }

            private int m_BrowserHeight;
            public int BrowserHeight
            {
                get
                {
                    return m_BrowserHeight;
                }
                set
                {
                    m_BrowserHeight = value;
                }
            }

            public Bitmap GenerateWebSiteThumbnailImage()
            {
                Thread m_thread = new Thread(new ThreadStart(_GenerateWebSiteThumbnailImage));
                m_thread.SetApartmentState(ApartmentState.STA);
                m_thread.Start();
                m_thread.Join();
                return m_Bitmap;
            }

            private void _GenerateWebSiteThumbnailImage()
            {
                WebBrowser m_WebBrowser = new WebBrowser();
                m_WebBrowser.ScrollBarsEnabled = false;
                m_WebBrowser.Navigate(m_Url);
                m_WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
                //while (m_WebBrowser.ReadyState != WebBrowserReadyState.Complete)
                //    Application.DoEvents();
                m_WebBrowser.Dispose();
            }

            private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                WebBrowser m_WebBrowser = (WebBrowser)sender;
                m_WebBrowser.ClientSize = new Size(this.m_BrowserWidth, this.m_BrowserHeight);
                m_WebBrowser.ScrollBarsEnabled = false;
                m_Bitmap = new Bitmap(m_WebBrowser.Bounds.Width, m_WebBrowser.Bounds.Height);
                m_WebBrowser.BringToFront();
                m_WebBrowser.DrawToBitmap(m_Bitmap, m_WebBrowser.Bounds);
                m_Bitmap = (Bitmap)m_Bitmap.GetThumbnailImage(m_ThumbnailWidth, m_ThumbnailHeight, null, IntPtr.Zero);
            }
        }
    }
}


//    using System;
//    using System.Data;
//    using System.Configuration;
//    using System.Collections;
//    using System.Web;
//    using System.Web.Security;
//    using System.Web.UI;
//    using System.Web.UI.WebControls;
//    using System.Web.UI.WebControls.WebParts;
//    using System.Web.UI.HtmlControls;
//    using System.Windows.Forms;
//    using System.Drawing;
//    using System.Drawing.Imaging;
//    using System.Threading;

//public partial class snapshot : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        string url = ((string.IsNullOrEmpty(Request.Params["site"])) ? "www.google.com" : Request.Params["site"]);
//        int width = ((string.IsNullOrEmpty(Request.Params["width"])) ? 200 : int.Parse(Request.Params["width"]));
//        int height = ((string.IsNullOrEmpty(Request.Params["height"])) ? 140 : int.Parse(Request.Params["height"]));
//        int capWidth = ((string.IsNullOrEmpty(Request.Params["capWidth"])) ? 800 : int.Parse(Request.Params["capWidth"]));
//        int capHeight = ((string.IsNullOrEmpty(Request.Params["capHeight"])) ? 600 : int.Parse(Request.Params["capHeight"]));

//        string address = "http://" + url;
//        Bitmap thumbnail = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, capWidth, capHeight, width, height);

//        Response.ContentType = "image/jpeg";
//        thumbnail.Save(Response.OutputStream, ImageFormat.Jpeg);
//    }
//}

//public class WebsiteThumbnailImageGenerator
//{
//    public static Bitmap GetWebSiteThumbnail(string Url, int BrowserWidth, int BrowserHeight, int ThumbnailWidth, int ThumbnailHeight)
//    {
//        WebsiteThumbnailImage thumbnailGenerator = new WebsiteThumbnailImage(Url, BrowserWidth, BrowserHeight, ThumbnailWidth, ThumbnailHeight);
//        return thumbnailGenerator.GenerateWebSiteThumbnailImage();
//    }

//    private class WebsiteThumbnailImage
//    {
//        public WebsiteThumbnailImage(string Url, int BrowserWidth, int BrowserHeight, int ThumbnailWidth, int ThumbnailHeight)
//        {
//            this.m_Url = Url;
//            this.m_BrowserWidth = BrowserWidth;
//            this.m_BrowserHeight = BrowserHeight;
//            this.m_ThumbnailHeight = ThumbnailHeight;
//            this.m_ThumbnailWidth = ThumbnailWidth;
//        }

//        private string m_Url = null;
//        public string Url
//        {
//            get
//            {
//                return m_Url;
//            }
//            set
//            {
//                m_Url = value;
//            }
//        }

//        private Bitmap m_Bitmap = null;
//        public Bitmap ThumbnailImage
//        {
//            get
//            {
//                return m_Bitmap;
//            }
//        }

//        private int m_ThumbnailWidth;
//        public int ThumbnailWidth
//        {
//            get
//            {
//                return m_ThumbnailWidth;
//            }
//            set
//            {
//                m_ThumbnailWidth = value;
//            }
//        }

//        private int m_ThumbnailHeight;
//        public int ThumbnailHeight
//        {
//            get
//            {
//                return m_ThumbnailHeight;
//            }
//            set
//            {
//                m_ThumbnailHeight = value;
//            }
//        }

//        private int m_BrowserWidth;
//        public int BrowserWidth
//        {
//            get
//            {
//                return m_BrowserWidth;
//            }
//            set
//            {
//                m_BrowserWidth = value;
//            }
//        }

//        private int m_BrowserHeight;
//        public int BrowserHeight
//        {
//            get
//            {
//                return m_BrowserHeight;
//            }
//            set
//            {
//                m_BrowserHeight = value;
//            }
//        }

//        public Bitmap GenerateWebSiteThumbnailImage()
//        {
//            Thread m_thread = new Thread(new ThreadStart(_GenerateWebSiteThumbnailImage));
//            m_thread.SetApartmentState(ApartmentState.STA);
//            m_thread.Start();
//            m_thread.Join();
//            return m_Bitmap;
//        }

//        private void _GenerateWebSiteThumbnailImage()
//        {
//            WebBrowser m_WebBrowser = new WebBrowser();
//            m_WebBrowser.ScrollBarsEnabled = false;
//            m_WebBrowser.Navigate(m_Url);
//            m_WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
//            while (m_WebBrowser.ReadyState != WebBrowserReadyState.Complete)
//                Application.DoEvents();
//            m_WebBrowser.Dispose();
//        }

//        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
//        {
//            WebBrowser m_WebBrowser = (WebBrowser)sender;
//            m_WebBrowser.ClientSize = new Size(this.m_BrowserWidth, this.m_BrowserHeight);
//            m_WebBrowser.ScrollBarsEnabled = false;
//            m_Bitmap = new Bitmap(m_WebBrowser.Bounds.Width, m_WebBrowser.Bounds.Height);
//            m_WebBrowser.BringToFront();
//            m_WebBrowser.DrawToBitmap(m_Bitmap, m_WebBrowser.Bounds);
//            m_Bitmap = (Bitmap)m_Bitmap.GetThumbnailImage(m_ThumbnailWidth, m_ThumbnailHeight, null, IntPtr.Zero);
//        }
//    }
//}