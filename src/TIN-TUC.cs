#TIN TỨC

public ActionResult KhuyenMai(int itemId = 0)
        {
            if (itemId == 0)
            {
                var model = db.Sales.OrderByDescending(e => e.Id).Take(10).ToList();
                return View(model);
            }
            else
            {
                var model = db.Sales.SingleOrDefault(e => e.Id == itemId);
                if (model == null)
                    return RedirectToAction("KhuyenMai");
                return View("ChiTietKhuyenMai", model);
            }
        }