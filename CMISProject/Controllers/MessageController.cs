using CMISProject.DAL;
using CMISProject.Models;
using CMISProject.ViewModels.MessageViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CMISProject.Controllers
{
    public class MessageController : Controller
    {
        //
        private CIMSEntities db = new CIMSEntities();

        // GET: /Message/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Message/Details/5
        public ActionResult Details(int? id)
        {
            //List<MessageViewModel> ViewModels = new List<MessageViewModel>();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if(message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }

        //
        // GET: /Message/Create
        public ActionResult Create()
        {
            return View(new MessageViewModel());
        }

        //
        // POST: /Message/Create
        [HttpPost]
        public ActionResult Create(MessageViewModel messageViewModel)
        {

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Resource resource = new Resource() 
                    { 
                        ResourceName = DateTime.Now.ToString("yyyymmddMMss") + messageViewModel.Attachment.FileName,
                        Filename = messageViewModel.Attachment.FileName,
                    };
                    Message message = new Message()
                    {
                        Attachment = resource,
                        MessageType = messageViewModel.MessageType,
                        Mode = messageViewModel.Mode,
                        Msg = messageViewModel.Msg,
                        React = messageViewModel.React,
                    };
                    db.Resources.Add(resource);
                    db.Messages.Add(message);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(messageViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }

            if (message.CreatedBy != User.Identity.Name)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            MessageViewModel messageViewModel = new MessageViewModel()
            {
                //Attachment = message.Attachment.ToString(),
                MessageType = message.MessageType,
                Mode = message.Mode,
                Msg = message.Msg,
                React = message.React,
            };

            return View(messageViewModel);
        }

        //
        // POST: /Message/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MessageViewModel messageViewModel)
        {

            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Resource resource = new Resource()
                    {
                        ResourceName = DateTime.Now.ToString("yyyymmddMMss") + messageViewModel.Attachment.FileName,
                        Filename = messageViewModel.Attachment.FileName,
                    };

                    Message message = new Message()
                    {
                        Attachment = resource,
                        MessageType = messageViewModel.MessageType,
                        Mode = messageViewModel.Mode,
                        Msg = messageViewModel.Msg,
                        React = messageViewModel.React,
                    };

                    if (message == null)
                    {
                        return HttpNotFound();
                    }
                    messageViewModel.Attachment.SaveAs(Path.Combine(Server.MapPath("~/Uploads/") , message.Attachment.ResourceName));
                    db.Entry(resource).State = EntityState.Modified;
                    db.Entry(message).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(messageViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }

            if (message.CreatedBy != User.Identity.Name)
            {
                ViewBag.ErrorMessage = "Sorry, you don't have access to delete the message.";
                return View("~/Views/Shared/Error.cshtml");
            }
            //db.Messages.Remove(message);
            //db.SaveChanges();

            return View(message);
        }

        //
        // POST: /Message/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Messages.Remove(db.Messages.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
