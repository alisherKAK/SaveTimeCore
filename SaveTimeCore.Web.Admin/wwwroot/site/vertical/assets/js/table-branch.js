$.get("/Branch/GetAll", null, function (res) {
    var data = JSON.parse(res);
    for (var i = 0; i < data.length; i++) {
        var tr = "<tr>";
        tr += "<th>" + data[i].address + "</th>";
        tr += "<td>" + data[i].phone + "</td>";
        tr += "<td>" + data[i].email + "</td>";
        tr += "<td>" + data[i].startWork + "</td>";
        tr += "<td>" + data[i].endWork + "</td>";
        tr += "</tr>";

        $("#datatable tbody").append(tr);
    };

    load_js("assets/pages/datatables.init.js");
});