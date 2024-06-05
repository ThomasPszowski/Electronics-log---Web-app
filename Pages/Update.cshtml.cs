using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projekt_web.Models;
using System.Collections.ObjectModel;

namespace projekt_web.Pages
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public IFormFile? UploadedPdfFile { get; set; }
        [BindProperty]
        public string? DivDescriptionContent { get; set; }
        [BindProperty]
        public string? DivNameContent { get; set; }
        [BindProperty]
        public string? DivDatasheetContent { get; set; }
        [BindProperty]
        public string? DivIdContent { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ItemId { get; set; }
        public Item? Record { get; set; }
        private readonly IItemRepository _itemRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UpdateModel(IItemRepository itemRepository, IWebHostEnvironment hostingEnvironment)
        {
            if (Record == null) Record = new Item();
            _itemRepository = itemRepository;
            _hostingEnvironment = hostingEnvironment;
        }
        public void OnGet()
        {
            if (ItemId == 0) { ItemId = Int32.Parse(DivIdContent); }

            Record = _itemRepository.Read(ItemId);

        }
        public IActionResult OnPostSave()
        {
            Record = new Item();
            if (DivNameContent == null || DivIdContent == null )
            {
                return Page();
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
            else
            {
                Record.Datasheet = DivDatasheetContent;
            }
            Record.Description = DivDescriptionContent;
            Record.Name = DivNameContent;
            Record.Id = Int32.Parse(DivIdContent);
            if (_itemRepository.Update(Record) == 1)
            {
                return Page();
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
    }
}
