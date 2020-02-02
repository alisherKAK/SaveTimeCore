$.get("/Barber/GetAll", null, function (res) {
    var data = JSON.parse(res);
    for (var i = 0; i < data.length; i++) {
        var tr = "<tr>";
        tr += "<th>" + data[i].name + "</th>";
        tr += "<td>" + data[i].workDayStart + "</td>";
        tr += "<td>" + data[i].workDayEnd + "</td>";
        tr += '<td><a class="btn btn-primary waves-effect waves-light" href="/Barber/Delete/' + data[i].id + '" role="button">Delete</a></td>';
        tr += "</tr>";

        $("#datatable tbody").append(tr);
    };

    load_js("assets/pages/datatables.init.js");
});