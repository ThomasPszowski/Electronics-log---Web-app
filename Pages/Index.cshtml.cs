using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting.Internal;
using projekt_web.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace projekt_web.Pages
{
    public class IndexModel : PageModel
    {

        public ObservableCollection<Item> Items { get; set; }
        [BindProperty]
        public string? KeyWord { get; set; } = string.Empty;
        [BindProperty]
        public string? SearchDescription { get; set; } = string.Empty;
        [BindProperty]
        public int deleteId {  get; set; }
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IItemRepository itemRepository, IWebHostEnvironment hostingEnvironment)
        {
            Items = new ObservableCollection<Item>();
            Item.FillTest(Items);

            _logger = logger;
            _itemRepository = itemRepository;
            _hostingEnvironment = hostingEnvironment;

            DeleteTemporaryFiles();
        }

        public void OnGet()
        {

            if (Request.Cookies.TryGetValue("KeyWord", out string? keyword))
            {
                KeyWord = keyword;
            }
            else
            {
                KeyWord = string.Empty;
            }
            _itemRepository.SearchAll(Items, KeyWord);
        }
        public IActionResult OnPostDelete()
        {
            _itemRepository.Delete(deleteId);   
            return RedirectToPage();
        }
        public IActionResult OnPostSearch()
        {
            if (KeyWord == null) KeyWord = string.Empty;
            _itemRepository.SearchAll(Items, KeyWord);
            CookieOptions keyWordCookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };
            Response.Cookies.Append("Keyword", KeyWord, keyWordCookieOptions);
            return RedirectToPage();
        }

        public void DeleteTemporaryFiles()
        {
            string tempFolder = Path.Combine(_hostingEnvironment.WebRootPath, "PDFs");

            if (Directory.Exists(tempFolder))
            {
                foreach (string? file in Directory.GetFiles(tempFolder, "tmp*"))
                {
                    try
                    {
                        System.IO.File.Delete(file);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting file {file}: {ex.Message}");
                    }
                }
            }
        }
    }
}