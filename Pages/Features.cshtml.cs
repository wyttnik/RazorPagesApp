using RazorPagesApp.Services;

namespace RazorPagesApp.Pages
{
    public class FeaturesModel : DefaultModel
    {
        public FeaturesModel(IDataReader reader) : base(reader, "features")
        {
        }

        public void OnGet()
        {
            title = _dataReader.GetData(_pageName)["title"];
            activeState = new string[] { "", "", "", "", "active", "", "", "" };
        }
    }
}
