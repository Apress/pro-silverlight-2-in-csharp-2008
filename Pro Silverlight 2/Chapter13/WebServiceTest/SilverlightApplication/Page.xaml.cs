using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightApplication.ServiceReference1;
using System.Windows.Browser;

namespace SilverlightApplication
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
        }

        private void callService_Click(object sender, RoutedEventArgs e)
        {
            System.ServiceModel.EndpointAddress address = new System.ServiceModel.EndpointAddress("http://localhost:" +
                HtmlPage.Document.DocumentUri.Port + "/SilverlightApplication.Web/TestService.svc");
            TestServiceClient proxy = new TestServiceClient(new System.ServiceModel.BasicHttpBinding(),
                address);
            
            proxy.GetServerTimeCompleted += new EventHandler<GetServerTimeCompletedEventArgs>(GetServerTimeCompleted);
            proxy.GetServerTimeAsync();
        }
        private void GetServerTimeCompleted(object sender, GetServerTimeCompletedEventArgs e)
        {
            try
            {
                lblTime.Text = e.Result.ToLongTimeString();
            }
            catch (Exception err)
            {
                lblTime.Text = err.Message;
                if (err.InnerException != null) lblTime.Text += "\n" + err.InnerException.Message;
            }
        }

        private void callCachedService_Click(object sender, RoutedEventArgs e)
        {
            System.ServiceModel.EndpointAddress address = new System.ServiceModel.EndpointAddress("http://localhost:" +
                HtmlPage.Document.DocumentUri.Port + "/SilverlightApplication.Web/TestService.svc");
            TestServiceClient proxy = new TestServiceClient(new System.ServiceModel.BasicHttpBinding(),
                address);

            proxy.GetCachedServerTimeCompleted += new EventHandler<GetCachedServerTimeCompletedEventArgs>(GetCachedServerTimeCompleted);
            proxy.GetCachedServerTimeAsync();
        }
        private void GetCachedServerTimeCompleted(object sender, GetCachedServerTimeCompletedEventArgs e)
        {
            try
            {
                lblTime.Text = e.Result.ToLongTimeString();
            }
            catch (Exception err)
            {
                lblTime.Text = err.Message;
                if (err.InnerException != null) lblTime.Text += "\n" + err.InnerException.Message;
            }
        }
    }
}
