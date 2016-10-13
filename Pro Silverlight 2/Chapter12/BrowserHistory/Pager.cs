using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace BrowserHistory
{
    [ScriptableType]
    public class Pager
    {
        public void AddHistoryItem(string stateKey)
        {
            AddHistoryItem(stateKey, "Pager");
        }

        private bool pageSwitch = false;
    
        public void AddHistoryItem(string stateKey, string pagerElementName)
        {
            currentStateKey = stateKey;
            HtmlElement iframe = HtmlPage.Document.GetElementById(pagerElementName);
            pageSwitch = !pageSwitch;
      
            if (pageSwitch)
            {
                iframe.SetAttribute("src", "Pager1.html?StateKey=" + stateKey);
            }
            else
            {
                iframe.SetAttribute("src", "Pager2.html?StateKey=" + stateKey);
            }
            
        }


        public Pager()
        {
            HtmlPage.RegisterScriptableObject("PagerScript", this);
        }

        private string currentStateKey;

        [ScriptableMember]
        public void Navigate(string stateKey)
        {   
            //DEBUG
            //TextBlock txt = (TextBlock)((Grid)App.Current.RootVisual).Children[1];
            //txt.Text = DateTime.Now.TimeOfDay.ToString() + " " + stateKey;
                       

            if (stateKey != currentStateKey)
            {
                App.RestorePage(stateKey);
                pageSwitch = !pageSwitch;
                currentStateKey = stateKey;
            }
           
        }

    }
}
