$(document).ready(function () {

    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Report/getAttendenceReport/",
            "data": {
                "fromDate": fdate,
                "toDate": tdate
            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
                { "data": "UserName" },
                { "data": "StartDate" },
                { "data": "EndDate" },
               { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer" onclick="house_route(' + full["DA_ID"] + ')" ><i class="material-icons location-icon">location_on</i><span class="tooltiptext1">Route</span> </a>'; }, "width": "10%" },
               { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer" onclick="user_route(' + full["DA_ID"] + ')" ><i class="material-icons location-icon">location_on</i><span class="tooltiptext1">Route</span> </a>'; }, "width": "10%" },

                //{ "data": "Lat" },
                //{ "data": "Long" },
                //{ "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["UserID"] + ')" >Edit</a>'; }, "width": "10%" },
        ]
    });

});

function Datatable() {

    $("#datatable").dataTable().fnDestroy();
    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();
    

    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Report/getAttendenceReport/",
            "data": {
                "fromDate": fdate,
                "toDate": tdate
            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
                { "data": "UserName" },
                { "data": "StartDate" },
                { "data": "EndDate" },
                 { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer" onclick="house_route(' + full["DA_ID"] + ')" ><i class="material-icons location-icon" style="color:red">location_on</i><span class="tooltiptext1">Route</span> </a>'; }, "width": "10%" },
              { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer" onclick="user_route(' + full["DA_ID"] + ')" ><i class="material-icons location-icon" style="color:rgb(244,67,54)!important">location_on</i><span class="tooltiptext1">Route</span> </a>'; }, "width": "10%" },

                //{ "data": "Lat" },
                //{ "data": "Long" },
                //{ "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["UserID"] + ')" >Edit</a>'; }, "width": "10%" },
        ]
    });

}

function user_route(id) {
    window.location.href = "/Attendence/UserRoute?daId=" + id;
};

function house_route(id) {
    window.location.href = "/Attendence/HouseRoute?daId=" + id;
};
function Search() {
    Datatable();
}
