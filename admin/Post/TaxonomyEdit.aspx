<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TaxonomyEdit.aspx.cs" Inherits="_TaxonomyEdit" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
    <style>
        .list_status.active{
            font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-lg-12">

                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5><asp:Literal ID="titlepage" runat="server"></asp:Literal></h5>

                            
                        </div>
                        <div class="ibox-content">

                            <div class="row">
                                <div class="col-sm-5 m-b-xs">
                                  <%-- <strong>Role:</strong> <asp:DropDownList ID="dropRole" ClientIDMode="Static" runat="server" CssClass="input-sm form-control input-s-sm inline">

                                    </asp:DropDownList>--%>
                                   <%-- <select class="input-sm form-control input-s-sm inline">
                                    <option value="0">Option 1</option>
                                    <option value="1">Option 2</option>
                                    <option value="2">Option 3</option>
                                    <option value="3">Option 4</option>
                                    </select>--%>
                                </div>
                                <div class="col-sm-4 m-b-xs">
                                   <%-- <div data-toggle="buttons" class="btn-group">
                                        <label class="btn btn-sm btn-white"> <input type="radio" id="option1" name="options"> Day </label>
                                        <label class="btn btn-sm btn-white active"> <input type="radio" id="option2" name="options"> Week </label>
                                        <label class="btn btn-sm btn-white"> <input type="radio" id="option3" name="options"> Month </label>
                                    </div>--%>
                                </div>
                                <div class="col-sm-3" style="text-align:right">
                                    <a class="list_status active" data-status="true" href="#" id="list_all_status"> All (<label></label>)</a> | <a class="list_status" id="list_trash_status"  data-status="false">Trash (<label></label>)</a> 
                                   <%--<asp:HyperLink ID="addTax" runat="server" CssClass="btn btn-w-m btn-success" Text="Add New"></asp:HyperLink>--%>
                                   <%-- <a  href="Taxonomy.aspx?Mode=add" class="btn btn-w-m btn-success">Add New</a>--%>
                                   <%-- <div class="input-group"><input type="text" placeholder="Search" class="input-sm form-control"> <span class="input-group-btn">
                                        <button type="button" class="btn btn-sm btn-primary"> Go!</button> </span></div>--%>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                    <tr>

                                        <%--<th></th>--%>
                                        <th>Title </th>
                                        <th>Author </th>
                                        <th>Date Published</th>
                                        <th>View</th>
                                        <th>Action</th>
                                    </tr>
                                    </thead>
                                    <tbody id="body_list">
                                   <%-- <tr>
                                        <td><input type="checkbox"  checked class="i-checks" name="input[]"></td>
                                        <td>Project<small>This is example of project</small></td>
                                        <td><span class="pie">0.52/1.561</span></td>
                                        <td>20%</td>
                                        <td>Jul 14, 2013</td>
                                        <td><a href="#"><i class="fa fa-check text-navy"></i></a></td>
                                    </tr>--%>
                                    
                                    </tbody>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
   
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {



            getList();


            $('.list_status').on('click', function () {
                $('.list_status').removeClass('active');
                $(this).toggleClass('active');
                getList();


                return false;
            });

            ////$('#dropRole').on('change', function () {

            ////    var v = $(this).val();
            ////    getList(v);
            ////});
        });


        function getList(v) {

            var url = "<%= ResolveUrl("/admin/Post/ajax_webmethod_post.aspx/GetTaxMain") %>";

            if (!v) { v = 0 }

            var Pt = getParameterByName('PostTypeID');
            var tty = getParameterByName('TaxTypeID');
            var data = { PostTypeID: Pt, TaxTypeID:tty };
            var param = JSON.stringify({ parameters: data });

            AjaxPost(url, param, function () {
               
            }, function (data) {

              //  console.log(data);
                

                var s = $('.list_status.active').data('status');
                var total = $.grep(data, function (e) { return e.Trash == true; });
                var trash = $.grep(data, function (e) { return e.Trash == false; });

                var newdata = (s? total : trash);
                var h = GenlistAll(newdata);

                $('#list_all_status label').html(total.length);
                $('#list_trash_status label').html(trash.length);
                $('#body_list').html(h);
               
            });
        }


        function GenlistAll(raw_data) {
            var ret = "";
            var TaxTypeID = getParameterByName('TaxTypeID');
            var PostTypeID = getParameterByName('PostTypeID');
            var data = $.grep(raw_data, function (e) { return e.RefID == 0; }); 
            for (var i in data) {
              
                ret += '<tr>';
                //ret += '   <td><input type="checkbox" checked class="i-checks" disabled name="input[]"></td>';
                ret += '   <td><strong><a href="Taxonomy?Mode=Edit&PostTypeID=' + PostTypeID + '&TaxTypeID=' + TaxTypeID + '&TaxID=' + data[i].TaxID +'"><i class="fa fa-star"></i>' + data[i].Title+'</a></strong></td>';
                ret += '   <td>' + data[i].UserFirstName +'</td>';
                ret += '   <td>' + data[i].DatePublishFormat +'</td>';
                ret += '   <td><span class="label label-primary">' + data[i].ViewCount +'</span></td>';
                ret += '   <td><a href="Taxonomy?Mode=Edit&PostTypeID=' + PostTypeID+'&TaxTypeID=' + TaxTypeID+'&TaxID=' + data[i].TaxID+'"><i class="fa fa-pencil"></i> Edit </a></td>';
                ret += '   </tr >';

                var lv1 = $.grep(raw_data, function (e) { return e.RefID == data[i].TaxID; }); 
                var v = 1;
                if (lv1.length > 0) {
                    ret += child(v,raw_data,lv1, data[i].TaxID);
                }
                

            }

            return ret;
        }

        function child(v, RawData, data, key) {
            var TaxTypeID = getParameterByName('TaxTypeID');
            var PostTypeID = getParameterByName('PostTypeID');
            var ret = "";
            if (data.length > 0) {
                v = v + 1;
                for (var i in data) {

                    ret += '<tr>';
                    //ret += '   <td><input type="checkbox" checked class="i-checks" disabled name="input[]"></td>';
                    ret += '   <td><a href="Taxonomy?Mode=Edit&PostTypeID=' + PostTypeID + '&TaxTypeID=' + TaxTypeID + '&TaxID=' + data[i].TaxID +'">' + level(v) + data[i].Title + '</a></td>';
                    ret += '   <td>' + data[i].UserFirstName + '</td>';
                    ret += '   <td>' + data[i].DatePublishFormat + '</td>';
                    ret += '   <td><span class="label label-primary">' + data[i].ViewCount + '</span></td>';
                    ret += '   <td><a href="Taxonomy?Mode=Edit&PostTypeID=3&TaxTypeID=1&TaxID=' + data[i].TaxID + '"><i class="fa fa-pencil"></i> Edit </a></td>';
                    ret += '   </tr >';
                    var lv1 = $.grep(RawData, function (e) { return e.RefID == data[i].TaxID; }); 
                    ret += child(v,RawData,lv1, data[i].TaxID);
                }
            }
            return ret;
        }


        function level(v) {
            var ret = "";
            var sp = "";
            if (v > 0) {
                for (var i = 1; i < v;i++ ) {
                    ret += '<i class="fa fa-long-arrow-right"></i>&nbsp;';
                    sp += "&nbsp;&nbsp;";
                }
            }
            return sp+ret;
        }

    </script>
</asp:Content>