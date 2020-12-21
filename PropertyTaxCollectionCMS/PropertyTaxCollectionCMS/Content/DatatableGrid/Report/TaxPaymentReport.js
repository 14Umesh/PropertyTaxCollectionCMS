$(document).ready(function () {

    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        "order": [[0, "desc"]],
        "ajax": {
            "url": "/Report/getTaxPaymentReport",
            "data": {
                "fromDate": fdate,
                "toDate": tdate,
                "q": 2
            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
                { "data": "TC_ID" },
                //{ "data": "TCAT_ID" },
                { "data": "RECEIPT_NO" },
                { "data": "RECEIVER_NAME" },
                { "data": "TOTAL_AMOUNT" },
                { "data": "RECEIVED_AMOUNT" },
                { "data": "REMAINING_AMOUNT" },
                { "data": "PAYMENT_DATE" },
                //{ "data": "RECEIVER_SIGNATURE" },
        ]
    });
   

});


function Datatable() {

    $("#datatable").dataTable().fnDestroy();
    var fdate1 = $('#txt_fdate').val();
    var tdate1 = $('#txt_tdate').val();
    //var UserID1 = $('#EmployeeID').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        "order": [[0, "desc"]],
        "ajax": {
            "url": "/Report/getTaxPaymentReport",
            "data": {
                "fromDate": fdate1,
                "toDate": tdate1,
                "q": 2
            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
                { "data": "TC_ID" },
                //{ "data": "TCAT_ID" },
                { "data": "RECEIPT_NO" },
                { "data": "RECEIVER_NAME" },
                { "data": "TOTAL_AMOUNT" },
                { "data": "RECEIVED_AMOUNT" },
                { "data": "REMAINING_AMOUNT" },
                { "data": "PAYMENT_DATE" },
                //{ "data": "RECEIVER_SIGNATURE" },
        ]
    });
}
function Search() {
    Datatable();
}
