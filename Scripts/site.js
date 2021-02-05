$(document).ready(function () {

    $('#txtsearchfilm').on('change keyup paste', function () {

        if ($(this).val() == "") {
            $('.movietr').show();
        }
        else {
            var _searchterm = $(this).val().toLowerCase();

            $('.movietr').hide();

            $('.movietr').each(function () {

                var _movietitle = $(this).attr('movietitle').toString().toLowerCase();

                if (_movietitle.includes(_searchterm)) {
                    $(this).show();
                }

            });
        }
    });
});