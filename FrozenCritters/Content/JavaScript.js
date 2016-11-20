var altPhotoTwoSrc = document.getElementById("altPhoto2").src;
var altPhotoThreeSrc = document.getElementById("altPhoto3").src;
var altPhotoFourSrc = document.getElementById("altPhoto4").src;
var altPhotoFiveSrc = document.getElementById("altPhoto5").src;
var defaultPhotoSrc = document.getElementById("mainPhoto").src;



function defaultPhoto() {
    document.getElementById("mainPhoto").src = "/Content/img/ad8677e4-12b0-4f38-b637-b51f819eebf4RiverOtter1.jpg";
    alert("defaultPhoto");
}

function altPhoto2() {
    document.getElementById("mainPhoto").src = altPhotoTwoSrc;
    alert("altPhoto2");
}

function altPhoto3() {
    document.getElementById("mainPhoto").src = altPhotoThreeSrc;
    alert("altPhoto3");
}

function altPhoto4() {
    document.getElementById("mainPhoto").src = altPhotoFourSrc;
    alert("altPhoto4");
}

function altPhoto5() {
    document.getElementById("mainPhoto").src = altPhotoFiveSrc;
    alert("altPhoto5");
}