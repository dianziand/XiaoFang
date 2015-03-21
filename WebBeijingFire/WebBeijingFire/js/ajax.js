
//该函数可以创建我们需要的XMLHttpRequest对象 
function getHTTPObject() {
    var xmlhttp = false;
    if (window.XMLHttpRequest) {
        xmlhttp = new XMLHttpRequest();
        if (xmlhttp.overrideMimeType) {
            xmlhttp.overrideMimeType('text/xml');
        }
    } else {
        try {
            xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (E) { xmlhttp = false; }
        }
    }
    return xmlhttp;
}
function getBiaoZhunStatus(tt) {
    url = "<a href=http://www.csres.com/s.jsp?keyword=" + escape(tt.value) + " target=_blank >查看标准状态</a>";
    document.getElementById("StatusID").innerHTML = url;
}




function getValueReturn(url) {
    var xmlhttp1 = getHTTPObject();
    xmlhttp1.open("GET", url, true);
    xmlhttp1.onreadystatechange = function() {
        if (xmlhttp1.readyState == 4) {
            if (xmlhttp1.status == 200) {
                var nums = xmlhttp1.responseText;
                if (nums > 0) {
                    alert("该标准已经存在，请不要重复添加！");
                }
            }
        }
    }
    xmlhttp1.send(null);
}


function ffffff(tt) {
    url = "/a/GetArticleNums.aspx?Title="
    url = url + tt.value;
    if (tt.value.length > 0) {
        getValueReturn(url);
    }
}

function ffffff1(tt) {
    url = "/a/GetArticleNumsByNo.aspx?No="
    url = url + escape(tt.value);
    if (tt.value.length > 0) {
        getValueReturn(url);
    }
}


function YanzhengUserName(tt) {
    url = "/GetUserNameNums.aspx?UserName="
    url = url + tt.value;
    if (tt.value.length > 0) {
        getUserNameReturn(url);
    }
}

function getUserNameReturn(url) {
    var xmlhttp1 = getHTTPObject();
    xmlhttp1.open("GET", url, true);
    xmlhttp1.onreadystatechange = function() {
        if (xmlhttp1.readyState == 4) {
            if (xmlhttp1.status == 200) {
                var nums = xmlhttp1.responseText;
                if (nums > 0) {
                    alert("该用户已经存在！请重新选择一个用户名！");
                }
            }
        }
    }
    xmlhttp1.send(null);
}

function getEmailReturn(url) {
    var xmlhttp1 = getHTTPObject();
    xmlhttp1.open("GET", url, true);
    xmlhttp1.onreadystatechange = function() {
        if (xmlhttp1.readyState == 4) {
            if (xmlhttp1.status == 200) {
                var nums = xmlhttp1.responseText;
                if (nums > 0) {
                    alert("该email已经被注册过！！");
                }
            }
        }
    }
    xmlhttp1.send(null);
}


function getEmailByTeleReturn(url) {
    var xmlhttp1 = getHTTPObject();
    xmlhttp1.open("GET", url, true);
    xmlhttp1.onreadystatechange = function() {
        if (xmlhttp1.readyState == 4) {
            if (xmlhttp1.status == 200) {
                var email1 = xmlhttp1.responseText;
                if (email1.length > 0) {
                    document.getElementById('ctl00_ContentPlaceHolder1_TxtEmail').value = email1;
                }
            }
        }
    }
    xmlhttp1.send(null);
}


function YanzhengEmail(tt) {
    url = "/GetEmailNums.aspx?Email="
    url = url + tt.value;
    if (tt.value.length > 0) {
        getEmailReturn(url);
    }
}
function GetEmailByTele(tt) {
    url = "/GetEmailByTele.aspx?Tele="
    url = url + tt.value;
    if (tt.value.length > 0) {
        getEmailByTeleReturn(url);
    }
}



function getClass1IDByJianXie(url) {
    var xmlhttp1 = getHTTPObject();
    xmlhttp1.open("GET", url, true);
    xmlhttp1.onreadystatechange = function() {
        if (xmlhttp1.readyState == 4) {
            if (xmlhttp1.status == 200) {
                var nums = xmlhttp1.responseText;


                if (nums > 0) {


                    var DrpClass1ID1 = document.getElementById('DrpClass1ID');

                    for (var i = 0; i < DrpClass1ID1.options.length; i++) {
                        if (DrpClass1ID1.options[i].value == nums) {
                            DrpClass1ID1.options[i].selected = true;
                        }
                    }

                }
            }
        }
    }
    xmlhttp1.send(null);
}


function getClass1IDByJianXieUser(url) {
    var xmlhttp1 = getHTTPObject();
    xmlhttp1.open("GET", url, true);
    xmlhttp1.onreadystatechange = function() {
        if (xmlhttp1.readyState == 4) {
            if (xmlhttp1.status == 200) {
                var nums = xmlhttp1.responseText;


                if (nums > 0) {


                    var DrpClass1ID1 = document.getElementById('ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_DrpClass1ID');

                    for (var i = 0; i < DrpClass1ID1.options.length; i++) {
                        if (DrpClass1ID1.options[i].value == nums) {
                            DrpClass1ID1.options[i].selected = true;
                        }
                    }

                }
            }
        }
    }
    xmlhttp1.send(null);
}




function Class1JianXie(tt) {
    url = "/a/GetClass1IDByJianXie.aspx?JianXie="
    url = url + tt.value;
    if (tt.value.length > 0) {
        getClass1IDByJianXie(url);
    }
}


function Class1JianXieUser(tt) {
    url = "/a/GetClass1IDByJianXie.aspx?JianXie="
    url = url + tt.value;
    if (tt.value.length > 0) {
        getClass1IDByJianXieUser(url);
    }
}
