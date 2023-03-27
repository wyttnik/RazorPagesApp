using RazorPagesApp.Services;

namespace RazorPagesApp.Pages
{
    public class IndexModel : DefaultModel
    {
        public IndexModel(IDataReader reader) : base(reader, "index")
        {
        }

        public void OnGet()
        {
            title = _dataReader.GetData(_pageName)["title"];
            activeState = new string[] { "active", "", "", "", "", "", "", "" };
        }
    }
}