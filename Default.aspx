<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" ViewStateMode="Disabled" EnableViewState="false" EnableViewStateMac="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%@ MasterType virtualpath="~/Site.User.master" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Literal ID="HeaderSection" runat="server"></asp:Literal>


 

        
       <%-- Blog Page TEMPLATE--%>
        <section  style="padding-top:9px;padding-bottom: 20px;" id="SectionBlogPage"  class="page_content" runat="server" visible="false">
            Blog Page
        </section>
       <%-- Product Page TEMPLATE--%>
        
       <%-- Product Page TEMPLATE--%>
        <section  style="padding-top:9px;padding-bottom: 20px;" id="SectionProduct"  class="page_content" runat="server" visible="false">
              Product Page
        </section>
      <%-- Product Page TEMPLATE--%>
        

        <!-- PAGE TEMPLATE-->
		<section  style="padding-top:9px;padding-bottom: 20px;" id="page_content"  class="page_content" runat="server" visible="false">
			
			
			<div class="container" >

			  <% Response.Write(this.ContentBody); %>

             
			</div>
		</section>
        <!--  PAGE TEMPLATE -->

        

        <!-- PAGE HOME TEMPLATE -->
         <section id="section_page_home" runat="server" visible="false">
            <!-- TOVAR SECTION -->
		        <section class="tovar_section">
			
			        <!-- CONTAINER -->
			        <div class="container">
				        <h2>สินค้าแนะนำ</h2>
				
				        <!-- ROW -->
				        <div class="row">
					
					        <!-- TOVAR WRAPPER -->
					        <div class="tovar_wrapper" data-appear-top-offset='-100' data-animated='fadeInUp'>
						

                                <%  Model_Post p = new Model_Post();
                                    List<Model_Post> plist = p.GetPostByTax("สินค้าแนะนำ");
                                    foreach (Model_Post item in plist)
                                    {
                                    %>
						        <!-- TOVAR1 -->
						        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-6 col-ss-12 padbot40">
							        <div class="tovar_item">
								        <div class="tovar_img">
									        <div class="tovar_img_wrapper">
										        <img class="img" src="images/tovar/women/1.jpg" alt="" />
										        <img class="img_h" src="images/tovar/women/1_2.jpg" alt="" />
									        </div>
									        <div class="tovar_item_btns">
										        <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a></div>
										        <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
										        <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
									        </div>
								        </div>
								        <div class="tovar_description clearfix">
									        <a class="tovar_title" href="<%Response.Write(item.Permarlink); %>" ><%  Response.Write(item.Title);%></a>
									        <span class="tovar_price">$98.00</span>
								        </div>
							        </div>
						        </div><!-- //TOVAR1 -->
						
						       
						<%} %>
						        <div class="respond_clear_768"></div>
						
						        <!-- BANNER -->
						        <div class="col-lg-3 col-md-3 col-xs-6 col-ss-12">
							        <a class="banner type1 margbot30" href="javascript:void(0);"  ><img src="images/tovar/banner1.jpg" alt="" /></a>
							        <a class="banner type2 margbot40" href="javascript:void(0);" ><img src="images/tovar/banner2.jpg" alt="" /></a>
						        </div><!-- //BANNER -->
					        </div><!-- //TOVAR WRAPPER -->
				        </div><!-- //ROW -->
				
				
				        <!-- ROW -->
				        <div class="row">
					
					        <!-- TOVAR WRAPPER -->
					        <div class="tovar_wrapper" data-appear-top-offset='-100' data-animated='fadeInUp'>
						
						        <!-- BANNER -->
						        <div class="col-lg-3 col-md-3 col-xs-6 col-ss-12">
							        <a class="banner type3 margbot40" href="javascript:void(0);" ><img src="images/tovar/banner3.jpg" alt="" /></a>
						        </div><!-- //BANNER -->
						
						        <div class="respond_clear_768"></div>
						
						        <!-- TOVAR4 -->
						        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-6 col-ss-12 padbot40">
							        <div class="tovar_item">
								        <div class="tovar_img">
									        <div class="tovar_img_wrapper">
										        <img class="img" src="images/tovar/women/4.jpg" alt="" />
										        <img class="img_h" src="images/tovar/women/4_2.jpg" alt="" />
									        </div>
									        <div class="tovar_item_btns">
										        <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/4.html" >quick view</a></div>
										        <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
										        <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
									        </div>
								        </div>
								        <div class="tovar_description clearfix">
									        <a class="tovar_title" href="product-page.html" >Peacoat trench</a>
									        <span class="tovar_price">$298.00</span>
								        </div>
							        </div>
						        </div><!-- //TOVAR4 -->
						
						        <!-- TOVAR5 -->
						        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-6 col-ss-12 padbot40">
							        <div class="tovar_item tovar_sale">
								        <div class="tovar_img">
									        <div class="tovar_img_wrapper">
										        <img class="img" src="images/tovar/women/5.jpg" alt="" />
										        <img class="img_h" src="images/tovar/women/5_2.jpg" alt="" />
									        </div>
									        <div class="tovar_item_btns">
										        <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/5.html" >quick view</a></div>
										        <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
										        <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
									        </div>
								        </div>
								        <div class="tovar_description clearfix">
									        <a class="tovar_title" href="product-page.html" >Schoolboy blazer in italian wool</a>
									        <span class="tovar_price">$194.00</span>
								        </div>
							        </div>
						        </div><!-- //TOVAR5 -->
						
						        <!-- TOVAR6 -->
						        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-6 col-ss-12 padbot40">
							        <div class="tovar_item">
								        <div class="tovar_img">
									        <div class="tovar_img_wrapper">
										        <img class="img" src="images/tovar/women/6.jpg" alt="" />
										        <img class="img_h" src="images/tovar/women/6_2.jpg" alt="" />
									        </div>
									        <div class="tovar_item_btns">
										        <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/6.html" >quick view</a></div>
										        <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
										        <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
									        </div>
								        </div>
								        <div class="tovar_description clearfix">
									        <a class="tovar_title" href="product-page.html" >Cashmere mockneck sweater</a>
									        <span class="tovar_price">$257.00</span>
								        </div>
							        </div>
						        </div><!-- //TOVAR6 -->


					        </div><!-- //TOVAR WRAPPER -->
				        </div><!-- //ROW -->
				
				
				        <!-- ROW -->
				        <div class="row">
					
					        <!-- BANNER WRAPPER -->
					        <div class="banner_wrapper" data-appear-top-offset='-100' data-animated='fadeInUp'>
						        <!-- BANNER -->
						        <div class="col-lg-9 col-md-9">
							        <a class="banner type4 margbot40 gs-banner-custom" href="javascript:void(0);" style="background-image:url(<%:this.CTF.SingleOrDefault(b=>b.PcName == "banner-announce").URL %>);height:100px;" ></a>
						        </div><!-- //BANNER -->
						
						        <!-- BANNER -->
						        <div class="col-lg-3 col-md-3">
							        <a class="banner nobord margbot40 gs-banner-custom" href="javascript:void(0);" style="background-image:url(<%:this.CTF.SingleOrDefault(b=>b.PcName == "banner-announce-right").URL %>);height:100px;" ></a>
						        </div><!-- //BANNER -->
					        </div><!-- //BANNER WRAPPER -->
				        </div><!-- //ROW -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //TOVAR SECTION -->
		
		
		        <!-- NEW ARRIVALS -->
		        <section class="new_arrivals padbot50">
			
			        <!-- CONTAINER -->
			        <div class="container">
				        <h2>สินค้ามาใหม่</h2>
				
				        <!-- JCAROUSEL -->
				        <div class="jcarousel-wrapper">
					
					        <!-- NAVIGATION -->
					        <div class="jCarousel_pagination">
						        <a href="javascript:void(0);" class="jcarousel-control-prev" ><i class="fa fa-angle-left"></i></a>
						        <a href="javascript:void(0);" class="jcarousel-control-next" ><i class="fa fa-angle-right"></i></a>
					        </div><!-- //NAVIGATION -->
					
					        <div class="jcarousel" data-appear-top-offset='-100' data-animated='fadeInUp'>
						        <ul>

                                     <%  
                                    List<Model_Post> pnew = p.GetPostByTax("สินค้ามาใหม่");
                                    foreach (Model_Post item in pnew)
                                    {
                                    %>
                                 
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/1.jpg" alt="" />
										        <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a></div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="<%Response.Write(item.Permarlink); %>" ><%  Response.Write(item.Title);%></a>
										        <span class="tovar_price">$98.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							       
							        <%} %>
						        </ul>
					        </div>
				        </div><!-- //JCAROUSEL -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //NEW ARRIVALS -->
		
		
		        <!-- BRANDS -->
		        <section class="brands_carousel">
			
			        <!-- CONTAINER -->
			        <div class="container">
				
				        <!-- JCAROUSEL -->
				        <div class="jcarousel-wrapper">
					
					        <!-- NAVIGATION -->
					        <div class="jCarousel_pagination">
						        <a href="javascript:void(0);" class="jcarousel-control-prev" ><i class="fa fa-angle-left"></i></a>
						        <a href="javascript:void(0);" class="jcarousel-control-next" ><i class="fa fa-angle-right"></i></a>
					        </div><!-- //NAVIGATION -->
					
					        <div class="jcarousel" data-appear-top-offset='-100' data-animated='fadeInUp'>
						        <ul>
							        <li><a href="javascript:void(0);" ><img src="images/brands/1.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/2.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/3.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/4.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/5.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/6.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/7.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/8.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/9.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/10.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/11.jpg" alt="" /></a></li>
							        <li><a href="javascript:void(0);" ><img src="images/brands/12.jpg" alt="" /></a></li>
						        </ul>
					        </div>
				        </div><!-- //JCAROUSEL -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //BRANDS -->
		
		
		        <hr class="container">
		
		
		        <asp:Literal ID="home_content" runat="server"></asp:Literal>
		
		        <hr class="container">
		
		
		        <!-- RECENT POSTS -->
		        <section class="recent_posts padbot40">
			
			        <!-- CONTAINER -->
			        <div class="container">
				        <h2>New blog posts</h2>
				
				        <!-- ROW -->
				        <div class="row" data-appear-top-offset='-100' data-animated='fadeInUp'>
					        <div class="col-lg-6 col-md-6 padbot30">
						        <div class="recent_post_item clearfix">
							        <div class="recent_post_date">15<span>oct</span></div>
							        <a class="recent_post_img" href="blog-post.html" ><img src="images/blog/recent1.jpg" alt="" /></a>
							        <a class="recent_post_title" href="blog-post.html" >Be Unafraid, Self-Hosted WordPress Is WAY Easier Nowadays</a>
							        <div class="recent_post_content">The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
							        </ul>
						        </div>
					        </div>
					
					        <div class="col-lg-6 col-md-6 padbot30">
						        <div class="recent_post_item clearfix">
							        <div class="recent_post_date">07<span>dec</span></div>
							        <a class="recent_post_img" href="blog-post.html" ><img src="images/blog/recent2.jpg" alt="" /></a>
							        <a class="recent_post_title" href="blog-post.html" >True Story: I Went Two Weeks Without Social Media</a>
							        <div class="recent_post_content">Since I began blogging 5.5 years ago, social media (and my blog) have taken hold on my life. I’ve been an early adopter for most major networks and use them extensively.  This past year I’ve been overwhelmed.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
							        </ul>
						        </div>
					        </div>
				        </div><!-- //ROW -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //RECENT POSTS -->
                <!-- PAGE HOME TEMPLATE -->

                </section>
        <!-- PAGE HOME TEMPLATE -->
   
</asp:Content>

<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
