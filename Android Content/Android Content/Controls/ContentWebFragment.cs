using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using AllContent_Client;

namespace Android_Content
{
    public class ContentWebFragment : Android.Support.V4.App.Fragment
    {
        ContentUnit cu;
        WebView webView;
        
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.WebLayout, container, false);

            TextView titleTextView = v.FindViewById<TextView>(Resource.Id.titleTextView);

            webView = v.FindViewById<WebView>(Resource.Id.webView);
            webView.Settings.JavaScriptEnabled = true;

            webView.SetWebChromeClient(new MyChromeWebClient(titleTextView));
            webView.SetWebViewClient(new MyWebViewClient());
            string url = Activity.Intent.Data.ToString();
            webView.LoadUrl(url);
            return v;
        }

    }
   
    class MyChromeWebClient : WebChromeClient
    {
        TextView titleTextView { get; set; }
        public MyChromeWebClient(TextView titleView)
        {
            titleTextView = titleView;
        }
       
        public override void OnReceivedTitle(WebView view, string title)
        {
            titleTextView.Text = title;
        }

    }

    class MyWebViewClient : WebViewClient
    {
        public MyWebViewClient()
        {

        }
        [Obsolete]
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            return false;
        }
    }
}