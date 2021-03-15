



function LookProvi() {
    $("#Refres").submit();

}

function validDocument(ch) {


    var checkboxJson = document.getElementById("chJson");

    var checkboxXML = document.getElementById("chXML");

    var checkboxCSV = document.getElementById("chCSV");


    var LabelJson = document.getElementById("lbJson");

    var LabelXML = document.getElementById("lbXML");

    var LabelCSV = document.getElementById("lbCSV");



    if (ch === "XML") {

        if (!checkboxXML.checked) {
            LabelXML.classList.remove("btn-default");
            LabelXML.classList.add("btn-primary");
            // checkboxXML.checked = checked;

        }
        else {
            LabelXML.classList.remove("btn-primary");
            LabelXML.classList.add("btn-default");
            checkboxXML.checked = false;

        }
        checkboxJson.checked = false;
        LabelJson.classList.remove("btn-primary");
        LabelJson.classList.add("btn-default");
        checkboxCSV.checked = false;
        LabelCSV.classList.remove("btn-primary");
        LabelCSV.classList.add("btn-default");


    }

    if (ch === "JSON") {

        if (!checkboxJson.checked) {
            LabelJson.classList.remove("btn-default");
            LabelJson.classList.add("btn-primary");
            //checkboxJson.checked = true;
        }
        else {
            LabelJson.classList.remove("btn-primary");
            LabelJson.classList.add("btn-default");
            checkboxJson.checked = false;
        }
        checkboxXML.checked = false;
        LabelXML.classList.remove("btn-primary");
        LabelXML.classList.add("btn-default");
        checkboxCSV.checked = false;
        LabelCSV.classList.remove("btn-primary");
        LabelCSV.classList.add("btn-default");

    }

    if (ch === "CSV") {

        if (!checkboxCSV.checked) {
            LabelCSV.classList.remove("btn-default");
            LabelCSV.classList.add("btn-primary");
            // checkboxCSV.checked = checked;
        }
        else {
            LabelCSV.classList.remove("btn-primary");
            LabelCSV.classList.add("btn-default");
            checkboxCSV.checked = false;
        }
        checkboxXML.checked = false;
        LabelXML.classList.remove("btn-primary");
        LabelXML.classList.add("btn-default");
        checkboxJson.checked = false;
        LabelJson.classList.remove("btn-primary");
        LabelJson.classList.add("btn-default");


    }

}


