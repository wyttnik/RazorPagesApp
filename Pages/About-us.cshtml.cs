using RazorPagesApp.Services;

namespace RazorPagesApp.Pages
{
    public class About_usModel : DefaultModel
    {
        public About_usModel(IDataReader reader) : base(reader, "about-us")
        {
        }

        public void OnGet()
        {
            title = _dataReader.GetData(_pageName)["title"];
            activeState = new string[] { "", "active", "", "", "", "", "", "" };
        }
    }
}
