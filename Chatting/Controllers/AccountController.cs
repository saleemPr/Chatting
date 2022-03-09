using Chatting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chatting.Controllers
{
    public class AccountController : Controller
    {
        ChattingUs db = new ChattingUs();
        [HttpGet]
        public ActionResult Register()
        {
            Session["Reg"] = "Hidethis";
            Session["Log"] = "Viewthis";
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register Chat,HttpPostedFileBase image)
        {
            var User = from U in db.Registers.Where(Us => Us.UserName == Chat.UserName) select U.UserName;
            if (ModelState.IsValid)
            {
                if(User.Count() > 0)
                {
                    ViewData["NotValid"] = "This username already exist";
                    ViewData["success"] = "";
                    Session["Message"] = "";
                }
                else
                {
                    ViewData["success"] = "registered succeed";
                    ViewData["NotValid"] = "";
                    Session["Message"] = "";
                    if (image != null)
                    {
                        var fn = Path.GetFileName(image.FileName);
                        var path = Path.Combine(Server.MapPath("~/pictures"), fn);
                        image.SaveAs(path);
                        Chat.Image = fn;
                    }
                    else
                    {
                        Chat.Image = "user-2517433_960_720.png";
                    }

                    Chat.Status = "away";
                    db.Registers.Add(Chat);
                    db.SaveChanges();
                }
            }
            Session["Reg"] = "Viewthis";
            Session["Log"] = "Hidethis";
            return View();
        }
        public ActionResult Login(Register Chat)
        {
            var Check = db.Registers.FirstOrDefault(m=>m.UserName==Chat.UserName && m.Password == Chat.Password);
            if (Check != null)
            {
                Session["Id"] = Check.Id;
                int sendid = Convert.ToInt32(Session["Id"]);
                var LMessage = db.Messages.ToList() as IEnumerable<Messages>;
                int lstchat;
                if (LMessage.LastOrDefault(lst => lst.SenderId == sendid) != null)
                {
                    lstchat = LMessage.LastOrDefault(lst => lst.SenderId == sendid).ReceiverId;
                }
                else if(LMessage.LastOrDefault(lst => lst.ReceiverId == sendid) != null)
                {
                    lstchat = LMessage.LastOrDefault(lst => lst.ReceiverId == sendid).SenderId;
                }
                else
                {
                    lstchat = 13;
                }
                return RedirectToAction("messages", "Home", new { id = lstchat});
            }
            else
            {
                Session["Message"] = "User Name or Password Not Valid";
                ViewData["NotValid"] = "";
                ViewData["success"] = "";
                Session["Reg"] = "Hidethis";
                Session["Log"] = "Viewthis";
                return RedirectToAction("Register");
            }

        }
    }
}