using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using NuGet.Protocol.Core.Types;
using PhotoSharingAppJessieDomingo.Data;
using PhotoSharingAppJessieDomingo.Models;
using System.Collections;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol;
using System.IO;
using System.Xml.Linq;

namespace PhotoSharingAppJessieDomingo.Controllers
{
    public class PhotoController : Controller
    {

        private IPhotoData _IPhotoData;
        private ICommentData _ICommentData;
        private IUserData _IUserData;
        //private IHostingEnvironment _environment;

        public PhotoController(IPhotoData _photodata, ICommentData _commentdata, IUserData _userdata)
        {
            _IPhotoData = _photodata;
            _ICommentData = _commentdata;
            _IUserData = _userdata;
        }
        public async Task<IActionResult> Index(string title)
        {
            var Username = HttpContext.Session.GetString("Username");

            if (Username != null && Username != "")
            {
                var Fullname = HttpContext.Session.GetString("Fullname");
                ViewBag.name = Fullname;
                ViewBag.Description = "Signed In";
            }
            else
            {
                ViewBag.Description = "Sign In";
            }

            if (title != null && title.Length > 0)
            {
                return View(await _IPhotoData.SearchPhotos(title));
            }
            else
            {
                return View(await _IPhotoData.GetPhotos());
            }

        }

        [HttpPost, ActionName("Search")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string Title)
        {

            return RedirectToAction("Index", new { title = Title });

        }



        [HttpGet]
        public IActionResult Create()
        {
            var Username = HttpContext.Session.GetString("Username");

            if (Username != null && Username != "")
            {
                var Fullname = HttpContext.Session.GetString("Fullname");
                ViewBag.name = Fullname;
                ViewBag.Description = "Signed In";
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost, ActionName("Create")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(PhotoModel _photo)
        {

            if (_photo.PhotoAvatar != null && _photo.PhotoAvatar.Length > 0)
            {
                _photo.ImageMimeType = _photo.PhotoAvatar.ContentType;
                _photo.ImageName = Path.GetFileName(_photo.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    _photo.PhotoAvatar.CopyTo(memoryStream);
                    _photo.PhotoFile = memoryStream.ToArray();
                }
                int i = await _IPhotoData.InsertPhoto(_photo);
                if (i == 1)
                {
                    return RedirectToAction("Index");
                }

                return View(_photo);
            }
            return View(_photo);
        }

        [HttpPost, ActionName("AddComment")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewComment(CommentModel _comment)
        {

            if (_comment.Body != null)
            {
                var Username = HttpContext.Session.GetString("Username");
                if (Username != null && Username != "")
                {
                    _comment.UserID = Username;

                    int i = await _ICommentData.InsertComment(_comment);

                    return RedirectToAction("Details", new { id = _comment.PhotoID });

                }
                else
                {
                    return RedirectToAction("Login");
                }


            }
            return RedirectToAction("Details", new { id = _comment.PhotoID });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Username = HttpContext.Session.GetString("Username");
            if (Username != null && Username != "")
            {
                var Fullname = HttpContext.Session.GetString("Fullname");
                ViewBag.name = Fullname;
                ViewBag.Description = "Signed In";
                ViewData["Photos"] = await _IPhotoData.GetPhoto(id);
                ViewData["Comments"] = (List<CommentModel>)await _ICommentData.GetComments(id);
                if (ViewData == null)
                {
                    return NotFound();
                }
                return View(ViewData);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Username = HttpContext.Session.GetString("Username");
            if (Username != null && Username != "")
            {
                var Fullname = HttpContext.Session.GetString("Fullname");
                ViewBag.name = Fullname;
                ViewBag.Description = "Signed In";

                var _photo = await _IPhotoData.GetPhoto(id);
                if (_photo == null)
                {
                    return NotFound();
                }
                return View(_photo);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost, ActionName("Delete")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _IPhotoData.DeletePhoto(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Slide()
        {
            var Username = HttpContext.Session.GetString("Username");

            if (Username != null && Username != "")
            {
                var Fullname = HttpContext.Session.GetString("Fullname");
                ViewBag.name = Fullname;
                ViewBag.Description = "Signed In";
            }
            else
            {
                ViewBag.Description = "Sign In";
            }

            return View(await _IPhotoData.GetPhotos());
        }

        public async Task<IActionResult> Gallery()
        {
            var Username = HttpContext.Session.GetString("Username");

            if (Username != null && Username != "")
            {
                var Fullname = HttpContext.Session.GetString("Fullname");
                ViewBag.name = Fullname;
                ViewBag.Description = "Signed In";
            }
            else
            {
                ViewBag.Description = "Sign In";
            }
            return View(await _IPhotoData.GetPhotos());
        }

        public async Task<IActionResult> GetImage(int id)
        {
            var requestedPhoto = await _IPhotoData.GetPhoto(id);
            if (requestedPhoto != null)
            {

                byte[] buffer = new byte[2048];

                buffer = requestedPhoto.PhotoFile;
                return File(buffer, "image/jpeg");
            }
            else
            {
                return NotFound();

            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            var Username = HttpContext.Session.GetString("Username");

            if (Username != null && Username != "")
            {
                var Fullname = HttpContext.Session.GetString("Fullname");
                ViewBag.name = Fullname;
                ViewBag.Description = "Signed In";
            }
            else
            {
                ViewBag.Description = "Sign In";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            var Username = HttpContext.Session.GetString("Username");

            if (Username != null && Username != "")
            {
                var Fullname = HttpContext.Session.GetString("Fullname");
                ViewBag.name = Fullname;
                ViewBag.Description = "Signed In";
            }
            else
            {
                ViewBag.Description = "Sign In";
            }
            return View();
        }

        [HttpPost, ActionName("Enroll")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel _usermodel)
        {

            if (_usermodel != null)
            {
                int i = await _IUserData.InsertUser(_usermodel);
                if (i == 1)
                {
                    return RedirectToAction("Verify");
                }

                return RedirectToAction("Signup");
            }
            return RedirectToAction("Signup");
        }

        [HttpPost, ActionName("Verify")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidateUser(string userid, string password)
        {

            ILoginModel _loginmodel = new LoginModel();
            _loginmodel = await _IUserData.Login(userid, password);
            if (_loginmodel != null)
            {
                if (_loginmodel.FullName != null && _loginmodel.FullName != "")
                {
                    var fullname = _loginmodel.FullName;
                    HttpContext.Session.SetString("Fullname", fullname);
                    var Username = _loginmodel.UserID;
                    HttpContext.Session.SetString("Username", Username);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}

