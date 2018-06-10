var __isLocal = false;
var localConfig = {
    apiPath: "",
    staticPath: "http://127.0.0.1/static/",
    webUrl: "",
   	gameUrl: "",
    mobileUrl: ""
};
var onlineConfig = function() {
    return {
        apiPath: "",
        staticPath: "/static/",
        webUrl: "http://www." + getRootDomain(),
        gameUrl: "",
        mobileUrl: "http://m." + getRootDomain()
    }
};
function getDomainConfig(a) {
    if (typeof(a) == "boolean") {
        __isLocal = a
    }
    if (__isLocal) {
        return localConfig
    } else {
        return onlineConfig()
    }
}
function getRootDomain() {
    var b = "";
    var a = location.hostname.split(".");
    if (a.length > 2) {
        b = a.slice(a.length - 2).join(".")
    } else {
        b = a.join(".")
    }
    return b
}
var domainConfig = getDomainConfig(__isLocal);
function guestLogin() {
    /*if (!domainConfig.gameUrl) {
        alert("无法登录游客系统，请联系管理员");
        return
    }*/
    $.ajax({
        type: "POST",
        url: domainConfig.gameUrl + "/api/guestLogin.do",
        data: {
            username: "!guest!",
            password: "!guest!"
        },
        dataType: "text",
        success: function(a) {
            if (a=='ok') {
                window.location.href = domainConfig.gameUrl + "/"
            } else {
                alert(a || "登录失败");
				return false;
            }
        },
        error: function(a) {
            alert("登录失败");
			return false;
        }
    })
}
function browserRedirect() {
    var sUserAgent = navigator.userAgent.toLowerCase();
    //var bIsIpad = sUserAgent.match(/ipad/i) == "ipad";
    var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
    var bIsMidp = sUserAgent.match(/midp/i) == "midp";
    var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
    var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
    var bIsAndroid = sUserAgent.match(/android/i) == "android";
    var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
    var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile";
    if (( bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM) )
	{
		window.location.href=domainConfig.mobileUrl;  //
	}
}
//browserRedirect();