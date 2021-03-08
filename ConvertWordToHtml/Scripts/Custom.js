

class Converter {

    static Syncfusion() {
        $("#HtmlContents").hide();
        var form = $("#SyncfusionForm");

        $('#CreateDocument').on("click", function () {
            var fileUpload = $("#DocumentFile").get(0);
            var files = fileUpload.files;

            var fileData = new FormData();
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }
            //fileData.append('username', `Manas`);
            $.ajax({
                type: "POST",
                url: form.attr('action'),
                contentType: false,
                processData: false,
                data: fileData,
                dataType: "json",
                success: function (data) {
                    $('#HtmlContents').html(data.data);
                    $('#HtmlContents').show();

                },
                error: function (data) {
                    $('#HtmlContents').html(data.responseText);
                    $('#HtmlContents').show();
                }
            });

            return false;
        })
    }

    static Aspose() {
        $("#HtmlContents").hide();
        var form = $("#AsposeForm");

        $('#ConvertAsposeDocument').on("click", function () {
            var fileUpload = $("#AsposeFile").get(0);
            var files = fileUpload.files;

            var fileData = new FormData();
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }

            $.ajax({
                type: "POST",
                url: form.attr('action'),
                contentType: false,
                processData: false,
                data: fileData,
                dataType: "json",
                success: function (data) {
                    $('#AsposeHtmlContents').html(data.data);
                    $('#AsposeHtmlContents').show();

                },
                error: function (data) {
                    $('#AsposeHtmlContents').html(data.responseText);
                    $('#AsposeHtmlContents').show();
                }
            });

            return false;
        });
    }

    static Mommoth() {
        $("#HtmlContents").hide();
        var form = $("#MammothForm");

        $('#ConvertMammothDocument').on("click", function () {
            var fileUpload = $("#MommothFile").get(0);
            var files = fileUpload.files;

            var fileData = new FormData();
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }

            $.ajax({
                type: "POST",
                url: form.attr('action'),
                contentType: false,
                processData: false,
                data: fileData,
                dataType: "json",
                success: function (data) {
                    $('#HtmlMommothContents').html(data.data);
                    $('#HtmlMommothContents').show();

                },
                error: function (data) {
                    $('#HtmlMommothContents').html(data.responseText);
                    $('#HtmlMommothContents').show();
                }
            });

            return false;
        });
    }
}