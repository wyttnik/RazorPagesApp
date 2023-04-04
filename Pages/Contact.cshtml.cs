using Microsoft.AspNetCore.Mvc;
using RazorPagesApp.Services;
using System.Net;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace RazorPagesApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class ContactModel : DefaultModel
    {
        public ContactModel(IDataReader reader) : base(reader, "contacts")
        {
        }
        
        public void OnGet()
        {
            title = _dataReader.GetData(_pageName)["title"];
            activeState = new string[] { "", "", "", "", "", "", "", "active" };
        }

        public bool isEmail(string email)
        {
            return Regex.IsMatch(email, "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])",
                    RegexOptions.CultureInvariant | RegexOptions.Singleline);
        }

        public IActionResult OnPost()
        {
            var request = Request.Form;
            var result = new ContentResult();

//$first_name = $_POST['first_name'];
//$last_name = $_POST['last_name'];
//$email = $_POST['email'];
//$phone = $_POST['phone'];
//$select_price = $_POST['select_price'];
//$select_service = $_POST['select_service'];
//$subject = $_POST['subject'];
//$comments = $_POST['comments'];
//$verify = $_POST['verify'];

            if (request["first_name"] == "")
            {
                result.Content = "<div class=\"error_message\">Attention! You must enter your name</div>";
                result.ContentType = "text/html";
                result.StatusCode = 406;
                return result;
            }
            else if (request["email"] == "")
            {
                result.Content = "<div class=\"error_message\">Attention! Please enter a valid email address.</div>";
                result.ContentType = "text/html";
                result.StatusCode = 400;
                return result;
            }
            else if (!isEmail(request["email"]))
            {
                result.Content = "<div class=\"error_message\">Attention! You have enter an invalid e-mail address, try again.</div>";
                result.ContentType = "text/html";
                result.StatusCode = 400;
                return result;
            }

            if (request["comments"] == "")
            {
                result.Content = "<div class=\"error_message\">Attention! Please enter your message.</div>";
                result.ContentType = "text/html";
                result.StatusCode = 400;
                return result;
            }

            result.StatusCode = 200;
            return result;
            //// Configuration option.
            //// Enter the email address that you want to emails to be sent to.
            //// Example $address = "joe.doe@yourdomain.com";

            ////$address = "example@themeforest.net";
            //$address = "example@yourdomain.com";


            //// Configuration option.
            //// i.e. The standard subject will appear as, "You've been contacted by John Doe."

            //// Example, $e_subject = '$name . ' has contacted you via Your Website.';

            //$e_subject = 'You\'ve been contacted by '. $first_name. '.';


            //// Configuration option.
            //// You can change this if you feel that you need to.
            //// Developers, you may wish to add more fields to the form, in which case you must be sure to add them here.

            //$e_body = "You have been contacted by $first_name. $first_name selected service of $select_service, their additional message is as follows. Customer max budge is $select_price, for this project.".PHP_EOL.PHP_EOL;
            //$e_content = "\"$comments\"".PHP_EOL.PHP_EOL;
            //$e_reply = "You can contact $first_name via email, $email or via phone $phone";

            //$msg = wordwrap( $e_body. $e_content. $e_reply, 70);

            //$headers = "From: $email".PHP_EOL;
            //$headers.= "Reply-To: $email".PHP_EOL;
            //$headers.= "MIME-Version: 1.0".PHP_EOL;
            //$headers.= "Content-type: text/plain; charset=utf-8".PHP_EOL;
            //$headers.= "Content-Transfer-Encoding: quoted-printable".PHP_EOL;

            //            if (mail($address, $e_subject, $msg, $headers))
            //            {

            //                // Email has sent successfully, echo a success page.

            //                echo "<fieldset>";
            //                echo "<div id='success_page'>";
            //                echo "<h1>Email Sent Successfully.</h1>";
            //                echo "<p>Thank you <strong>$first_name</strong>, your message has been submitted to us.</p>";
            //                echo "</div>";
            //                echo "</fieldset>";

            //            }
            //            else
            //            {

            //                echo 'ERROR!';

            //            }
        }
    }
}
