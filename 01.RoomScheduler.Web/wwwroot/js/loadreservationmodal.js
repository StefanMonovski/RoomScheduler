function loadReserveTimeSlotModal() {
    let container = arguments[0];
    $('#room').text(container.getAttribute('data-room'));
    $('#date').text(container.getAttribute('data-date'));
    $('#from').text(container.getAttribute('data-from'));
    $('#to').text(container.getAttribute('data-to'));

    let formIndex = arguments[1];
    let formId = `reserveTimeSlotForm[${formIndex}]`;
    $('#reserveButton').attr("form", formId);

    $('#currentAvailableTimeModal').modal('show');
}