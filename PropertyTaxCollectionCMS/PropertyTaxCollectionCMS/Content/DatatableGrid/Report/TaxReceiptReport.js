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
             { "data": "TC_ID" },
             { data: "RECEIVER_SIGNATURE", name: "RECEIVER_SIGNATURE",
             render: function (data, type, row, meta) { var imgsrc = data; // here data should be in base64 string
             return '<img class="img-responsive" src="' + imgsrc + '" alt="RECEIVER_SIGNATURE" height="40px" width="60px">';} },
              {
                  data: "RECEIVER_SIGNATURE", name: "RECEIVER_SIGNATURE",
                  render: function (data, type, row, meta) {
                      var imgsrc = data; // here data should be in base64 string
                      return '<img class="img-responsive" src="' + imgsrc + '" alt="RECEIVER_SIGNATURE" height="40px" width="60px">';
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
             { "data": "TC_ID" },
          {
              data: "RECEIVER_SIGNATURE", name: "RECEIVER_SIGNATURE",
              render: function (data, type, row, meta) {
                  var imgsrc = data; // here data should be in base64 string
                  return '<img class="img-responsive" src="' + imgsrc + '" alt="RECEIVER_SIGNATURE" height="40px" width="60px">';
              }
          },

        { data: "RECEIVER_SIGNATURE", name: "RECEIVER_SIGNATURE",
    render: function (data, type, row, meta) { var imgsrc = data; // here data should be in base64 string
        return '<img class="img-responsive" src="' + imgsrc + '" alt="RECEIVER_SIGNATURE" height="40px" width="60px">';} },

        ]
    });
}
function Search() {
    Datatable();
}
