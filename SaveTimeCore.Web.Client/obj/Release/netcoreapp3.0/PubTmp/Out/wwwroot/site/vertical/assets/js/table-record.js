$.get("/Client/GetAllRecords", null, function (res) {
    var data = JSON.parse(res);
    var dataFiltered = [];
    for (var i = 0; i < data.length; i++) {
        if (data[i].clientId == docCookies.getItem("clientId")) {
            dataFiltered.push(data[i]);
        }
    }

    for (var i = 0; i < dataFiltered.length; i++) {
        var tr = "<tr>";
        tr += "<th>" + dataFiltered[i].bookingTime + "</th>";
        tr += "<td>" + dataFiltered[i].spendTime + "</td>";
        tr += "<td>" + dataFiltered[i].status + "</td>";
        tr += '<td>';
        tr += '<a class="btn btn-primary waves-effect waves-light" href="/Record/Delete/' + dataFiltered[i].id + '" role="button">Delete</a></td>';
        tr += "</tr>";

        $("#datatable tbody").append(tr);
    };

    load_js("assets/pages/datatables.init.js");
});