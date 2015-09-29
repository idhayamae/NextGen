<%@ Page Title="" Language="C#" MasterPageFile="~/HP.master" AutoEventWireup="true"
    CodeFile="FunctionalGroup.aspx.cs" Inherits="FunctionalGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divTopContentContainer" runat="server" visible="false">
        <section class="topContainer">
		<div class="w940">
			<article class="health_content">
            <div id="divTopCotent" runat="server"></div>
			</article>
		</div>
	</section>
    </div>
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
