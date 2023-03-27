using RazorPagesApp.Services;

namespace RazorPagesApp.Pages
{
    public class TestimonialsModel : DefaultModel
    {
        public TestimonialsModel(IDataReader reader) : base(reader, "testimonials")
        {
        }

        public void OnGet()
        {
            title = _dataReader.GetData(_pageName)["title"];
            activeState = new string[] { "", "", "", "", "", "active", "", "" };
        }
    }
}
