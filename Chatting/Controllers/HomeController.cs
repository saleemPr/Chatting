using Chatting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chatting.Views
{
    public class HomeController : Controller
    {
        public static int sid;
        public static int rid;
        ChattingUs db = new ChattingUs();
        public ActionResult Index()
        {
            ViewData["Names"] = db.Registers.ToList();
            ViewData["LMsg"] = db.Messages.ToList();
            return View();
        }
        public ActionResult messages(int id)
        {
            ViewData["Names"] = db.Registers.ToList();
            ViewData["LMsg"] = db.Messages.ToList();
            sid = Convert.ToInt32(Session["Id"]);
            Session["receiver"] = id;
            rid = id;
            //ViewData["msg"] = db.Messages.Where(msg => msg.ReceiverId == id && msg.SenderId == sid ||
            //msg.ReceiverId == sid && msg.SenderId == id);
            return View(db.Messages.Where(msg => msg.ReceiverId == id && msg.SenderId == sid ||
             msg.ReceiverId == sid && msg.SenderId == id));
        }
        public void msgsave(int SId , int RId, string message)
        {
            
                Messages msg = new Messages();
                msg.DateTime = DateTime.Now;
                msg.SenderId = SId;
                msg.ReceiverId = RId;
                msg.Message = message;
                db.Messages.Add(msg);
                db.SaveChanges();
            
        }
        public void UpdateState(int SId, string status)
        {
            db.Registers.Find(SId).Status = status;
            db.SaveChanges();
        }
        
    }
}