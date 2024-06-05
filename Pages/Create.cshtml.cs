using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projekt_web.Models;

namespace projekt_web.Pages
{
    public class CreateModel : PageModel, IDisposable
    {
        [BindProperty]
        public IFormFile? UploadedPdfFile { get; set; }
        [BindProperty]
        public string? DivDescriptionContent { get; set; }
        [BindProperty]
        public string? DivNameContent { get; set; }
        [BindProperty]
        public string? DivDatasheetContent {  get; set; }
        public Item Record { get; set; }

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IItemRepository _itemRepository;
        
        public CreateModel(IItemRepository itemRepository, IWebHostEnvironment hostingEnvironment)
        {
            if (Record == null) Record = new Item();
            _hostingEnvironment = hostingEnvironment;
            _itemRepository = itemRepository;
        }
        public void OnGet()
        {
            
        }
        // operacje na plikach - zapisywanie/usuwanie tymczasowych/stałych plików
        public IActionResult OnPostSave()
        {
            if (DivNameContent == null)
            {
                return null;
            }
            if (DivDatasheetContent != null && DivDatasheetContent.StartsWith("tmp_"))
            {
                string savedFileName = DivDatasheetContent.Substring(4);
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "PDFs");
                string oldFilePath = Path.Combine(uploadsFolder, DivDatasheetContent);
                string newFilePath = Path.Combine(uploadsFolder, savedFileName);

                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Move(oldFilePath, newFilePath);
                    Record.Datasheet = savedFileName;
                }
            }
            Record.Description = DivDescriptionContent;
            Record.Name = DivNameContent;
            if (_itemRepository.Create(Record) == 1)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }

        }
        public async Task SavePdfFileAsync()
        {
            if (UploadedPdfFile != null && UploadedPdfFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "PDFs");
                string uniqueFileName = "tmp_" + Guid.NewGuid().ToString() + "_" + UploadedPdfFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await UploadedPdfFile.CopyToAsync(stream);
                    Record.Datasheet = uniqueFileName;
                }
            }
        }
        public async Task<IActionResult> OnPostUploadAsync()
        {
            await SavePdfFileAsync();
            return Page(); 
        }
        public void Dispose()
        {
            //DeleteTemporaryFiles();
        }
        ~CreateModel()
        {
            Dispose();
        }
    }
}
