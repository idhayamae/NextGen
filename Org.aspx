<%@ Page Title="" Language="C#" MasterPageFile="~/HP.master" AutoEventWireup="true"
    CodeFile="Org.aspx.cs" Inherits="Org" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script src="includes/js/Facilitiesslider.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="text_container withoutRightSec">
		<div class="w940 eq_hgt">
			<section class="tabset_top">			
            <div id="divTabsList" runat="server"></div>			
			<section class="tab_content_main">
             <div id="divTabsContent" runat="server"></div>                    
			</section>
			</section>
		</div>
        </section>
</asp:Content>
