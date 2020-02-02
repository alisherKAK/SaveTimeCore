$.get("/Account/GetAll", null, function (res) {
    var data = JSON.parse(res);
    for (var i = 0; i < data.length; i++) {
        var option = "<option value='" + data[i].id + "'>";
        option += data[i].login + ' - ' + data[i].email;
        option += "</option>";

        $("#accountId").append(option);
    }
});