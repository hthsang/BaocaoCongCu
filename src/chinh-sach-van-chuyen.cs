 public ActionResult VanChuyen()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LienHe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LienHe(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact()
                {
                    From = model.From,
                    Subject = model.Subject,
                    Message = model.Message,
                    Read = false
                };
                db.Contacts.Add(contact);
                db.SaveChanges();
                ModelState.AddModelError("", "Cảm ơn bạn đã góp ý. Thư của bạn đã được gửi đi, chúng tôi sẽ phản hồi lại qua email "+model.From+" !");
            }
            return View(model);
        }