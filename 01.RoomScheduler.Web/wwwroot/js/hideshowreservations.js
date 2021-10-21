function hideOrShowReservations() {
    let container = arguments[0];
    let reservations = document.getElementById(container.getAttribute('data-for'));

    if (reservations.style.display === 'none') {
        reservations.style.display = 'grid';
        $('#' + container.id).children('img[name="arrow"]').attr("src", "/svg/arrow-up.svg");
    }
    else {
        reservations.style.display = 'none';
        $('#' + container.id).children('img[name="arrow"]').attr("src", "/svg/arrow-down.svg");
    }
}