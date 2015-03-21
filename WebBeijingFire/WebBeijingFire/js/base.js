﻿var G = function(A) {
    if (typeof A == "string") {
        A = document.getElementById(A)
    }
    return A
};
var Class = function() {
    var A = function() {
        this.initialize.apply(this, arguments)
    };
    return A
};
Object.extend = function(A, C) {
    for (var B in C) {
        A[B] = C[B]
    }
    return A
};
if (!("console" in window) || !("firebug" in console)) {
    var names = ["log", "debug", "info", "warn", "error", "assert", "dir", "dirxml", "group", "groupEnd", "time", "timeEnd", "count", "trace", "profile", "profileEnd"];
    window.console = {};
    for (var i = 0; i < names.length; ++i) {
        window.console[names[i]] = function() { }
    }
}
var Browser = {
    IE: !!(window.attachEvent && !window.opera),
    Opera: !!window.opera,
    WebKit: navigator.userAgent.indexOf("AppleWebKit/") > -1,
    Gecko: navigator.userAgent.indexOf("Gecko") > -1 && navigator.userAgent.indexOf("KHTML") == -1,
    MobileSafari: !!navigator.userAgent.match(/Apple.*Mobile.*Safari/)
};
Function.prototype.bind = function() {
    var D = [];
    for (var E = 0,
    B = arguments.length; E < B; E++) {
        D.push(arguments[E])
    }
    var A = this,
    C = D[0];
    return function() {
        return A.apply(C, D)
    }
};
Function.prototype.bindAsEventListener = function(B) {
    var A = this;
    return function(C) {
        A.call(B, C || window.event)
    }
};
if (!window.Event) {
    var Event = new Object()
}
Object.extend(Event, {
    pointerX: function(A) {
        return A.pageX || (A.clientX + Element.getBodyDimension().scrollLeft)
    },
    pointerY: function(A) {
        return A.pageY || (A.clientY + Element.getBodyDimension().scrollTop)
    },
    _observeAndCache: function(D, C, B, A) {
        if (!this.observers) {
            this.observers = []
        }
        this.observers.push([D, C, B, A]);
        if (!D) {
            return
        }
        if (D.addEventListener) {
            D.addEventListener(C, B, A)
        } else {
            if (D.attachEvent) {
                D.attachEvent("on" + C, B)
            }
        }
    },
    observe: function(D, C, B, A) {
        var D = G(D);
        A = A || false;
        if (C == "keypress" && (navigator.appVersion.match(/Konqueror|Safari|KHTML/) || D.attachEvent)) {
            C = "keydown"
        }
        this._observeAndCache(D, C, B, A)
    },
    stopObserving: function(D, C, B, A) {
        var D = G(D);
        if (!D) {
            return
        }
        A = A || false;
        if (C == "keypress" && (navigator.appVersion.match(/Konqueror|Safari|KHTML/) || D.detachEvent)) {
            C = "keydown"
        }
        if (D.removeEventListener) {
            D.removeEventListener(C, B, A)
        } else {
            if (D.detachEvent) {
                D.detachEvent("on" + C, B)
            }
        }
    },
    element: function(A) {
        return A.target || A.srcElement
    },
    preventDefault: function(A) {
        if (A && A.preventDefault) {
            Event.preventDefault = function(B) {
                B.preventDefault()
            }
        } else {
            Event.preventDefault = function(B) {
                event.returnValue = false
            }
        }
        return Event.preventDefault(A)
    },
    cancelBubble: function(A) {
        if (A && A.stopPropagation) {
            Event.cancelBubble = function(B) {
                B.stopPropagation()
            }
        } else {
            Event.cancelBubble = function(B) {
                event.cancelBubble = true
            }
        }
        return Event.cancelBubble(A)
    },
    unloadCache: function() {
        if (!Event.observers) {
            return
        }
        for (var A = 0; A < Event.observers.length; A++) {
            Event.stopObserving.apply(this, Event.observers[A]);
            Event.observers[A][0] = null
        }
        Event.observers = false
    }
});
Event.observe(window, "unload", Event.unloadCache, false);
if (!window.Element) {
    var Element = new Object()
}
Element = {
    show: function(A) {
        var A = G(A);
        if (A) {
            A.style.display = ""
        }
    },
    getWidth: function(A) {
        return G(A).offsetWidth
    },
    hide: function(A) {
        var A = G(A);
        if (A) {
            A.style.display = "none"
        }
    },
    getBodyDimension: function(E) {
        var A, K, F, C, B, L;
        var I = window,
        D = E ? top.document : document,
        J = D.documentElement;
        if (D.compatMode && D.compatMode != "BackCompat") {
            var A = J.clientWidth;
            var K = J.clientHeight
        } else {
            var A = D.body.clientWidth;
            var K = D.body.clientHeight
        }
        if (I.pageXOffset) {
            F = I.pageXOffset
        } else {
            if (J && J.scrollLeft) {
                F = J.scrollLeft
            } else {
                if (D.body) {
                    F = D.body.scrollLeft
                }
            }
        }
        if (I.pageYOffset) {
            C = I.pageYOffset
        } else {
            if (J && J.scrollTop) {
                C = J.scrollTop
            } else {
                if (D.body) {
                    C = D.body.scrollTop
                }
            }
        }
        if (J && J.scrollWidth) {
            B = J.scrollWidth;
            L = J.scrollHeight
        } else {
            if (D.body) {
                B = D.body.scrollWidth;
                L = D.body.scrollHeight
            }
        }
        return {
            scrollTop: C,
            scrollLeft: F,
            scrollWidth: B,
            scrollHeight: L,
            clientWidth: A,
            clientHeight: K
        }
    },
    addClass: function(C, B) {
        var A = C.className;
        if (!new RegExp(("(^|\\s)" + B + "(\\s|$)"), "i").test(A)) {
            C.className = A + ((A.length > 0) ? " " : "") + B
        }
        return this
    },
    removeClass: function(C, B) {
        var A = new RegExp(("(^|\\s)" + B + "(\\s|$)"), "i");
        C.className = C.className.replace(A,
        function(D) {
            var E = "";
            if (new RegExp("^\\s+.*\\s+$").test(D)) {
                E = D.replace(/(\s+).+/, "$1")
            }
            return E
        }).replace(/^\s+|\s+$/g, "");
        return C
    },
    hasClassName: function(B, A) {
        return !!B.className.match(new RegExp("\\b" + A + "\\b"))
    },
    getPosition: function(A) {
        var B = curtop = 0;
        if (A.offsetParent) {
            B = A.offsetLeft;
            curtop = A.offsetTop;
            while (A = A.offsetParent) {
                B += A.offsetLeft;
                curtop += A.offsetTop
            }
        }
        return [B, curtop]
    },
    isElem: function(B) {
        if (B === undefined || B === null) {
            return false
        }
        if (B.htmlElement) {
            return true
        }
        var A = typeof B;
        if (A == "object" && B.nodeName && B.nodeType == 1) {
            return true
        }
        return false
    }
};
if (!Array.prototype.forEach) {
    Array.prototype.forEach = function(B, C) {
        for (var A = 0; A < this.length; A++) {
            B.call(C, this[A], A)
        }
    }
}
Array.prototype.each = Array.prototype.forEach;
document.getElementsByClassName = function(D, B) {
    var C = [];
    var A = D.getElementsByTagName("*");
    GA(A).each(function(E) {
        if (Element.hasClassName(E, B)) {
            C.push(E)
        }
    });
    return C
};
document.getDocumentSize = function() {
    function A(B) {
        return Math.max(Math.max(document.body["scroll" + B], document.documentElement["scroll" + B]), Math.max(document.body["offset" + B], document.documentElement["offset" + B]))
    }
    return {
        width: A("Width"),
        height: A("Height")
    }
};
var GA = function(C) {
    var B = [];
    for (var A = 0; A < C.length; A++) {
        B.push(C[A])
    }
    return B
};
Object.extend(String.prototype, {
    Alltrim: function() {
        return this.replace(/(^[　\s]+)|([　\s]+$)/g, "")
    },
    rOneBk: function() {
        var A = /([\s\t\xa0\u3000])[\s\t\xa0\u3000]*/g;
        return this.replace(A, "$1")
    },
    byteLength: function() {
        return this.replace(/[^\u0000-\u007f]/g, "\u0061\u0061").length
    },
    stripTags: function() {
        return this.replace(/<\/?[^>]+>/gi, "")
    },
    escapeJS: function() {
        return this.replace(/'/g, "&#39;").replace(/"/g, "&#34;")
    },
    escapeHTML: function() {
        return this.replace(/</g, "&lt;").replace(/>/g, "&gt;")
    },
    unescapeHTML: function() {
        var A = document.createElement("div");
        A.innerHTML = this.stripTags();
        return A.childNodes[0] ? A.childNodes[0].nodeValue : ""
    },
    getByByteLen: function(C) {
        var D = Math.floor(C / 2);
        var E = this.substring(0, D).byteLength();
        for (var B = D,
        A = this.length; B <= A; B++) {
            if (E > C) {
                return this.substring(0, B - 1);
                break
            } else {
                E += this.charAt(B).byteLength()
            }
        }
        return this
    },
    format: function() {
        if (arguments.length == 0) {
            return this
        }
        for (var B = this,
        A = 0; A < arguments.length; A++) {
            B = B.replace(new RegExp("\\{" + A + "\\}", "g"), arguments[A])
        }
        return B
    },
    formatObj: function(C) {
        var B = this;
        for (var A in C) {
            if (typeof C[A] == "string") {
                C[A] = C[A].replace(/\$/g, "$$$$");
                B = B.replace(new RegExp("#{" + A + "}", "g"), C[A])
            }
        }
        return B
    }
});
if (!Array.prototype.push) {
    Array.prototype.push = function() {
        var B = this.length;
        for (var A = 0; A < arguments.length; A++) {
            this[B + A] = arguments[A]
        }
        return this.length
    }
}
Object.extend(Array.prototype, {
    indexOf: function(C) {
        for (var B = 0,
        A = this.length; B < A; B++) {
            if (this[B] == C) {
                return B
            }
        }
        return -1
    },
    contains: function(A) {
        return (this.indexOf(A) >= 0)
    },
    clear: function() {
        this.length = 0
    },
    removeAt: function(A) {
        this.splice(A, 1)
    },
    remove: function(B) {
        var A = this.indexOf(B);
        if (A >= 0) {
            this.removeAt(A)
        }
    },
    addBefore: function(A) {
        if (this == []) {
            return A
        } else {
            return A.concat(this)
        }
    },
    addAfter: function(A) {
        if (this == []) {
            return A
        } else {
            return this.concat(A)
        }
    }
});
var Try = {
    these: function() {
        var D;
        for (var C = 0,
        A = arguments.length; C < A; C++) {
            var B = arguments[C];
            try {
                D = B();
                break
            } catch (E) { }
        }
        return D
    }
};
var encode = encodeURIComponent;
var decode = decodeURIComponent;
var Ajax = {
    getTransport: function() {
        return Try.these(function() {
            return new XMLHttpRequest()
        },
        function() {
            return new ActiveXObject("Microsoft.XMLHTTP")
        },
        function() {
            return new ActiveXObject("Msxml2.XMLHTTP")
        }) || false
    }
};
Ajax.Base = function() { };
Ajax.Base.prototype = {
    setOptions: function(A) {
        this.options = {
            method: "post",
            asynchronous: true,
            contentType: "application/x-www-form-urlencoded",
            parameters: ""
        };
        Object.extend(this.options, A || {})
    },
    responseIsSuccess: function() {
        return this.transport.status == undefined || this.transport.status == 0 || (this.transport.status >= 200 && this.transport.status < 300)
    },
    responseIsFailure: function() {
        return !this.responseIsSuccess()
    }
};
Ajax.Request = new Class();
Ajax.Request.Events = ["Uninitialized", "Loading", "Loaded", "Interactive", "Complete"];
Ajax.Request.prototype = Object.extend(new Ajax.Base(), {
    initialize: function(B, A) {
        this.transport = Ajax.getTransport();
        this.setOptions(A);
        this.request(B)
    },
    request: function(B) {
        this.url = B;
        var C = this.options.parameters || "";
        if (C.length > 0) {
            C += "&_="
        }
        if (this.options.method == "get" && C.length > 0) {
            this.url += (this.url.match(/\?/) ? "&" : "?") + C
        }
        try {
            this.transport.open(this.options.method, this.url, this.options.asynchronous);
            if (this.options.asynchronous) {
                setTimeout(function() {
                    this.respondToReadyState(1)
                } .bind(this), 10)
            }
            this.transport.onreadystatechange = this.onStateChange.bind(this);
            this.setRequestHeaders();
            var A = this.options.postBody ? this.options.postBody : C;
            this.transport.send(this.options.method == "post" ? A : null)
        } catch (D) {
            this.dispatchException(D)
        }
    },
    setRequestHeaders: function() {
        var C = ["X-Requested-With", "XMLHttpRequest"];
        if (this.options.method == "post") {
            var B = this.options.contentType;
            C.push("Content-type", B);
            if (this.transport.overrideMimeType && (navigator.userAgent.match(/Gecko\/(\d{4})/) || [0, 2005])[1] < 2005) {
                C.push("Connection", "close")
            }
        }
        if (this.options.requestHeaders) {
            C.push.apply(C, this.options.requestHeaders)
        }
        for (var A = 0; A < C.length; A += 2) {
            this.transport.setRequestHeader(C[A], C[A + 1])
        }
    },
    onStateChange: function() {
        var A = this.transport.readyState;
        if (A != 1) {
            this.respondToReadyState(this.transport.readyState)
        }
    },
    header: function(A) {
        try {
            return this.transport.getResponseHeader(A)
        } catch (B) { }
    },
    evalJSON: function() {
        try {
            return eval(this.header("X-JSON"))
        } catch (e) { }
    },
    evalResponse: function() {
        try {
            return eval(this.transport.responseText)
        } catch (e) {
            this.dispatchException(e)
        }
    },
    respondToReadyState: function(A) {
        var C = Ajax.Request.Events[A];
        var E = this.transport,
        B = this.evalJSON();
        if (C == "Complete") {
            try {
                (this.options["on" + this.transport.status] || this.options["on" + (this.responseIsSuccess() ? "Success" : "Failure")] ||
                function() { })(E, B)
            } catch (D) {
                this.dispatchException(D)
            }
            if ((this.header("Content-type") || "text/javascript").match(/^(text|application)\/(x-)?(java|ecma)script(;.*)?$/i)) {
                this.evalResponse()
            }
        }
        try {
            (this.options["on" + C] ||
            function() { })(E, B)
        } catch (D) {
            this.dispatchException(D)
        }
        if (C == "Complete") {
            this.transport.onreadystatechange = function() { }
        }
    },
    dispatchException: function(A) {
        (this.options.onException ||
        function() { })(this, A)
    }
});
var Form = new Class();
Form.prototype = {
    checkMethods: {
        byteLength: "chkByteLength",
        isNull: "chkIsNull",
        isContain: "chkIsContain"
    },
    initialize: function(A, B) {
        this.Errors = {
            byteLength: "名称长度不能超过8个汉字，请重试",
            isNull: "必须填写相册名称",
            isContain: "仅限使用汉字、字母、数字和下划线"
        };
        this.configs = {
            isAlert: false,
            style: {
                color: "red",
                fontSize: "12px"
            }
        };
        this.isSubmit = true;
        this.isError = false;
        this.setConfigs(A);
        this.setErrors(B)
    },
    setErrors: function(A) {
        Object.extend(this.Errors, A)
    },
    setConfigs: function(A) {
        Object.extend(this.configs, A)
    },
    checkSubmit: function(E, D, K) {
        var F = 0;
        this.isSubmit = true;
        this.isError = false;
        D = D || E.objects || [];
        if (D.length == 0) {
            for (var B = 0,
            H = E.elements.length; B < H; B++) {
                if (E.elements[B].getAttribute("require")) {
                    D.push(E.elements[B])
                }
            }
        } else {
            if (D.constructor != Array) {
                D = [D]
            }
        }
        for (var C = 0; C < D.length; C++) {
            var J = null,
            A = null;
            if (D[C].constructor == Array) {
                J = G(D[C][0]);
                A = G(D[C][1])
            } else {
                J = G(D[C])
            }
            this.options = this.getOptions(J, K);
            for (property in this.options) {
                var I = this.options[property];
                if (I != null && I != false && I != "" && F == 0) {
                    F += this[this.checkMethods[property]](J, A, property)
                }
            }
        }
        return F
    },
    checkElement: function(H, B, E) {
        var D = null,
        F = null;
        if (H.constructor == Array) {
            F = G(H[0]);
            D = G(H[1])
        } else {
            F = G(H)
        }
        this.options = this.getOptions(F, E);
        this.isSubmit = false;
        var A = this,
        C = 0;
        F["on" + (B || "keyup")] = function() {
            for (property in A.options) {
                var I = A.options[property];
                if (I != null && I != false && I != "" && C == 0) {
                    C = A[A.checkMethods[property]](F, D, property)
                }
                if (C == 1) {
                    A.isError = 1;
                    break
                } else {
                    A.isError = 0
                }
            }
            C = 0
        }
    },
    checkElements: function(C) {
        if (C.constructor == Array) {
            for (var B = 0,
            A = C.length; B < A; B++) {
                new Form().checkElement(C[B][0], C[B][1], C[B][2])
            }
        }
    },
    getOptions: function(C, J) {
        var H = C.getAttribute("require");
        if (H && H != null) {
            H = H.split("|")
        } else {
            H = []
        }
        var F = C.getAttribute("errors");
        if (F && F != null) {
            F = F.split("|")
        } else {
            F = []
        }
        var A = {};
        this.TempErrors = {};
        if (!J) {
            J = {}
        }
        if (H.length > 0) {
            for (var D = 0,
            E = H.length; D < E; D++) {
                var B = H[D].match(/^[a-zA-Z]+/);
                var I = H[D].replace(/^[a-zA-Z]+[:]?/, "");
                if (I.match(/[,]/)) {
                    I = I.substring(1, I.length - 1).split(",")
                }
                if (I.constructor != Array && I.replace(/(^[　\s]+)|([　\s]+$)/g, "") == "") {
                    I = true
                }
                A[B] = I
            }
        }
        Object.extend(J, A);
        for (D = 0; D < F.length; D++) {
            var B = F[D].match(/^[a-zA-Z]+/);
            var I = F[D].replace(/^[a-zA-Z]+[:]?/, "");
            if (I.replace(/(^[　\s]+)|([　\s]+$)/g, "") != "") {
                this.TempErrors[B] = I
            }
        }
        return J
    },
    getErrorTip: function(A) {
        if (!(A in this.TempErrors)) {
            return this.Errors[A]
        } else {
            return this.TempErrors[A]
        }
    },
    showTip: function(D, B, C) {
        var A = null;
        if (this.configs.isAlert == true) {
            if (this.isError == false) {
                alert(this.getErrorTip(C))
            }
            if (this.isSubmit == true) {
                this.isError = true
            }
        } else {
            if (B != null) {
                A = B;
                B.innerHTML = this.getErrorTip(C);
                B.style.display = ""
            } else {
                A = D.nextSibling;
                if (A && A.name == "erTip") {
                    A.innerHTML = this.getErrorTip(C);
                    A.style.display = ""
                } else {
                    A = document.createElement("span");
                    A.name = "erTip";
                    A.innerHTML = this.getErrorTip(C);
                    if (!D.nextSibling) {
                        D.parentNode.appendChild(A)
                    } else {
                        D.parentNode.insertBefore(A, D.nextSibling)
                    }
                }
            }
            if (typeof this.configs.style == "string") {
                A.className = this.configs.style
            } else {
                for (C in this.configs.style) {
                    A.style[C] = this.configs.style[C]
                }
            }
        }
    },
    hideTip: function(C, B) {
        if (B != null) {
            B.style.display = "none"
        } else {
            var A = C.nextSibling;
            if (A && A.name == "erTip") {
                A.style.display = "none"
            }
        }
    },
    strArrToNumArr: function(B) {
        if (B.constructor != Array) {
            return parseInt(B)
        }
        for (var A = 0; A < B.length; A++) {
            B[A] = parseInt(B[A])
        }
        return B
    }
};
Form.Methods = {
    chkByteLength: function(E, B, D) {
        var A = E.value.replace(/[^\u0000-\u007f]/g, "\u0061\u0061").length;
        var C = this.options[D];
        if (C.constructor == Array && C.length == 2) {
            if (A <= C[1] && A >= C[0]) {
                this.hideTip(E, B);
                return 0
            } else {
                this.showTip(E, B, D);
                return 1
            }
        } else {
            if (C < 0) {
                A = -A
            }
            if (A <= C) {
                this.hideTip(E, B);
                return 0
            } else {
                this.showTip(E, B, D);
                return 1
            }
        }
    },
    chkIsNull: function(D, A, C) {
        var B = D.value.replace(/(^[　\s]+)|([　\s]+$)/g, "");
        if (B == "") {
            this.showTip(D, A, C);
            return 1
        } else {
            this.hideTip(D, A);
            return 0
        }
    },
    chkIsContain: function(D, A, C) {
        var B = /[^0-9a-zA-Z_\u4E00-\u9FA5]/g;
        if (D.value.match(B)) {
            this.showTip(D, A, C);
            return 1
        } else {
            this.hideTip(D, A);
            return 0
        }
    }
};
Object.extend(Form.prototype, Form.Methods);
var Popup = new Class();
Popup.prototype = {
    iframeIdName: "ifr_popup",
    dialogBoxName: "dialogBox",
    initialize: function(A) {
        this.config = Object.extend({
            contentType: 1,
            isHaveTitle: true,
            scrollType: "no",
            isBackgroundCanClick: false,
            isSupportDraging: true,
            isShowShadow: true,
            isReloadOnClose: false,
            isTopCenter: false,
            isHasClose: true,
            width: 400,
            height: 300
        },
        A || {});
        this.info = {
            shadowWidth: 4,
            title: "",
            contentUrl: "",
            contentHtml: "",
            callBack: null,
            callBackCancel: null,
            parameter: null,
            confirmCon: "",
            alertCon: "",
            someHiddenTag: "object,embed",
            someHiddenEle: "",
            overlay: 0,
            coverOpacity: 40
        };
        this.color = {
            cColor: "#EEEEEE",
            bColor: "#FFFFFF",
            tColor: "#709CD2",
            wColor: "#FFFFFF"
        };
        this.dropClass = null;
        this.someToHidden = [];
        if (!this.config.isHaveTitle) {
            this.config.isSupportDraging = false
        }
        this.iniBuild()
    },
    setContent: function(A, B) {
        if (B != "") {
            switch (A) {
                case "width":
                    this.config.width = B;
                    break;
                case "height":
                    this.config.height = B;
                    break;
                case "title":
                    this.info.title = B;
                    break;
                case "contentUrl":
                    this.info.contentUrl = B;
                    break;
                case "contentHtml":
                    this.info.contentHtml = B;
                    break;
                case "callBack":
                    this.info.callBack = B;
                    break;
                case "callBackCancel":
                    this.info.callBackCancel = B;
                    break;
                case "parameter":
                    this.info.parameter = B;
                    break;
                case "confirmCon":
                    this.info.confirmCon = B;
                    break;
                case "alertCon":
                    this.info.alertCon = B;
                    break;
                case "someHiddenTag":
                    this.info.someHiddenTag = B;
                    break;
                case "someHiddenEle":
                    this.info.someHiddenEle = B;
                    break;
                case "overlay":
                    this.info.overlay = B;
                    break;
                case "isReloadOnClose":
                    this.config.isReloadOnClose = B
            }
        }
    },
    iniBuild: function() {
        if (G("dialogCase")) {
            G("dialogCase").parentNode.removeChild(G("dialogCase"))
        }
        var A = document.createElement("span");
        A.id = "dialogCase";
        document.body.insertBefore(A, document.body.firstChild)
    },
    build: function() {
        var B = 10001 + this.info.overlay * 10;
        var H = B + 2;
        this.iframeIdName = "ifr_popup" + this.info.overlay;
        var K = "http://img.baidu.com/hi/img/";
        var I = this.config.isHasClose ? '<input type="image" id="dialogBoxClose" src="' + K + 'dialogclose.gif" border="0" width="16" height="16" align="absmiddle" title="关闭"/>' : "";
        var F = "filter: alpha(opacity=" + this.info.coverOpacity + ");opacity:" + this.info.coverOpacity / 100 + ";";
        var D = Element.getBodyDimension();
        var C = D.scrollWidth;
        var A = D.scrollHeight;
        if (Browser.IE && !(document.compatMode && document.compatMode != "BackCompat")) {
            C -= 20;
            A += D.scrollTop
        }
        var J = '<div id="dialogBoxBG" style="position:absolute;top:0px;left:0px;width:' + C + "px;height:" + A + "px;z-index:" + B + ";" + F + "background-color:" + this.color.cColor + ';display:none;"></div>';
        var E = "<div id=" + this.dialogBoxName + ' style="border:1px solid ' + this.color.tColor + ";display:none;z-index:" + H + ";position:relative;width:" + this.config.width + 'px;"><table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="' + this.color.bColor + '">';
        if (this.config.isHaveTitle) {
            E += '<tr height="24" bgcolor="' + this.color.tColor + '"><td><table style="-moz-user-select:none;height:24px;" width="100%" border="0" cellpadding="0" cellspacing="0" ><tr><td width="6" height="24"></td><td id="dialogBoxTitle" style="color:' + this.color.wColor + ';font-size:14px;font-weight:bold;">' + this.info.title + '&nbsp;</td><td id="dialogClose" width="20" align="right" valign="middle">' + I + '</td><td width="6"></td></tr></table></td></tr>'
        } else {
            E += '<tr height="10"><td align="right">' + I + "</td></tr>"
        }
        E += '<tr style="height:' + this.config.height + 'px" valign="top"><td id="dialogBody" style="position:relative;"></td></tr></table></div><div id="dialogBoxShadow" style="display:none;z-index:' + B + ';"></div>';
        if (!this.config.isBackgroundCanClick) {
            G("dialogCase").innerHTML = J + E;
            G("dialogBoxBG").style.height = A
        } else {
            G("dialogCase").innerHTML = E
        }
        if (this.config.isHasClose) {
            Event.observe(G("dialogBoxClose"), "click", this.reset.bindAsEventListener(this), false)
        }
        if (this.config.isSupportDraging) {
            dropClass = new Dragdrop(this.config.width, this.config.height, this.info.shadowWidth, this.config.isSupportDraging, this.config.contentType);
            G("dialogBoxTitle").style.cursor = "move"
        }
        this.lastBuild()
    },
    lastBuild: function() {
        var B = '<div style="width:100%;height:100%;text-align:center;"><div style="margin:20px 20px 0 20px;font-size:14px;line-height:16px;color:#000000;">' + this.info.confirmCon + '</div><div style="margin:20px;"><input id="dialogOk" type="button" value="  确定  "/>&nbsp;<input id="dialogCancel" type="button" value="  取消  "/></div></div>';
        var E = '<div style="width:100%;height:100%;text-align:center;"><div style="margin:20px 20px 0 20px;font-size:14px;line-height:16px;color:#000000;">' + this.info.alertCon + '</div><div style="margin:20px;"><input id="dialogYES" type="button" value="  确定  "/></div></div>';
        var A = 10001 + this.info.overlay * 10;
        var D = A + 4;
        if (this.config.contentType == 1) {
            var C = "<iframe width='100%' style='height:" + this.config.height + "px' name='" + this.iframeIdName + "' id='" + this.iframeIdName + "' src='" + this.info.contentUrl + "' frameborder='0' scrolling='" + this.config.scrollType + "'></iframe>";
            var F = "<div id='iframeBG' style='position:absolute;top:0px;left:0px;width:1px;height:1px;z-index:" + D + ";filter: alpha(opacity=00);opacity:0.00;background-color:#ffffff;'><div>";
            G("dialogBody").innerHTML = C + F
        } else {
            if (this.config.contentType == 2) {
                G("dialogBody").innerHTML = this.info.contentHtml
            } else {
                if (this.config.contentType == 3) {
                    G("dialogBody").innerHTML = B;
                    Event.observe(G("dialogOk"), "click", this.forCallback.bindAsEventListener(this), false);
                    Event.observe(G("dialogCancel"), "click", this.close.bindAsEventListener(this), false)
                } else {
                    if (this.config.contentType == 4) {
                        G("dialogBody").innerHTML = E;
                        Event.observe(G("dialogYES"), "click", this.close.bindAsEventListener(this), false)
                    }
                }
            }
        }
    },
    reBuild: function() {
        G("dialogBody").height = G("dialogBody").clientHeight;
        this.lastBuild()
    },
    show: function() {
        this.hiddenSome();
        this.middle();
        if (this.config.isShowShadow) {
            this.shadow()
        }
    },
    forCallback: function() {
        return this.info.callBack(this.info.parameter)
    },
    shadow: function() {
        var A = G("dialogBoxShadow");
        var B = G(this.dialogBoxName);
        A.style["position"] = "absolute";
        A.style["background"] = "#000";
        A.style["display"] = "";
        A.style["opacity"] = "0.2";
        A.style["filter"] = "alpha(opacity=20)";
        A.style["top"] = B.offsetTop + this.info.shadowWidth + "px";
        A.style["left"] = B.offsetLeft + this.info.shadowWidth + "px";
        A.style["width"] = B.offsetWidth + "px";
        A.style["height"] = B.offsetHeight + "px"
    },
    middle: function() {
        if (!this.config.isBackgroundCanClick) {
            G("dialogBoxBG").style.display = ""
        }
        var F = G(this.dialogBoxName);
        var I = this.config.isTopCenter;
        F.style["position"] = "absolute";
        F.style["display"] = "";
        var C = I ? Element.getBodyDimension("top").clientWidth : Element.getBodyDimension().clientWidth;
        var E = I ? Element.getBodyDimension("top").clientHeight : Element.getBodyDimension().clientHeight;
        var B = I ? Element.getBodyDimension("top").scrollTop : Element.getBodyDimension().scrollTop;
        var D = ((I ? Element.getBodyDimension("top").clientWidth : Element.getBodyDimension().clientWidth) / 2) - (F.offsetWidth / 2);
        var H = (I ? -150 : -80) + (E / 2 + B) - (F.offsetHeight / 2);
        var A = H > 0 ? H : (E / 2 + B) - (F.offsetHeight / 2);
        if (A < 1) {
            A = "20"
        }
        if (D < 1) {
            D = "20"
        }
        F.style["left"] = D + "px";
        F.style["top"] = A + "px"
    },
    reset: function() {
        if (this.config.isReloadOnClose) {
            window.location.reload()
        }
        this.close()
    },
    close: function() {
        if (this.info.callBackCancel) {
            if (!this.info.callBackCancel()) {
                return
            }
        }
        G(this.dialogBoxName).style.display = "none";
        if (!this.config.isBackgroundCanClick) {
            G("dialogBoxBG").style.display = "none"
        }
        if (this.config.isShowShadow) {
            G("dialogBoxShadow").style.display = "none"
        }
        G("dialogBody").innerHTML = "";
        this.showSome()
    },
    hideSpecialEle: function() { },
    showSpecialEle: function() { },
    hiddenSome: function() {
        var A = this.info.someHiddenTag.split(",");
        if (A.length == 1 && A[0] == "") {
            A.length = 0
        }
        for (var B = 0; B < A.length; B++) {
            this.hiddenTag(A[B])
        }
        var C = this.info.someHiddenEle.split(",");
        if (C.length == 1 && C[0] == "") {
            C.length = 0
        }
        for (var B = 0; B < C.length; B++) {
            this.hiddenEle(C[B])
        }
        this.hideSpecialEle()
    },
    hiddenTag: function(B) {
        var C = document.getElementsByTagName(B);
        if (C != null) {
            for (var A = 0; A < C.length; A++) {
                if (C[A].style.display != "none" && C[A].style.visibility != "hidden") {
                    C[A].style.visibility = "hidden";
                    this.someToHidden.push(C[A])
                }
            }
        }
    },
    hiddenEle: function(B) {
        var A = document.getElementById(B);
        if (typeof (A) != "undefined" && A != null) {
            A.style.visibility = "hidden";
            this.someToHidden.push(A)
        }
    },
    showSome: function() {
        for (var A = 0; A < this.someToHidden.length; A++) {
            this.someToHidden[A].style.visibility = "visible"
        }
        this.showSpecialEle()
    },
    alert: function(A, B) {
        this.config.contentType = 4;
        this.setContent("alertCon", A);
        if (B) {
            this.setContent("callBack", B)
        }
        this.build();
        this.show()
    },
    confirm: function(B, A, C) {
        this.config.contentType = 3;
        this.config.isReloadOnClose = false;
        if (B) {
            this.setContent("title", B)
        }
        this.setContent("confirmCon", A);
        this.setContent("callBack", C);
        this.build();
        this.show()
    },
    html: function(B, A) {
        this.config.contentType = 2;
        if (A) {
            this.setContent("title", A)
        }
        this.setContent("contentHtml", B);
        this.build();
        this.show()
    },
    xwindow: function(A, B) {
        this.config.contentType = 1;
        if (B) {
            this.setContent("title", B)
        }
        this.setContent("contentUrl", A);
        this.build();
        this.show()
    }
};
var Dragdrop = new Class();
Dragdrop.prototype = {
    initialize: function(C, B, A, D, E) {
        this.dragData = null;
        this.dragDataIn = null;
        this.backData = null;
        this.width = C;
        this.height = B;
        this.shadowWidth = A;
        this.showShadow = D;
        this.contentType = E;
        this.IsDraging = false;
        this.oObj = G("dialogBox");
        Event.observe(G("dialogBoxTitle"), "mousedown", this.moveStart.bindAsEventListener(this), false)
    },
    moveStart: function(A) {
        this.IsDraging = true;
        if (this.contentType == 1) {
            G("iframeBG").style.display = "";
            G("iframeBG").style.width = this.width;
            G("iframeBG").style.height = this.height
        }
        Event.observe(document, "mousemove", this.mousemove.bindAsEventListener(this), false);
        Event.observe(document, "mouseup", this.mouseup.bindAsEventListener(this), false);
        Event.observe(document, "selectstart", this.returnFalse, false);
        this.dragData = {
            x: Event.pointerX(A),
            y: Event.pointerY(A)
        };
        this.backData = {
            x: parseInt(this.oObj.style.left),
            y: parseInt(this.oObj.style.top)
        }
    },
    mousemove: function(A) {
        if (!this.IsDraging) {
            return
        }
        var C = Event.pointerX(A) - this.dragData.x + parseInt(this.oObj.style.left);
        var B = Event.pointerY(A) - this.dragData.y + parseInt(this.oObj.style.top);
        if (this.dragData.y < parseInt(this.oObj.style.top)) {
            B = B - 12
        } else {
            if (this.dragData.y > parseInt(this.oObj.style.top) + 25) {
                B = B + 12
            }
        }
        this.oObj.style.left = C + "px";
        this.oObj.style.top = B + "px";
        if (this.showShadow) {
            G("dialogBoxShadow").style.left = C + this.shadowWidth + "px";
            G("dialogBoxShadow").style.top = B + this.shadowWidth + "px"
        }
        this.dragData = {
            x: Event.pointerX(A),
            y: Event.pointerY(A)
        };
        document.body.style.cursor = "move"
    },
    mouseup: function(C) {
        if (!this.IsDraging) {
            return
        }
        if (this.contentType == 1) {
            G("iframeBG").style.display = "none"
        }
        document.onmousemove = null;
        document.onmouseup = null;
        var B = Event.pointerX(C) - (Element.getBodyDimension().scrollLeft);
        var A = Event.pointerY(C) - (Element.getBodyDimension().scrollTop);
        if (B < 1 || A < 1 || B > Element.getBodyDimension().clientWidth || A > Element.getBodyDimension().clientHeight) {
            this.oObj.style.left = this.backData.x + "px";
            this.oObj.style.top = this.backData.y + "px";
            if (this.showShadow) {
                G("dialogBoxShadow").style.left = this.backData.x + this.shadowWidth + "px";
                G("dialogBoxShadow").style.top = this.backData.y + this.shadowWidth + "px"
            }
        }
        this.IsDraging = false;
        document.body.style.cursor = "";
        Event.stopObserving(document, "selectstart", this.returnFalse, false)
    },
    returnFalse: function() {
        return false
    }
};
var AlertPopup = {
    popup: null,
    alertMessage: function(A, B) {
        this.alert(A, "message", B)
    },
    alertError: function(A, B) {
        this.alert(A, "error", B)
    },
    alert: function(D, C, F) {
        this.popup = new Popup(D);
        if (F) {
            this.popup.setContent("callBackCancel", F)
        }
        var E = "";
        if (C == "message") {
            E = "http://static.tieba.baidu.com/tb/img/messageFace.gif"
        } else {
            if (C == "error") {
                E = "http://static.tieba.baidu.com/tb/img/errorFace.gif"
            }
        }
        var B = 280;
        if (D.width) {
            B = D.width - 60
        }
        var A = "<div style='margin: 12px 30px 0px 30px;font-size:14px;line-height:20px;text-align:left;font-family: \"宋体\";'><table style='width:90%'><tr><td width='60'><img src='" + E + "' style='border:none;'></td><td valign='middle' style='font-size:20px;line-height:22px;font-family: \"黑体\";'>" + D.messageTitle + "</td></tr></table>" + D.content + "<div style='text-align:center;width:" + B + "px;'><input style='margin:8px auto 0 auto;display:block' type='button' value='  确定  ' onclick='AlertPopup.popup.close()'></div></div>";
        this.popup.html(A, D.title)
    }
};
var Sel = new Class();
Sel.prototype = {
    initialize: function(B, A) {
        if (G(B)) {
            this.selObj = G(B);
            this.selDatas = A
        } else {
            return
        }
    },
    addSels: function() {
        var A = this.selDatas.length;
        for (var B = 0; B < A; B++) {
            if (typeof this.selDatas[B] == "Array") {
                this.addSel(this.selDatas[B][0], this.selDatas[B][0])
            } else {
                this.addSel(this.selDatas[B])
            }
        }
    },
    addSel: function() {
        var A = arguments.length,
        C = arguments[0],
        B = (A > 1) ? arguments[1] : C;
        this.selObj.options[this.selObj.length] = new Option(C, B)
    },
    selOption: function(B, C) {
        if (C == "value") {
            for (var A = 0; A < this.selObj.options.length; A++) {
                if (this.selObj.options[A].value.Alltrim() == B) {
                    this.selObj.selectedIndex = A;
                    break
                }
            }
        } else {
            if (C == "index") {
                this.selObj.selectedIndex = B
            }
        }
    }
};
var Suggest = new Class();
Suggest.prototype = {
    initialize: function(A, D, C) {
        this.inputBox = A;
        this.suggestArea = D;
        this.settings = {
            type: 0,
            data: [],
            url: "",
            pars: "",
            sg_width: 0,
            sg_Bcolor: "#f7941c",
            subSg_width: 120,
            subSg_Fcolor: "#666",
            subSg_Fsize: 12,
            SubSg2_Fcolor: "#666",
            subSg2_Fsize: 13,
            sg_num: 7,
            sg_h: 5,
            if2D: true,
            ifMulti: true,
            sugHv: "sugHv",
            sugItem: "sugItem",
            divide: ","
        };
        Object.extend(this.settings, C);
        this.rWords = [];
        this.suggestWords = [];
        if (this.settings.type == 0) {
            if (this.settings.if2D) {
                this.suggestWords = this.settings.data
            } else {
                for (var B = 0; B < this.settings.data.length; B++) {
                    this.suggestWords[B] = [this.settings.data[B], ""]
                }
            }
        }
        this.switchkey = 1;
        this.index = 0;
        this.readyWordNum = -1;
        this.prefix = "";
        Event.observe(document, "click", this.outClick.bindAsEventListener(this), false);
        G(this.inputBox).onkeyup = this.keyUpdateSuggest.bindAsEventListener(this);
        Event.observe(G(this.suggestArea), "click", this.selectSuggest.bindAsEventListener(this), false)
    },
    outClick: function(B) {
        if (G("vAlbum")) {
            G("vAlbum").style.visibility = "visible"
        }
        var A = Event.element(B);
        if (A.id != this.inputBox && A.id != this.suggestArea) {
            Element.hide(this.suggestArea);
            return
        }
    },
    getValue: function(A) {
        return this.settings.ifMulti ? A.replace(/^[\,\;\，\；\、]+/, "").replace(/[^\,\;\，\；\、]+[\,\;\，\；\、]+/g, "") : A
    },
    getKeycode: function(B) {
        var A = -1;
        if (navigator.userAgent.indexOf("MSIE") != -1) {
            A = event.keyCode
        } else {
            A = B.which
        }
        return A
    },
    setCursor: function(D, A, E) {
        if (navigator.userAgent.indexOf("Mozilla/5.") != -1) {
            D.setSelectionRange(A, E + A)
        } else {
            if (navigator.userAgent.indexOf("MSIE") != -1) {
                var B = D.createTextRange();
                B.collapse();
                B.select();
                var C = document.selection.createRange();
                B.collapse();
                C.moveStart("character", A);
                C.moveEnd("character", E);
                C.select()
            }
        }
    },
    suggestInputBox: function(A) {
        var B = A.value;
        A.value = B.replace(/([^\,\;\，\；\、]*)$/, "") + G(this.suggestArea + "_" + this.readyWordNum).firstChild.innerHTML.unescapeHTML() + (this.settings.ifMulti ? this.settings.divide : "")
    },
    selectSuggest: function(A) {
        if (!A) {
            A = window.event
        }
        A.cancelBubble = true;
        if (this.readyWordNum < 0) {
            return
        }
        this.suggestInputBox(G(this.inputBox));
        len = G(this.inputBox).value.length;
        G(this.inputBox).focus();
        this.setCursor(G(this.inputBox), len, 0);
        Element.hide(this.suggestArea);
        this.readyWordNum = -1
    },
    changeReadyWord: function(B) {
        var A = Event.element(B);
        G(this.suggestArea + "_" + this.readyWordNum).className = this.settings.sugItem;
        if (A.tagName == "SPAN") {
            A = A.parentNode
        }
        this.readyWordNum = parseInt(A.id.split("_")[1]);
        A.className = this.settings.sugHv
    },
    changeWordonKey: function(B) {
        var A = G(this.suggestArea);
        var C = B.offsetTop - A.scrollTop + 1;
        if (C >= 25 * this.settings.sg_h) {
            A.scrollTop += 25
        }
        if (C < 0) {
            A.scrollTop -= 25
        }
        if (this.readyWordNum >= 0) {
            G(this.suggestArea + "_" + this.readyWordNum).className = this.settings.sugItem
        }
        B.className = this.settings.sugHv;
        this.readyWordNum = parseInt(B.id.split("_")[1])
    },
    genSuggestItem: function(D, A, C) {
        var B = document.createElement("div");
        B.id = this.suggestArea + "_" + A;
        B.className = this.settings.sugItem;
        B.innerHTML = "<span style='float:left;text-align:left;height:19px;width:" + this.settings.subSg_width + "px;font-size:" + this.settings.subSg_Fsize + "px'>" + D.escapeHTML() + "</span><span style='float:right;text-align:right;height:19px;font-size:" + this.settings.subSg2_Fsize + "px'>" + C + "</span>";
        B.onmouseover = this.changeReadyWord.bindAsEventListener(this);
        return B
    },
    keyChoose: function(B) {
        var A = this.getKeycode(B);
        switch (A) {
            case 38:
                this.setCursor(G(this.inputBox), G(this.inputBox).value.length, 0);
                if (this.readyWordNum > 0 && this.switchkey == 1) {
                    this.changeWordonKey(G(this.suggestArea + "_" + (this.readyWordNum - 1)))
                }
                return true;
                break;
            case 40:
                if (G(this.suggestArea + "_" + (this.readyWordNum + 1)) && this.switchkey == 1) {
                    this.changeWordonKey(G(this.suggestArea + "_" + (this.readyWordNum + 1)))
                }
                return true;
                break;
            case 13:
                if (this.switchkey == 1) {
                    this.selectSuggest(B)
                }
                return true;
                break;
            case 8:
                return false;
                break;
            case 37:
                return true;
                break;
            case 39:
                return true;
                break;
            case 16:
                if (this.switchkey == 1) {
                    this.switchkey = 0;
                    Element.hide(this.suggestArea);
                    return true
                } else {
                    this.switchkey = 1;
                    return false
                }
                break;
            default:
                return false
        }
    },
    initSatus: function(A) {
        if (A > 0) {
            if (A > 1 && G("vAlbum")) {
                G("vAlbum").style.visibility = "hidden"
            }
            Element.show(this.suggestArea);
            if (this.settings.sg_width == 0) {
                G(this.suggestArea).style.width = (Element.getWidth(this.inputBox) - 1) + "px"
            } else {
                G(this.suggestArea).style.width = this.settings.sg_width + "px"
            }
            G(this.suggestArea).scrollTop = "0px";
            this.changeWordonKey(G(this.suggestArea + "_0"))
        } else {
            Element.hide(this.suggestArea);
            this.readyWordNum = -1
        }
    },
    keyUpdateSuggest: function(A) {
        if (G("DivTagLayer")) {
            VideoUpload.chkIsSld()
        }
        if (this.keyChoose(A) || this.switchkey == 0) {
            return
        }
        if (this.index == 0) {
            this.index = 1;
            if (G("vAlbum")) {
                G("vAlbum").style.visibility = "visible"
            }
            setTimeout(this.updateSuggest.bindAsEventListener(this), 300)
        }
    },
    matchWords: function(C, D) {
        var B = [];
        for (var A = 0; A < D.length; A++) {
            if (D[A][0].length >= C.length && D[A][0].substring(0, C.length).toLowerCase() == C.toLowerCase()) {
                B.push([D[A][0], D[A][1]])
            }
        }
        return B
    },
    updateSuggest: function(H) {
        this.prefix = this.getValue(G(this.inputBox).value);
        this.index = 0;
        var B = 0;
        if (this.prefix) {
            if (!this.rWords[this.prefix]) {
                if (this.settings.type == 1) {
                    this.getData(this, this.prefix)
                } else {
                    G(this.suggestArea).innerHTML = "";
                    G(this.suggestArea).style.height = "";
                    this.dest = [];
                    var F = this.matchWords(this.prefix, this.suggestWords);
                    var A = F.length > this.settings.sg_num ? this.settings.sg_num : F.length;
                    for (var D = 0; D < A; D++) {
                        this.dest[B] = this.genSuggestItem(F[D][0], B, F[D][1]);
                        G(this.suggestArea).appendChild(this.dest[B]);
                        B++
                    }
                    if (B > this.settings.sg_h) {
                        G(this.suggestArea).style.height = 25 * this.settings.sg_h + "px"
                    }
                    this.rWords[this.prefix] = G(this.suggestArea).innerHTML;
                    this.initSatus(B)
                }
            } else {
                G(this.suggestArea).style.height = "";
                G(this.suggestArea).innerHTML = this.rWords[this.prefix];
                var E = G(this.suggestArea).childNodes;
                B = E.length;
                for (var C = 0; C < B; C++) {
                    E[C].onmouseover = this.changeReadyWord.bindAsEventListener(this)
                }
                if (B > this.settings.sg_h) {
                    G(this.suggestArea).style.height = 25 * this.settings.sg_h + "px"
                }
                this.initSatus(B)
            }
        } else {
            this.initSatus(0)
        }
    },
    getData: function(self, word) {
        var _items = [];
        new Ajax.Request(self.settings.url, {
            method: "get",
            parameters: self.settings.pars,
            onComplete: function(xmlHttp) {
                var jsonResults = "(" + unescape(xmlHttp.responseText) + ")";
                var Items = eval(jsonResults);
                var totalSugs = 0;
                for (var i = 0; i < Items.items.length; i++) {
                    if (self.settings.if2D) {
                        _items[i] = [Items.items[i].tagName, Items.items[i].tagItemNum]
                    } else {
                        _items[i] = [Items.items[i].tagName, ""]
                    }
                }
                self.suggestWords = _items;
                var len = self.suggestWords.length > self.settings.sg_num ? self.settings.sg_num : self.suggestWords.length;
                G(self.suggestArea).innerHTML = "";
                G(self.suggestArea).style.height = "";
                self.dest = [];
                for (i = 0; i < len; i++) {
                    self.dest[totalSugs] = self.genSuggestItem(self.suggestWords[i][0], totalSugs, self.suggestWords[i][1]);
                    G(self.suggestArea).appendChild(self.dest[totalSugs]);
                    totalSugs++
                }
                if (totalSugs > self.settings.sg_h) {
                    G(self.suggestArea).style.height = 25 * self.settings.sg_h + "px"
                }
                self.rWords[self.prefix] = G(self.suggestArea).innerHTML;
                self.initSatus(totalSugs)
            }
        })
    }
};
var Tip = new Class();
Tip.prototype = {
    initialize: function(B, A) {
        this.config = {
            eventStart: "mouseover",
            eventClose: "",
            width: 100,
            height: 0,
            moveLeft: 0,
            moveTop: 15,
            arrowMoveLeft: 0,
            isDirectIcon: true,
            isCloseIcon: true,
            tipInfo: ""
        };
        this.object = B;
        this.setConfig(A)
    },
    setConfig: function(A) {
        Object.extend(this.config, A);
        this.build()
    },
    build: function() {
        G(this.object)["on" + this.config.eventStart] = this.showTip.bindAsEventListener(this)
    },
    showTip: function(A) {
        if (!G("BaiduTipDiv")) {
            this.createTip()
        } else {
            this.BaiduTipDiv = G("BaiduTipDiv")
        }
        G("BaiduTipDiv").style.display = "";
        this.initTipStatus()
    },
    hideTip: function() {
        if (G("BaiduTipDiv")) {
            G("BaiduTipDiv").style.display = "none"
        }
    },
    chgPostion: function(A) {
        var A = A || window.event;
        var C = A.pageX || A.clientX;
        var B = A.pageY || A.clientY;
        this.BaiduTipDiv.style.left = C + "px";
        this.BaiduTipDiv.style.top = B + "px"
    },
    createTip: function() {
        var A = document.createElement("div");
        A.id = "BaiduTipDiv";
        A.style.width = this.config.width + "px";
        A.style.position = "absolute";
        A.style.zIndex = "999";
        var B = "<div style='height:170px;width:450px;background:url(http://static.tieba.baidu.com/static/tb/img/videoFormatBImg.gif) no-repeat'><div style='width:100%;text-align:right'><img id='closeImg' src='http://static.tieba.baidu.com/static/tb/img/close2.gif' border='0' style='cursor:pointer;position:absolute;margin:20px -25px;' ></div><div style='padding: 30px 10px 30px 15px;line-height:24px'>" + this.config.tipInfo + "</div>";
        A.innerHTML = B;
        document.body.appendChild(A);
        this.BaiduTipDiv = A
    },
    initTipStatus: function(A) {
        G("closeImg")["onclick"] = this.closeTip.bindAsEventListener(this);
        this.setPosition()
    },
    closeTip: function() {
        G("BaiduTipDiv").style.display = "none"
    },
    setPosition: function() {
        var A = this.getPosition();
        this.BaiduTipDiv.style.left = A[0] + "px";
        this.BaiduTipDiv.style.top = A[1] + "px"
    },
    getPosition: function(H, F) {
        var C = document.documentElement.clientWidth;
        var J = document.documentElement.clientHeight;
        var A = this.BaiduTipDiv.offsetWidth;
        var I = this.BaiduTipDiv.offsetHeight;
        var B = this.returnIeVer();
        var D = ((B < 7) ? this.findPosX(this.object) : this.findPosX(this.object)) - this.config.moveLeft;
        var E = this.findPosY(this.object) + 10;
        if ((D + A) > C) {
            D -= A
        }
        if (E < 0) {
            E += parseInt(I) + parseInt(this.object.offsetHeight) + this.config.moveTop + 10
        }
        return [D, E]
    },
    findPosX: function(A) {
        var B = 0;
        if (A.offsetParent) {
            while (A.offsetParent) {
                B += A.offsetLeft;
                A = A.offsetParent
            }
        } else {
            if (A.x) {
                B += A.x
            }
        }
        return B
    },
    findPosY: function(B) {
        var A = 0;
        if (B.offsetParent) {
            while (B.offsetParent) {
                A += B.offsetTop;
                B = B.offsetParent
            }
        } else {
            if (B.y) {
                A += B.y
            }
        }
        return A
    },
    returnIeVer: function() {
        var A = navigator.userAgent.toLowerCase(),
        C = A.indexOf("msie"),
        B = "";
        if (C > 0) {
            B = A.substr(C + 4);
            B = B.replace(/(^[　\s]+)|([　\s]+$)/g, "").substr(0, 1);
            if (parseInt(B) == "NaN") {
                return 0
            }
            return parseInt(B)
        } else {
            return -1
        }
    }
};
function creatPager(F, D, J, H) {
    var F = parseInt(F);
    var D = parseInt(D);
    var J = parseInt(J);
    var A = [];
    var C, B;
    var I = (J - 1) / 2;
    var E = I;
    if (D > 1) {
        if (F > D) {
            F = D
        }
        if (F == 1) {
            C = 1;
            if (D > J) {
                B = J
            } else {
                B = D
            }
        } else {
            if (F <= I) {
                if (D > 4) {
                    A.push(' <a href="#" onclick="' + H + '(1); return false;"> 首页</a>  <a href="#" onclick="' + H + "(" + (F - 1) + '); return false;">上一页</a> ')
                } else {
                    A.push('<a href="#" onclick="' + H + "(" + (F - 1) + '); return false;">上一页</a> ')
                }
                C = 1;
                if (D > J) {
                    B = J
                } else {
                    B = D
                }
            } else {
                A.push(' <a href="#" onclick="' + H + '(1); return false;"> 首页</a>  <a href="#" onclick="' + H + "(" + (F - 1) + '); return false;">上一页</a> ');
                C = F - E;
                if ((D - F) <= I) {
                    B = D;
                    if (D >= J) {
                        if ((D - (J - 1)) > 0) {
                            C = D - (J - 1)
                        }
                    }
                } else {
                    B = F + I
                }
            }
        }
        for (; C <= B; C++) {
            if (C == F) {
                A.push(" <span>" + C + "</span> ")
            } else {
                A.push(' <a href="#" onclick="' + H + "(" + C + '); return false;"> [' + C + "]</a> ")
            }
        }
        if (F != D) {
            if (D <= 4) {
                A.push(' <a href="#" onclick="' + H + "(" + (F + 1) + '); return false;">下一页</a>')
            } else {
                A.push(' <a href="#" onclick="' + H + "(" + (F + 1) + '); return false;">下一页</a> <a href="#" onclick="' + H + "(" + D + '); return false;">尾页</a>')
            }
        }
    }
    return A.join("")
}
function myPopLogin(B) {
    var A = new Popup({
        width: 370,
        height: 300
    });
    A.xwindow("https://passport.baidu.com/?login&psp_tt=2&tpl=tb&fu=" + escape(B) + "&u=" + escape(top.location), "您尚未登录")
}
function passPopLogin() {
    var A = new Popup({
        width: 370,
        height: 300
    });
    A.xwindow("https://passport.baidu.com/?login&psp_tt=2&tpl=tb&fu=http%3A//tieba.baidu.com/tb/TBjump.html%3Ftype%3D0&u=" + escape(top.location), "您尚未登录")
};