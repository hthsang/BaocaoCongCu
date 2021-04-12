# pLAYOUT tRANG CHỦ


@{ 
    var db = new DAN.Models.DANEntities();
}
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <link rel="shortcut icon" type="image/png" href="~/assets/images/android-icon-36x36.png" />
    <title>@ViewBag.Title</title>
    @Styles.Render("~/Styles/css")
    @Scripts.Render("~/bundles/modernizr")

</head>
<body>
    <div id="wrapper">
        @if (User.Identity.IsAuthenticated)
        {
            if (User.Identity.Name == "admin")
            {
                @:Xin chào, @User.Identity.Name <a href="/System/Manage">Bảng điều khiển</a>|
            }
            
        }
        <header id="header">
            <div class="container">
                <div class="row" style="width: 130% !important;">
                    <div class="col-lg-12">
                        <div class="col-md-5 col-sm-6 col-xs-12">
                            <a href="/"><div class="logo" style="background-image: url(/images/DYOGdob.jpg);"></div></a>

                        </div>
                        <div class="col-md-4" style="padding-left: 0px;">
                            <b style="color:#000000; font-size: 48px;font-family:'Times New Roman', Times, serif;">𝕊𝕒𝕚𝔾𝕠𝕟 𝔸𝕦𝕥𝕙𝕖𝕟𝕥𝕚𝕔</b>
                        </div>
                        <div class="col-md-3">
                            <span class="hotline visible-lg">
                               0397488875
                            </span>
                            <span>
                                @*<a href="" style="background-color: #339900; color: #FFF; padding: 10px;">Đăng nhập</a>*@
                                @if (!User.Identity.IsAuthenticated tran ca phu)
                                {
                                    <h5 style="float: right">
                                        <a style="background: #339900; border-radius: 20px; text-align: center;padding: 10px; color: #FFF;margin-right: 20px;" href="/System/Home/Login">
                                            Đăng nhập
                                        </a>
                                    </h5>
                                }
                                else
                                {
                            <h5 style="float:left; #339900; border-radius: 20px; text-align: center;padding: 10px;margin-right: 20px;">Xin chào, @User.Identity.Name!  <a style="background-color: #009900; padding: 10px; border-radius: 10px;color: #FFF; font-weight: bold;" href="/System/Home/Logout">Thoát</a> </h5>
                                  
                                }
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="wrapper-menu" style="margin-top: 0px;padding-bottom: 10px;border-radius: 40px;">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="select-mate visible-xs">
                                <select id="select-mate">
                                    <option value="" selected>Lựa chọn Menu</option>
                                    <option value="/">Trang chủ</option>
                                    <optgroup label="Danh mục món ăn">
                                        @foreach (var item in db.Categories.ToList())
                                        {
                                            <option value="/Category/Index/@item.CId">@item.Cname</option>
                                        }
                                    </optgroup>
                                    <option value="/Home/KhuyenMai">Tin tức</option>
                                    <option value="/Home/Chinh-Sach-Van-Chuyen">Chính sách vận chuyển</option>
                                    <option value="/Home/LienHe">Liên hệ cửa hàng</option>
                                </select>
                            </div>
                            <div class="hidden-xs">
                                <ul>
                                    <li>
                                        <a href="/">Trang chủ</a>
                                    </li>
                                    <li class="mdrop">
                                        Danh sách món ăn
                                        <ul class="mdrop-menu">
                                            @foreach (var item in db.Categories.ToList())
                                            {
                                                <li><a href="/Category/Index/@item.CId">@item.Cname</a></li>
                                            }
                                        </ul>
                                    </li>
                                    <li>
                                        <a href="/Home/KhuyenMai">Tin tức</a>
                                    </li>
                                    <li class="visible-lg">
                                        <a href="/Home/Chinh-Sach-Van-Chuyen">Chính sách vận chuyển</a>
                                    </li>
                                    <li>

                                        <a href="/Home/LienHe">Liên hệ cửa hàng</a>
                                    </li>
                                </ul>
                            </div>
                            <div style="display: block;padding-top: 12px;">
                                @using (Html.BeginForm("SearchProduct", "Home", FormMethod.Get)) // -- phần thay đổi
                                {
                                    <p>
                                        @Html.TextBox("searchStr", null, new { style = "max-width:100% !important;", @placeholder = "Tìm kiếm" }) <input style="display: contents;" type="submit" value="Tìm kiếm" />
                                    </p>
                                }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="shopping-cart" onclick="showCart()">
                <span class="counter">
                    @if (Session["Cart"] == null)
                    {
                        @: 0
                    }
                    else
                    {
                        @(((List<DAN.Models.Product>)Session["Cart"]).Count)
                    }
                </span>
            </div>
        </header><!-- /header -->
        <div id="content">
            @RenderBody()
        </div>
        <footer id="footer">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-6 col-xs-12"></div>
                    <div class="col-md-4"></div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <div class="contact">
                            Liên hệ
                        </div>
                        <p class="c-text"><i class="glyphicon glyphicon-home"></i> Địa chỉ: NHON TRACH , DONG NAI </p>
                        <p class="c-text"><i class="glyphicon glyphicon-earphone"></i> Hoteline: 0397488875 </p>
                        <p class="c-text"><i class="glyphicon glyphicon-envelope"></i> Email: nguyenthong1799@gmail.com</p>
                        <p class="c-text"><i class="glyphicon glyphicon-time"></i> Mở cửa: 8h-22h</p>
                    </div>
                </div>
            </div>
        </footer>
        <div class="copyright"></div>
        <div id="up-arrow"></div>
    </div>
    <!-- Load Facebook SDK for JavaScript -->
    <div id="fb-root"></div>
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                xfbml: true,
                version: 'v7.0'
            });
        };

        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = 'https://connect.facebook.net/vi_VN/sdk/xfbml.customerchat.js';
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));</script>

    <!-- Your customer chat code -->
    <div class="fb-customerchat"
         attribution=setup_tool
         page_id="111729403863727"
         theme_color="#13cf13"
         logged_in_greeting="Chào bạn! Đồ ăn vặt HUTECH  có thể giúp gì cho bạn ?"
         logged_out_greeting="Chào bạn! Đồ ăn vặt HUTECH có thể giúp gì cho bạn ?">
    </div>

    <div class="fb-customerchat"
         page_id="<PAGE_ID>">
    </div>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/sitejs")
    @Scripts.Render("~/bundles/bootstrap")
</body>
</html>
