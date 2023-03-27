using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Services;
using System.Text.Json.Nodes;

namespace RazorPagesApp.Pages
{
    public class DefaultModel : PageModel
    {
        protected IDataReader _dataReader;
        public string _pageName;
        public JsonNode title;
        public JsonNode testimonials;
        public string[] activeState;

        public DefaultModel(IDataReader dataService,string name)
        {
            _dataReader = dataService;
            _pageName = name;
            testimonials = dataService.GetData("testimonials")["items"];
        }
    }
}
