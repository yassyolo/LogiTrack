
$(document).ready(function () {
    $('#infoBtn').click(function () {
        showSection('#infoSection');
    });
    $('#vehicleBtn').click(function () {
        showSection('#vehicleSection');
    });
    $('#statusBtn').click(function () {
        showSection('#statusSection');
    });
    $('#addressesBtn').click(function () {
        showSection('#addressesSection');
        initPickupMap();
        initDeliveryMap();
    });
    $('#metricsBtn').click(function () {
        showSection('#metricsSection');
    });
    $('#invoicesBtn').click(function () {
        showSection('#invoicesSection');
    });
    $('#licenseBtn').click(function () {
        showSection('#licenseSection');
    });
    $('#carbonBtn').click(function () {
        showSection('#carbonSection');
    });
    $('#cashRegistersBtn').click(function () {
        showSection('#cashRegistersSection');
    });
    $('#statisticsBtn').click(function () {
        showSection('#statisticsSection');
    });
    $('#deliveriesBtn').click(function () {
        showSection('#deliveriesSection');
    });
    $('#priceBtn').click(function () {
        showSection('#priceSection');
    });
    function showSection(sectionId) {
        $('.section').addClass('d-none');
        $(sectionId).removeClass('d-none');
    }
});
