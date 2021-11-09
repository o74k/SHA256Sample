using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace SHA256
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = CreateHMACSHA256(TextBox1.Text,TextBox2.Text);
        }

        private string CreateHMACSHA256(String inputText,String inKey)
        {
            var encoding = new System.Text.UTF8Encoding();

            byte[] keyByte = encoding.GetBytes(inKey);
            byte[] messageBytes = encoding.GetBytes(inputText);
            using (var hmacSHA256 = new HMACSHA256(keyByte))
            {
                byte[] hashMessage = hmacSHA256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashMessage).Replace("-", "").ToLower();
            }
        }

        private string CreateSHA256(String inputText, String inKey)
        {
            var encoding = new System.Text.UTF8Encoding();
            //byte[] keyByte = encoding.GetBytes(inKey);
            byte[] messageBytes = encoding.GetBytes(inputText);


            System.Security.Cryptography.SHA256 testSHA256 = System.Security.Cryptography.SHA256.Create();

            byte[] hashMessage = testSHA256.ComputeHash(messageBytes);
            return BitConverter.ToString(hashMessage).Replace("-","").ToLower();

        }

    }

}