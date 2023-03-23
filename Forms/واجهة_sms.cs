using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Vonage;
//using Vonage.Request;


namespace MYSCHOOLFINAL
{
    public partial class واجهة_sms : Form
    {
        public واجهة_sms()
        {
            InitializeComponent();
            if (n == null)
                n = this;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
        private static واجهة_sms n;
        static void cf(object sender,FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_sms deleg
        {
            get
            {
                if(n==null)
                {
                    n = new واجهة_sms();
                }
                return n;
            }

        }
        private void واجهة_sms_Load(object sender, EventArgs e)
        {

        }

        private void زر_إرسال_sms_Click(object sender, EventArgs e)
        {
       
    //        var credentials = Credentials.FromApiKeyAndSecret(
    //"dcdacdfd",
    //"mlX3Gmg5klsPCWCu"
    //);

    //        var VonageClient = new VonageClient(credentials);
         
    //       var resultst = client.SMS..Send(HelpRequested: new Nexmo.Api.SMS.SMSRequest)
    //    {
    //            from = txt_name.Text,
    //         to = txt_Tel.Text,
    //        text = txt_message.Text ,
    //       });

  //          curl - X "POST" "https://rest.nexmo.com/sms/json" \
  //-d "from=Vonage APIs" \
  //-d "text=A text message sent using the Vonage SMS API" \
  //-d "to=4915758258043" \
  //-d "api_key=dcdacdfd" \
  //-d "api_secret=mlX3Gmg5klsPCWCu"
        }
    }
}
