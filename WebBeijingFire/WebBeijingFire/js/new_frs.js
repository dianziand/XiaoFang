var BdeText = {
    EH: Element.hide,
    ES: Element.show,
    IE: Browser.IE,
    Gecko: Browser.Gecko,
    Opera: Browser.Opera,
    Safari: (navigator.userAgent.indexOf("Safari") > -1),
    Chrome: (navigator.userAgent.indexOf("Chrome") > -1),
    Pop: Popup,
    E: Event,
    textPanel: "bdeTextPanel",
    textTool: "bdeTextTool",
    textArea: "bdeTextArea",
    uneditToolbar: "bdeUneditToolbar",
    uneditArea: "bdeUneditArea",
    popup: null,
    body: null,
    listeners: {},
    urlLength: 1024,
    path: "../js/editor/",
    G: function(A) {
        return document.getElementById(A)
    },
    getBody: function() {
        var A = this;
        if (!A.body) {
            A.body = A.G(A.textArea)
        }
        return A.body
    },
    appendHtml: function(B) {
        if (!B || B == "") {
            return
        }
        var A = this.getBody();
        if (this.isEmptyContent(A.innerHTML)) {
            A.innerHTML = B
        } else {
            A.innerHTML = A.innerHTML + B
        }
    },
    clearHtml: function() {
        var A = this.getBody();
        if (this.IE) {
            A.innerHTML = ""
        } else {
            A.innerHTML = "<br>"
        }
    },
    getImageNum: function() {
        return this.getElemNum("IMG", "BDE_Image")
    },
    getSmileyNum: function() {
        return this.getElemNum("IMG", "BDE_Smiley")
    },
    getFlashNum: function() {
        var A = this.getElemNum("EMBED", "BDE_Flash");
        if (!this.IE) {
            A += this.getElemNum("IMG", "BDE_Flash")
        }
        return A
    },
    isEmpty: function() {
        return this.isEmptyContent(this.getBody().innerHTML)
    },
    getHtml: function() {
        var M = this;
        M.reLayout();
        var L = M.setAttribute,
        J = M.getAttribute;
        var K = document.createElement("SPAN");
        K.innerHTML = M.getBody().innerHTML;
        M.parseURL(K);
        var H = "";
        if (M.IE) {
            var B = M.tags(K, "A");
            for (var E = 0,
            C = B.length; E < C; E++) {
                B[E].target = "_blank"
            }
            var I = M.tags(K, "EMBED");
            for (var E = 0,
            C = I.length; E < C; E++) {
                L(I[E], "style", null)
            }
            var F = M.tags(K, "IMG");
            for (var E = 0,
            C = F.length; E < C; E++) {
                L(F[E], "style", null)
            }
            H = M.clearEmailLink(K.innerHTML)
        } else {
            var F = M.tags(K, "IMG");
            for (var E = 0,
            C = F.length; E < C; E++) {
                var D = F[E];
                if (D.className == "BDE_Flash") {
                    var A = document.createElement("EMBED");
                    L(A, "class", "BDE_Flash");
                    L(A, "type", "application/x-shockwave-flash");
                    L(A, "pluginspage", "http://www.macromedia.com/go/getflashplayer");
                    L(A, "wmode", "transparent");
                    L(A, "play", "true");
                    L(A, "loop", "false");
                    L(A, "menu", "false");
                    L(A, "src", J(D, "flash_url"));
                    L(A, "width", J(D, "width"));
                    L(A, "height", J(D, "height"));
                    L(A, "allowscriptaccess", "always");
                    L(A, "allowfullscreen", "true");
                    L(A, "scale", "noborder");
                    D.parentNode.insertBefore(A, D);
                    L(D, "src", null);
                    D.style.display = "none"
                }
            }
            for (var E = F.length - 1; E >= 0; E--) {
                if (F[E].className == "BDE_Flash") {
                    F[E].parentNode.removeChild(F[E])
                }
            }
            H = K.innerHTML
        }
        return M.replace(H, [[/<p *>/gi, ""], [/< *\/p *>\r?\n/gi, "<br>"], [/< *\/p *>/gi, ""], [/<p\/>/gi, "<br>"], [/<div><br><\/div>/gi, "<br>"], [/<div *>/gi, "<br>"], [/< *\/div *>\r?/gi, ""], [/<div\/>/gi, "<br>"], [/<\/?strong>/gi, ""], [/<\/?u>/gi, ""], [/<\/?i>/gi, ""], [/<\/?b>/gi, ""], [/<\/?em>/gi, ""]])
    },
    focus: function() {
        if (this.isEmpty()) {
            this._focus()
        } else {
            this.focus2end()
        }
    },
    init: function() {
        if (this.Gecko) {
            var A = this.getBody();
            if (A) {
                A.innerHTML = "<br>"
            }
        }
    },
    isSuport: function() {
        var A = this;
        var C = navigator.userAgent.toString();
        var B = ["iPhone", "Symbian", "Mobile", "Nokia", "CellPhone", "Sony", "Windows CE", "SmaryPhone", "Samsung", "J2ME", "Opera Mini"];
        if (A.isIn(C, B)) {
            return false
        }
        if (A.isUCWeb()) {
            return false
        }
        return (this.Gecko || this.IE || this.Safari || this.Opera || this.Chrome)
    },
    isIn: function(C, B) {
        for (var A = 0; A < B.length; A++) {
            if (C.indexOf(B[A]) > -1) {
                return true
            }
        }
        return false
    },
    isUCWeb: function() {
        var A = navigator.userAgent.toString();
        if (A.indexOf("X11;") > -1 && A.indexOf("Linux i686;") > -1 && A.indexOf("Gecko") > -1 && A.indexOf("Firefox") < 0 && A.indexOf("Opera") < 0) {
            return true
        }
        return false
    },
    doImage: function() {
        this.saveFocus(true);
        this.createPopup(this.path + "quick/image.html?v=1", 540, 120, "插入图片")
    },
    doFlash: function() {
        this.saveFocus(true);
        this.createPopup(this.path + "quick/flash.html?v=1", 540, 120, "插入视频")
    },
    doSmiley: function() {
        var A = this;
        A.saveFocus();
        if (!A._smileyLoaded) {
            A._smileyLoaded = true;
            A.loadSmiley()
        }
        A.createPopup(A.path + "quick/smiley.html?v=1", 420, 295, "插入表情")
    },
    _smileyLoaded: false,
    loadSmiley: function() {
        var B = this.path + "images/default/";
        var D = ["jFace.gif", "fFace.gif", "wFace.gif", "tFace.gif", "bFace.gif"];
        for (var C = 0,
        A = D.length; C < A; C++) {
            (new Image()).src = B + D[C]
        }
    },
    listen: function(B, C) {
        if (B && C) {
            var A = this.listeners;
            if (typeof (A[B]) != "object") {
                A[B] = []
            } (A[B])[A[B].length] = C
        }
    },
    dispatch: function(C) {
        var B = this.listeners;
        if (B[C]) {
            for (var A = 0; A < B[C].length; A++) {
                B[C][A].call(null, C)
            }
        }
    },
    dispatchDelay: function(A) {
        var B = this;
        if (B.scTimer) {
            clearTimeout(B.scTimer);
            delete B.scTimer
        }
        B.scTimer = setTimeout(function() {
            B.dispatch(A)
        },
        100)
    },
    doPasteIE: function(B) {
        var C = clipboardData.getData("Text");
        if ((!C) || C == "") {
            return true
        }
        var A = this;
        C = A.replace(C, [[/&/g, "&amp;"], [/</g, "&lt;"], [/>/g, "&gt;"], [/\r?\n/g, "<br>"], [/\t/g, "&nbsp;&nbsp;&nbsp;&nbsp;"], [/\s/g, "&nbsp;"], [/\u3000/g, "&nbsp;&nbsp;"]]);
        A.paste(C);
        setTimeout(function() {
            A.dispatch("oneditorpaste")
        },
        50);
        return false
    },
    doPasteGecko: function(B) {
        var A = this;
        setTimeout(function() {
            A.filte();
            A.dispatch("oneditorpaste")
        },
        50);
        return (B.returnValue = true)
    },
    pasteHandler: function(A) {
        if (this.IE) {
            return this.doPasteIE(A)
        } else {
            return this.doPasteGecko(A)
        }
    },
    selectionChangeHandler: function(B) {
        var A = this;
        setTimeout(function() {
            A.reLayout();
            A.dispatch("oneditorselectionchange")
        },
        100)
    },
    focusHandler: function(A) {
        this.dispatch("oneditorfocus")
    },
    clickHandler: function(A) {
        this.dispatch("oneditorclick")
    },
    keydownHandler: function(H) {
        if (!BdeText.IE) {
            return
        }
        var E = window.event || H;
        var A = 8;
        var F = E.which || E.keyCode || E.charCode;
        if (E.ctrlKey || E.metaKey || E.shiftKey || E.altKey) {
            return (E.returnValue = true)
        } else {
            if (F == A && this.IE) {
                var D = document.selection;
                if ("control" == D.type.toLowerCase()) {
                    var B = D.createRange();
                    for (var C = B.length - 1; C >= 0; C--) {
                        B(C).parentNode.removeChild(B(C))
                    }
                    return (E.returnValue = false)
                }
            }
        }
        return (E.returnValue = true)
    },
    keyUpHandler: function(A) {
        this.dispatchDelay("oneditorkeyup")
    },
    hasFocus: function() {
        return (document.activeElement == this.getBody())
    },
    ieControl: null,
    ieCursor: null,
    saveFocus: function(A) {
        var E = this;
        if (E.IE) {
            try {
                if (!E.hasFocus()) {
                    if (A && (!E.isEmpty())) {
                        E.getBody().innerHTML = E.getBody().innerHTML + "<br>"
                    }
                    E.focus2end()
                }
                E.ieControl = null;
                E.ieCursor = null;
                var C = document.selection;
                var D = C.createRange();
                var B = C.type.toLowerCase();
                if ("control" == B) {
                    var F = D(0);
                    E.ieControl = F
                } else {
                    if ("none" == B || "text" == B) {
                        D.select();
                        D.pasteHTML("<img id='BDE_cursor' class='BDE_Image' style='width:1px;height:1px'>");
                        D.select();
                        E.ieCursor = "BDE_cursor"
                    }
                }
            } catch (H) { }
        }
    },
    ensureFocus: function(C) {
        var B = this;
        if (B.IE) {
            try {
                B.getBody().setActive();
                var A = null;
                if (B.ieControl) {
                    A = document.body.createControlRange();
                    A.addElement(B.ieControl);
                    A.select();
                    B.ieControl = null
                } else {
                    if (B.ieCursor) {
                        A = document.body.createControlRange();
                        A.addElement(B.G(B.ieCursor));
                        A.select();
                        B.paste("");
                        B.ieCursor = null
                    } else {
                        if (!B.isEmpty()) {
                            B.getBody().innerHTML = B.getBody().innerHTML
                        }
                    }
                }
            } catch (C) { }
        } else {
            if (B.Gecko || B.Opera) {
                B.getBody().focus()
            } else {
                if (B.isEmpty()) {
                    B.focus()
                }
            }
        }
    },
    _focus: function() {
        this.getBody().focus()
    },
    focus2end: function() {
        var D = this;
        try {
            var A = D.getBody();
            A.focus();
            if (D.IE) {
                A.innerHTML = A.innerHTML
            } else {
                if (window.getSelection) {
                    var B = window.getSelection();
                    var C = document.createRange();
                    C.setStartAfter(A.lastChild);
                    C.setEndAfter(A.lastChild);
                    B.removeAllRanges();
                    B.addRange(C)
                }
            }
        } catch (E) { }
    },
    replace: function(C, B) {
        for (var A = 0; A < B.length; A++) {
            C = C.replace(B[A][0], B[A][1])
        }
        return C
    },
    tags: function(B, A) {
        return B.getElementsByTagName(A)
    },
    getElemNum: function(D, E) {
        var F = 0;
        var A = this.tags(this.getBody(), D);
        for (var C = 0,
        B = A.length; C < B; C++) {
            if (A[C].className == E) {
                F++
            }
        }
        return F
    },
    setAttribute: function(B, A, C) {
        if (C == null || C.length == 0) {
            B.removeAttribute(A, 0)
        } else {
            B.setAttribute(A, C, 0)
        }
    },
    getAttribute: function(E, D, C) {
        var B = E.attributes[D];
        if (B == null || !B.specified) {
            return C || ""
        }
        var A = E.getAttribute(D, 2);
        if (!A) {
            A = B.nodeValue
        }
        return A || C
    },
    paste: function(A) {
        var C = this;
        var D = document;
        if (C.IE) {
            if (D.selection.type.toLowerCase() == "control") {
                D.execCommand("Delete", false, null)
            }
            var B = D.selection.createRange();
            B.select();
            B.pasteHTML(A);
            B.collapse(false);
            B.select()
        } else {
            D.execCommand("insertHTML", false, A)
        }
    },
    filte: function() {
        var E = this;
        E.paste("<img id='BDE_cursor' class='BDE_Image' style='width:1px;height:1px'>");
        var A = E.getBody();
        var C = A.innerHTML;
        C = E.replace(C, [[/\[/g, "[[-"], [/\]/g, "-]]"], [/<img ([^>]*class=["']?(BDE_Image|BDE_Flash|BDE_Smiley)["']?[^>]*)>/gi, "[img $1]"], [/<br[^>]*( *\/?)>/gi, "[br$1]"], [/<\/ ?p[^>]*>/gi, "[br]"], [/<table[^>]*>/gi, "[br]"], [/<\/ ?tr[^>]*>/gi, "[br]"], [/<\/ ?td[^>]*>/gi, "&nbsp;&nbsp;"], [/<(ul|dl|ol)[^>]*>/gi, "[br]"], [/<(li|dd)[^>]*>/gi, "[br]"], [/<script[^>]*>(.|\r?\n)*<\/script>/gi, ""], [/<xml[^>]*>(.|\r?\n)*<\/xml>/gi, ""], [/<style[^>]*>(.|\r?\n)*<\/style>/gi, ""], [/<applet[^>]*>(.|\r?\n)*<\/applet>/gi, ""], [/<object[^>]*>(.|\r?\n)*<\/object>/gi, ""], [/<!--(.*)-->/gi, ""], [/<[^>]*>/gi, ""], [/\[img ([^\]]*)\]/gi, "<img $1>"], [/\[br( *\/?)\]/gi, "<br$1>"], [/\[\[\-/g, "["], [/\-\]\]/g, "]"]]);
        A.innerHTML = C;
        var B = document.createRange();
        B.selectNode(document.getElementById("BDE_cursor"));
        var D = window.getSelection();
        D.removeAllRanges();
        D.addRange(B);
        if (E.Safari) {
            E.paste("")
        } else {
            B.deleteContents()
        }
    },
    parseURL: function(E) {
        var B = "(=*+)",
        A = "(+*=)";
        var D = 4;
        var C = function(F) {
            if (F.nodeType == 3) {
                var H = F.nodeValue;
                if (H && H.length > D) {
                    H = "." + H;
                    H = H.replace(/([^0-9a-zA-Z])((www\.|http:\/\/|mms:\/\/|rtsp:\/\/|ftp:\/\/|https:\/\/)[0-9a-zA-Z\.\!\~\#\?\:\/\&\%\-\+\*\'\=\@\_\$]+)/gi, "$1" + B + 'a href="$2" target="_blank"' + A + "$2" + B + "/a" + A);
                    H = H.substring(1);
                    F.nodeValue = H
                }
            } else {
                if (F.nodeType == 1) {
                    var I = F.firstChild;
                    while (I) {
                        if (I.nodeName.toUpperCase() != "A") {
                            C(I)
                        }
                        I = I.nextSibling
                    }
                }
            }
        };
        C(E);
        E.innerHTML = this.replace(E.innerHTML, [[/\(\=\*\+\)a\ href="www\./gi, '<a href="http://www.'], [/\(\=\*\+\)/gi, "<"], [/\(\+\*\=\)/gi, ">"]])
    },
    isEmptyContent: function(A) {
        if (!A) {
            return true
        }
        return ("" == this.replace(A, [[/<br *\/?>/gi, ""], [/<\/?p *\/?>/gi, ""], [/<\/?a *\/?>/gi, ""], [/&nbsp;/g, ""], [/(\r?\n)+/g, ""], [/[\u3000\s]+/g, ""]]))
    },
    clearEmailLink: function(A) {
        return A.replace(/<a[^>]*href=[\'\"]?mailto[^>]*>([^>]*)<\/a>/gi, "$1")
    },
    reLayout: function() {
        var L = this;
        var J = L.setAttribute,
        H = L.getAttribute;
        var N = function(Q, O) {
            var P = 0;
            if (O == "width") {
                P = Q.width
            } else {
                if (O == "height") {
                    P = Q.height
                }
            }
            return parseInt((P + "").replace(/px/g, ""))
        };
        var A = function(Q, O, T) {
            var P = N(Q, O);
            var S = (O == "width" ? "height" : "width");
            var R = N(Q, S);
            if (P > T || P < 0) {
                J(Q, O, T);
                if (P < 0) {
                    P = -P
                }
                J(Q, S, R * (T / P));
                return true
            } else {
                J(Q, O, P);
                J(Q, S, R);
                return false
            }
        };
        var B = function(R, P) {
            var Q = N(R, "height");
            var O = N(R, "width");
            if (P.toLowerCase().indexOf("baidu.com") > -1) {
                J(R, "width", 480);
                J(R, "height", 410)
            } else {
                J(R, "width", 500);
                J(R, "height", 450)
            }
        };
        var I = L.getBody();
        var F = L.tags(I, "IMG");
        for (var E = 0; E < F.length; E++) {
            var D = F[E];
            if (D.className == "BDE_Image") {
                if (A(D, "width", 570)) {
                    J(D, "changedsize", "true")
                }
            } else {
                if (D.className == "BDE_Flash") {
                    B(D, H(D, "flash_url"))
                } else {
                    if (D.className == "BDE_Smiley") {
                        var C = false;
                        if (N(D, "width") > 40 || N(D, "height") > 40) {
                            J(D, "width", 40);
                            J(D, "height", 40)
                        } else {
                            J(D, "width", N(D, "width"));
                            J(D, "height", N(D, "height"))
                        }
                        if (C) {
                            J(D, "changedsize", "true")
                        }
                    }
                }
            }
        }
        var K = L.tags(I, "EMBED");
        for (var E = 0; E < K.length; E++) {
            var M = K[E];
            if (M.className == "BDE_Flash") {
                B(M, H(M, "src"))
            }
        }
    },
    createPopup: function(B, A, D, C) {
        var E = this;
        E.popup = new E.Pop({
            width: A,
            height: D,
            title: C
        });
        E.popup.setContent("callBackCancel",
        function() {
            E.ensureFocus();
            return true
        });
        E.popup.xwindow(B, C)
    },
    closePopup: function() {
        if (this.popup) {
            this.popup.close()
        }
    },
    formatURL: function(A) {
        return this.replace(A, [[/[\u3000\s]+/g, ""], [/\\/g, "/"], [/</g, ""], [/>/g, ""], [/"/g, ""], [/;/g, ""], [/\(/g, ""], [/\)/g, ""]])
    }
};
var ContentTextInput = {
    ES: Element.show,
    EH: Element.hide,
    E: Event,
    _area: null,
    init: function() {
        var A = this;
        A._area = G("ctl00_ContentPlaceHolder1_textInput");
        A._area.value = "";
        A.EH("editorInput");
        A.ES(A._area);
        return A
    },
    getHtml: function() {
        return this._area.value.replace(/&/gi, "&amp;").replace(/</gi, "&lt;").replace(/>/gi, "&gt;").replace(/\r?\n/gi, "<br>").replace(/[\u3000\s]/gi, "&nbsp;").replace(/\t/gi, "&nbsp;&nbsp;&nbsp;&nbsp;")
    },
    isEmpty: function() {
        var A = this._area;
        return !(A && A.value && A.value.replace(/[\u3000\s]/gi, "").replace(/\r?\n/gi, "").replace(/\t/gi, "") != "")
    },
    appendHtml: function(A) {
        var B = A.replace(/<br>/gi, "\r\n").replace(/<[^>]*>/gi, "").replace(/&nbsp;/gi, " ").replace(/&lt;/gi, "<").replace(/&gt;/gi, ">").replace(/&amp;/gi, "&");
        return this._area.value = this._area.value + B
    },
    clearHtml: function() {
        this._area.value = ""
    },
    getImageNum: function() {
        return 0
    },
    getSmileyNum: function() {
        return 0
    },
    getFlashNum: function() {
        return 0
    },
    focus: function() {
        var A = this._area;
        if (A) {
            A.focus();
            A.value = A.value
        }
    },
    listen: function(B, A) {
        var C = this;
        if (B == "oneditorfocus") {
            C.E.observe(C._area, "focus", A, false)
        } else {
            if (B == "oneditorkeyup") {
                C.E.observe(C._area, "keyup", A, false)
            } else {
                if (B == "oneditorclick") {
                    C.E.observe(C._area, "click", A, false)
                } else {
                    if (B == "oneditorpaste") {
                        C.E.observe(C._area, "paste", A, false)
                    }
                }
            }
        }
    }
};
ContentInput = BdeText;
var nPopup = null;

String.prototype.getByteLength = function() {
    return this.replace(/[^\x00-\xff]/g, "mm").length
};
String.prototype.subByte = function(C) {
    if (this.getByteLength() <= C) {
        return this
    }
    for (var B = Math.floor((C = C - 2) / 2), A = this.length; B < A; B++) {
        if (this.substr(0, B).getByteLength() >= C) {
            return this.substr(0, B) + "\u2026"
        }
    }
    return this
};
String.prototype.subChar = function(A) {
    if (this.length <= A) {
        return this
    } else {
        return this.substr(0, A - 1) + "\u2026"
    }
};
