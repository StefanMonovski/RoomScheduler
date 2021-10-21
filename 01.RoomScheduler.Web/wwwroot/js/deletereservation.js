function deleteReserveTimeSlotModal() {
    let container = arguments[0];
    $('#room').text(container.getAttribute('data-room'));
    $('#date').text(container.getAttribute('data-date'));
    $('#from').text(container.getAttribute('data-from'));
    $('#to').text(container.getAttribute('data-to'));

    let formIndex = arguments[1];
    let formId = `deleteTimeSlotForm[${formIndex}]`;
    $('#deleteButton').attr("form", formId);

    $('#deleteTimeSlotModal').modal('show');
}

function showDeleteButton() {
    index = arguments[0];
    document.getElementById(`deleteButton[${index}]`).style.display = 'inline';
}

function hideDeleteButton() {
    index = arguments[0];
    document.getElementById(`deleteButton[${index}]`).style.display = 'none';
}