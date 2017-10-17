<%@ Page Title="" Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Justice.Main.Product" %>

<asp:Content ID="Content" ContentPlaceHolderID="HeaderContent" runat="server">
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <style>
        .sp-zoom {
            width: 900px;
        }
        .sp-zoom img {
            width: 100%;
        }
        .navbar-static-top {
            z-index: 1;
            border-width: 0 0 1px;
        }
        .top-primary-menu ul li a {
        font-size: 12px;
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <section id="product_single">
                <div class="container">
                    <div class="row">
						<div class='col-md-12'>
                            <div class='title'>
                                <h3>
                                    <a href='../Index.aspx'>Ana Səhifə</a> 
                                    <i class='fa fa-arrow-right' aria-hidden='true'></i> 
                                    <a href='../Category?id=<%= data["kateqoriya_ID"]%>'> <%= data["mehsul_kateqoriya"] %></a> 
                                    <i class='fa fa-arrow-right' aria-hidden='true'></i> 
                                     <%= data["mehsul_ad"] %>
                                </h3>
                            </div>
                        </div>
                        <div class='col-md-5'>
                            <div class='page'>
                                <div class='sp-loading'><img src='/Content/Main/images/sp-loading.gif' alt=''><br>LOADING IMAGES</div>
                                <div class='sp-wrap'>
                                    <a href='/Content/Main/images/products/<%= data["image1"] %>.jpg'><img src='/Content/Main/images/products/<%= data["image1"] %>.jpg' alt=''></a>
                                    <a href='/Content/Main/images/products/<%= data["image2"] %>.jpg'><img src='/Content/Main/images/products/<%= data["image2"] %>.jpg' alt=''></a>
                                    <a href='/Content/Main/images/products/<%= data["image3"] %>.jpg'><img src='/Content/Main/images/products/<%= data["image3"] %>.jpg' alt=''></a>
                                    <a href='/Content/Main/images/products/<%= data["image4"] %>.jpg'><img src='/Content/Main/images/products/<%= data["image4"] %>.jpg' alt=''></a>
                                </div>
                            </div>
                            <br>
                        </div>
                        <div class='col-md-7'>
                            <div class='product_single_about'>
                                <table class='table table-striped table-responsive'>
                                  <tbody>
										<tr>
										  <td>Məhsul kodu</td>
										  <td><%= data["mehsul_kod"] %></td>
										</tr>
										<tr>
										  <td>Məhsulun adı</td>
										  <td><%= data["mehsul_ad"] %></td>
										</tr>
										<tr>
										  <td> Məhsulun ölçüləri</td>
										  <td><%= data["mehsul_olcu"] %> sm</td>
										</tr>
										<tr>
											<td>Məhsulun material növü</td>
											<td><%= data["mehsul_material"] %></td>
										</tr>
										<tr>
											<td>Məhsulun kateqoriyası</td>
											<td><%= data["mehsul_kateqoriya"] %></td>
										</tr>
										<tr>
											<td>Məhsulun çəkisi</td>
											<td><%= data["mehsul_ceki"] %> kq</td>
										</tr>
										<tr>
											<td>Anbardakı sayı</td>
											<td><%= data["mehsul_say"] %></td>
										</tr>
										<tr>
											<td>Əlavə məlumat</td>
											<td><%= data["elave_melumat"] %></td>
										</tr>

										<tr>
											<td>Qiyməti </td>
											<td><%= data["mehsul_qiymet"] %> AZN</td>
										</tr>
										<tr>
											<td>Endirimli qiyməti</td>
											<td><%= data["endirimli_qiymet"] %> AZN</td>
										</tr>
                                  </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
         <section id='add'>
                <div class='container'>
                    <div class='row'>
                        <div class='col-md-8 col-md-offset-4'>
                            <asp:LinkButton cssClass='pull-right btn btn-success addtobasket' runat="server" ID="addToCart" OnClick="addToCart_Click">
                                   <i class='fa fa-shopping-cart' aria-hidden='true'></i>Səbətə əlavə et
                            </asp:LinkButton>
                            <button type='button' class=' pull-right btn btn-secondary'>
								<a href='/api/?v=1&m=addFavorite&user_id=".$json2->data->id."&product_id=".$json->data[0]->id."'><i class='fa fa-star-o'></i>Bəyəndiklərimə əlavə et</a>
                            </button>
                        </div> <br/> <br/>
					<div id='fb-root'></div>
			<script>
                (function (d, s, id) {
                    var js, fjs = d.getElementsByTagName(s)[0];
                    if (d.getElementById(id)) return;
                    js = d.createElement(s); js.id = id;
                    js.src = '//connect.facebook.net/aze_AZE/sdk.js#xfbml=1&version=v2.9';
                    fjs.parentNode.insertBefore(js, fjs);
                }(document, 'script', 'facebook-jssdk'));
		</script>
			
                <div class='fb-comments' data-href='http://192.168.5.22/api/?v=1&m=getProduct&code=".$code."' data-width='100%' data-numposts='10'></div>
                    </div>
                </div>
            </section>
			
            <section id='products'>
                <div class='container'>
                    <div class='col-md-12 title'>
                    <h3>Oxşar Məhsullar</h3>
                        
                    </div>
                    <div class='row'>
                        <div class='col-md-3'>
                            <div class='product'>
                            		<div class='discount' style='right:25px;'>
                                        <span>". ceil(($data->price - $data->discount)*100/$data->price)."%</span>
										</div>
                                    <div class='images'>
                                        <a href='productsingle.php?code=". $data->code ."'><img class='img-responsive'  src='thumb/thumb_".$data->image1."' alt=''></a>
                                    </div>
                                    <div class='detailes'>
                                        <h5 class='text-center'>
                                            <a href='productsingle.php?code=". $data->code ."'>". $data->product_name ."</a>
                                        </h5>
                                        <div class='addShopp'>
                                            <p class='pull-left'>". $data->price ." AZN</p><a href=''> 
                                            <button class='pull-right'>
                                                    <a href='/api/?v=1&m=addFavorite&user_id=".$json2->data->id."&product_id=".$data->id."'><i class='fa fa-star-o fa-2x' aria-hidden='true'></i></a>
                                            </button>
                                            </a>
                                        </div>
                                   </div>
                              </div>
                        </div>
					</div>
                </div>
            </section>
</asp:Content>

<asp:Content ID="EndContent" ContentPlaceHolderID="EndContent" runat="server">
    <script src="/Scripts/Main/bootstrap.js"></script> 
    <script src="/Scripts/Main/script.js" ></script>
    <script type="text/javascript" src="/Scripts/Main/smoothproducts.min.js"></script>
<script type="text/javascript">
    /* wait for images to load */
    $(window).load(function () {
        $('.sp-wrap').smoothproducts();
        $('.addtobasket').click(function () {
            var id = $(this).data('id'), price = $(this).data('price'), img = $(this).data('img'), name = $(this).data('name'), code = $(this).data('code');
            var data = [];
            data.push({ 'id': id }), data.push({ 'name': name }), data.push({ 'price': price }), data.push({ 'img': img }), data.push({ 'code': code }), data.push({ 'action': 'add' });
            if (id > 0) {
                $.post('basket-action.php', { data: data }).done(function (data) {
                    console.log(data.cart_item);
                    $('.basketcount').html(data.cart_item);
                });
            }
        });

        $('.removebasketproduct').click(function () {
            var id = $(this).data('id');
            var data = [];
            data.push({ 'id': id }), data.push({ 'action': 'remove' });
            $.post('basket-action.php', { data: data }).done(function (data) {
                if (data.success == true) {
                    $('#product-' + data.id).remove(), $('#product_count').html(data.product_count), $('#product_sum').html(data.product_sum), $('.basketcount').html(data.product_sum);
                }
            });
        });
    });
    </script>  
 </asp:Content>
  
        
