$.get("/Branch/GetAll", null, function (res) {
    var data = JSON.parse(res);
    for (var i = 0; i < data.length; i++) {
        var tr = "<tr>";
        tr += "<th>" + data[i].address + "</th>";
        tr += "<td>" + data[i].phone + "</td>";
        tr += "<td>" + data[i].email + "</td>";
        tr += "<td>" + data[i].startWork + "</td>";
        tr += "<td>" + data[i].endWork + "</td>";
        tr += '<td><a class="btn btn-primary waves-effect waves-light" href="/Branch/Delete/' + data[i].id + '" role="button">Delete</a></td>';
        tr += "</tr>";

        $("#datatable tbody").append(tr);
    };

    load_js("assets/pages/datatables.init.js");
});