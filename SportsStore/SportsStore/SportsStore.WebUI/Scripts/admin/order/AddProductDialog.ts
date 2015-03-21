var addProductDialog;

function setupProductListDialog(div: any) {
    addProductDialog = div.dialog({
        autoOpen: false,
        height: 500,
        width: 550,
        modal: false,
        buttons: {
            //"Thêm": updateOrderDetail,
            "Thoát": function () {
                dialog.dialog("close");
            }
        },
        close: function () {
            //form[0].reset();
            //allFields.removeClass("ui-state-error");
        }
    });
}

function showAddProductDialogDialog(event: MouseEvent) {
    event.preventDefault();
    //var orderDetail = getOrderDetailFromParentForm(orderDetailId);        
    addProductDialog.dialog({
        title: "Thêm Sản Phẩm"
    }).dialog("open");
}
