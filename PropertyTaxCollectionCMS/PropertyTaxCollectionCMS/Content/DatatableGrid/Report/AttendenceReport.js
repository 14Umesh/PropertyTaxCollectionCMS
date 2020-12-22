$(document).ready(function () {
  
    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();
    var UserId = $('#selectnumber').val();
    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Report/getAttendenceReport/",
            "data": {
                "fromDate": fdate,
                "toDate": tdate,
                "q": -1


            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
                { "data": "UserName" },
                { "data": "StartDate" },
                { "data": "EndDate" },
               { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer" onclick="house_route(' + full["DA_ID"] + ')" ><i class="material-icons location-icon" style="color:rgb(244,67,54)!important">location_on</i><span class="tooltiptext1">Route</span> </a>'; }, "width": "10%" },
               { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer" onclick="user_route(' + full["DA_ID"] + ')" ><i class="material-icons location-icon" style="color:rgb(244,67,54)!important">location_on</i><span class="tooltiptext1">Route</span> </a>'; }, "width": "10%" },

                //{ "data": "Lat" },
                //{ "data": "Long" },
                //{ "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["UserID"] + ')" >Edit</a>'; }, "width": "10%" },
        ]
    });

});

var UserId = $('#selectnumber').val();
$.ajax({
    type: "POST",
    url: "/Report/GetEmployeeList",
    data: { userId: UserId },
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
function Datatable() {

    $("#datatable").dataTable().fnDestroy();
    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();
    var UserId = $('#selectnumber').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Report/getAttendenceReport/",
            "data": {
                "fromDate": fdate,
                "toDate": tdate,
                "q": UserId
            },
            "tye": "GET",
            "datatype": "json",
        },

        "columns": [
                { "data": "UserName" },
                { "data": "StartDate" },
                { "data": "EndDate" },
                 { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer" onclick="house_route(' + full["DA_ID"] + ')" ><i class="material-icons location-icon" style="color:rgb(244,67,54)!important">location_on</i><span class="tooltiptext1">Route</span> </a>'; }, "width": "10%" },
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
