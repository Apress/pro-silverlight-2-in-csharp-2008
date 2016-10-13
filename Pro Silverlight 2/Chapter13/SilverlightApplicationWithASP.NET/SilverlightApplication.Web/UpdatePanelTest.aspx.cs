using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UpdatePanelTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void cmdUpdatePost_Click(object sender, EventArgs e)
    {
        lbl.Text = "This label was refreshed at " + DateTime.Now.ToLongTimeString();
    }
    protected void cmdUpdateNoPost_Click(object sender, EventArgs e)
    {
        lbl.Text = "This label was refreshed at " + DateTime.Now.ToLongTimeString();
    }
}
