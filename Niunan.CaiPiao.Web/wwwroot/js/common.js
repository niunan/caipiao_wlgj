//iframe 自适应高度
//function iFrameHeight(elementid) {
//    var ifm = document.getElementById(elementid);
//    var subWeb = document.frames ? document.frames[elementid].document : ifm.contentDocument;
//    if (ifm != null && subWeb != null) {
//        ifm.height = subWeb.body.scrollHeight+10;
//    }
//}

// param srcStr表示要格式化的数 param nAfterDot 要保留的位数
function FormatNumber(srcStr, nAfterDot) {
    var srcStr, nAfterDot;
    var resultStr, nTen;
    srcStr = "" + srcStr + "";
    strLen = srcStr.length;
    dotPos = srcStr.indexOf(".", 0);
    if (dotPos == -1) {
        resultStr = srcStr + ".";
        for (i = 0; i < nAfterDot; i++) {
            resultStr = resultStr + "0";
        }
        return resultStr;
    }
    else {
        if ((strLen - dotPos - 1) >= nAfterDot) {
            nAfter = dotPos + nAfterDot + 1;
            nTen = 1;
            for (j = 0; j < nAfterDot; j++) {
                nTen = nTen * 10;
            }
            resultStr = Math.round(parseFloat(srcStr) * nTen) / nTen;
            return resultStr;
        }
        else {
            resultStr = srcStr;
            for (i = 0; i < (nAfterDot - strLen + dotPos + 1); i++) {
                resultStr = resultStr + "0";
            }
            return resultStr;
        }
    }
}

 
/*复制文本到剪切板*/
function copyToClipboard(txt) {
    if (window.clipboardData) {
        window.clipboardData.clearData();
        window.clipboardData.setData("Text", txt);
        //alert("复制成功.");
    } else if (navigator.userAgent.indexOf("Opera") != -1) {
        window.location = txt;
    } else if (window.netscape) {
        try {
            netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
        } catch (e) {
            alert("被浏览器拒绝！\n请在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
        }
        var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
        if (!clip)
            return;
        var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
        if (!trans)
            return;
        trans.addDataFlavor('text/unicode');
        var str = new Object();
        var len = new Object();
        var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
        var copytext = txt;
        str.data = copytext;
        trans.setTransferData("text/unicode", str, copytext.length * 2);
        var clipid = Components.interfaces.nsIClipboard;
        if (!clip)
            return false;
        clip.setData(trans, null, clipid.kGlobalClipboard);
        alert("复制成功.");
    }
}

function addCookie(objName, objValue, objHours) {//添加cookie
    var str = objName + "=" + escape(objValue);
    if (objHours > 0) {//为0时不设定过期时间，浏览器关闭时cookie自动消失
        var date = new Date();
        var ms = objHours * 3600 * 1000;
        date.setTime(date.getTime() + ms);
        str += "; expires=" + date.toGMTString();
    }
    document.cookie = str;
}

function getCookie(objName) {//获取指定名称的cookie的值
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);
    }
}

/*substr*/
function cutStr(str, len) {
    if (str.length > len) {
        str = str.substr(0, len);
        str += "...";
    }
    return str;
}
 
 
 
 
//去的页面参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}

