String.prototype.replaceAll = function (pattern, withstr) {
    return this.replace(
        new RegExp(pattern.replace(/[.^$*+?()[{\|]/g, '\\$&'), 'g'),
        withstr
    );
};

$.fn.extend({
    // under the called element finds the header and set a click evetn to get
    excollapseOnClick: function () {
        $(this).find(`> .header`).click(function () {
            $(this).clickForCardStyle();
        });
    },

    initialCollapseAll: function(){
        $(this).find(`.header`).each(function(){
            $(this).trigger("click");
        });

    },

    clickForCardStyle: function () {
        parent = $(this).parent();
        parent.find("> .content").slideToggle().toggleClass("active");

        if (parent.find("> .content").hasClass("active")) {
            $(this).find("> span").text("-");
        } else {
            $(this).find("> span").text("+");
        }
    },

    addCardStyle: function (exclude = true) {
        if (exclude) {
            let header = $(this).find(`> .header`).addClass("card-header").detach();
            let body = $(this).find(`> .content`).addClass("card-body").detach();

            let card = $(`<div class="card"></div>`)
                .append(header)
                .append(body);
            $(this).prepend(card);
        }
        else {
            $(this).find(`> .header`).addClass("card-header");
            $(this).find(`> .content`).addClass("card-body");
            $(this).wrapInner(`<div class="card"></div>`);
        }
    },

    decorateService: function () {
        $(this).wrap("<div class='container'></div>");
        let serhead = $(".i-ser-head");
        let namehead = $(".i-ser-head > .i-name").text();

        serhead.addClass("content");

        $(this).prepend(`<div id="s-head" class="header">${namehead}<span><strong>+</strong></span></div>`);

        $("#s-head").excollapseOnClick();
        $(this).excollapseOnClick();
        $(this).addCardStyle();

        $(this).find(`.i-ser-head`).serviceAddRowStyle();
    },

    decorateDefinitions: function () {
        $(this).find("> .i-def").each(function () {
            let defhead = $(this).find('> .i-name').addClass("header").detach();
            defhead.append(`<span><strong>+</strong></span></div>`);

            $(this).wrapInner(`<div class="content"></div>`)
            $(this).prepend(defhead);
            $(this).excollapseOnClick();
            $(this).addCardStyle();
        });
    },

    decorateTypes: function () {
        $(this).find('> .i-type').each(function () {
            let deftype = $(this).find(`> .i-name`).addClass("header").detach();
            deftype.append(`<span><strong>+</strong></span></div>`);

            $(this).wrapInner(`<div class="content"></div>`);
            $(this).prepend(deftype);
            $(this).excollapseOnClick();
            $(this).addCardStyle();
        });

        $(this).wrapInner(`<div class="content"></div>`)
            .prepend(`<div class="header">Types <span><strong>+</strong></span></div>`)
        $(this).excollapseOnClick();
        $(this).addCardStyle();
    },

    forTypesIds: function () {
        $(this).find(`> .i-type`).each(function () {
            let idfullname = $.trim($(this).find(`> .i-full-name`).cleanTypeFormat());
            $(this).attr('id', idfullname);
        });
    },

    setReferenceForSections: function (sections, acctoids, itself = true) {
        let doc = $(this);
        $.each(sections, function (i, val) {
            doc.find(val).each(function () {
                $(this).find(".i-prop").each(function () {
                    var target = $.trim($(this).find("> .i-prim").cleanDefaultText("Primitive : "));
                    if (target == "false") {
                        let strid = ("#" + $.trim($(this).find(`> .i-full-name`).cleanTypeFormat()));
                        if ($(strid, acctoids).length) {
                            $(this).find(`> .i-type`).attr('href', strid);
                        }
                    }
                });
            });
        });
    },

    cleanDefaultText: function (pattern) {
        return $(this).text().replaceAll(pattern, "");
    },

    cleanTypeFormat: function () {
        return $(this).cleanDefaultText("Full Name : ")
            .replaceAll('.', '').replaceAll(`<`, '').replaceAll(`>`, '')
            .replaceAll(`[`, '').replaceAll(`]`, '');
    },

    ///automatic uncollapse the searched type on click
    autoUnCollapse: function () {
        let first;
        [first] = $(this).find(".card-header");

        let revParents = $(this).parents(".card-body").toArray().reverse();

        $.each(revParents, function (i, val) {
            if ($(val).hasClass("active")) {
                $(val).clickForCardStyle();
            }
        });

        if ($(first).parent().find("> .content").hasClass("active")) {
            $(first).clickForCardStyle();
        }
    },

    decorateProperties: function () {
        $(this).find('.i-properties').each(function () {
            $(this).wrap(`<fieldset class="scheduler-border"></fieldset>`);
            $(this).parent().prepend(`<legend class="scheduler-border">Properties</legend>`);

            $(this).find('> .i-prop').each(function () {
                let headName = $(this).find(`> .i-name`).cleanDefaultText("Name : ");
                $(this).wrap(`<fieldset class="scheduler-border"></fieldset>`);
                $(this).parent().prepend(`<legend class="scheduler-border">${headName}</legend>`);
                $(this).collumProp("col-md-7", "col-md-5");
            });
        });
    },

    //calls under the i-prop
    collumProp: function (firstcollumn, secocollumn) {
        $(this).addClass('row');
        $(this).find('> .i-desc').wrap(`<div class=${secocollumn}></div>`);
        let deta = $(this).find(`> .${secocollumn}`).detach();
        $(this).wrapInner(`<div class=${firstcollumn}></div>`);
        $(this).append(deta);
    },
    // put here service content
    serviceAddRowStyle: function () {
        let mess = $(this).find(`> .i-messages`).detach();
        $(this).wrapInner(`<div class="i"></div>`);
        $(this).find('div').first().collumProp("col-md-7", "col-md-5");

        mess.addClass('row').find('> div').each(function () {
            $(this).addClass("col-md-4");
        });

        $(this).append(mess);
    },

    /// adding header with style
    addHeader: function () {
        let apiselect = $("#api");
        let last;
        last = apiselect.wrap(`<div class="wrapper"><div class="api-selection"><fieldset></fieldset></div></div>`)
            .parent().prepend(`<label>Api select:</label>`).parent().parent();

        last.prepend(`<div class="logo">EVENT BUS DOC</div>`).wrap(`<div class="topbar"></div>`);

        $("#api").on('change', function (e) {
            let http = new XMLHttpRequest();
            http.onreadystatechange = function (e) {
                if (this.readyState == 4 && this.status == 200) {
                    $("#eventbusdoc-ui").empty();
                    postParse(this, "eventbusdoc-ui");
                    $(this).enableGenUi();
                }
            };
            http.open("GET", this.value, false);
            http.send();
        });
    },

    ///enbaling ui give it a asic event and style
    enableGenUi: function()
    {
        $('#types').forTypesIds();

        $(this).setReferenceForSections([".i-def", ".i-type"], "#types", true);
    
        $('div[href^="#"').on('click', function (event) {
            let target = $(this.getAttribute('href'));
            if (target.length) {
                event.preventDefault();
                target.autoUnCollapse();
                $('html, body').stop().animate({
                    scrollTop: target.offset().top
                }, 1000);
            }
        });
    
        $("#service").decorateService();
    
        $("#definitions").decorateDefinitions();
    
        $("#types").decorateTypes();
    
        $(this).decorateProperties();

    }
});

$(document).ready(function () {
    $(this).enableGenUi();
    $(this).addHeader();
});