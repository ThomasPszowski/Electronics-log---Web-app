using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting.Internal;
using projekt_web.Models;
using System.Reflection;

namespace projekt_web.Pages
{
    public class ViewModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ItemId { get; set; }
        [BindProperty]
        public int deleteId { get; set; }
        public Item? Record { get; set; }
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IItemRepository _itemRepository;
        public ViewModel(IItemRepository itemRepository, IWebHostEnvironment hostingEnvironment)
        {
            _itemRepository = itemRepository; 
            _hostingEnvironment = hostingEnvironment;

        }

        public void OnGet()
        {
            Record = _itemRepository.Read(ItemId);
        }
        public IActionResult OnPostDelete()
        {
            Record = _itemRepository.Read(deleteId);
            DeleteFile();
            _itemRepository.Delete(deleteId);
            return RedirectToPage("/Index");
        }
        public void DeleteFile()
        {
            if (Record != null && Record.Datasheet != null) {
                string folder = Path.Combine(_hostingEnvironment.WebRootPath, "PDFs");
                string filePath = Path.Combine(folder, Record.Datasheet);
                System.IO.File.Delete(filePath);
            }
        }
    }
}
