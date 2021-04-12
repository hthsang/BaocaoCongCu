public ActionResult SearchProduct(string searchStr, int page = 0)
        {
		//Trần Cả Phú
            var product = from p in db.Products select p;
            if (!String.IsNullOrEmpty(searchStr))
            {
                product = product.Where(p => p.Pname.Contains(searchStr));
            }
            return View("SearchProduct", product.ToList());
        }