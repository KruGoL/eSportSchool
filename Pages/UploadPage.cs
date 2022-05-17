using eSportSchool.Domain;
using eSportSchool.Facade;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace eSportSchool.Pages
{
    public abstract class UploadPage<TView, TEntity, TRepo> : PagedPage<TView, TEntity, TRepo>,
        IPageModel, IIndexModel<TView>
        where TView : UniqueView, new()
        where TEntity : UniqueEntity
        where TRepo : IPagedRepo<TEntity>
    {
        [BindProperty]
        public IFormFile? File { get; set; }
        protected string _item;
        protected string _folderPath;
        protected string _defaultFileName; 
        private 
        IHostingEnvironment _webHostEnv;
        protected UploadPage(TRepo r, IHostingEnvironment webHostEnv) : base(r){_webHostEnv = webHostEnv;}
        protected string UploadFile(string folderPath,string defaultFileName = "Unknown file")
        {
            string? uniqueFileName = null;
            if (File != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnv.WebRootPath, folderPath);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fs = new FileStream(filePath, FileMode.Create)) { File.CopyTo(fs); }
            }
            return uniqueFileName ?? defaultFileName;
        }
        protected override async Task<IActionResult> postEditAsync()
        {
            if (File != null)
            {
                PropertyInfo p = GetPropertyFile(_item);
                if (p != null)
                {
                    if (p.GetValue(Item) != null)
                    {
                        string filePath = Path.Combine(_webHostEnv.WebRootPath, _folderPath, p.GetValue(Item).ToString());
                        var my = p.GetValue(Item).ToString();
                        if (my != _defaultFileName)
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                    p.SetValue(Item, UploadFile(_folderPath, _defaultFileName));
                }               
            }
            return await base.postEditAsync();
        }
        protected override async Task<IActionResult> postCreateAsync()
        {
            PropertyInfo p = GetPropertyFile(_item) ;
            if (p != null) { p.SetValue(Item, UploadFile(_folderPath, _defaultFileName)); }
            return await base.postCreateAsync();
        }
        private PropertyInfo? GetPropertyFile(string itemName)
        {
            Type t = typeof(TView);
            PropertyInfo[] propInfos = t.GetProperties();
            foreach (PropertyInfo p in propInfos)
            {
                if (p.Name == itemName) return p;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Property to create file does not exist ");
            Console.ResetColor();
            return null;
        }
    }
}
