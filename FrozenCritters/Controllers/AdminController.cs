using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrozenCritters.ViewModels;
using System.IO;
using FrozenCritters.Models;

namespace FrozenCritters.Controllers
{
    [Authorize(Roles = Models.RoleAction.Admin)]
    [RequireHttps]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Products product)
        {
            var allowedExtensions = new[] { ".png", ".jpg" };

            if (ModelState.IsValid)
            {
                HttpPostedFileBase hpf = Request.Files[0];

                hpf = Request.Files[0];
                var extension = Path.GetExtension(hpf.FileName);
                if (Request.Files[0].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                {
                    product.ProductsPhoto = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                    hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto));
                }
                else
                {
                    product.ProductsPhoto = null;
                    if (Request.Files[0].ContentLength > 0)
                    {
                        ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                        return View();
                    }
                }

                hpf = Request.Files[1];
                extension = Path.GetExtension(hpf.FileName);
                if (Request.Files[1].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                {
                    hpf = Request.Files[1];
                    product.ProductsPhoto2 = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                    hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto2));
                }
                else
                {

                    product.ProductsPhoto2 = null;
                    if (Request.Files[1].ContentLength > 0)
                    {
                        ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                        return View();
                    }
                }

                hpf = Request.Files[2];
                extension = Path.GetExtension(hpf.FileName);
                if (Request.Files[0].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                {
                    hpf = Request.Files[2];
                    product.ProductsPhoto3 = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                    hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto3));
                }
                else
                {
                    product.ProductsPhoto3 = null;
                    if (Request.Files[2].ContentLength > 0)
                    {
                        ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                        return View();
                    }
                }

                hpf = Request.Files[3];
                extension = Path.GetExtension(hpf.FileName);
                if (Request.Files[0].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                {
                    hpf = Request.Files[3];
                    product.ProductsPhoto4 = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                    hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto4));
                }
                else
                {
                    product.ProductsPhoto4 = null;
                    if (Request.Files[3].ContentLength > 0)
                    {
                        ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                        return View();
                    }
                }

                hpf = Request.Files[4];
                extension = Path.GetExtension(hpf.FileName);
                if (Request.Files[0].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                {
                    hpf = Request.Files[4];
                    product.ProductsPhoto5 = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                    hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto5));
                }
                else
                {
                    product.ProductsPhoto5 = null;
                    if (Request.Files[4].ContentLength > 0)
                    {
                        ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                        return View();
                    }
                }

            }

            if (Models.FrozenCrittersDb.AddProduct(product))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult EditProduct()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductForm(int id)
        {
            return View(Models.FrozenCrittersDb.GetProd(id));
        }

        [HttpPost]
        public ActionResult ProductForm(Products product, int id)
        {
            var allowedExtensions = new[] { ".png", ".jpg" };
            Products prod = FrozenCritters.Models.FrozenCrittersDb.GetProd(id);
            if (ModelState.IsValid)
            {

                if (Request.Files.Count > 0 || Request.Files.Count != 0)
                {
                    HttpPostedFileBase hpf = Request.Files[0];
                    var extension = Path.GetExtension(hpf.FileName);
                    if (Request.Files[0].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                    {
                        product.ProductsPhoto = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                        hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto));
                    }
                    else
                    {

                        if (Request.Files[0].ContentLength > 0)
                        {
                            ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                            return View(FrozenCritters.Models.FrozenCrittersDb.GetProd(id));
                        }
                        product.ProductsPhoto = prod.ProductsPhoto;
                    }

                    if (Request.Files[1].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                    {
                        hpf = Request.Files[1];
                        product.ProductsPhoto2 = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                        hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto2));
                    }
                    else
                    {
                        if (Request.Files[1].ContentLength > 0)
                        {
                            ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                            return View(FrozenCritters.Models.FrozenCrittersDb.GetProd(id));
                        }
                        product.ProductsPhoto2 = prod.ProductsPhoto2;
                    }

                    if (Request.Files[2].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                    {
                        hpf = Request.Files[2];
                        product.ProductsPhoto3 = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                        hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto3));
                    }
                    else
                    {
                        if (Request.Files[2].ContentLength > 0)
                        {
                            ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                            return View(FrozenCritters.Models.FrozenCrittersDb.GetProd(id));
                        }
                        product.ProductsPhoto3 = prod.ProductsPhoto3;
                    }

                    if (Request.Files[3].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                    {
                        hpf = Request.Files[3];
                        product.ProductsPhoto4 = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                        hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto4));
                    }
                    else
                    {
                        if (Request.Files[3].ContentLength > 0)
                        {
                            ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                            return View(FrozenCritters.Models.FrozenCrittersDb.GetProd(id));
                        }
                        product.ProductsPhoto4 = prod.ProductsPhoto4;
                    }

                    if (Request.Files[4].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                    {
                        hpf = Request.Files[4];
                        product.ProductsPhoto5 = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                        hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), product.ProductsPhoto5));
                    }
                    else
                    {
                        if (Request.Files[4].ContentLength > 0)
                        {
                            ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                            return View(FrozenCritters.Models.FrozenCrittersDb.GetProd(id));
                        }
                        product.ProductsPhoto5 = prod.ProductsPhoto5;

                    }
                }
            }

            if (Models.FrozenCrittersDb.EditProduct(product, id))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public ActionResult AdminProductPage()
        {
            return View();
        }

        public ActionResult AddCategory(Categories category)
        {
            if (ModelState.IsValid)
            {
                if (Models.FrozenCrittersDb.AddCategory(category))
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CategoryForm(int id)
        {
            return View(Models.FrozenCrittersDb.GetCategory(id));
        }

        [HttpPost]
        public ActionResult CategoryForm(Categories cat, int id)
        {
            if (ModelState.IsValid)
            {
                if (FrozenCritters.Models.FrozenCrittersDb.EditCategory(cat, id))
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }

        public ActionResult EditCategory(Categories cat)
        {
            return View();
        }

        public ActionResult RemoveCategoryList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RemoveCategory(int id)
        {
            Models.FrozenCrittersDb.RemoveCategory(id);

            return View();
        }

        [HttpGet]
        public ActionResult ConfirmRemoveCategory(int id)
        {
            return View(Models.FrozenCrittersDb.GetCategory(id));
        }

        [HttpPost]
        public ActionResult ConfirmRemoveCategory(string id)
        {
            return View(Models.FrozenCrittersDb.RemoveCategory(Int32.Parse(id)));
        }

        public ActionResult AdminCategoryPage()
        {
            return View();
        }

        public ActionResult AddNews(ViewModels.AddNewsViewModel news)
        {
            if (ModelState.IsValid)
            {
                if (Models.FrozenCrittersDb.AddNews(news))
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }

        public ActionResult AdminNewsPage()
        {
            return View();
        }

        public ActionResult EditNews(News news)
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewsForm(int id)
        {
            return View(Models.FrozenCrittersDb.GetNews(id));
        }

        [HttpPost]
        public ActionResult NewsForm(News news, int id)
        {
            if (ModelState.IsValid)
            {
                if (Models.FrozenCrittersDb.EditNews(news, id))
                {
                    return RedirectToAction("Index", "Admin");
                }
                return View();
            }
            return View();
        }

        public ActionResult RemoveNewsList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RemoveNews(int id)
        {
            Models.FrozenCrittersDb.RemoveNews(id);

            return View();
        }

        [HttpGet]
        public ActionResult ConfirmRemoveNews(int id)
        {
            return View(Models.FrozenCrittersDb.GetNews(id));
        }

        [HttpPost]
        public ActionResult AddPhoto(Photos photo)
        {
            var allowedExtensions = new[] { ".png", ".jpg" };

            if (ModelState.IsValid)
            {
                HttpPostedFileBase hpf = Request.Files[0];

                hpf = Request.Files[0];
                var extension = Path.GetExtension(hpf.FileName);
                if (Request.Files[0].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                {
                    photo.PhotosFile = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                    hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), photo.PhotosFile));
                }
                else
                {
                    photo.PhotosFile = null;
                    ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                    return View();
                }
            }

            if (Models.FrozenCrittersDb.AddPhotos(photo))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddPhoto()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditPhoto(Photos photo)
        {
            return View();
        }

        [HttpGet]
        public ActionResult PhotoForm(int id)
        {
            return View(Models.FrozenCrittersDb.GetPhoto(id));
        }

        [HttpPost]
        public ActionResult PhotoForm(Photos photo, int id)
        {
            var allowedExtensions = new[] { ".png", ".jpg" };

            if (ModelState.IsValid)
            {
                Photos pho = FrozenCrittersDb.GetPhoto(id);
                if (Request.Files.Count > 0 || Request.Files.Count != 0)
                {
                    HttpPostedFileBase hpf = Request.Files[0];
                    var extension = Path.GetExtension(hpf.FileName);
                    if (Request.Files[0].ContentLength > 0 && (allowedExtensions.Contains(extension)))
                    {
                        photo.PhotosFile = Guid.NewGuid() + Path.GetFileName(hpf.FileName);
                        hpf.SaveAs(Path.Combine(Server.MapPath("//Content/img"), photo.PhotosFile));
                    }
                    else
                    {
                        photo.PhotosFile = pho.PhotosFile;
                        ViewBag.Error = "One of the file types you attempted to upload was incorrect. The file type must be a jpg or png";
                        return View();
                    }
                }
            }

            if (Models.FrozenCrittersDb.EditPhoto(photo, id))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public ActionResult RemovePhotoList()
        {
            ;
            return View();
        }

        [HttpGet]
        public ActionResult RemovePhoto(int id)
        {
            Models.FrozenCrittersDb.RemovePhoto(id);

            return View();
        }

        [HttpGet]
        public ActionResult ConfirmRemovePhoto(int id)
        {
            return View(Models.FrozenCrittersDb.GetPhoto(id));
        }

        [HttpPost]
        public ActionResult ConfirmRemovePhoto(string id)
        {
            return View(Models.FrozenCrittersDb.RemovePhoto(Int32.Parse(id)));
        }

        public ActionResult AdminPhotoPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UpdateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            if (ModelState.IsValid)
            {
                if (FrozenCritters.Models.FrozenCrittersDb.updateAbout(about))
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (FrozenCritters.Models.FrozenCrittersDb.UpdateContact(contact))
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }
        public ActionResult AdminLawsPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddLaw()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLaw(Laws law)
        {
            if (ModelState.IsValid)
            {
                if (FrozenCritters.Models.FrozenCrittersDb.AddLaw(law))
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult EditLaw()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LawForm(int id)
        {
            return View(Models.FrozenCrittersDb.GetLaw(id));
        }

        [HttpPost]
        public ActionResult LawForm(Laws law, int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult RemoveLaw(int id)
        {
            Models.FrozenCrittersDb.RemoveLaw(id);

            return View();
        }

        [HttpGet]
        public ActionResult RemoveLawList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmRemoveLaw(int id)
        {
            return View(Models.FrozenCrittersDb.GetLaw(id));
        }
    }
}