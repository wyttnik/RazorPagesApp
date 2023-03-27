using RazorPagesApp.Services;

namespace RazorPagesApp.Pages
{
    public class ServicesModel : DefaultModel
    {
        public ServicesModel(IDataReader reader) : base(reader, "services")
        {
        }

        public void OnGet()
        {
            title = _dataReader.GetData(_pageName)["title"];
            activeState = new string[] { "", "", "active", "", "", "", "", "" };
        }
    }
}
