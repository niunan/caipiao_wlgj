function registerBeforSubmit(){
	var type=$('[name=type]:checked',this).val();
	if(!this.username.value) throw('没有输入用户名');
	if(!/^\w{4,16}$/.test(this.username.value)) throw('用户名由4到16位的字母、数字及下划线组成');
	if(!this.password.value) throw('请输入密码');
	if(this.password.value.length<6) throw('密码至少6位');
	if(!this.cpasswd.value) throw('请输入确认密码');
	if(this.cpasswd.value!=this.password.value) throw('两次输入密码不一样');
	if(!this.name.value) throw('请输入真实姓名');
	if(!this.coinpwd.value) throw('请输入取款密码');
	if(this.coinpwd.value.length<6) throw('取款密码至少6位');
	if(this.password.value==this.coinpwd.value) throw('登陆密码和取款密码不能相同');
	if(!this.email.value) throw('请输入电子邮箱');
	var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,5}$/;
	if(!myreg.test(this.email.value)) throw('电子邮箱输入不正确');
}
function registerSubmit(err,data){
	if(err){
		alert(err);
	}else{
		//alert(data);
		location='/';
	}
	$("#vcode").trigger("click");
}
function userBeforeLogin(){
	var u=this.username.value;
	var v=this.vcode.value;
	if(!u || u=='帐号'){throw("请输入用户名");}
	if(!v || v=='验证码'){throw("请输入验证码");}
}
function userLogin(err, data){
	if(err){
		alert(err);
		$('input[name=vcode]')
		.val('')
		.closest('div')
		.find('.ico-code img')
		.click();
	}else{
		location='/';
		//location='/index.php/user/loginto';
	}
}
function userBeforeLoginto(){
    var u=this.username.value;
	var p=this.password.value;
	var v=this.vcode.value;
	if(!u || u=='帐号'){throw("请输入用户名");}
	if(!p || p=='xx@x@x.x'){throw("请输入密码");}
	if(!v || v=='验证码'){throw("请输入验证码");}
}
function userLoginto(err, data){
	if(err){
		alert(err);
		
	}else{
		location='/';
	}
}

function myBrowser() {
    var l = navigator.userAgent;
    var b = l.indexOf("Opera") > -1;
    var e = l.indexOf("compatible") > -1 && l.indexOf("MSIE") > -1 && !b;
    var c = l.indexOf("Firefox") > -1;
    var j = l.indexOf("Safari") > -1;
    var a = l.indexOf("Chrome") > -1;
    if (e) {
        var g = IE55 = IE6 = IE7 = IE8 = false;
        var k = new RegExp("MSIE (\\d+\\.\\d+);");
        k.test(l);
        var f = parseFloat(RegExp["$1"]);
        IE55 = f == 5.5;
        IE6 = f == 6;
        IE7 = f == 7;
        IE8 = f == 8;
        if (IE55) {
            return "IE55"
        }
        if (IE6) {
            return "IE6"
        }
        if (IE7) {
            return "IE7"
        }
        if (IE8) {
            return "IE8"
        }
    }
    if (c) {
        return "FF"
    }
    if (b) {
        return "Opera"
    }
    if (a) {
        return "Chrome"
    }
}
var browser = myBrowser();
if (browser == "IE55" || browser == "IE6" || browser == "IE7" || browser == "IE8") {
    window.location.href = "/browser.html";
    /*! LAB.js (LABjs :: Loading And Blocking JavaScript)
    v2.0.3 (c) Kyle Simpson
    MIT License
*/
}