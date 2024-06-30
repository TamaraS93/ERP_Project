function updateQuantity(productId, action) {
    $.ajax({
        url: '/Cart/UpdateCartItem',
        type: 'POST',
        data: {
            productId: productId,
            action: action
        },
        success: function (result) {
            if (result.success) {
                updateCartUI(result.cartItems, result.cartTotal);
            } else {
                console.error('Greška prilikom ažuriranja količine: akcija nije uspešna');
            }
        },
        error: function (xhr, status, error) {
            console.error('Greška prilikom ažuriranja količine:', error);
        }
    });
}



function updateCartUI(cartItems, cartTotal) {
    var tableBody = $('#cart-table tbody');
    if (tableBody.length === 0) {
        console.error('Element sa id="cart-table" ili <tbody> nije pronađen');
        return;
    }

    tableBody.empty();

    $.each(cartItems, function (index, item) {
        if (!item.hasOwnProperty('productId')) {
            console.error('ProductId nije definisan za item:', item);
            return;
        }

        var row = $('<tr data-product-id="' + item.productId + '"></tr>');
        row.append('<td>' + item.productName + '</td>');
        row.append('<td class="quantity">' +
            '<button class="btn btn-sm btn-secondary update-quantity" data-product-id="' + item.productId + '" data-action="increase">+</button> ' +
            item.quantity +
            ' <button class="btn btn-sm btn-secondary update-quantity" data-product-id="' + item.productId + '" data-action="decrease">-</button>' +
            '</td>');
        row.append('<td class="price">' + item.price.toFixed(2) + '</td>');
        row.append('<td class="item-total">' + (item.quantity * item.price).toFixed(2) + '</td>');

        tableBody.append(row);
    });

    var cartTotalElement = $('#cart-total h4');
    if (cartTotalElement.length === 0) {
        console.error('Element sa id="cart-total" nije pronađen');
        return;
    }

    var currencySymbol = 'RSD';
    var newText = cartTotal.toFixed(2) + ' ' + currencySymbol;
    cartTotalElement.text(newText);

    console.log('Cart total updated:', cartTotal);

    tableBody.off('click', '.update-quantity'); 
    tableBody.on('click', '.update-quantity', function () {
        var productId = $(this).data('product-id');
        var action = $(this).data('action');
        updateQuantity(productId, action);
    });
}

function clearCart() {
    $.ajax({
        url: '/Cart/ClearCart',
        type: 'POST',
        success: function () {
            location.reload();
        },
        error: function (xhr, status, error) {
            console.error('Greška prilikom brisanja korpe:', error);
        }
    });
}
function removeFromCart(productId) {
    $.ajax({
        url: '/Cart/RemoveFromCart',
        type: 'POST',
        data: {
            productId: productId
        },
        success: function (result) {
            if (result.success) {
                updateCartUI(result.cartItems, result.cartTotal);
                location.reload(); 
            } else {
                console.error('Greška prilikom uklanjanja proizvoda iz korpe: ' + result.message);
            }
        },
        error: function (xhr, status, error) {
            console.error('Greška prilikom uklanjanja proizvoda iz korpe:', error);
        }
    });
}