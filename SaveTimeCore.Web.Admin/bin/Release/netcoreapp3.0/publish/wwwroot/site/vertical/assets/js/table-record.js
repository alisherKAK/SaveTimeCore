$.get("/Record/GetAll", null, function (res) {
    var data = JSON.parse(res);
    for (var i = 0; i < data.length; i++) {
        var tr = "<tr>";
        tr += "<th>" + data[i].barberId + "</th>";
        tr += "<td>" + data[i].clientId + "</td>";
        tr += "<td>" + data[i].bookingTime + "</td>";
        tr += "<td>" + data[i].spendTime + "</td>";
        tr += '<td>';
        tr += '<a class="btn btn-primary waves-effect waves-light" href="/Record/Delete/' + data[i].id + '" role="button">Delete</a></td>';
        tr += "</tr>";

        $("#datatable tbody").append(tr);
    };

    load_js("assets/pages/datatables.init.js");
});