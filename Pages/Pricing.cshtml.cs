using RazorPagesApp.Services;

namespace RazorPagesApp.Pages
{
    public class PricingModel : DefaultModel
    {
        public PricingModel(IDataReader reader) : base(reader, "pricing")
        {
        }

        public void OnGet()
        {
            title = _dataReader.GetData(_pageName)["title"];
            activeState = new string[] { "", "", "", "", "", "", "active", "" };
        }
    }
}
