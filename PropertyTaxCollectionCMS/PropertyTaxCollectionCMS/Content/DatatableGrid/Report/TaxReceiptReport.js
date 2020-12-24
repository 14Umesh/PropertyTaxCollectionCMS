$(document).ready(function () {

    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();
    debugger;
    $('#datatable').DataTable({
        "pageLength": 10,
        //"order": [[0, "desc"]],
        "responsive": true,
        //"processing": true,
        "ajax": {
            "url": "/Report/getTaxReceiptReport",
            "data": {
                "fromDate": fdate,
                "toDate": tdate,
                "q": -1
            },
            "type": "GET",
            "datatype": "json",
        },

        "columns": [
              { "data": "ADUM_USER_NAME" },
             { "data": "PAYMENT_DATE", "name": "PAYMENT_DATE" },
             { "data": "HOUSEID" },
             { "data": "House_Owner_NAME" },
                 { "data": "House_Owner_Address" },
             //{ "data": "TCAT_ID" },
             { "data": "RECEIVER_NAME" },
             { "data": "RECEIPT_NO" },
             //{ "data": "TC_ID" },

                     {
                         data: "CAMERA_IMAGE", name: "CAMERA_IMAGE",
                         render: function (data, type, row, full, meta) {
                             //var imgsrc = data; // here data should be in base64 string
                             //return '<img class="img-responsive" src="' + imgsrc + '" alt="RECEIVER_SIGNATURE"height="40px" width="60px">';
                             return "<div style='cursor:pointer;display:inline-flex;'  onclick=PopImages(this)><img alt='No Photo'  src='" + data +
                                  "' style='height:43px;width:43px;cursor:pointer;margin-left:0px;'></img><span><ul class='dt_pop'  style='margin:2px -5px -5px -5px; padding:0px;list-style:none;display:none;'><li  class='li_date datediv' >" + row["PAYMENT_DATE"] + "</li><li class='addr-length' style='margin:0px 0px 0px 10px;'>"
                                  + row["RECEIVER_NAME"] + "</li><li style='display:none' class='li_title' >Photo </li></ul></span></div>";
                         }
                     },
          {
           data: "RECEIVER_SIGNATURE", name: "RECEIVER_SIGNATURE",
              render: function (data, type, row,full, meta) {
               //var imgsrc = data; // here data should be in base64 string
               //return '<img class="img-responsive" src="' + imgsrc + '" alt="RECEIVER_SIGNATURE"height="40px" width="60px">';
               return "<div style='cursor:pointer;display:inline-flex;'  onclick=PopImages(this)><img alt='No Photo'  src='" + data +
                    "' style='height:43px;width:43px;cursor:pointer;margin-left:0px;'></img><span><ul class='dt_pop'  style='margin:2px -5px -5px -5px; padding:0px;list-style:none;display:none;'><li  class='li_date datediv' >" + row["PAYMENT_DATE"] + "</li><li class='addr-length' style='margin:0px 0px 0px 10px;'>"
                    + row["RECEIVER_NAME"] + "</li><li style='display:none' class='li_title' >Photo </li></ul></span></div>";
                         }
                     }, 
        ]
    });
    var UserId = $('#selectnumber').val();
    debugger
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
    var fdate1 = $('#txt_fdate').val();
    var tdate1 = $('#txt_tdate').val();
    var UserId = $('#selectnumber').val();
    //var UserID1 = $('#EmployeeID').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        //"order": [[0, "desc"]],
        "responsive": true,
        //"processing": true,
        "ajax": {
            "url": "/Report/getTaxReceiptReport",
            "data": {
                "fromDate": fdate1,
                "toDate": tdate1,
                "q": UserId
            },
            "type": "GET",
            "datatype": "json",
        },

        "columns": [
             { "data": "ADUM_USER_NAME", },
             { "data": "PAYMENT_DATE", "name": "PAYMENT_DATE" },
             { "data": "HOUSEID" },
             { "data": "House_Owner_NAME" },
                 { "data": "House_Owner_Address" },
             //{ "data": "TCAT_ID" },
             { "data": "RECEIVER_NAME" },
             { "data": "RECEIPT_NO" },
             //{ "data": "TC_ID" },
                {
                    data: "CAMERA_IMAGE", name: "CAMERA_IMAGE",
                    render: function (data, type, row, full, meta) {
                        //var imgsrc = data; // here data should be in base64 string
                        //return '<img class="img-responsive" src="' + imgsrc + '" alt="RECEIVER_SIGNATURE"height="40px" width="60px">';
                        return "<div style='cursor:pointer;display:inline-flex;'  onclick=PopImages(this)><img alt='No Photo'  src='" + data +
                             "' style='height:43px;width:43px;cursor:pointer;margin-left:0px;'></img><span><ul class='dt_pop'  style='margin:2px -5px -5px -5px; padding:0px;list-style:none;display:none;'><li  class='li_date datediv' >" + row["PAYMENT_DATE"] + "</li><li class='addr-length' style='margin:0px 0px 0px 10px;'>"
                             + row["RECEIVER_NAME"] + "</li><li style='display:none' class='li_title' >Photo </li></ul></span></div>";
                    }
                },

                   {
                       data: "RECEIVER_SIGNATURE", name: "RECEIVER_SIGNATURE",
                       render: function (data, type, row, full, meta) {
                           //var imgsrc = data; // here data should be in base64 string
                           //return '<img class="img-responsive" src="' + imgsrc + '" alt="RECEIVER_SIGNATURE"height="40px" width="60px">';
                           return "<div style='cursor:pointer;display:inline-flex;'  onclick=PopImages(this)><img alt='No Photo'  src='" + data +
                                "' style='height:43px;width:43px;cursor:pointer;margin-left:0px;'></img><span><ul class='dt_pop'  style='margin:2px -5px -5px -5px; padding:0px;list-style:none;display:none;'><li  class='li_date datediv' >" + row["PAYMENT_DATE"] + "</li><li class='addr-length' style='margin:0px 0px 0px 10px;'>"
                                + row["RECEIVER_NAME"] + "</li><li style='display:none' class='li_title' >Photo </li></ul></span></div>";
                       }
                   },
        ]
    });
}
function Search() {
   Datatable();
}
//function showInventoriesGrid() {
//    Search();
//}


//function Search() {
//    var txt_fdate, txt_tdate, Client, UserId;
//    var name = [];
//    var arr = [$('#txt_fdate').val(), $('#txt_tdate').val()];
//    debugger
//    for (var i = 0; i <= arr.length - 1; i++) {
//        name = arr[i].split("/");
//        arr[i] = name[1] + "/" + name[0] + "/" + name[2];
//    }

//    txt_fdate = arr[0];
//    txt_tdate = arr[1];
//    UserId = $('#selectnumber').val();
//    Client = " ";
//    NesEvent = " ";
//    var Product = "";
//    var catProduct = "";
//    var value = txt_fdate + "," + txt_tdate + "," + UserId //+ "," + $("#s").val();txt_fdate + "," + txt_tdate + "," + UserId + "," + Client + "," + NesEvent + "," + Product + "," + catProduct + "," + 1;
//    // alert(value );
//    oTable = $('#datatable').DataTable();
//    oTable.search(value).draw();
//    oTable.search("");
//    //document.getElementById('USER_ID_FK').value = -1;
//}
