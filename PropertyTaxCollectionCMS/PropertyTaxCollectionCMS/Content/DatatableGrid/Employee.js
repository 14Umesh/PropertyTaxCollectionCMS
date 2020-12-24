$(document).ready(function () {

    $('#datatable').DataTable({
        "pageLength": 10,
        "order": [
               [0, "desc"]
        ],
        "ajax": {
            "url": "/Master/getEmployeeDetails/",
            "tye": "GET",
            "datatype": "json",
        },

        "columnDefs":
        [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
                { "data": "ADUM_USER_CODE" },
                { "data": "ADUM_USER_NAME" },
                { "data": "ADUM_EMPLOYEE_ID" },
                { "data": "ADUM_DESIGNATION" },
                { "data": "ADUM_MOBILE" },
                //{ "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["ADUM_USER_CODE"] + ')" >Edit</a>'; }, "width": "10%" },
                { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" class="tooltip1" style="cursor:pointer"   onclick="Edit(' + full["ADUM_USER_CODE"] + ')"  ><i class="material-icons edit-icon">edit</i>'; }, "width": "10%" }
        ]
    });

});

function Edit(ID) {
    window.location.href = "/Master/Employee?q=" + ID;
}

