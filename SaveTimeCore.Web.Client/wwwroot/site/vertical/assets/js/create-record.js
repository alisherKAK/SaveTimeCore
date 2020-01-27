$.get("/Record/GetAllBarbers", null, function (res) {
    var data = JSON.parse(res);
    for (var i = 0; i < data.length; i++) {
        var option = "<option value='" + data[i].id + "'>";
        option += data[i].name;
        option += "</option>";

        $("#barberId").append(option);
    }
});