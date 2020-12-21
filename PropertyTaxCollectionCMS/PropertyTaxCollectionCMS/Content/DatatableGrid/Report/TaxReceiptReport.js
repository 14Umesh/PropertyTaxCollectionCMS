$(document).ready(function () {

    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();
    debugger;
    $('#datatable').DataTable({
        "pageLength": 10,
        "order": [[0, "desc"]],
        "ajax": {
            "url": "/Report/getTaxReceiptReport",
            "data": {
                "fromDate": fdate,
                "toDate": tdate,
                "q": 1
            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
              { "data": "ADUM_USER_NAME" },
             { "data": "PAYMENT_DATE" },
             { "data": "HOUSEID" },
             { "data": "House_Owner_NAME" },
             //{ "data": "TCAT_ID" },
             { "data": "RECEIVER_NAME" },
             { "data": "RECEIPT_NO" },
             //{ "data": "TC_ID" },
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

});


function Datatable() {

    $("#datatable").dataTable().fnDestroy();
    var fdate1 = $('#txt_fdate').val();
    var tdate1 = $('#txt_tdate').val();
    var UserID1 = $('#EmployeeID').val();

    debugger;

    $('#datatable').DataTable({
        "pageLength": 10,
        "order": [[0, "desc"]],
        "ajax": {
            "url": "/Report/getTaxReceiptReport",
            "data": {
                "fromDate": fdate1,
                "toDate": tdate1,
                "q": 1
            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
             { "data": "ADUM_USER_NAME" },
             { "data": "PAYMENT_DATE" },
             { "data": "HOUSEID" },
             { "data": "House_Owner_NAME" },
             //{ "data": "TCAT_ID" },
             { "data": "RECEIVER_NAME" },
             { "data": "RECEIPT_NO" },
             //{ "data": "TC_ID" },
          {
              data: "CAMERA_IMAGE", name: "CAMERA_IMAGE",
              render: function (data, type, row, meta) {
                  var imgsrc = data; // here data should be in base64 string
                  return '<img class="img-responsive"  src="' + imgsrc + '" alt="CAMERA_IMAGE" onclick="image(this)" height="40px" width="100px" >'


              }
          },

        { data: "RECEIVER_SIGNATURE", name: "RECEIVER_SIGNATURE",
    render: function (data, type, row, meta) { var imgsrc = data; // here data should be in base64 string
        return '<img class="img-responsive"  src="' + imgsrc + '" alt="RECEIVER_SIGNATURE" onclick="image(this)" height="40px" width="100px" >'


    }
        },


         //{ "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="View(' + full["RECEIVER_SIGNATURE"] + ')" >View</a>'; }, "width": "10%" },
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
