$(document).ready(function () {

    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        "order": [[0, "desc"]],
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
                    { "data": "House_Owner_NAME" },
                    { "data": "REASON" },
                { "data": "RECEIVER_NAME" },
                { "data": "TOTAL_AMOUNT" },
                { "data": "RECEIVED_AMOUNT" },
                { "data": "REMAINING_AMOUNT" },
                 { "data": "PAYMENT_DATE" },
                    {
                        data: "TaxRemImage", name: "TaxRemImage",
                        render: function (data, type, row, full, meta) {
                            //var imgsrc = data; // here data should be in base64 string
                            //return '<img class="img-responsive" src="' + imgsrc + '" alt="RECEIVER_SIGNATURE"height="40px" width="60px">';
                            return "<div style='cursor:pointer;display:inline-flex;'  onclick=PopImages(this)><img alt='No Photo'  src='" + data +
                                 "' style='height:43px;width:43px;cursor:pointer;margin-left:0px;'></img><span><ul class='dt_pop'  style='margin:2px -5px -5px -5px; padding:0px;list-style:none;display:none;'><li  class='li_date datediv' >" + row["PAYMENT_DATE"] + "</li><li class='addr-length' style='margin:0px 0px 0px 10px;'>"
                                 + row["RECEIVER_NAME"] + "</li><li style='display:none' class='li_title' >Photo </li></ul></span></div>";
                        }
                    },
                //{ "data": "RECEIVER_SIGNATURE" },
        ]

    });

});


function PopImages(cel) {

    $('#myModal_Image').modal('toggle');
    debugger
    var addr = $(cel).find('.addr-length').text();
    var date = $(cel).find('.li_date').text();
    var imgsrc = $(cel).find('img').attr('src');
    var head = $(cel).find('.li_title').text();
    jQuery("#latlongData").text(addr);
    jQuery("#dateData").text(date);
    jQuery("#imggg").attr('src', imgsrc);
    //jQuery("#latlongData").text(cellValue);
    jQuery("#header_data").html(head);
}

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
                    { "data": "House_Owner_NAME" },
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