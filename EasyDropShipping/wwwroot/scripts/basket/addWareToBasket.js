'use strict';

$(document).ready(function () {

    $('.addToBasket').click(function (event) {

        var wareId = $(this).data('id');

        $.ajax({
            url: '/Shop/SetWareToBasket',
            type: 'POST',
            data: {
                Id: wareId
            },
            success: function (wareQuantity) {
                $('.hub-i-count').text(wareQuantity).removeClass('hidden');
            },
            error: function (wareQuantity) {
                alert('Ajax Error! wareQuantity =', wareQuantity);
            }
        });
    })
});