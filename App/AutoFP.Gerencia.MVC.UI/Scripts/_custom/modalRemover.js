$(function () {
    $(".btnRemove").click(function () {
        $("#deleteModalLabel").text($("#title").val() + " " + this.name.toUpperCase());
        $("#messageModal").text($("#message").val());

        $("#deleteModal .modal-body input[type=hidden]").val(this.id);
        $("#deleteModal .modal-body label").text(this.name);

        $("#deleteModal").modal("show");
    });

    $("#deleteModal .modal-footer button").click(function (e) {

        var url = $("#urlRemove").val();
        var id = $(".modal-body input[type=hidden]").val();
        var rowNumber = "#row-" + id;

        $.ajax({
            url: url,
            type: "post",
            datatype: "json",
            data: { id: id },
            beforeSend: function () {
                var loading = "<span class='remove'><em>Removendo</em>&nbsp;<i class='glyphicon glyphicon-refresh icon-refresh-animate'></i></span>";
                $("#deleteModal .modal-header h4").after(loading);
            },
            success: function () {
                $(".modal-header span").remove(".remove");
                $("#deleteModal").modal("hide");

                $(rowNumber).animate({ opacity: 0.0 }, 400, function () {
                    $(rowNumber).remove();
                });
            },
            complete: function (data) {
                var $div = $("#messageNotification");
                $div.removeClass("hidden");
                $("#messageNotificationContainer").html(data.responseText.replace(/\"/g, ''));
                setTimeout(function () {
                    $div.addClass("hidden");
                }, 4000);
            }
        });
    });
});