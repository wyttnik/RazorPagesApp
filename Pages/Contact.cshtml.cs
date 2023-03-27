using RazorPagesApp.Services;

namespace RazorPagesApp.Pages
{
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
    }
}
