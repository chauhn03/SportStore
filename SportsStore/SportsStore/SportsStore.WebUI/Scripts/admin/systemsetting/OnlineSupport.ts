var yahooAccountType: string = "Yahoo";
var skypeAccountType: string = "Skype";
var yahooAccountCount: number = 1;
var skypeAccountCount: number = 1;

// Function workaround textarea includes some html tags.
function ClearTextArea() {
    var textAreas = document.getElementsByClassName("textarea-medium");
    for (var key in textAreas) {
        var textArea = <HTMLTextAreaElement>textAreas[key];
        textArea.value = "";
    }
}

function AddOnlineSupport(event: MouseEvent, onlineSupportType: string, rowId: number) {
    alert('ab');
    event.preventDefault();    
    CreateNewRow(onlineSupportType, rowId);
}

function CreateNewRow(onlineSupportType: string, rowId: number) {
    if (onlineSupportType == yahooAccountType) {
        yahooAccountCount++;
        var table = <HTMLTableElement>document.getElementById("tableForm");
        var row = <HTMLTableRowElement>table.insertRow(yahooAccountCount);
        //row.id = "SystemSettingViewModels[" + rowId + "].SystemSetting.Value";
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        //cell2.id = "SystemSettingViewModels[" + 3 + "].SystemSetting.Value";
        //cell2.tagName = "SystemSettingViewModels[" + 3 + "].SystemSetting.Value";
        cell1.innerHTML = "Yahoo account " + yahooAccountCount;
        //cell2.innerHTML = "50";
        var textArea = <HTMLTextAreaElement>document.createElement("textarea");
        var newId = yahooAccountCount + 1;
        textArea.name = "SystemSettingViewModels[" + newId + "].SystemSetting.Value";
        textArea.className = "textarea-medium";
        cell2.appendChild(textArea);
    }

    if (onlineSupportType == skypeAccountType)
        skypeAccountCount++;
}