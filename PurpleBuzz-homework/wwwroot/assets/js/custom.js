$(function () {

    var skipRow = 1;
    $(document).on('click', '#loadmore', function () {
        $.ajax({
            method: "GET",
            url: "/home/loadmore",
            data: {
                skipRow: skipRow
            },

            success: function (result) {
                $('#recentworks').append(result);
                skipRow++;
            }
        })
    })
})