var currentTotal: number;
var dialog;

function setUpDialog(div: any) {
    dialog = div.dialog({
        autoOpen: false,
        height: 230,
        width: 400,
        modal: false,
        buttons: {
            "Thêm": updateOrderDetail,
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

function updateOrderDetail() {
    var valid = true;
    var orderDetail = getOrderDetailFromDialogForm();
    setDialogParentForm(orderDetail);
    if (valid) {
        //$("#users tbody").append("<tr>" +
        //  "<td>" + name.val() + "</td>" +
        //  "<td>" + email.val() + "</td>" +
        //  "<td>" + password.val() + "</td>" +
        //"</tr>");
        dialog.dialog("close");
    }
    return valid;
}

function removeOrderDetail(event: MouseEvent, orderDetailId: number) {
    event.preventDefault();
    var name = "hiddenInputOrderDetailId" + "[" + orderDetailId + "]";    
    var input = <HTMLInputElement>document.getElementById(name);
    var row = findParent(input.parentElement);    
    var table = <HTMLTableElement>document.getElementById("example");        
        
    var orderDetail = getOrderDetailFromParentForm(orderDetailId);
    currentTotal = orderDetail.Total;
    orderDetail.Delete = true;
    setHiddenInputOrderDetail(orderDetail);
    calculateTotalOrderBill(0);
    row.style.display = "none";
    //table.deleteRow(row.rowIndex);
}

function findParent<T>(element: HTMLElement): HTMLTableRowElement {
    if (element instanceof HTMLTableRowElement)
        return element;

    return findParent(element.parentElement);
}

function showDetailDialog(event: MouseEvent, orderDetailId: number, title: string) {
    event.preventDefault();
    var orderDetail = getOrderDetailFromParentForm(orderDetailId);
    currentTotal = orderDetail.Total;
    setDialogFormValues(orderDetail);
    dialog.dialog({
        title: orderDetail.ProductNo + " - " + orderDetail.ProductName
    }).dialog("open");
}

function calculateTotalOfDetail() {
    var textBoxQuantity = <HTMLTextAreaElement>document.getElementById("dialog-quantity");
    var textBoxPrice = <HTMLTextAreaElement>document.getElementById("dialog-price");
    var quantity = textBoxQuantity.value;
    var price = textBoxPrice.value;
    quantity = quantity.replace(/,/g, "");
    price = price.replace(/,/g, "");
    var textBoxTotal = <HTMLTextAreaElement>document.getElementById("dialog-total");
    var total = parseInt(price) * parseInt(quantity);
    textBoxTotal.value = total.toLocaleString();
}

function getCurrentTotalOrderBill(): number {
    var labelName = "labelOrderTotalBill";
    var lable = <HTMLLabelElement>document.getElementById(labelName);
    var value = lable.innerHTML;
    value = value.replace(/,/g, "");
    return parseInt(value);
}

function setCurrentTotalOrderBill(total: number) {
    var label = <HTMLTextAreaElement>document.getElementById("labelOrderTotalBill");
    label.innerHTML = total.toLocaleString();

    var hiddenField = <HTMLTextAreaElement>document.getElementById("hiddenFieldOrderTotal");
    hiddenField.value = total.toString();
}

function getOrderDetailFromParentForm(orderDetailId: number): OrderDetail {
    var orderDetail = new OrderDetail();
    orderDetail.OrderDetailId = orderDetailId;

    var labelName = "labelProductNo" + "[" + orderDetailId + "]";
    var lable = <HTMLLabelElement>document.getElementById(labelName);
    var value = lable.innerHTML;
    orderDetail.ProductNo = value;

    labelName = "labelProductName" + "[" + orderDetailId + "]";
    lable = <HTMLLabelElement>document.getElementById(labelName);
    value = lable.innerHTML;
    orderDetail.ProductName = value;

    labelName = "labelQuantity" + "[" + orderDetailId + "]";
    var lable = <HTMLLabelElement>document.getElementById(labelName);
    var value = lable.innerHTML;
    value = value.replace(/,/g, "");
    orderDetail.Quantity = parseInt(value);

    labelName = "labelPrice" + "[" + orderDetailId + "]";
    lable = <HTMLLabelElement>document.getElementById(labelName);
    value = lable.innerHTML;
    value = value.replace(/,/g, "");
    orderDetail.Price = parseInt(value);

    labelName = "labelTotal" + "[" + orderDetailId + "]";
    lable = <HTMLLabelElement>document.getElementById(labelName);
    value = lable.innerHTML;
    value = value.replace(/,/g, "");
    orderDetail.Total = parseInt(value);

    return orderDetail;
}

function setDialogFormValues(orderDetail: OrderDetail): void {
    var hiddenFieldOrderDetailId = <HTMLInputElement>document.getElementById("dialog-OrderDetailId");
    hiddenFieldOrderDetailId.value = orderDetail.OrderDetailId.toString();

    var textBoxQuantity = <HTMLTextAreaElement>document.getElementById("dialog-quantity");
    textBoxQuantity.value = orderDetail.Quantity.toLocaleString();

    var textBoxPrice = <HTMLTextAreaElement>document.getElementById("dialog-price");
    textBoxPrice.value = orderDetail.Price.toLocaleString();

    var textBoxTotal = <HTMLTextAreaElement>document.getElementById("dialog-total");
    textBoxTotal.value = orderDetail.Total.toLocaleString();
}

function getOrderDetailFromDialogForm(): OrderDetail {
    var orderDetail = new OrderDetail();

    var input = <HTMLInputElement>document.getElementById("dialog-OrderDetailId");
    var value = input.value;
    value = value.replace(/,/g, "");
    orderDetail.OrderDetailId = parseInt(value);

    input = <HTMLInputElement>document.getElementById("dialog-quantity");
    value = input.value;
    value = value.replace(/,/g, "");
    orderDetail.Quantity = parseInt(value);

    input = <HTMLInputElement>document.getElementById("dialog-price");
    value = input.value;
    value = value.replace(/,/g, "");
    orderDetail.Price = parseInt(value);

    input = <HTMLInputElement>document.getElementById("dialog-total");
    value = input.value;
    value = value.replace(/,/g, "");
    orderDetail.Total = parseInt(value);
    return orderDetail;
}

function setDialogParentForm(orderDetail: OrderDetail): void {
    var labelName = "labelQuantity" + "[" + orderDetail.OrderDetailId + "]";
    var label = <HTMLLabelElement>document.getElementById(labelName);
    label.innerHTML = orderDetail.Quantity.toLocaleString();

    labelName = "labelPrice" + "[" + orderDetail.OrderDetailId + "]";
    label = <HTMLLabelElement>document.getElementById(labelName);
    label.innerHTML = orderDetail.Price.toLocaleString();

    labelName = "labelTotal" + "[" + orderDetail.OrderDetailId + "]";
    label = <HTMLLabelElement>document.getElementById(labelName);
    label.innerHTML = orderDetail.Total.toLocaleString();

    setHiddenInputOrderDetail(orderDetail);
    calculateTotalOrderBill(orderDetail.Total);
}

function setHiddenInputOrderDetail(orderDetail: OrderDetail): void {
    var name = "hiddenInputQuantity" + "[" + orderDetail.OrderDetailId + "]";
    var hiddenField = <HTMLInputElement>document.getElementById(name);
    hiddenField.value = orderDetail.Quantity.toString();

    name = "hiddenInputPrice" + "[" + orderDetail.OrderDetailId + "]";
    hiddenField = <HTMLInputElement>document.getElementById(name);
    hiddenField.value = orderDetail.Price.toString();

    name = "hiddenInputTotal" + "[" + orderDetail.OrderDetailId + "]";
    hiddenField = <HTMLInputElement>document.getElementById(name);
    hiddenField.value = orderDetail.Total.toString();

    name = "hiddenInputDeleted" + "[" + orderDetail.OrderDetailId + "]";
    hiddenField = <HTMLInputElement>document.getElementById(name);
    hiddenField.value = orderDetail.Delete.toString();
}

function calculateTotalOrderBill(total: number) {
    var currentTotalOrderBill = getCurrentTotalOrderBill();
    currentTotalOrderBill += (total - currentTotal);
    setCurrentTotalOrderBill(currentTotalOrderBill);
}