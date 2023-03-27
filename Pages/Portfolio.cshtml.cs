using RazorPagesApp.Services;

namespace RazorPagesApp.Pages
{
    public class PortfolioModel : DefaultModel
    {
        public PortfolioModel(IDataReader reader) : base(reader, "portfolio")
        {
        }

        public void OnGet()
        {
            title = _dataReader.GetData(_pageName)["title"];
            activeState = new string[] { "", "", "", "active", "", "", "", "" };
        }
    }
}
