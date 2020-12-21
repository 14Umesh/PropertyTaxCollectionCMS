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
