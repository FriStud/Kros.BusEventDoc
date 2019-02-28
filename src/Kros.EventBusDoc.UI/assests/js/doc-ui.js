var __entityMap = {
    "&": "&amp;",
    "<": "&lt;",
    ">": "&gt;",
    '"': '&quot;',
    "'": '&#39;',
    "/": '&#x2F;'
};

String.prototype.escapeHTML = function() {
    return String(this).replace(/[&<>"'\/]/g, function (s) {
        return __entityMap[s];
    });
}

//fire the generation of pure tagged html from json document
function CreateUI(config) {
    console.log("setting for the creation");
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            parseResponse(this, config);
            console.log("creation done");
        }
    };
    xhttp.open("GET", config.urls[0].url, false);
    xhttp.send();
}

//fire the parsing the data use as callback for http.onreadystatechange
function parseResponse(xhttp, config) {
    var textJson = xhttp.responseText;
    var obj = JSON.parse(textJson);
    console.log("parsing data");

    insertHtml(config.dom_id,
        getVersionSectionHtml(obj.middleWareVersion),
        geServiceSectionHtml(obj.service),
        getDefinitionSectionHtml(obj.definitions),
        getTypesSectionHtml(obj.types)
    );
}

///concates the htmlData array into  one element and put it to specified element by id
function insertHtml(elementId, ...htmlData) {
    let insertedHtml = ``;

    htmlData.forEach(element => {
        insertedHtml += element;
    });

    document.getElementById(elementId).innerHTML = insertedHtml;
}

/// :D like interface
function getVersionSectionHtml(jsonVersion) {
    return (jsonVersion ? jsonVersion : `   undified    `);
}
/// :D like interface
function geServiceSectionHtml(jsonService) {
    return (jsonService ? getServiceHtml(jsonService) : `   undified    `);
}
/// :D like interface
function getDefinitionSectionHtml(jsonDefinition) {
    return (jsonDefinition ? getAllDefinitionsHtml(jsonDefinition) : `  undified  `);
}
/// :D like interface
function getTypesSectionHtml(jsontypes) {
    return (jsontypes ? getlAllTypesHtml(jsontypes) : ` undified    `);
}

//creates a html for service defition
// service {events[],commands[],consumes[],version,description}
function getServiceHtml(jsonservice) {
    let p = `<div id="service">
                <div class="i-ser-head">
                    <div class="i-name">Name : no name</div>
                    <div class="i-version">Version: ${jsonservice.version}</div>
                    <div class="i-desc">Description: ${jsonservice.description}
                </div>
                <div class="i-messages">`;

    p += `<div class="l-event">Events: ${getListOf(jsonservice.events, "event")} </div>`;
    p += `<div class="l-command">Commands: ${getListOf(jsonservice.commands, "command")} </div>`;
    p += `<div class="l-consume">Consumes: ${getListOf(jsonservice.consumes, "consumes")} </div>`;

    p += `</div></div>`;

    return p;
}

//create a html repre for the collection as 'ul' with classname and its 'li' items
function getListOf(collection, className) {
    let p = `<ul class="${className}">`;

    collection.forEach(element => {
        p += `<li class="i-name">${element}</li>`;
    });

    p += `</ul>`;

    return p;
}

//stick together all defitions as html rep
function getAllDefinitionsHtml(jsonDefs) {
    let p = `<div id="definitions">`;

    jsonDefs.forEach(element => {
        p += getDefinitionHtml(element);
    });

    p += `</div>`;

    return p;
}

//stick together all type as html rep
function getlAllTypesHtml(jsonTypes) {
    let p = `<div id="types">`;

    jsonTypes.forEach(element => {
        p += getTypeHtml(element);
    });

    p += `</div>`;

    return p;
}

// create a simple html of defintion
// defintion {messageType, fullName,properties}
function getDefinitionHtml(definition) {
    let p = `<div class="i-def">
                    <div class="i-name">Name : ${definition.name}</div>
                    <div class="i-mess-type">Message Type : ${definition.messageType}</div>
                    <div class="i-full-name">Full Name : ${definition.fullName.escapeHTML()}</div>
                    <div class="i-properties">`;
    definition.properties.forEach(element => {
        p += getPropertyHtml(element);
    });
    p += `</div>`
        ;

    p += `<div class="i-desc">
                Descrition : ${definition.description}
            </div>
            </div>
            `;

    return p;
}

//create simple two collumn stage type with data
// typeData {name, fullname, description, properties[]}
function getTypeHtml(typeData) {
    let p = `<div class="i-type">
                <div class="i-name">Name : ${typeData.name}</div>
                <div class="i-full-name">Full Name : ${typeData.fullName.escapeHTML()}</div>
                <div class="i-properties">
     `;

    typeData.properties.forEach(element => {
        p += getPropertyHtml(element);
    });

    p += `</div></div>`;

    return p;
}

//create simple two collumn staged property html prop{description,name,type,isPrimitive}
function getPropertyHtml(property) {
    return `
<div class="i-prop">
        <div class="i-name">
          Name : ${property.name}
        </div>
        <div class="i-type">
          Type : ${property.type.escapeHTML()}
        </div>
        <div class="i-prim">
          Primitive : ${property.isPrimitive}
        </div>
        <div class="i-desc">
          Descrition : ${property.description}
        </div>
        <div class="i-full-name" hidden>
            ${property.fullName.escapeHTML()}
        </div>
</div>
`;
}