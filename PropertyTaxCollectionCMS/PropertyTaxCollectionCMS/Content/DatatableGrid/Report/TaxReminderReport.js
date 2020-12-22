$(document).ready(function () {

    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        "order": [[0, "desc"]],
        "responsive":true,
        "ajax": {
            "url": "/Report/getTaxReminderReport",
            "data": {
                "fromDate": fdate,
                "toDate": tdate,
                "q": -1
            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
             { "data": "ADUM_USER_NAME" },
                { "data": "TC_ID" },
                //{ "data": "TCAT_ID" },
                { "data": "RECEIPT_NO" },
                  { "data": "HOUSEID" },
                    { "data": "REASON" },
                { "data": "RECEIVER_NAME" },
                { "data": "TOTAL_AMOUNT" },
                { "data": "RECEIVED_AMOUNT" },
                { "data": "REMAINING_AMOUNT" },
                 { "data": "PAYMENT_DATE" },
                 { "data": "TaxRemImage" },
                //{ "data": "RECEIVER_SIGNATURE" },
        ]

    });

});


function Datatable() {

    $("#datatable").dataTable().fnDestroy();

    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();
    var UserId = $('#selectnumber').val();
    $('#datatable').DataTable({
        "pageLength": 10,
        "order": [[0, "desc"]],
        "ajax": {
            "url": "/Report/getTaxReminderReport",
            "data": {
                "fromDate": fdate,
                "toDate": tdate,
                "q": UserId
            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
             { "data": "ADUM_USER_NAME" },
                { "data": "TC_ID" },
                //{ "data": "TCAT_ID" },
                { "data": "RECEIPT_NO" },
                  { "data": "HOUSEID" },
                    { "data": "REASON" },
                { "data": "RECEIVER_NAME" },
                { "data": "TOTAL_AMOUNT" },
                { "data": "RECEIVED_AMOUNT" },
                { "data": "REMAINING_AMOUNT" },
                { "data": "PAYMENT_DATE" },
                { "data": "TaxRemImage" },
                //{ "data": "RECEIVER_SIGNATURE" },
        ]
    });

}


var UserId = $('#selectnumber').val();
debugger;
$.ajax({
    type: "POST",
    url: "/Report/GetEmployeeList",
    data: { ADUM_USER_CODE: UserId },
    datatype: "json",
    traditional: true,
    success: function (data) {
        district = '<option value="-1">Select Employee</option>';
        for (var i = 0; i < data.length; i++) {
            district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
        }
        //district = district + '</select>';
        $('#selectnumber').html(district);
    }
});
function Search() {
    Datatable();
}