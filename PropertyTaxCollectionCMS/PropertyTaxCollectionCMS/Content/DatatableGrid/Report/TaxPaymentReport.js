$(document).ready(function () {

    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        "order": [[0, "desc"]],
        "responsive": true,
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
              { "data": "RECEIVER_NAME", name: "RECEIVER_NAME" },
              { "data": "TOTAL_AMOUNT" },
              { "data": "RECEIVED_AMOUNT" },
              { "data": "REMAINING_AMOUNT" },
              { "data": "PAYMENT_DATE", name: "PAYMENT_DATE" },
              { "data": "HOUSEID" },
              { "data": "House_Owner_NAME" },
        {
            data: "CAMERA_IMAGE", name: "CAMERA_IMAGE",
            render: function (data, type, row, meta) {
                //var imgsrc = data; // here data should be in base64 string
                //return '<img class="img-responsive"  src="' + imgsrc + '" alt="CAMERA_IMAGE" onclick="image(this)" height="40px" width="100px" >'
                return "<div style='cursor:pointer;display:inline-flex;'  onclick=PopImages(this)><img alt='No Photo'  src='" + data +
                  "' style='height:43px;width:43px;cursor:pointer;margin-left:0px;'></img><span><ul class='dt_pop'  style='margin:2px -5px -5px -5px; padding:0px;list-style:none;display:none;'><li  class='li_date datediv' >" + row["PAYMENT_DATE"] + "</li><li class='addr-length' style='margin:0px 0px 0px 10px;'>"
                     + row["RECEIVER_NAME"] + "</li><li style='display:none' class='li_title' >Photo </li></ul></span></div>";


            }
        },
              {
                  data: "RECEIVER_SIGNATURE", name: "RECEIVER_SIGNATURE",
                  render: function (data, type, row, meta,full) {
                      //var imgsrc = data; // here data should be in base64 string
                      //return '<img class="img-responsive"  src="' + imgsrc + '" alt="RECEIVER_SIGNATURE" onclick="image(this)" height="40px" width="100px" >'
                      debugger
                      return "<div style='cursor:pointer;display:inline-flex;'  onclick=PopImages(this)><img alt='No Photo'  src='" + data +
                   "' style='height:43px;width:43px;cursor:pointer;margin-left:0px;'></img><span><ul class='dt_pop'  style='margin:2px -5px -5px -5px; padding:0px;list-style:none;display:none;'><li  class='li_date datediv' >" + row["PAYMENT_DATE"] + "</li><li class='addr-length' style='margin:0px 0px 0px 10px;'>"
                      + row["RECEIVER_NAME"] + "</li><li style='display:none' class='li_title' >Photo </li></ul></span></div>";


                  }
              },
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
                { "data": "HOUSEID" },
                { "data": "House_Owner_NAME" },
            {
                data: "CAMERA_IMAGE", name: "CAMERA_IMAGE",
                render: function (data, type, row, meta) {
                    var imgsrc = data; // here data should be in base64 string
                    return '<img class="img-responsive"  src="' + imgsrc + '" alt="CAMERA_IMAGE" onclick="image(this)" height="40px" width="100px" >'


                }
            },
               {
                   data: "RECEIVER_SIGNATURE", name: "RECEIVER_SIGNATURE",
                   render: function (data, type, row, meta) {
                       var imgsrc = data; // here data should be in base64 string
                       return '<img class="img-responsive"  src="' + imgsrc + '" alt="RECEIVER_SIGNATURE" onclick="image(this)" height="40px" width="100px" >'


                   }
               },
        ]
    });
}

function image(img) {
    debugger;
    var src = img.src;
    var image = new Image();
    image.src = src;

    var w = window.open("");
    w.document.write(image.outerHTML);

}

function Search() {
    Datatable();
}
