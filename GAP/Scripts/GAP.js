var slideIndex = 1;

$(function () {
    setTimeout(autoSlide, 4000);
});

function autoSlide() {
    try {
        slideIndex++;
        mostrarSlide(slideIndex);
    }
    finally {
        setTimeout(autoSlide, 4000);
    }
}

function mostrarSlide(n) {
    var i;
    var slides = document.getElementsByClassName("slideFotos");

    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }

    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }

    slides[slideIndex - 1].style.display = "inline-block";
}