<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta name="viewport" content="width=device-width, initial-scale=1">

<link rel="stylesheet" href="w3.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div  class="w3-content w3-display-container">
  <img class="mySlides" src="Olgimg/ind60.jpg" style="width:100%">
  <img class="mySlides" src="Olgimg/hd883.jpg" style="width:100%">
  <img class="mySlides" src="Olgimg/bmw.jpg" style="width:100%">
  <img class="mySlides" src="Olgimg/hdfb.jpg" style="width:100%">
  <img class="mySlides" src="Olgimg/lre.jpg" style="width:100%">
  <img class="mySlides" src="Olgimg/lrd.jpg" style="width:100%">
  <img class="mySlides" src="Olgimg/rd.jpg" style="width:100%">
  <img class="mySlides" src="Olgimg/dr.jpg" style="width:100%">
  <img class="mySlides" src="Olgimg/jgc.jpg" style="width:100%">

  
  

  <button class="w3-button w3-black w3-display-left" onclick="plusDivs(-1)">&#10094;</button>
  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
  <button class="w3-button w3-black w3-display-right" onclick="plusDivs(1)">&#10095;</button>
</div>
<div><embed src="audio/Cartoon - On  On feat Daniel Levi NCS Release.mp3" autostart="true" loop="true" width="2" height="0"></embed>
<script>
    var slideIndex = 1;
    showDivs(slideIndex);

    function plusDivs(n) {
        showDivs(slideIndex += n);
    }

    function showDivs(n) {
        var i;
        var x = document.getElementsByClassName("mySlides");
        if (n > x.length) { slideIndex = 1 }
        if (n < 1) { slideIndex = x.length }
        for (i = 0; i < x.length; i++) {
            x[i].style.display = "none";
        }
        x[slideIndex - 1].style.display = "block";
    }
</script>
</asp:Content>

