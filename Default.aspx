<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" ViewStateMode="Disabled" EnableViewState="false" EnableViewStateMac="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%@ MasterType virtualpath="~/Site.User.master" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Literal ID="HeaderSection" runat="server"></asp:Literal>

         <%-- Blog Page TEMPLATE--%>
            <section   id="SectionBlogPageSingle"  runat="server" visible="false">
               	
		        <!-- PAGE HEADER -->
		        <section class="page_header">
			
			        <!-- CONTAINER -->
			        <div class="container">
				        <h3 class="pull-left"><b>Blog Post</b></h3>
				
				        <div class="pull-right">
					        <a href="women.html" >Back to shop<i class="fa fa-angle-right"></i></a>
				        </div>
			        </div><!-- //CONTAINER -->
		        </section><!-- //PAGE HEADER -->
		
		
		        <!-- BLOG BLOCK -->
		        <section class="blog">
			
			        <!-- CONTAINER -->
			        <div class="container">
			
				        <!-- ROW -->
				        <div class="row">
					
					        <!-- BLOG LIST -->
					        <div class="col-lg-9 col-md-9 col-sm-9">
						
						        <article class="post blog_post clearfix margbot20" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <div class="post_title" href="blog-post.html" >See All the Ridiculously Hot, Nearly Naked Looks From Shakira and Rihanna's New Video</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
							        <div class="post_large_image">
								        <div class="recent_post_date">15<span>dec</span></div>
								        <img src="images/blog/large_image.jpg" alt="" />
							        </div>
							
							        <div class="blog_post_content">
								        <h3>You could say Barbara Casasola has had a charmed run. After a critically acclaimed London Fashion Week debut last September, the Porto Alegre, Brazil–born, London-based upstart was tapped to be the sole women’s wear presenter at Pitti Uomo, the biannual menswear trade show in Florence, an honor previously accorded to Peter Pilotto and Rodarte.</h3>
								
								        <h2>Single Post Whit Sidebar</h2>
								
								        <p>The cousin had a point. Consider Casasola’s spring/ summer 2014 lineup, which, inspired by the work of Brazilian constructivist master Lygia Clark, explores the duality of discipline and sensuality: There is something decidedly not of this century about the evening dresses—and they are almost all evening dresses, with a few soigné jumpsuits and pencil skirts in the mix—that she crafts from unembellished satins, cadys, and organzas, with hems cropped just above the ankle. “A lot of people think it makes you look shorter,” says Casasola of her preferred silhouette. “But it’s the other way around.”</p>
								
								        <p>This courage of conviction allows such friends of the designer as Caroline Issa and Brazilian princess Paola Orléans e Bragança and other fans—like, say, Gwyneth Paltrow—to stand tall in her designs. (The five-inch pumps she collaborated on with Manolo Blahnik also help). Casasola has a Central Saint Martins degree and design work at Lanvin on her résumé, but she says she learned the most from her seamstress grandmother, who never left the house in anything but a maxi-length. The lesson, she says: “Luxury is simplicity.”</p>
								
								        <blockquote>
									        <i>Eveningwear was my starting point for my first, AW 2012 collection, because my sense of what was out there tended to reference a different generation. I went for a kind of Madame Gres-meets-1990s Helmut Lang; or a certain mix of elegance and attitude.</i>
								        </blockquote>
								
								        <p>You could say Barbara Casasola has had a charmed run. After a critically acclaimed London Fashion Week debut last September, the Porto Alegre, Brazil–born, London-based upstart was tapped to be the sole women’s wear presenter at Pitti Uomo, the biannual menswear trade show in Florence, an honor previously accorded to Peter Pilotto and Rodarte. But the 29-year-old wasn’t always sure she’d have industry support—or even familial understanding. “When my cousin saw my first collection, she started laughing—hard,” the designer says sheepishly. She was like, “It looks like grandma’s clothes!”</p>
							        </div>
							
						        </article>
						
						        <div class="shared_tags_block clearfix" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <div class="pull-left post_tags">
								        <a href="javascript:void(0);" >DRESS</a>
								        <a href="javascript:void(0);" >Sweaters</a>
								        <a href="javascript:void(0);" >MATERNITY</a>
								        <a href="javascript:void(0);" >SHIRTS & TOPS</a>
							        </div>
							
							        <div class="pull-right tovar_shared clearfix">
								        <p>Share item with friends</p>
								        <ul>
									        <li><a class="facebook" href="javascript:void(0);" ><i class="fa fa-facebook"></i></a></li>
									        <li><a class="twitter" href="javascript:void(0);" ><i class="fa fa-twitter"></i></a></li>
									        <li><a class="linkedin" href="javascript:void(0);" ><i class="fa fa-linkedin"></i></a></li>
									        <li><a class="google-plus" href="javascript:void(0);" ><i class="fa fa-google-plus"></i></a></li>
									        <li><a class="tumblr" href="javascript:void(0);" ><i class="fa fa-tumblr"></i></a></li>
								        </ul>
							        </div>
						        </div>
						
						
						        <!-- COMMENTS -->
						        <div id="comments" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <h2>Comments (3)</h2>
							        <ol>
								        <li>
									        <div class="pull-left avatar"><a href="javascript:void(0);"><img src="images/avatar1.jpg" alt="" /></a></div>
									        <div class="comment_right">
										        <div class="comment_info">
											        <a class="comment_author" href="javascript:void(0);" >Anna Balashova</a>
											        <a class="comment_reply" href="javascript:void(0);" ><i class="fa fa-share"></i> Reply</a>
											        <div class="clear"></div>
											        <div class="comment_date">13 January 2014</div>
										        </div>
										        Thank you so much for putting this together Jeremy. Most of these seem like common sense but it is amazing how many times I see new employees having the worst days of their life because managers/leaders don’t want to be “bothered” with the new guy.
									        </div>
									        <div class="clear"></div>
									        <ul>
										        <li>
											        <div class="pull-left avatar"><a href="javascript:void(0);"><img src="images/avatar2.jpg" alt="" /></a></div>
											        <div class="comment_right">
												        <div class="comment_info">
													        <a class="comment_author" href="javascript:void(0);" >Anna Balashova</a>
													        <a class="comment_reply" href="javascript:void(0);" ><i class="fa fa-share"></i> Reply</a>
													        <div class="clear"></div>
													        <div class="comment_date">13 January 2014</div>
												        </div>
												        Thank you so much for putting this together Jeremy. Most of these seem like common sense but it is amazing how many times I see new employees having the worst days of their life because managers/leaders don’t want to be “bothered” with the new guy.
											        </div>
											        <div class="clear"></div>
										        </li>
									        </ul>
								        </li>
								        <li>
									        <div class="pull-left avatar"><a href="javascript:void(0);"><img src="images/avatar3.jpg" alt="" /></a></div>
									        <div class="comment_right">
										        <div class="comment_info">
											        <a class="comment_author" href="javascript:void(0);" >Anna Balashova</a>
											        <a class="comment_reply" href="javascript:void(0);" ><i class="fa fa-share"></i> Reply</a>
											        <div class="clear"></div>
											        <div class="comment_date">13 January 2014</div>
										        </div>
										        Thank you so much for putting this together Jeremy. Most of these seem like common sense but it is amazing how many times I see new employees having the worst days of their life because managers/leaders don’t want to be “bothered” with the new guy.
									        </div>
									        <div class="clear"></div>
								        </li>
							        </ol>
						        </div><!-- //COMMENTS -->
						
						
						        <!-- LEAVE A COMMENT -->
						        <div id="comment_form" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <h2>Leave a Comment</h2>
							        <div class="comment_form_wrapper">
								        <div class="form-comment-gs">
									        <input type="text" name="name" value="Name" onFocus="if (this.value == 'Name') this.value = '';" onBlur="if (this.value == '') this.value = 'Name';" />
									        <input class="email" type="text" name="email" value="Email" onFocus="if (this.value == 'Email') this.value = '';" onBlur="if (this.value == '') this.value = 'Email';" /></br>
									        <textarea name="message" onFocus="if (this.value == 'Your comment') this.value = '';" onBlur="if (this.value == '') this.value = 'Your comment';">Your comment</textarea>
									        <div class="clear"></div>
									        <span class="comment_note">Your email address will not be published. Required fields are marked *</span>
									        <input type="submit" value="Send comment" />
									        <div class="clear"></div>
								        </div>
							        </div>
						        </div><!-- //LEAVE A COMMENT -->
						
						
						        <article class="post margbot40 clearfix" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <a class="post_large_image pull-left" href="blog-post.html" >
								        <div class="recent_post_date">24<span>feb</span></div>
								        <img src="images/blog/5.jpg" alt="" />
							        </a>
							        <a class="post_title" href="blog-post.html" >DIY Beauty: The Best Use of Valentine's Day Roses</a>
							        <div class="post_content">The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done. The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
						        </article>
						
						        <article class="post margbot40 clearfix" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <a class="post_large_image pull-left" href="blog-post.html" >
								        <div class="recent_post_date">08<span>Oct</span></div>
								        <img src="images/blog/6.jpg" alt="" />
							        </a>
							        <a class="post_title" href="blog-post.html" >Editor's Style: Dobrina Zhekova's Touch of Sparkle</a>
							        <div class="post_content">The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done. The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
						        </article>
					        </div><!-- //BLOG LIST -->
					
					
					        <!-- SIDEBAR -->
					        <div id="sidebar" class="col-lg-3 col-md-3 col-sm-3 padbot50">
						
						        <!-- WIDGET SEARCH -->
						        <div class="sidepanel widget_search">
							        <form class="search_form" action="javascript:void(0);" method="get" name="search_form">
								        <input type="text" name="Search..." value="Search..." onFocus="if (this.value == 'Search...') this.value = '';" onBlur="if (this.value == '') this.value = 'Search...';" />
							        </form>
						        </div><!-- //WIDGET SEARCH -->
						
						        <!-- CATEGORIES -->
						        <div class="sidepanel widget_categories">
							        <h3>BLOG CATEGORIES</h3>
							        <ul>
								        <li><a href="javascript:void(0);" >Sweaters</a></li>
								        <li><a href="javascript:void(0);" >SHIRTS &amp; TOPS</a></li>
								        <li><a href="javascript:void(0);" >KNITS &amp; TEES</a></li>
								        <li><a href="javascript:void(0);" >PANTS</a></li>
								        <li><a href="javascript:void(0);" >DENIM</a></li>
								        <li><a href="javascript:void(0);" >DRESSES</a></li>
								        <li><a href="javascript:void(0);" >Maternity</a></li>
							        </ul>
						        </div><!-- //CATEGORIES -->
						
						        <!-- NEWSLETTER FORM WIDGET -->
						        <div class="sidepanel widget_newsletter">
							        <div class="newsletter_wrapper">
								        <h3>NEWSLETTER</h3>
								        <form class="newsletter_form clearfix" action="javascript:void(0);" method="get">
									        <input type="text" name="newsletter" value="Enter E-mail & Get 10% off" onFocus="if (this.value == 'Enter E-mail & Get 10% off') this.value = '';" onBlur="if (this.value == '') this.value = 'Enter E-mail & Get 10% off';" />
									        <input class="btn newsletter_btn" type="submit" value="Sign up & get 10% off">
								        </form>
							        </div>
						        </div><!-- //NEWSLETTER FORM WIDGET -->
						
						        <!-- WIDGET POPULAR POSTS -->
						        <div class="sidepanel widget_popular_posts">
							        <h3>POPULAR POSTS</h3>
							        <ul>
								        <li class="widget_popular_post_item clearfix">
									        <a class="widget_popular_post_img" href="blog-post.html" ><img src="images/blog/popular1.jpg" alt="" /></a>
									        <a class="widget_popular_post_title" href="blog-post.html" >New Fashion Vintage Double Breasted Trench Long</a>
									        <span class="widget_popular_post_date">13 January 2014</span>
								        </li>
								        <li class="widget_popular_post_item clearfix">
									        <a class="widget_popular_post_img" href="blog-post.html" ><img src="images/blog/popular2.jpg" alt="" /></a>
									        <a class="widget_popular_post_title" href="blog-post.html" >In the Kitchen with…The New Potato</a>
									        <span class="widget_popular_post_date">10 January 2014</span>
								        </li>
								        <li class="widget_popular_post_item clearfix">
									        <a class="widget_popular_post_img" href="blog-post.html" ><img src="images/blog/popular3.jpg" alt="" /></a>
									        <a class="widget_popular_post_title" href="blog-post.html" >2013 Hot Women thicken fleece Warm Coat Lady</a>
									        <span class="widget_popular_post_date">5 January 2014</span>
								        </li>
							        </ul>
						        </div><!-- //WIDGET POPULAR POSTS -->
						
						        <!-- WIDGET POPULAR TAGS -->
						        <div class="sidepanel widget_tags">
							        <h3>Popular Tags</h3>
							
							        <a href="javascript:void(0);" >DRESS</a>
							        <a href="javascript:void(0);" >Sweaters</a>
							        <a href="javascript:void(0);" >MATERNITY</a>
							        <a href="javascript:void(0);" >SHIRTS & TOPS</a>
							        <a href="javascript:void(0);" >BEAUTY</a>
							        <a href="javascript:void(0);" >SHOP</a>
							        <a href="javascript:void(0);" >Jackets & Blazers</a>
							        <a href="javascript:void(0);" >Outerwear</a>
						        </div><!-- //WIDGET POPULAR TAGS -->
						
						        <!-- WIDGET BEST SELLERS -->
						        <div class="sidepanel widget_best_sellers">
							        <h3>BEST SELLERS</h3>
							
							        <ul class="tovar_items_small">
								        <li class="clearfix">
									        <img class="tovar_item_small_img" src="images/tovar/women/1.jpg" alt="" />
									        <a href="product-page.html" class="tovar_item_small_title">Embroidered bib peasant top</a>
									        <span class="tovar_item_small_price">$88.00</span>
								        </li>
								        <li class="clearfix">
									        <img class="tovar_item_small_img" src="images/tovar/women/2.jpg" alt="" />
									        <a href="product-page.html" class="tovar_item_small_title">Merino tippi sweater in geometric</a>
									        <span class="tovar_item_small_price">$67.00</span>
								        </li>
								        <li class="clearfix">
									        <img class="tovar_item_small_img" src="images/tovar/women/3.jpg" alt="" />
									        <a href="product-page.html" class="tovar_item_small_title">Merino triple-stripe elbow-patch sweater</a>
									        <span class="tovar_item_small_price">$94.00</span>
								        </li>
							        </ul>
						        </div><!-- //WIDGET BEST SELLERS -->
						
						        <!-- BANNERS WIDGET -->
						        <div class="widget_banners">
							        <a class="banner nobord margbot10" href="javascript:void(0);" ><img src="images/tovar/banner10.jpg" alt="" /></a>
							        <a class="banner nobord margbot10" href="javascript:void(0);" ><img src="images/tovar/banner9.jpg" alt="" /></a>
							        <a class="banner nobord margbot10" href="javascript:void(0);" ><img src="images/tovar/banner8.jpg" alt="" /></a>
						        </div><!-- //BANNERS WIDGET -->
					        </div><!-- //SIDEBAR -->
				        </div><!-- //ROW -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //BLOG BLOCK -->
            </section>
           <%--  End Blog Page TEMPLATE--%>
 
          <%-- Blog Page Archive--%>
        <section   id="SectionBlogPageArchive"  runat="server" visible="false">
          
		    <!-- PAGE HEADER -->
		        <section class="page_header">
			
			        <!-- CONTAINER -->
			        <div class="container">
				        <h3 class="pull-left"><b>Blog</b></h3>
				
				        <div class="pull-right">
					        <a href="women.html" >Back to shop<i class="fa fa-angle-right"></i></a>
				        </div>
			        </div><!-- //CONTAINER -->
		        </section><!-- //PAGE HEADER -->
		
		
		<!-- BLOG BLOCK -->
		        <section class="blog">
			
			        <!-- CONTAINER -->
			        <div class="container">
			
				        <!-- ROW -->
				        <div class="row">
					
					        <!-- BLOG LIST -->
					        <div class="col-lg-9 col-md-9 col-sm-9 padbot30">
						
						        <article class="post large_image clearfix margbot30" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <a class="post_title" href="blog-post.html" >See All the Ridiculously Hot, Nearly Naked Looks From Shakira and Rihanna's New Video</a>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
							        <a class="post_large_image" href="blog-post.html" >
								        <div class="recent_post_date">15<span>dec</span></div>
								        <img src="images/blog/large_image.jpg" alt="" />
							        </a>
						        </article>
						
						        <article class="post margbot40 clearfix" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <a class="post_image pull-left" href="blog-post.html" >
								        <div class="recent_post_date">07<span>dec</span></div>
								        <img src="images/blog/1.jpg" alt="" />
							        </a>
							        <a class="post_title" href="blog-post.html" >Be Unafraid, Self-Hosted WordPress Is WAY Easier Nowadays</a>
							        <div class="post_content">The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done. The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
						        </article>
						
						        <article class="post margbot40 clearfix" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <a class="post_image pull-left" href="blog-post.html" >
								        <div class="recent_post_date">24<span>aug</span></div>
								        <img src="images/blog/2.jpg" alt="" />
							        </a>
							        <a class="post_title" href="blog-post.html" >Celebrities React to Philip Seymour Hoffman's Death</a>
							        <div class="post_content">The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done. The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
						        </article>
						
						        <article class="post margbot40 clearfix" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <a class="post_image pull-left" href="blog-post.html" >
								        <div class="recent_post_date">07<span>oct</span></div>
								        <img src="images/blog/3.jpg" alt="" />
							        </a>
							        <a class="post_title" href="blog-post.html" >Gwyneth Paltrow Loves New Designer Barbara Casasola and You Will Too</a>
							        <div class="post_content">The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done. The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
						        </article>
						
						        <article class="post margbot40 clearfix" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <a class="post_image pull-left" href="blog-post.html" >
								        <div class="recent_post_date">16<span>sep</span></div>
								        <img src="images/blog/4.jpg" alt="" />
							        </a>
							        <a class="post_title" href="blog-post.html" >Revlon x Marchesa Parts 2 and 3 are Finally Here</a>
							        <div class="post_content">The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done. The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
						        </article>
						
						        <article class="post margbot40 clearfix" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <a class="post_image pull-left" href="blog-post.html" >
								        <div class="recent_post_date">24<span>feb</span></div>
								        <img src="images/blog/5.jpg" alt="" />
							        </a>
							        <a class="post_title" href="blog-post.html" >DIY Beauty: The Best Use of Valentine's Day Roses</a>
							        <div class="post_content">The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done. The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
						        </article>
						
						        <article class="post margbot40 clearfix" data-appear-top-offset='-100' data-animated='fadeInUp'>
							        <a class="post_image pull-left" href="blog-post.html" >
								        <div class="recent_post_date">08<span>Oct</span></div>
								        <img src="images/blog/6.jpg" alt="" />
							        </a>
							        <a class="post_title" href="blog-post.html" >Editor's Style: Dobrina Zhekova's Touch of Sparkle</a>
							        <div class="post_content">The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done. The beauty of self-hosted WordPress, is that you can build your site however you like, want to add forums to your website? Done. Want to add a ecommerce to your blog? Done.</div>
							        <ul class="post_meta">
								        <li><i class="fa fa-user"></i><a href="javascript:void(0);" >Anna Balashova</a></li>
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
								        <li><i class="fa fa-eye"></i>views <span class="sep">|</span> 259</li>
							        </ul>
						        </article>
						
						        <hr>
						
						        <!-- PAGINATION -->
						        <ul class="pagination clearfix">
							        <li><a href="javascript:void(0);" >1</a></li>
							        <li><a href="javascript:void(0);" >2</a></li>
							        <li class="active"><a href="javascript:void(0);" >3</a></li>
							        <li><a href="javascript:void(0);" >4</a></li>
							        <li><a href="javascript:void(0);" >5</a></li>
							        <li><a href="javascript:void(0);" >6</a></li>
							        <li><a href="javascript:void(0);" >...</a></li>
						        </ul><!-- //PAGINATION -->
					        </div><!-- //BLOG LIST -->
					
					
					        <!-- SIDEBAR -->
					        <div id="sidebar" class="col-lg-3 col-md-3 col-sm-3 padbot50">
						
						        <!-- WIDGET SEARCH -->
						        <div class="sidepanel widget_search">
							        <form class="search_form" action="javascript:void(0);" method="get" name="search_form">
								        <input type="text" name="Search..." value="Search..." onFocus="if (this.value == 'Search...') this.value = '';" onBlur="if (this.value == '') this.value = 'Search...';" />
							        </form>
						        </div><!-- //WIDGET SEARCH -->
						
						        <!-- CATEGORIES -->
						        <div class="sidepanel widget_categories">
							        <h3>BLOG CATEGORIES</h3>
							        <ul>
								        <li><a href="javascript:void(0);" >Sweaters</a></li>
								        <li><a href="javascript:void(0);" >SHIRTS &amp; TOPS</a></li>
								        <li><a href="javascript:void(0);" >KNITS &amp; TEES</a></li>
								        <li><a href="javascript:void(0);" >PANTS</a></li>
								        <li><a href="javascript:void(0);" >DENIM</a></li>
								        <li><a href="javascript:void(0);" >DRESSES</a></li>
								        <li><a href="javascript:void(0);" >Maternity</a></li>
							        </ul>
						        </div><!-- //CATEGORIES -->
						
						        <!-- NEWSLETTER FORM WIDGET -->
						        <div class="sidepanel widget_newsletter">
							        <div class="newsletter_wrapper">
								        <h3>NEWSLETTER</h3>
								        <form class="newsletter_form clearfix" action="javascript:void(0);" method="get">
									        <input type="text" name="newsletter" value="Enter E-mail & Get 10% off" onFocus="if (this.value == 'Enter E-mail & Get 10% off') this.value = '';" onBlur="if (this.value == '') this.value = 'Enter E-mail & Get 10% off';" />
									        <input class="btn newsletter_btn" type="submit" value="Sign up & get 10% off">
								        </form>
							        </div>
						        </div><!-- //NEWSLETTER FORM WIDGET -->
						
						        <!-- WIDGET POPULAR POSTS -->
						        <div class="sidepanel widget_popular_posts">
							        <h3>POPULAR POSTS</h3>
							        <ul>
								        <li class="widget_popular_post_item clearfix">
									        <a class="widget_popular_post_img" href="blog-post.html" ><img src="images/blog/popular1.jpg" alt="" /></a>
									        <a class="widget_popular_post_title" href="blog-post.html" >New Fashion Vintage Double Breasted Trench Long</a>
									        <span class="widget_popular_post_date">13 January 2014</span>
								        </li>
								        <li class="widget_popular_post_item clearfix">
									        <a class="widget_popular_post_img" href="blog-post.html" ><img src="images/blog/popular2.jpg" alt="" /></a>
									        <a class="widget_popular_post_title" href="blog-post.html" >In the Kitchen with…The New Potato</a>
									        <span class="widget_popular_post_date">10 January 2014</span>
								        </li>
								        <li class="widget_popular_post_item clearfix">
									        <a class="widget_popular_post_img" href="blog-post.html" ><img src="images/blog/popular3.jpg" alt="" /></a>
									        <a class="widget_popular_post_title" href="blog-post.html" >2013 Hot Women thicken fleece Warm Coat Lady</a>
									        <span class="widget_popular_post_date">5 January 2014</span>
								        </li>
							        </ul>
						        </div><!-- //WIDGET POPULAR POSTS -->
						
						        <!-- WIDGET POPULAR TAGS -->
						        <div class="sidepanel widget_tags">
							        <h3>Popular Tags</h3>
							
							        <a href="javascript:void(0);" >DRESS</a>
							        <a href="javascript:void(0);" >Sweaters</a>
							        <a href="javascript:void(0);" >MATERNITY</a>
							        <a href="javascript:void(0);" >SHIRTS & TOPS</a>
							        <a href="javascript:void(0);" >BEAUTY</a>
							        <a href="javascript:void(0);" >SHOP</a>
							        <a href="javascript:void(0);" >Jackets & Blazers</a>
							        <a href="javascript:void(0);" >Outerwear</a>
						        </div><!-- //WIDGET POPULAR TAGS -->
						
						        <!-- WIDGET BEST SELLERS -->
						        <div class="sidepanel widget_best_sellers">
							        <h3>BEST SELLERS</h3>
							
							        <ul class="tovar_items_small">
								        <li class="clearfix">
									        <img class="tovar_item_small_img" src="images/tovar/women/1.jpg" alt="" />
									        <a href="product-page.html" class="tovar_item_small_title">Embroidered bib peasant top</a>
									        <span class="tovar_item_small_price">$88.00</span>
								        </li>
								        <li class="clearfix">
									        <img class="tovar_item_small_img" src="images/tovar/women/2.jpg" alt="" />
									        <a href="product-page.html" class="tovar_item_small_title">Merino tippi sweater in geometric</a>
									        <span class="tovar_item_small_price">$67.00</span>
								        </li>
								        <li class="clearfix">
									        <img class="tovar_item_small_img" src="images/tovar/women/3.jpg" alt="" />
									        <a href="product-page.html" class="tovar_item_small_title">Merino triple-stripe elbow-patch sweater</a>
									        <span class="tovar_item_small_price">$94.00</span>
								        </li>
							        </ul>
						        </div><!-- //WIDGET BEST SELLERS -->
						
						        <!-- BANNERS WIDGET -->
						        <div class="widget_banners">
							        <a class="banner nobord margbot10" href="javascript:void(0);" ><img src="images/tovar/banner10.jpg" alt="" /></a>
							        <a class="banner nobord margbot10" href="javascript:void(0);" ><img src="images/tovar/banner9.jpg" alt="" /></a>
							        <a class="banner nobord margbot10" href="javascript:void(0);" ><img src="images/tovar/banner8.jpg" alt="" /></a>
						        </div><!-- //BANNERS WIDGET -->
					        </div><!-- //SIDEBAR -->
				        </div><!-- //ROW -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //BLOG BLOCK -->
		
        </section>
       <%-- End Blog Page Archive--%>

          <%-- Blog Taxonomy Page Archive TEMPLATE--%>
        <section  id="SectionBlogPageTaxArchive"  runat="server" visible="false">
              Blog Page Taxonomy Archive
        </section>
      <%-- End Blog Taxonomy Page Archive TEMPLATE--%>


      
       <%-- Product Page TEMPLATE--%>
        <section   id="SectionProductSingle"  runat="server" visible="false">
              <!-- TOVAR DETAILS -->
		        <section class="tovar_details padbot70">
			
			        <!-- CONTAINER -->
			        <div class="container">
				
				        <!-- ROW -->
				        <div class="row">
					
					        <!-- SIDEBAR TOVAR DETAILS -->
					        <div class="col-lg-3 col-md-3 sidebar_tovar_details">
						        <h3><b>other sweatersss</b></h3>
						
						        <ul class="tovar_items_small clearfix">
							        <li class="clearfix">
								        <img class="tovar_item_small_img" src="images/tovar/women/1.jpg" alt="" />
								        <a href="product-page.html" class="tovar_item_small_title">Embroidered bib peasant top</a>
								        <span class="tovar_item_small_price">$88.00</span>
							        </li>
							        <li class="clearfix">
								        <img class="tovar_item_small_img" src="images/tovar/women/2.jpg" alt="" />
								        <a href="product-page.html" class="tovar_item_small_title">Merino tippi sweater in geometric</a>
								        <span class="tovar_item_small_price">$67.00</span>
							        </li>
							        <li class="clearfix">
								        <img class="tovar_item_small_img" src="images/tovar/women/3.jpg" alt="" />
								        <a href="product-page.html" class="tovar_item_small_title">Merino triple-stripe elbow-patch sweater</a>
								        <span class="tovar_item_small_price">$94.00</span>
							        </li>
							        <li class="clearfix">
								        <img class="tovar_item_small_img" src="images/tovar/women/4.jpg" alt="" />
								        <a href="product-page.html" class="tovar_item_small_title">Collection cashmere getaway hoodie</a>
								        <span class="tovar_item_small_price">$228.00</span>
							        </li>
						        </ul>
					        </div><!-- //SIDEBAR TOVAR DETAILS -->
					
					        <!-- TOVAR DETAILS WRAPPER -->
					        <div class="col-lg-9 col-md-9 tovar_details_wrapper clearfix">
						        <div class="tovar_details_header clearfix margbot35">
							        <h3 class="pull-left"><b>Sweaters</b></h3>
							
							        <div class="tovar_details_pagination pull-right">
								        <a class="fa fa-angle-left" href="javascript:void(0);" ></a>
								        <span>2 of 34</span>
								        <a class="fa fa-angle-right" href="javascript:void(0);" ></a>
							        </div>
						        </div>
						
						        <!-- CLEARFIX -->
						        <div class="clearfix padbot40">
							        <div class="tovar_view_fotos clearfix">
								        <div id="slider2" class="flexslider">
									        <ul class="slides">
										        <li><a href="javascript:void(0);" ><img src="images/tovar/women/1.jpg" alt="" /></a></li>
										        <li><a href="javascript:void(0);" ><img src="images/tovar/women/1_2.jpg" alt="" /></a></li>
										        <li><a href="javascript:void(0);" ><img src="images/tovar/women/1_3.jpg" alt="" /></a></li>
										        <li><a href="javascript:void(0);" ><img src="images/tovar/women/1_4.jpg" alt="" /></a></li>
									        </ul>
								        </div>
								        <div id="carousel2" class="flexslider">
									        <ul class="slides">
										        <li><a href="javascript:void(0);" ><img src="images/tovar/women/1.jpg" alt="" /></a></li>
										        <li><a href="javascript:void(0);" ><img src="images/tovar/women/1_2.jpg" alt="" /></a></li>
										        <li><a href="javascript:void(0);" ><img src="images/tovar/women/1_3.jpg" alt="" /></a></li>
										        <li><a href="javascript:void(0);" ><img src="images/tovar/women/1_4.jpg" alt="" /></a></li>
									        </ul>
								        </div>
							        </div>
							
							        <div class="tovar_view_description">
								        <div class="tovar_view_title">Popover Sweatshirt in Floral Jacquard</div>
								        <div class="tovar_article">88-305-676</div>
								        <div class="clearfix tovar_brend_price">
									        <div class="pull-left tovar_brend">Calvin Klein</div>
									        <div class="pull-right tovar_view_price">$98.00</div>
								        </div>
								        <div class="tovar_color_select">
									        <p>Select color</p>
									        <a class="color1" href="javascript:void(0);" ></a>
									        <a class="color2 active" href="javascript:void(0);" ></a>
									        <a class="color3" href="javascript:void(0);" ></a>
									        <a class="color4" href="javascript:void(0);" ></a>
								        </div>
								        <div class="tovar_size_select">
									        <div class="clearfix">
										        <p class="pull-left">Select SIZE</p>
										        <span>Size & Fit</span>
									        </div>
									        <a class="sizeXS" href="javascript:void(0);" >XS</a>
									        <a class="sizeS active" href="javascript:void(0);" >S</a>
									        <a class="sizeM" href="javascript:void(0);" >M</a>
									        <a class="sizeL" href="javascript:void(0);" >L</a>
									        <a class="sizeXL" href="javascript:void(0);" >XL</a>
									        <a class="sizeXXL" href="javascript:void(0);" >XXL</a>
									        <a class="sizeXXXL" href="javascript:void(0);" >XXXL</a>
								        </div>
								        <div class="tovar_view_btn">
									        <select class="basic">
										        <option value="">QTY</option>
										        <option>Lo</option>
										        <option>Ips</option>
										        <option>Dol</option>
										        <option>Sit</option>
										        <option>Amet</option>
									        </select>
									        <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i>Add to bag</a>
									        <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
								        </div>
								        <div class="tovar_shared clearfix">
									        <p>Share item with friends</p>
									        <ul>
										        <li><a class="facebook" href="javascript:void(0);" ><i class="fa fa-facebook"></i></a></li>
										        <li><a class="twitter" href="javascript:void(0);" ><i class="fa fa-twitter"></i></a></li>
										        <li><a class="linkedin" href="javascript:void(0);" ><i class="fa fa-linkedin"></i></a></li>
										        <li><a class="google-plus" href="javascript:void(0);" ><i class="fa fa-google-plus"></i></a></li>
										        <li><a class="tumblr" href="javascript:void(0);" ><i class="fa fa-tumblr"></i></a></li>
									        </ul>
								        </div>
							        </div>
						        </div><!-- //CLEARFIX -->
						
						        <!-- TOVAR INFORMATION -->
						        <div class="tovar_information">
							        <ul class="tabs clearfix">
								        <li class="current">Details</li>
								        <li>Information</li>
								        <li>Reviews (2)</li>
							        </ul>
							        <div class="box visible">
								        <p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
								        <p>Curabitur pretium tincidunt lacus. Nulla gravida orci a odio. Nullam varius, turpis et commodo pharetra, est eros bibendum elit, nec luctus magna felis sollicitudin mauris. Integer in mauris eu nibh euismod gravida. Duis ac tellus et risus vulputate vehicula. Donec lobortis risus a elit. Etiam tempor. Ut ullamcorper, ligula eu tempor congue, eros est euismod turpis, id tincidunt sapien risus a quam. Maecenas fermentum consequat mi. Donec fermentum. Pellentesque malesuada nulla a mi. Duis sapien sem, aliquet nec, commodo eget, consequat quis, neque. Aliquam faucibus, elit ut dictum aliquet, felis nisl adipiscing sapien, sed malesuada diam lacus eget erat. Cras mollis scelerisque nunc. Nullam arcu. Aliquam consequat. Curabitur augue lorem, dapibus quis, laoreet et, pretium ac, nisi. Aenean magna nisl, mollis quis, molestie eu, feugiat in, orci. In hac habitasse platea dictumst. </p>
							        </div>
							        <div class="box">
								        Original Levi 501 <br>
								        Button fly<br>
								        Regular fit<br>
								        waist 28"-32 =16"hem<br>
								        waist 33" = 17" hem<br>
								        waist 34"-40"=18" hem<br>
								        Levi's have started to introduce the red tab with just the (R) (registered trade mark) on the red tab<br><br>

								        Size Details:<br>
								        All sizes from 28-40 waist<br>
								        Leg length 30", 32", 34", 36"
							        </div>
							        <div class="box">
								        <ul class="comments">
									        <li>
										        <div class="clearfix">
											        <p class="pull-left"><strong><a href="javascript:void(0);" >John Doe</a></strong></p>
											        <span class="date">2013-10-09 09:23</span>
											        <div class="pull-right rating-box clearfix">
												        <i class="fa fa-star"></i>
												        <i class="fa fa-star"></i>
												        <i class="fa fa-star"></i>
												        <i class="fa fa-star-o"></i>
												        <i class="fa fa-star-o"></i>
											        </div>
										        </div>
										        <p>Ut tellus dolor, dapibus eget, elementum vel, cursus eleifend, elit. Aenean auctor wisi et urna. Aliquam erat volutpat. Duis ac turpis. Integer rutrum ante eu lacus.Vestibulum libero nisl, porta vel, scelerisque eget, malesuada at, neque.</p>
									        </li>
									        <li>
										        <div class="clearfix">
											        <p class="pull-left"><strong><a href="javascript:void(0);" >John Doe</a></strong></p>
											        <span class="date">2013-10-09 09:23</span>
											        <div class="pull-right rating-box clearfix">
												        <i class="fa fa-star"></i>
												        <i class="fa fa-star"></i>
												        <i class="fa fa-star"></i>
												        <i class="fa fa-star"></i>
												        <i class="fa fa-star"></i>
											        </div>
										        </div>
										        <p>Ut tellus dolor, dapibus eget, elementum vel, cursus eleifend, elit. Aenean auctor wisi et urna. Aliquam erat volutpat. Duis ac turpis. Integer rutrum ante eu lacus.Vestibulum libero nisl, porta vel, scelerisque eget, malesuada at, neque.</p>
										
										        <ul>
											        <li>
												        <p><strong><a href="javascript:void(0);" >Jane Doe</a></strong></p>
												        <p>Ut tellus dolor, dapibus eget, elementum vel, cursus eleifend, elit. Aenean auctor wisi et urna. Aliquam erat volutpat. Duis ac turpis. Integer rutrum ante eu lacus.Vestibulum libero nisl, porta vel, scelerisque eget, malesuada at, neque.</p>
											        </li>
										        </ul>
									        </li>
								        </ul>
								
								        <h3>WRITE A REVIEW</h3>
								        <p>Now please write a (short) review....(min. 200, max. 2000 characters)</p>
								        <div class="clearfix">
									        <textarea id="review-textarea"></textarea>
									        <label class="pull-left rating-box-label">Your Rate:</label>
									        <div class="pull-left rating-box clearfix">
										        <i class="fa fa-star-o"></i>
										        <i class="fa fa-star-o"></i>
										        <i class="fa fa-star-o"></i>
										        <i class="fa fa-star-o"></i>
										        <i class="fa fa-star-o"></i>
									        </div>
									        <input type="submit" class="dark-blue big" value="Submit a review">
								        </div>
							        </div>
						        </div><!-- //TOVAR INFORMATION -->
					        </div><!-- //TOVAR DETAILS WRAPPER -->
				        </div><!-- //ROW -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //TOVAR DETAILS -->
		
		
		        <!-- BANNER SECTION -->
		        <section class="banner_section">
			
			        <!-- CONTAINER -->
			        <div class="container">
				
				        <!-- ROW -->
				        <div class="row">
					
					        <!-- BANNER WRAPPER -->
					        <div class="banner_wrapper">
						        <!-- BANNER -->
						        <div class="col-lg-9 col-md-9">
							        <a class="banner type4 margbot40" href="javascript:void(0);" ><img src="images/tovar/banner4.jpg" alt="" /></a>
						        </div><!-- //BANNER -->
						
						        <!-- BANNER -->
						        <div class="col-lg-3 col-md-3">
							        <a class="banner nobord margbot40" href="javascript:void(0);" ><img src="images/tovar/banner5.jpg" alt="" /></a>
						        </div><!-- //BANNER -->
					        </div><!-- //BANNER WRAPPER -->
				        </div><!-- //ROW -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //BANNER SECTION -->
		
		
		        <!-- NEW ARRIVALS -->
		        <section class="new_arrivals padbot50">
			
			        <!-- CONTAINER -->
			        <div class="container">
				        <h2>new arrivals</h2>
				
				        <!-- JCAROUSEL -->
				        <div class="jcarousel-wrapper">
					
					        <!-- NAVIGATION -->
					        <div class="jCarousel_pagination">
						        <a href="javascript:void(0);" class="jcarousel-control-prev" ><i class="fa fa-angle-left"></i></a>
						        <a href="javascript:void(0);" class="jcarousel-control-next" ><i class="fa fa-angle-right"></i></a>
					        </div><!-- //NAVIGATION -->
					
					        <div class="jcarousel">
						        <ul>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/1.jpg" alt="" />
										        <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a></div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >Moonglow paisley silk tee</a>
										        <span class="tovar_price">$98.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/2.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >PEASANT TOP IN SUCKERED STRIPE</a>
										        <span class="tovar_price">$78.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/3.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >EMBROIDERED BIB PEASANT TOP</a>
										        <span class="tovar_price">$88.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/4.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >SILK POCKET BLOUSE</a>
										        <span class="tovar_price">$98.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/5.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >SWISS-DOT TUXEDO SHIRT</a>
										        <span class="tovar_price">$65.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/6.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >STRETCH PERFECT SHIRT</a>
										        <span class="tovar_price">$72.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/1.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >Moonglow paisley silk tee</a>
										        <span class="tovar_price">$98.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/2.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >PEASANT TOP IN SUCKERED STRIPE</a>
										        <span class="tovar_price">$78.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/3.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >EMBROIDERED BIB PEASANT TOP</a>
										        <span class="tovar_price">$88.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/4.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >SILK POCKET BLOUSE</a>
										        <span class="tovar_price">$98.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
						        </ul>
					        </div>
				        </div><!-- //JCAROUSEL -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //NEW ARRIVALS -->
		
		        <!-- NEW ARRIVALS -->
		        <section class="new_arrivals padbot50">
			
			        <!-- CONTAINER -->
			        <div class="container">
				        <h2>Recent Products</h2>
		
				        <!-- JCAROUSEL -->
				        <div class="jcarousel-wrapper">
					
					        <!-- NAVIGATION -->
					        <div class="jCarousel_pagination">
						        <a href="javascript:void(0);" class="jcarousel-control-prev" ><i class="fa fa-angle-left"></i></a>
						        <a href="javascript:void(0);" class="jcarousel-control-next" ><i class="fa fa-angle-right"></i></a>
					        </div><!-- //NAVIGATION -->
					
					        <div id="jcarousel_id" class="jcarousel">
						        <ul>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/1.jpg" alt="" />
										        <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a></div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >Moonglow paisley silk tee</a>
										        <span class="tovar_price">$98.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/2.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >PEASANT TOP IN SUCKERED STRIPE</a>
										        <span class="tovar_price">$78.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/3.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >EMBROIDERED BIB PEASANT TOP</a>
										        <span class="tovar_price">$88.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/4.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >SILK POCKET BLOUSE</a>
										        <span class="tovar_price">$98.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/5.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >SWISS-DOT TUXEDO SHIRT</a>
										        <span class="tovar_price">$65.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/6.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >STRETCH PERFECT SHIRT</a>
										        <span class="tovar_price">$72.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/1.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >Moonglow paisley silk tee</a>
										        <span class="tovar_price">$98.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/2.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >PEASANT TOP IN SUCKERED STRIPE</a>
										        <span class="tovar_price">$78.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/3.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >EMBROIDERED BIB PEASANT TOP</a>
										        <span class="tovar_price">$88.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="images/tovar/women/new/4.jpg" alt="" />
										        <div class="open-project-link">
											        <a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" >quick view</a>
										        </div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="product-page.html" >SILK POCKET BLOUSE</a>
										        <span class="tovar_price">$98.00</span>
									        </div>
								        </div><!-- //TOVAR -->
							        </li>
						        </ul>
					        </div>
				        </div><!-- //JCAROUSEL -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //NEW ARRIVALS -->
		
        </section>
      <%-- End Product Page TEMPLATE--%>

      <%-- Product Page Archive TEMPLATE--%>
        <section   id="SectionProductArchive"   runat="server" visible="false">
            		
		        <!-- PAGE HEADER -->
		    <section class="page_header">
			
			    <!-- CONTAINER -->
			    <div class="container">
				    <h3 class="pull-left"><b><%:this.TaxForPostType.Title %></b></h3>
				
				    <%--<div class="pull-right">
					    <a href="women.html" >Back to shop<i class="fa fa-angle-right"></i></a>
				    </div>--%>
			    </div><!-- //CONTAINER -->
		    </section><!-- //PAGE HEADER -->
		
            <% if (this.TaxList.Count > 0)
                { %>
		
		    <!-- PRODUCT CATALOG SECTION -->
		    <section class="product_catalog_block">
			
			    <!-- CONTAINER -->
			    <div class="container">
				
				    <!-- ROW -->
				    <div class="row">


                        <%  
                            int rowcount = 1;
                            foreach (Model_PostTaxonomy mpt in this.TaxList)
                            { 


                                        string imgPath = string.Empty;
                                        string alt = string.Empty;
                                        string title = string.Empty;
                                        string Price = string.Empty;
                                        List<Model_TaxMedia> cm = mpt.TaxMedia;
                                        Model_TaxMedia cimg = cm.SingleOrDefault(o => o.TaxMediaTypeID == TaxMediaType.FeatureImage);

                                        if (cimg != null)
                                        {
                                            imgPath =cimg.MediaFullPath;
                                            alt = cimg.Alt;
                                            title = cimg.Title;
                                        }
%>

					    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 col-ss-12 product_catalog_item clearfix">
						    <img style="width:45%" class="product_catalog_img product_women" src="<% Response.Write(imgPath); %>" alt="<% Response.Write(alt); %>" title="<% Response.Write(title); %>" />
						    <p class="product_catalog_title"><a href="<% Response.Write(mpt.Permarlink); %>" ><% Response.Write(mpt.Title); %></a></p>
						    <ul class="product_catalog_list">

                                <%

                                    List<Model_PostTaxonomy> child = this.TaxForPostType.FrontGetTaxonomyByRefID(mpt.TaxID);
                                    foreach (Model_PostTaxonomy mc in child)
                                    { %>
							            <li><a href="<% Response.Write(mc.Permarlink); %>" ><% Response.Write(mc.Title); %></a></li>

                                       <% List<Model_PostTaxonomy> childVv3 = this.TaxForPostType.FrontGetTaxonomyByRefID(mc.TaxID);
                                           if (childVv3.Count > 0)
                                           {
                                               foreach (Model_PostTaxonomy mcv3 in childVv3)
                                               { %>

                                                    <li style="margin-left:15px;"><a href="<% Response.Write(mcv3.Permarlink); %>" ><% Response.Write(mcv3.Title); %></a></li>
                                                <% }
                                           }

                                           %>
                                            
							        <%} %>
						    </ul>
					    </div>
                            


                        <% if(rowcount%2 == 0){ %>

                          </div><!-- //ROW -->
			            </div><!-- //CONTAINER -->
		            </section><!-- //PRODUCT CATALOG SECTION -->

                     <!-- PRODUCT CATALOG SECTION -->
		            <section class="product_catalog_block">
			
			            <!-- CONTAINER -->
			            <div class="container">
				
				            <!-- ROW -->
				            <div class="row">


                        <%} %>


                        <% rowcount = rowcount +1; } %>
					
					    
				    </div><!-- //ROW -->
			    </div><!-- //CONTAINER -->
		    </section><!-- //PRODUCT CATALOG SECTION -->
		
            <%} %>
		
		  
		
		    <section>
			
			    <!-- CONTAINER -->
			    <div class="container">
			
				    <!-- SHOP BANNER -->
				    <div class="row top_sale_banners center padbot30">
					    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 col-ss-12"><a class="banner nobord margbot30" href="javascript:void(0);" ><img src="images/tovar/banner22.jpg" alt="" /></a></div>
					    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 col-ss-12"><a class="banner nobord margbot30" href="javascript:void(0);" ><img src="images/tovar/banner10.jpg" alt="" /></a></div>
					    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 col-ss-12"><a class="banner nobord margbot30" href="javascript:void(0);" ><img src="images/tovar/banner23.jpg" alt="" /></a></div>
				    </div><!-- //SHOP BANNER -->
			    </div><!-- //CONTAINER -->
		    </section>
		
        </section>
      <%-- End Product Page Archive TEMPLATE--%>



        <%-- Product Taxonomy Page Archive TEMPLATE--%>
        <section   id="SectionProductTaxArchive"   runat="server" visible="false">
              <!-- SHOP BLOCK -->
		    <section class="shop">
			
			    <!-- CONTAINER -->
			    <div class="container">
			
				    <!-- ROW -->
				    <div class="row">
					
					    <!-- SIDEBAR -->
					    <div id="sidebar" class="col-lg-3 col-md-3 col-sm-3 padbot50">
						
						    <!-- CATEGORIES -->
						    <div class="sidepanel widget_categories">
							    <h3>Product Categories</h3>
							    <ul>
								    <li><a href="javascript:void(0);" >Sweaters</a></li>
								    <li><a href="javascript:void(0);" >SHIRTS &amp; TOPS</a></li>
								    <li><a href="javascript:void(0);" >KNITS &amp; TEES</a></li>
								    <li><a href="javascript:void(0);" >PANTS</a></li>
								    <li><a href="javascript:void(0);" >DENIM</a></li>
								    <li><a href="javascript:void(0);" >DRESSES</a></li>
								    <li><a href="javascript:void(0);" >Maternity</a></li>
							    </ul>
						    </div><!-- //CATEGORIES -->
						
						    <!-- PRICE RANGE -->
						    <div class="sidepanel widget_pricefilter">
							    <h3>Filter by price</h3>
							    <div id="price-range" class="clearfix">
								    <label for="amount">Range:</label>
								    <input type="text" id="amount"/>
								    <div class="padding-range"><div id="slider-range"></div></div>
							    </div>
						    </div><!-- //PRICE RANGE -->

						    <!-- SHOP BY SIZE -->
						    <div class="sidepanel widget_sized">
							    <h3>SHOP BY SIZE</h3>
							    <ul>
								    <li><a class="sizeXS" href="javascript:void(0);" >XS</a></li>
								    <li class="active"><a class="sizeS" href="javascript:void(0);" >S</a></li>
								    <li><a class="sizeM" href="javascript:void(0);" >M</a></li>
								    <li><a class="sizeL" href="javascript:void(0);" >L</a></li>
								    <li><a class="sizeXL" href="javascript:void(0);" >XL</a></li>
							    </ul>
						    </div><!-- //SHOP BY SIZE -->
						
						    <!-- SHOP BY COLOR -->
						    <div class="sidepanel widget_color">
							    <h3>SHOP BY COLOR</h3>
							    <ul>
								    <li><a class="color1" href="javascript:void(0);" ></a></li>
								    <li class="active"><a class="color2" href="javascript:void(0);" ></a></li>
								    <li><a class="color3" href="javascript:void(0);" ></a></li>
								    <li><a class="color4" href="javascript:void(0);" ></a></li>
								    <li><a class="color5" href="javascript:void(0);" ></a></li>
								    <li><a class="color6" href="javascript:void(0);" ></a></li>
								    <li><a class="color7" href="javascript:void(0);" ></a></li>
								    <li><a class="color8" href="javascript:void(0);" ></a></li>
							    </ul>
						    </div><!-- //SHOP BY COLOR -->
						
						    <!-- SHOP BY BRANDS -->
						    <div class="sidepanel widget_brands">
							    <h3>SHOP BY BRANDS</h3>
							    <input type="checkbox" id="categorymanufacturer1" /><label for="categorymanufacturer1">VERSACE <span>(24)</span></label>
							    <input type="checkbox" id="categorymanufacturer2" /><label for="categorymanufacturer2">J CREW <span>(35)</span></label>
							    <input type="checkbox" id="categorymanufacturer3" /><label for="categorymanufacturer3">Calvin KlEin <span>(48)</span></label>
							    <input type="checkbox" id="categorymanufacturer4" /><label for="categorymanufacturer4">Tommy hilfiger <span>(129)</span></label>
							    <input type="checkbox" id="categorymanufacturer5" /><label for="categorymanufacturer5">Ralph Lauren <span>(69)</span></label>
						    </div><!-- //SHOP BY BRANDS -->
						
						    <!-- BANNERS WIDGET -->
						    <div class="widget_banners">
							    <a class="banner nobord margbot10" href="javascript:void(0);" ><img src="images/tovar/banner10.jpg" alt="" /></a>
							    <a class="banner nobord margbot10" href="javascript:void(0);" ><img src="images/tovar/banner9.jpg" alt="" /></a>
							    <a class="banner nobord margbot10" href="javascript:void(0);" ><img src="images/tovar/banner8.jpg" alt="" /></a>
						    </div><!-- //BANNERS WIDGET -->
						
						    <!-- NEWSLETTER FORM WIDGET -->
						    <div class="sidepanel widget_newsletter">
							    <div class="newsletter_wrapper">
								    <h3>NEWSLETTER</h3>
								    <form class="newsletter_form clearfix" action="javascript:void(0);" method="get">
									    <input type="text" name="newsletter" value="Enter E-mail & Get 10% off" onFocus="if (this.value == 'Enter E-mail & Get 10% off') this.value = '';" onBlur="if (this.value == '') this.value = 'Enter E-mail & Get 10% off';" />
									    <input class="btn newsletter_btn" type="submit" value="Sign up & get 10% off">
								    </form>
							    </div>
						    </div><!-- //NEWSLETTER FORM WIDGET -->
					    </div><!-- //SIDEBAR -->
					
					
					    <!-- SHOP PRODUCTS -->
					    <div class="col-lg-9 col-sm-9 col-sm-9 padbot20">
						
						    <!-- SHOP BANNER -->
						    <div class="banner_block margbot15">
							    <a class="banner nobord" href="javascript:void(0);" ><img src="images/tovar/banner21.jpg" alt="" /></a>
						    </div><!-- //SHOP BANNER -->
						
						    <!-- SORTING TOVAR PANEL -->
						    <div class="sorting_options clearfix">
							
							    <!-- COUNT TOVAR ITEMS -->
							    <div class="count_tovar_items">
								    <p>Sweaters</p>
								    <span>194 Items</span>
							    </div><!-- //COUNT TOVAR ITEMS -->
							
							    <!-- TOVAR FILTER -->
							    <div class="product_sort">
								    <p>SORT BY</p>
								    <select class="basic">
									    <option value="">Popularity</option>
									    <option>Reting</option>
									    <option>Date</option>
								    </select>
							    </div><!-- //TOVAR FILTER -->
							
							    <!-- PRODUC SIZE -->
							    <div id="toggle-sizes">
								    <a class="view_box active" href="javascript:void(0);"><i class="fa fa-th-large"></i></a>
								    <a class="view_full" href="javascript:void(0);"><i class="fa fa-th-list"></i></a>
							    </div><!-- //PRODUC SIZE -->
						    </div><!-- //SORTING TOVAR PANEL -->
						
						
						    <!-- ROW -->
						    <div class="row shop_block">
								
							    <!-- TOVAR1 -->
							    <div class="tovar_wrapper col-lg-4 col-md-4 col-sm-6 col-xs-6 col-ss-12 padbot40">
								    <div class="tovar_item clearfix">
									    <div class="tovar_img">
										    <div class="tovar_img_wrapper">
											    <img class="img" src="images/tovar/women/1.jpg" alt="" />
											    <img class="img_h" src="images/tovar/women/1_2.jpg" alt="" />
										    </div>
										    <div class="tovar_item_btns">
											    <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/1.html" ><span>quick</span> view</a></div>
											    <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
											    <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
										    </div>
									    </div>
									    <div class="tovar_description clearfix">
										    <a class="tovar_title" href="product-page.html" >Popover Sweatshirt in Floral Jacquard</a>
										    <span class="tovar_price">$98.00</span>
									    </div>
									    <div class="tovar_content">What makes our cashmere so special? We start with the finest yarns from an Italian mill known for producing some of the softest cashmere out there.</div>
								    </div>
							    </div><!-- //TOVAR1 -->
							
							    <!-- TOVAR2 -->
							    <div class="tovar_wrapper col-lg-4 col-md-4 col-sm-6 col-xs-6 col-ss-12 padbot40">
								    <div class="tovar_item clearfix">
									    <div class="tovar_img">
										    <div class="tovar_img_wrapper">
											    <img class="img" src="images/tovar/women/2.jpg" alt="" />
											    <img class="img_h" src="images/tovar/women/2_2.jpg" alt="" />
										    </div>
										    <div class="tovar_item_btns">
											    <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/2.html" ><span>quick</span> view</a></div>
											    <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
											    <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
										    </div>
									    </div>
									    <div class="tovar_description clearfix">
										    <a class="tovar_title" href="product-page.html" >Popover Sweatshirt in Floral Jacquard</a>
										    <span class="tovar_price">$98.00</span>
									    </div>
									    <div class="tovar_content">What makes our cashmere so special? We start with the finest yarns from an Italian mill known for producing some of the softest cashmere out there.</div>
								    </div>
							    </div><!-- //TOVAR2 -->
							
							    <!-- TOVAR3 -->
							    <div class="tovar_wrapper col-lg-4 col-md-4 col-sm-6 col-xs-6 col-ss-12 padbot40">
								    <div class="tovar_item clearfix">
									    <div class="tovar_img">
										    <div class="tovar_img_wrapper">
											    <img class="img" src="images/tovar/women/3.jpg" alt="" />
											    <img class="img_h" src="images/tovar/women/3_2.jpg" alt="" />
										    </div>
										    <div class="tovar_item_btns">
											    <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/3.html" ><span>quick</span> view</a></div>
											    <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
											    <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
										    </div>
									    </div>
									    <div class="tovar_description clearfix">
										    <a class="tovar_title" href="product-page.html" >Japanese indigo denim jacket</a>
										    <span class="tovar_price">$158.00</span>
									    </div>
									    <div class="tovar_content">What makes our cashmere so special? We start with the finest yarns from an Italian mill known for producing some of the softest cashmere out there.</div>
								    </div>
							    </div><!-- //TOVAR3 -->
							
							    <!-- TOVAR4 -->
							    <div class="tovar_wrapper col-lg-4 col-md-4 col-sm-6 col-xs-6 col-ss-12 padbot40">
								    <div class="tovar_item clearfix">
									    <div class="tovar_img">
										    <div class="tovar_img_wrapper">
											    <img class="img" src="images/tovar/women/4.jpg" alt="" />
											    <img class="img_h" src="images/tovar/women/4_2.jpg" alt="" />
										    </div>
										    <div class="tovar_item_btns">
											    <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/4.html" ><span>quick</span> view</a></div>
											    <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
											    <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
										    </div>
									    </div>
									    <div class="tovar_description clearfix">
										    <a class="tovar_title" href="product-page.html" >Peacoat trench</a>
										    <span class="tovar_price">$298.00</span>
									    </div>
									    <div class="tovar_content">What makes our cashmere so special? We start with the finest yarns from an Italian mill known for producing some of the softest cashmere out there.</div>
								    </div>
							    </div><!-- //TOVAR4 -->
							
							    <!-- TOVAR5 -->
							    <div class="tovar_wrapper col-lg-4 col-md-4 col-sm-6 col-xs-6 col-ss-12 padbot40">
								    <div class="tovar_item tovar_sale clearfix">
									    <div class="tovar_img">
										    <div class="tovar_img_wrapper">
											    <img class="img" src="images/tovar/women/5.jpg" alt="" />
											    <img class="img_h" src="images/tovar/women/5_2.jpg" alt="" />
										    </div>
										    <div class="tovar_item_btns">
											    <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/5.html" ><span>quick</span> view</a></div>
											    <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
											    <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
										    </div>
									    </div>
									    <div class="tovar_description clearfix">
										    <a class="tovar_title" href="product-page.html" >Schoolboy blazer in italian wool</a>
										    <span class="tovar_price">$194.00</span>
									    </div>
									    <div class="tovar_content">What makes our cashmere so special? We start with the finest yarns from an Italian mill known for producing some of the softest cashmere out there.</div>
								    </div>
							    </div><!-- //TOVAR5 -->
							
							    <!-- TOVAR6 -->
							    <div class="tovar_wrapper col-lg-4 col-md-4 col-sm-6 col-xs-6 col-ss-12 padbot40">
								    <div class="tovar_item clearfix">
									    <div class="tovar_img">
										    <div class="tovar_img_wrapper">
											    <img class="img" src="images/tovar/women/6.jpg" alt="" />
											    <img class="img_h" src="images/tovar/women/6_2.jpg" alt="" />
										    </div>
										    <div class="tovar_item_btns">
											    <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/6.html" ><span>quick</span> view</a></div>
											    <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
											    <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
										    </div>
									    </div>
									    <div class="tovar_description clearfix">
										    <a class="tovar_title" href="product-page.html" >Cashmere mockneck sweater</a>
										    <span class="tovar_price">$257.00</span>
									    </div>
									    <div class="tovar_content">What makes our cashmere so special? We start with the finest yarns from an Italian mill known for producing some of the softest cashmere out there.</div>
								    </div>
							    </div><!-- //TOVAR6 -->
							
							    <!-- TOVAR7 -->
							    <div class="tovar_wrapper col-lg-4 col-md-4 col-sm-6 col-xs-6 col-ss-12 padbot40">
								    <div class="tovar_item clearfix">
									    <div class="tovar_img">
										    <div class="tovar_img_wrapper">
											    <img class="img" src="images/tovar/women/7.jpg" alt="" />
											    <img class="img_h" src="images/tovar/women/7_2.jpg" alt="" />
										    </div>
										    <div class="tovar_item_btns">
											    <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/7.html" ><span>quick</span> view</a></div>
											    <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
											    <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
										    </div>
									    </div>
									    <div class="tovar_description clearfix">
										    <a class="tovar_title" href="product-page.html" >Waxed canvas utility jacket</a>
										    <span class="tovar_price">$168.00</span>
									    </div>
									    <div class="tovar_content">What makes our cashmere so special? We start with the finest yarns from an Italian mill known for producing some of the softest cashmere out there.</div>
								    </div>
							    </div><!-- //TOVAR7 -->
							
							    <!-- TOVAR8 -->
							    <div class="tovar_wrapper col-lg-4 col-md-4 col-sm-6 col-xs-6 col-ss-12 padbot40">
								    <div class="tovar_item clearfix">
									    <div class="tovar_img">
										    <div class="tovar_img_wrapper">
											    <img class="img" src="images/tovar/women/8.jpg" alt="" />
											    <img class="img_h" src="images/tovar/women/8_2.jpg" alt="" />
										    </div>
										    <div class="tovar_item_btns">
											    <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/8.html" ><span>quick</span> view</a></div>
											    <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
											    <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
										    </div>
									    </div>
									    <div class="tovar_description clearfix">
										    <a class="tovar_title" href="product-page.html" >Thompson blazer in stretch cotton</a>
										    <span class="tovar_price">$173.00</span>
									    </div>
									    <div class="tovar_content">What makes our cashmere so special? We start with the finest yarns from an Italian mill known for producing some of the softest cashmere out there.</div>
								    </div>
							    </div><!-- //TOVAR8 -->
							
							    <!-- TOVAR9 -->
							    <div class="tovar_wrapper col-lg-4 col-md-4 col-sm-6 col-xs-6 col-ss-12 padbot40">
								    <div class="tovar_item clearfix">
									    <div class="tovar_img">
										    <div class="tovar_img_wrapper">
											    <img class="img" src="images/tovar/women/9.jpg" alt="" />
											    <img class="img_h" src="images/tovar/women/9_2.jpg" alt="" />
										    </div>
										    <div class="tovar_item_btns">
											    <div class="open-project-link"><a class="open-project tovar_view" href="javascript:void(0);" data-url="!projects/women/9.html" ><span>quick</span> view</a></div>
											    <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
											    <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>
										    </div>
									    </div>
									    <div class="tovar_description clearfix">
										    <a class="tovar_title" href="product-page.html" >Vintage denim jacket in patina wash</a>
										    <span class="tovar_price">$99.00</span>
									    </div>
									    <div class="tovar_content">What makes our cashmere so special? We start with the finest yarns from an Italian mill known for producing some of the softest cashmere out there.</div>
								    </div>
							    </div><!-- //TOVAR9 -->
						    </div><!-- //ROW -->
						
						    <hr>
						
						    <div class="clearfix">
							    <!-- PAGINATION -->
							    <ul class="pagination">
								    <li><a href="javascript:void(0);" >1</a></li>
								    <li><a href="javascript:void(0);" >2</a></li>
								    <li class="active"><a href="javascript:void(0);" >3</a></li>
								    <li><a href="javascript:void(0);" >4</a></li>
								    <li><a href="javascript:void(0);" >5</a></li>
								    <li><a href="javascript:void(0);" >6</a></li>
								    <li><a href="javascript:void(0);" >...</a></li>
							    </ul><!-- //PAGINATION -->
							
							    <a class="show_all_tovar" href="javascript:void(0);" >show all</a>
							
						    </div>
						
						    <hr>
						
						    <div class="padbot60 services_section_description">
							    <p>We empower WordPress developers with design-driven themes and a classy experience their clients will just love</p>
							    <span>Gluten-free quinoa selfies carles, kogi gentrify retro marfa viral. Odd future photo booth flannel ethnic pug, occupy keffiyeh synth blue bottle tofu tonx iphone. Blue bottle 90′s vice trust fund gastropub gentrify retro marfa viral. Gluten-free quinoa selfies carles, kogi gentrify retro marfa viral. Odd future photo booth flannel ethnic pug, occupy keffiyeh synth blue bottle tofu tonx iphone. Blue bottle 90′s vice trust fund gastropub gentrify retro marfa viral.</span>
						    </div>
						
						    <!-- SHOP BANNER -->
						    <div class="row top_sale_banners center">
							    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 col-ss-12"><a class="banner nobord margbot30" href="javascript:void(0);" ><img src="images/tovar/banner22.jpg" alt="" /></a></div>
							    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 col-ss-12"><a class="banner nobord margbot30" href="javascript:void(0);" ><img src="images/tovar/banner23.jpg" alt="" /></a></div>
						    </div><!-- //SHOP BANNER -->
					    </div><!-- //SHOP PRODUCTS -->
				    </div><!-- //ROW -->
			    </div><!-- //CONTAINER -->
		    </section><!-- //SHOP -->
        </section>
      <%-- End Product Taxonomy Page Archive TEMPLATE--%>
        

        <!-- PAGE TEMPLATE-->
		<section  id="page_content" runat="server" visible="false">
			
			    <section class="page_header">
			
			    <!-- CONTAINER -->
			        <div class="container">
				        <h3 class="pull-left"><b><%: this.PostDataUI.Title %></b></h3>
				
				       <%-- <div class="pull-right">
					        <a href="women.html">Back to shop<i class="fa fa-angle-right"></i></a>
				        </div>--%>
			        </div><!-- //CONTAINER -->
		        </section>
                <section class="about_us_info">
			
			    <!-- CONTAINER -->
			    <div class="container">
				
				     <% Response.Write(this.ContentBody); %>
			    </div><!-- //CONTAINER -->
		    </section>
			
		</section>
        <!-- End  PAGE TEMPLATE -->

        

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
						

                                <% 


                                    Model_Post p = new Model_Post();
                                    List<Model_Post> plist = p.GetPostByTax(PostType.Products,"สินค้าแนะนำ");
                                    foreach (Model_Post item in plist.Take(3))
                                    {
                                        Model_PostCustomItem cu = new Model_PostCustomItem();
                                        string imgPath = string.Empty;
                                        string alt = string.Empty;
                                        string title = string.Empty;
                                        string Price = string.Empty;
                                        List<Model_PostMedia> cm = item.PostMedia;
                                        Model_PostMedia cimg = cm.SingleOrDefault(o => o.PostMediaTypeID == PostMediaType.FeatureImage);


                                        List<Model_PostCustomItem> cul = cu.GetItemCustomByPostID(item.PostID);

                                        cu = cul.SingleOrDefault(o => o.PcName == "product-price-per-unit");
                                        if (cu != null)
                                        {
                                            Price = ((decimal)cu.PriceData).ToString("#,##0.00");
                                        }
                                        if (cimg != null)
                                        {
                                            imgPath =cimg.MediaFullPath;
                                            alt = cimg.Alt;
                                            title = cimg.Title;
                                        }

                                    %>
						        <!-- TOVAR1 -->
						        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-6 col-ss-12 padbot40">
							        <div class="tovar_item">
								        <div class="tovar_img">
									        <div class="tovar_img_wrapper">
										        <img class="img" src="<% Response.Write(imgPath); %>" alt="<% Response.Write(alt); %>" title="<% Response.Write(title); %>" />
										        <img class="img_h" src="<% Response.Write(imgPath);%>" alt="<% Response.Write(alt); %>" title="<% Response.Write(title); %>" />
									        </div>
									        <div class="tovar_item_btns">
										        <div class="open-project-link"><a class="open-project tovar_view" href="<% Response.Write(item.Permarlink);%>" 
                                                    data-url="<% Response.Write(item.Permarlink);%>" >quick view</a></div>
										        <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
										       <%-- <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>--%>
									        </div>
								        </div>
								        <div class="tovar_description clearfix">
									        <a class="tovar_title" href="<%Response.Write(item.Permarlink); %>" ><%  Response.Write(item.Title);%></a>
									        <span class="tovar_price"> <% Response.Write(Price); %> Baht</span>
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
						
                                <%   
                                    foreach (Model_Post item in plist.Skip(3).Take(3)){
                                         Model_PostCustomItem cu = new Model_PostCustomItem();
                                    string imgPath = string.Empty;
                                    string alt = string.Empty;
                                    string title = string.Empty;
                                    string Price = string.Empty;
                                        List<Model_PostMedia> cm = item.PostMedia;
                                        Model_PostMedia cimg = cm.SingleOrDefault(o => o.PostMediaTypeID == PostMediaType.FeatureImage);
                                       

                                        List<Model_PostCustomItem> cul = cu.GetItemCustomByPostID(item.PostID);
                                        cu = cul.SingleOrDefault(o => o.PcName == "product-price-per-unit");
                                        if(cu != null)
                                        {
                                            Price = ((decimal)cu.PriceData).ToString("#,##0.00");
                                        }
                                       

                                        if (cimg != null)
                                        {
                                            imgPath =cimg.MediaFullPath;
                                            alt = cimg.Alt;
                                            title = cimg.Title;
                                        }
                                        %>
						        <!-- TOVAR4 -->

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-6 col-ss-12 padbot40">
							        <div class="tovar_item tovar_sale">
								        <div class="tovar_img">
									        <div class="tovar_img_wrapper">
										        <img class="img" src="<% Response.Write(imgPath); %>" alt="<% Response.Write(alt); %>" title="<% Response.Write(title); %>" />
										        <img class="img_h" src="<% Response.Write(imgPath);%>" alt="<% Response.Write(alt); %>" title="<% Response.Write(title); %>" />
									        </div>
									        <div class="tovar_item_btns">
										        <div class="open-project-link"><a class="open-project tovar_view" href="<% Response.Write(item.Permarlink);%>" 
                                                    data-url="<% Response.Write(item.Permarlink);%>" >quick view</a></div>
										        <a class="add_bag" href="javascript:void(0);" ><i class="fa fa-shopping-cart"></i></a>
										       <%-- <a class="add_lovelist" href="javascript:void(0);" ><i class="fa fa-heart"></i></a>--%>
									        </div>
								        </div>
								        <div class="tovar_description clearfix">
									        <a class="tovar_title" href="<%Response.Write(item.Permarlink); %>" ><%  Response.Write(item.Title);%></a>
									        <span class="tovar_price"> <% Response.Write(Price); %> Baht</span>
								        </div>
							        </div>
						        </div>


						       
						        <%} %>
						       


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
                                    List<Model_Post> pnew = p.GetPostByTax(PostType.Products, "สินค้ามาใหม่");
                                    foreach (Model_Post item in pnew)
                                    {

                                              Model_PostCustomItem cu = new Model_PostCustomItem();
                                    string imgPath = string.Empty;
                                    string alt = string.Empty;
                                    string title = string.Empty;
                                    string Price = string.Empty;
                                        List<Model_PostMedia> cm = item.PostMedia;
                                        Model_PostMedia cimg = cm.SingleOrDefault(o => o.PostMediaTypeID == PostMediaType.FeatureImage);
                                       

                                        List<Model_PostCustomItem> cul = cu.GetItemCustomByPostID(item.PostID);
                                        cu = cul.SingleOrDefault(o => o.PcName == "product-price-per-unit");
                                        if(cu != null)
                                        {
                                            Price = ((decimal)cu.PriceData).ToString("#,##0.00");
                                        }
                                       

                                        if (cimg != null)
                                        {
                                            imgPath =cimg.MediaFullPath;
                                            alt = cimg.Alt;
                                            title = cimg.Title;
                                        }
                                    %>
                                 
							        <li>
								        <!-- TOVAR -->
								        <div class="tovar_item_new">
									        <div class="tovar_img">
										        <img src="<% Response.Write(imgPath);%>" alt="<% Response.Write(alt); %>" title="<% Response.Write(title); %>" />
										        <div class="open-project-link"><a class="open-project tovar_view" href="<% Response.Write(item.Permarlink);%>" data-url="<% Response.Write(item.Permarlink);%>" >quick view</a></div>
									        </div>
									        <div class="tovar_description clearfix">
										        <a class="tovar_title" href="<%Response.Write(item.Permarlink); %>" ><%  Response.Write(item.Title);%></a>
										        <span class="tovar_price"><% Response.Write(Price); %> Baht</span>
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
				        <h2>กิจกรรมและข่าวสาร ล่าสุด</h2>
				        
				        <!-- ROW -->
				        <div class="row" data-appear-top-offset='-100' data-animated='fadeInUp'>

                            <%  
                                List<Model_Post> pblog = p.GetPostByPostType(PostType.Blog);
                                foreach (Model_Post item in pblog.Take(2))
                                {

                                    Model_PostCustomItem cu = new Model_PostCustomItem();
                                    string imgPath = string.Empty;
                                    string alt = string.Empty;
                                    string title = string.Empty;
                                    string Price = string.Empty;
                                    List<Model_PostMedia> cm = item.PostMedia;
                                    Model_PostMedia cimg = cm.SingleOrDefault(o => o.PostMediaTypeID == PostMediaType.FeatureImage);


                                    List<Model_PostCustomItem> cul = cu.GetItemCustomByPostID(item.PostID);
                                    cu = cul.SingleOrDefault(o => o.PcName == "product-price-per-unit");
                                    if (cu != null)
                                    {
                                        Price = ((decimal)cu.PriceData).ToString("#,##0.00");
                                    }


                                    if (cimg != null)
                                    {
                                        imgPath = cimg.MediaFullPath;
                                        alt = cimg.Alt;
                                        title = cimg.Title;
                                    }
                                    %>
					        <div class="col-lg-6 col-md-6 padbot30">
						        <div class="recent_post_item clearfix">
                                    <div class="col-md-6 col-xs-12" style="padding-left:0px;padding-right:0px;">

                                        <div class="recent_post_date"><%  Response.Write(item.DatePublish.Day);%><span><%  Response.Write(item.DatePublish.ToString("MMM"));%></span></div>
							        <a class="recent_post_img_gcustom" href="<%Response.Write(item.Permarlink); %>" >
                                        <img class="img-responsive" src="<% Response.Write(imgPath);%>" alt="<% Response.Write(alt); %>" title="<% Response.Write(title); %>" /></a>
                                    </div>
                                    <div class="col-md-6 col-xs-12" style="padding-left:0px;padding-right:0px;">
                                         <a class="recent_post_title" href="<%Response.Write(item.Permarlink); %>" ><%  Response.Write(item.Title);%></a>
							        <div class="recent_post_content"><%  Response.Write(item.BodyContent.getShortContent());%></div>
							        <ul class="post_meta">
								        <li><i class="fa fa-comments"></i>Commetcs <span class="sep">|</span> 15</li>
							        </ul>

                                    </div>
							        
							       
						        </div>
					        </div>
					<%} %>
					        
				        </div><!-- //ROW -->
			        </div><!-- //CONTAINER -->
		        </section><!-- //RECENT POSTS -->
                <!-- PAGE HOME TEMPLATE -->

                </section>
        <!-- End PAGE HOME TEMPLATE -->
   
</asp:Content>

<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
