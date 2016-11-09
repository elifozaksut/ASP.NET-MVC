function GetCategories() {
    var url = "/Admin/Category/BindCategories";
    $.ajax({
        url: url,
        type: 'GET',
        cache: false,
        success: function (data) {
            var item = "";

            for (i = 0; i < data.length; i++) {
                item += "<tr>";
                item += "<td>" + data[i].ID + "</td>";
                item += "<td>";
                item += data[i].Name;
                item += "<div class='pull-right'>";
                item += "<a href='/Admin/Category/Update/" + data[i].ID + "'>Düzenle </a>";
                item += "<a href='/Admin/Category/Delete/" + data[i].ID + "'>Sil</a>";
                item += "</div>";
                item += "</td>";
                item += "</tr>";
            };

            $('#catTable').html(item);
            $('#loading').html('yüklendi!');
        },
        beforeSend: function () {
            $('#loading').html('yükleniyor...');
        }
    });
}

