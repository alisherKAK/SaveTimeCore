$.get("/Company/GetAll", null, function (res) {
    var data = JSON.parse(res);
    for (var i = 0; i < data.length; i++) {
        var tr = "<tr>";
        tr += "<th>" + data[i].name + "</th>";
        tr += "<td>" + data[i].city + "</td>";
        tr += "</tr>";

        $("#datatable tbody").append(tr);
    };

    load_js("assets/pages/datatables.init.js");
});