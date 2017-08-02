<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="EditPage.aspx.cs" Inherits="_EditPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-lg-12">

                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Staff List </h5>

                            
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
                                    <a href="PageNew"  class="btn btn-w-m btn-success">Add New Page</a>
                                   <%-- <div class="input-group"><input type="text" placeholder="Search" class="input-sm form-control"> <span class="input-group-btn">
                                        <button type="button" class="btn btn-sm btn-primary"> Go!</button> </span></div>--%>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                    <tr>

                                        <th></th>
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

            ////$('#dropRole').on('change', function () {

            ////    var v = $(this).val();
            ////    getList(v);
            ////});
        });


        function getList(v) {

            var url = "<%= ResolveUrl("/admin/Pages/ajax_webmethod_page.aspx/GetAll") %>";

            if(!v){ v = 0}
            var data = { };
            var param = JSON.stringify({ parameters: data });

            AjaxPost(url, param, function () {
               
            }, function (data) {

              //  console.log(data);
                var h = GenlistAll(data);
                $('#body_list').html(h);
               
            });
        }


        function GenlistAll(data) {
            var ret = "";
            for (var i in data) {
              
                ret += '<tr>';
                ret += '   <td><input type="checkbox" checked class="i-checks" disabled name="input[]"></td>';
                ret += '   <td>' + data[i].Title+'</td>';
                ret += '   <td>' + data[i].UserFirstName +'</td>';
                ret += '   <td>' + data[i].DatePublishFormat +'</td>';
                ret += '   <td><span class="label label-primary">' + data[i].ViewCount +'</span></td>';
                ret += '   <td><a href="Page?PostID=' + data[i].PostID+'"><i class="fa fa-pencil"></i> Edit </a></td>';
                ret += '   </tr >';
            }

            return ret;
        }

    </script>
</asp:Content>