var yahooAccountType: string = "YahooAccount";
var skypeAccountType: string = "SkypeAccount";
var yahooAccountCount: number = 1;
var skypeAccountCount: number = 1;
var yahooRowFirstIndex: number = 1;

// Function workaround textarea includes some html tags.
function ClearTextArea() {
    var textAreas = document.getElementsByClassName("textarea-medium");
    for (var key in textAreas) {
        var textArea = <HTMLTextAreaElement>textAreas[key];
        if (textArea.value != undefined) {
            textArea.value = textArea.value.trim();
        }
    }
}

function SetYahooAccountDefaultCount(yahooCount: number) {
    yahooAccountCount = yahooCount;
    DisableYahooRemoveButton();
}

function SetSkypeAccountDefaultCount(yahooCount: number) {
    skypeAccountCount = yahooCount;
    DisableSkypeRemoveButton();
}


function AddOnlineSupport(event: MouseEvent, onlineSupportType: string) {
    event.preventDefault();
    CreateNewRow(onlineSupportType);
}

function RemoveOnlineSupport(event: MouseEvent, onlineSupportType: string) {
    event.preventDefault();
    //CreateNewRow(onlineSupportType, rowId);
    RemoveLastRow(onlineSupportType);
}

function RemoveLastRow(onlineSupportType: string) {
    if (onlineSupportType == yahooAccountType) {
        RemoveYahooRow();
        DisableYahooRemoveButton();
    }

    if (onlineSupportType == skypeAccountType) {
        RemoveSkypeRow();
        DisableSkypeRemoveButton();
    }
}

function RemoveYahooRow() {
    if (yahooAccountCount < 2) {
        return;
    }

    var table = <HTMLTableElement>document.getElementById("tableForm");
    var deletedRowIndex = yahooRowFirstIndex + yahooAccountCount - 1;
    table.deleteRow(deletedRowIndex);
    yahooAccountCount--;    
}

function RemoveSkypeRow() {
    if (skypeAccountCount < 2) {
        return;
    }

    var table = <HTMLTableElement>document.getElementById("tableForm");
    var deletedRowIndex = table.rows.length - 4;
    table.deleteRow(deletedRowIndex);
    skypeAccountCount--;
}

function DisableSkypeRemoveButton() {
    var button = document.getElementById("btnRemoveSkype");            
    button.style.visibility = (skypeAccountCount < 2) ? "hidden" : "visible";
}

function DisableYahooRemoveButton() {
    var button = document.getElementById("btnRemoveYahoo");
    button.style.visibility = (yahooAccountCount < 2) ? "hidden" : "visible";
}


function CreateNewRow(onlineSupportType: string) {
    if (onlineSupportType == yahooAccountType) {
        CreateYahooRow();
        DisableYahooRemoveButton();
    }

    if (onlineSupportType == skypeAccountType) {
        CreateSkypeRow();
        DisableSkypeRemoveButton();
    }
}

function CreateYahooRow() {
    var newId = yahooAccountCount;
    yahooAccountCount++;

    //Create new row
    var table = <HTMLTableElement>document.getElementById("tableForm");
    var newRowIndex = yahooRowFirstIndex + yahooAccountCount - 1; // add button & minus button
    var row = <HTMLTableRowElement>table.insertRow(newRowIndex);
    var cell1 = row.insertCell(0);
    cell1.className = "col1 col-content-top";
    var cell2 = row.insertCell(1);    

    //Create label
    var div = <HTMLDivElement>document.createElement("div");
    var label = <HTMLLabelElement>document.createElement("label");
    div.className = "editor-label";
    label.innerHTML = "Nick yahoo " + yahooAccountCount;
    div.appendChild(label);
    cell1.appendChild(div);

    //Set attributes, class, value,...              
    var textArea = <HTMLTextAreaElement>document.createElement("textarea");
    textArea.name = "YahooAccounts[" + newId + "].SystemSetting.Value";
    textArea.className = "textarea-medium";
    cell2.appendChild(textArea);
    textArea.focus();
}

function CreateSkypeRow() {
    var newId = skypeAccountCount; // Off 1 because array base on 0
    skypeAccountCount++;

    //Create new row
    var table = <HTMLTableElement>document.getElementById("tableForm");
    var newRowIndex = table.rows.length - 3; // Save button + <hr> + add button= 3 row
    var row = <HTMLTableRowElement>table.insertRow(newRowIndex);
    var cell1 = row.insertCell(0);
    cell1.className = "col1 col-content-top";
    var cell2 = row.insertCell(1);    

    //Create label
    var div = <HTMLDivElement>document.createElement("div");
    var label = <HTMLLabelElement>document.createElement("label");
    div.className = "editor-label";
    label.innerHTML = "Nick skype " + skypeAccountCount;
    div.appendChild(label);
    cell1.appendChild(div);

    //Set attributes, class, value,...              
    var textArea = <HTMLTextAreaElement>document.createElement("textarea");
    textArea.name = "SkypeAccounts[" + newId + "].SystemSetting.Value";
    textArea.className = "textarea-medium";
    cell2.appendChild(textArea);
    textArea.focus();
}