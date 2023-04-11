using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using RazorPagesApp.Services;
using System.Globalization;
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

            if (request["first_name"] == "")
            {
                result.Content = "<div class=\"error_message\">Attention! You must enter your name</div>";
                result.ContentType = "text/html";
                result.StatusCode = 200;
                return result;
            }
            else if (request["last_name"] == "")
            {
                result.Content = "<div class=\"error_message\">Attention! You must enter your surname</div>";
                result.ContentType = "text/html";
                result.StatusCode = 200;
                return result;
            }
            else if (request["email"] == "")
            {
                result.Content = "<div class=\"error_message\">Attention! Please enter an email address.</div>";
                result.ContentType = "text/html";
                result.StatusCode = 200;
                return result;
            }
            else if (!isEmail(request["email"]))
            {
                result.Content = "<div class=\"error_message\">Attention! You have entered an invalid e-mail address, try again.</div>";
                result.ContentType = "text/html";
                result.StatusCode = 200;
                return result;
            }

            if (request["comments"] == "")
            {
                result.Content = "<div class=\"error_message\">Attention! Please enter your message.</div>";
                result.ContentType = "text/html";
                result.StatusCode = 200;
                return result;
            }

            var records = new List<FormContact> { 
                new FormContact
                {
                    name = request["first_name"],
                    surname = request["last_name"],
                    email = request["email"],
                    phone = request["phone"],
                    select_service = request["select_service"],
                    select_price = request["select_price"],
                    comments = request["comments"]
                } 
            };

            CsvConfiguration config;
            if (System.IO.File.Exists("contacts.csv"))
            {
                config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };
            }
            else
            {
                config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };
            }

            using (var writer = new StreamWriter("contacts.csv", true))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<ContactMap>();
                csv.WriteRecords(records);
            }

            result.StatusCode = 200;
            return result;
        }
    }

    public class FormContact
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string select_service { get; set; }
        public string select_price { get; set; }
        public string comments { get; set; }
    }

    public class ContactMap : ClassMap<FormContact>
    {
        public ContactMap()
        {
            Map(m => m.name).Index(0).Name("First Name");
            Map(m => m.surname).Index(1).Name("Last Name");
            Map(m => m.email).Index(2).Name("Email");
            Map(m => m.phone).Index(3).Name("Phone Number");
            Map(m => m.select_service).Index(4).Name("Service");
            Map(m => m.select_price).Index(5).Name("Price");
            Map(m => m.comments).Index(6).Name("Comments");
        }
    }
}