/*添加号码到号码列表，计算注数金额等*/
function add_haoma() {
    var czid = $('#czid').val();
    var wfid = $('#wfid').val();
    var wfname = GetWanFaName(wfid);

    var code = GetXiaZhuCode(wfid); //取下注号

    if (code.indexOf('error') > -1) { alert(code); return; }

    var zhushu = $().ZhushuFactory(wfid, code); //取注数

    var beishu = $('#beishu').val(); //倍数
    if (!parseInt(beishu) || parseInt(beishu) < 1) {
        beishu = 1;
    }

    var yjf_obj = $(".model").find(".selected");
    var yjf = parseFloat(yjf_obj.attr('title')); //元角分
    var yjf_str = yjf_obj.text();

    var total_price = parseInt(zhushu) * parseInt(beishu) * yjf;

    var jiangjin = $('#div_jiangjin').text(); //奖金
    var fandian = $('#div_fandian').text(); //返点

    var position = $('#position').val(); //位置 

    //  console.log('采种ID：' + czid + '，玩法ID：' + wfid + '，玩法名称：' + wfname + '，下注号：' + code + "， 注数：" + zhushu);

    var html = '';
    html += '<table class="item">';
    html += '<tr>';
    html += '    <td class="text">';
    html += '        [' + wfname + ']' + code;
    html += '    <input type="hidden" value="' + wfid + '" class="wfid" />';
    html += '    <input type="hidden" value="' + position + '" class="position" />';
    html += '    <input type="hidden" value="' + yjf + '" class="yjf" />';
    html += '    </td>';
    html += '    <td class="beishu">' + beishu + '倍</td>';
    html += '    <td class="nums">' + zhushu + '注</td>';
    html += '    <td class="yjf_str">模式（' + yjf_str + '）</td>';
    html += '    <td class="money">' + total_price + '元</td>';
    html += '    <td style="text-align:right;"><span class="jiangjin">' + jiangjin + '</span>元</td>';
    html += '    <td class="remove" onclick="remove_haoma(this)">';
    html += '        <a data-command="remove" class="layui-icon">&#x1006;</a>';
    html += '    </td>';
    html += '</tr>';
    html += '</table>';
    $('.lottery-record .list').append(html);
    $('.balls .selected').removeClass('selected');
}


/*号码列表里的移除按钮*/
function remove_haoma(thisobj) {
    $(thisobj).parents('.item').remove();

}


/*清空号码列表*/
function clear_haoma() {
    $('.lottery-record .list').html('');
    $('.balls .selected').removeClass('selected');
}

/*取提交到后台的一大串下注号拼接   下注号#注数#玩法ID#元角分#倍数$...*/
function GetXiaZhuCode_sub() {
    var code = "";
    if ($('.lottery-record .list .item').length != 0) {
        $('.lottery-record .list .item').each(function () {
            var obj = $(this);
            var one_wfid = obj.find('.wfid').val();
            var one_xiazhuhao = $.trim(obj.find('.text').text()).split(']')[1];
            var one_zhushu = obj.find('.nums').text().replace('注', '');
            var one_yjf = obj.find('.yjf').val();
            var one_beishu = obj.find('.beishu').text().replace('倍', '');

            code += one_xiazhuhao + "#" + one_zhushu + "#" + one_wfid  + "#" + one_yjf + "#" + one_beishu + "$";
        })
    }
    if (code != '') {
        code = code.substring(0, code.length - 1);
    }
    console.log(code);
    return code;
}

/*投注按钮，弹窗提示是否确认投注*/
function touzhu() {
    layui.use('layer', function () {
        var layer = layui.layer;

        var code = GetXiaZhuCode_sub();//多个下注单号拼接
        if (code == '') {
            layer.alert('请先选择下注号！');
            return;
        }
        var czid = $('#czid').val(); //采种ID 


        var qihao = $('#span_currentqihao').text();//期号
        var basemoshi = $('#Hd_BaseMoshi').val(); //基本模式，buyrecord表中的moshi字段存的是该值，jiangjin字段存的是上面滑块右边的奖金


        var url = "/xiazhuinfo/Add";
        var postdata = { code: code, czid: czid, qihao: qihao, basemoshi };

        var pop_html = GetPopHtml(); //取弹出来的内容HTML

        

        var close_index = layer.open({
            type: 1,
            title: '您的投注如下：',
            yes: function () { 
                $.post(url, postdata, function (json) {
                    layer.alert(json.msg);
                    gethistory();
                    clear_haoma();
                }, 'json');
                layer.close(close_index);
                
            },
            btn: ['确认投注'],
            content: pop_html
        });
    })
}

