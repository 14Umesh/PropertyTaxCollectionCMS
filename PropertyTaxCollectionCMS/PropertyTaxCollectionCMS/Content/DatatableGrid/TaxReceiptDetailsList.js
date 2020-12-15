$(document).ready(function () {

    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Dashboard/getTaxReceiptDetails?q=1",
            "order": [[0, "desc"]],
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
                //{ "data": "RECEIVER_SIGNATURE" },
        ]

    });

});

