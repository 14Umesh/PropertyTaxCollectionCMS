$(document).ready(function () {

    ActiveEmployee();
    $('#datatableActive').css("display", "inline-table");
    $('#datatableNonActive').css("display", "none");
   // $('#datatableNonActive').hide();
    $('#datatableNonActive_wrapper').css("display", "none");

   
    $('#NotActivebtn').on('click', function (e) {
        debugger;
        $('#datatableNonActive').css("display", "inline-table");
        $('#datatableActive').css("display", "none");
     //  ('#datatableActive').hide();
      $('#datatableActive_wrapper').css("display", "none");
      NotActiveEmployee();
        e.preventDefault();

    });

  

});

function Edit(ID) {
    window.location.href = "/Master/Employee?q=" + ID;
}


function ActiveEmployee() {
    $('#datatableActive').DataTable({
        "pageLength": 10,
        "order": [
               [0, "desc"]
        ],
        destroy: true,
        "ajax": {
            "url": "/Master/getEmployeeDetails/?isactive=true",
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

}
function NotActiveEmployee() {
    debugger;
    $('#datatableNonActive').DataTable({
        "pageLength": 10,
        "order": [
               [0, "desc"]
        ],
        destroy: true,
        "ajax": {
            "url": "/Master/getEmployeeDetails/?isactive=false",
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

}


