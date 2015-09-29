<%@ Page Title="" Language="C#" MasterPageFile="~/HP.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="Popup_1/Js/function.js"></script>
    <link rel="stylesheet" type="text/css" href="Popup_1/Css/styles.css" /> 


    <div class="selectlocation l_popup">
            <div class="close_l_popup">
            </div>
            <div class="container" style="margin-left: 54px\9">
                <div class="heading">
                    47 New IJP Openings!!</div>
                <div class="lt_col">
                    <div>
                        <span style="color: #bd1823;">Java</span> : <span style="color: #2a5fff;">24 Positions</div>
                    <div>
                        <span style="color: #bd1823;">Testing</span> : <span style="color: #2a5fff;">9 Positions</div>
		    <div>
                        <span style="color: #bd1823;">Program Management</span> : <span style="color: #2a5fff;">3 Positions</div>
                </div>
                <div class="rt_col">
                    <div>
                        <span style="color: #bd1823;">Peoplesoft</span> : <span style="color: #2a5fff;">2 Positions</div>
                    <div>
                        <span style="color: #bd1823;">SQL</span> : <span style="color: #2a5fff;">1 Positions</div>
		    <div>
                        <span style="color: #bd1823;">OBIEE / ODI</span> : <span style="color: #2a5fff;">2 Positions</div>
                    <div>
                        <span style="color: #000000;">and many more...</div>
                </div>
                <div class="clear">
                </div>
                <div style="margin-left: 38%;">
                    <a href="https://ps-prdsso.ehr.verizon.com/psc/vzehpra/EMPLOYEE/HRMS/c/HRS_HRS.HRS_APP_SCHJOB.GBL?Page=HRS_APP_SCHJOB&Action=U&TargetFrameName=None" class="btn_apply" style="text-decoration: none;" target="_blank"><font color="white"> Apply Now</font></a>
                </div>
                <div class="update">
                    Updated on - 25 Nov, 2013</div>
            </div>
            <div style="width: 200px; margin-left: 50px\9;">
                <div class="hand">
                </div>
            </div>
        </div>   

        <script type="text/javascript">
           
            /*function myFunction() {
                setTimeout(function() {
                $('div.selectlocation').show();
                $(document).ready(function() {
                    $(".l_popup").animate({ bottom: "190px" }, 700);
                    $('body').delay(700).queue(function() {
                        $(this).css('overflow', 'auto');
                    });
                    $(".l_popup").delay(700).queue(function() {
                        $(this).css('position', 'fixed');
                    });
                });
                }, 8000);
            }
            jQuery(function($) {
            myFunction();
            });*/

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">	
    <div class="divider">
    </div>
    <div id="divSliderContent" runat="server">
    </div>
    <section class="text_container">
		<div class="grid_8 eq_hgt">
			<section class="tabset_top">			
                <div id="divCenterTabsList" runat="server"></div>	
			    <section class="tab_content_main">
			        <div id="divCenterTabsContent" runat="server"></div>            
			    </section>
			</section>
		</div>
		<!--Main Column-->
		<!--Sidebar Right START-->
		<div class="grid_4 sidebar eq_hgt">
			<section class="tabset2">
			    <div id="divRightTabsList" runat="server"></div>
			    <section class="tab_content_main">
                    <div runat="server" id="divRightTabsContent"></div>            
			    </section>			
			</section>
            <!--Sidebar Right END-->
			<!--<div class="clear"></div>-->
		</div>
   </section>
</asp:Content>
