using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Models;
using RazorPagesApp.Services;

namespace RazorPagesApp.Pages
{
    public class TestimonialsModel : DefaultModel
    {

        private readonly GoodWebContext _context;

        public TestimonialsModel(IDataReader reader, GoodWebContext context) : base(reader, "testimonials")
        {
            _context = context;
        }

        public IList<Testimonial> Testimonials { get; set; } = default!;

        public async Task OnGetAsync()
        {
            title = _dataReader.GetData(_pageName)["title"];
            activeState = new string[] { "", "", "", "", "", "active", "", "" };

            if (_context.Testimonials != null)
            {
                Testimonials = await _context.Testimonials.ToListAsync();
            }
        }
    }
}
