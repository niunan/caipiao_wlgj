 /*根据玩法ID和下注号计算注数*/
function GetZhuShu(wfid, code) {
    console.log("GetZhuShu方法中，玩法ID："+wfid+"，下注号："+code);
    var zhushu = 1; 
    switch (parseInt(wfid)) {
        case 1011100: //五星直选复式 
            var arr = code.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    zhushu = zhushu * arr[i].length;
                }
            }
            break;
        case 1011101://五星直选单式
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 11101001: //前四直选复式
            var arr = code.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    zhushu = zhushu * arr[i].length;
                }
            }
            break;
        case 1100100://后四直选复式
            var arr = code.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    zhushu = zhushu * arr[i].length;
                }
            }
            break;
        case 11101010://前四直选单式
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 1100101://后四直选单式
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 0://前三直选复式
            var arr = code.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    zhushu = zhushu * arr[i].length;
                }
            }
            break;
        case 1://前三直选单式
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 10010001://中三直选复式
            var arr = code.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    zhushu = zhushu * arr[i].length;
                }
            }
            break;
        case 10010010://中三直选单式
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 10011111://后三直选复式
            var arr = code.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    zhushu = zhushu * arr[i].length;
                }
            }
            break;
        case 10101100://后三直选单式
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 11://前三组六
            var num = 3;
            var str = code;
            var len = str.length;
            var s = new Array(len);
            for (var i = 0; i < len; i++) {
                s[i] = str.substr(i, 1);
            }
            //return s.Length;
            //取得n个数,n!
            var n = 1;
            for (var j = len; j > 1; j--) {
                n = j * n;
            }
            var k = 1;
            for (var j = s.length - num; j > 1; j--) {
                k = k * j;
            }
            var m = 1;
            for (var j = num; j > 1; j--) {
                m = m * j;
            }
            return n / (m * k);
            break;
        case 10://前三组三
            zhushu = code.length * (code.length - 1);
            break;
        case 10100001: //后三组六
            var num = 3;
            var str = code;
            var len = str.length;
            var s = new Array(len);
            for (var i = 0; i < len; i++) {
                s[i] = str.substr(i, 1);
            }
            //return s.Length;
            //取得n个数,n!
            var n = 1;
            for (var j = len; j > 1; j--) {
                n = j * n;
            }
            var k = 1;
            for (var j = s.length - num; j > 1; j--) {
                k = k * j;
            }
            var m = 1;
            for (var j = num; j > 1; j--) {
                m = m * j;
            }
            return n / (m * k);
            break;
        case 10100000://后三组三
            zhushu = code.length * (code.length - 1);
            break;
        case 10101101://前三混合组选
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 10101111://后三混合组选
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 101://前二直选复式
            var arr = code.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    zhushu = zhushu * arr[i].length;
                }
            }
            break;
        case 110://前二直选单式
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 10110000://后二直选复式
            var arr = code.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    zhushu = zhushu * arr[i].length;
                }
            }
            break;
        case 10110001://后二直选单式
            var arr = code.split(',');
            if (arr.length > 0) {
                zhushu = arr.length;
            }
            break;
        case 111://前二组选复式
            var len = 0;
            len = code.length;
            if (len == 2) {
                zhushu = 2;
            }
            else if (len == 3) {
                zhushu = 6;
            }
            else if (len == 4) {
                zhushu = 12;
            }
            else if (len == 5) {
                zhushu = 20;
            }
            else if (len == 6) {
                zhushu = 30;
            }
            else if (len == 7) {
                zhushu = 42;
            }
            else if (len == 8) {
                zhushu = 56;
            }
            else if (len == 9) {
                zhushu = 72;
            }
            else if (len == 10) {
                zhushu = 90;
            }
            break;
        case 10110010://后二组选复式
            var len = 0;
            len = code.length;
            if (len == 2) {
                zhushu = 2;
            }
            else if (len == 3) {
                zhushu = 6;
            }
            else if (len == 4) {
                zhushu = 12;
            }
            else if (len == 5) {
                zhushu = 20;
            }
            else if (len == 6) {
                zhushu = 30;
            }
            else if (len == 7) {
                zhushu = 42;
            }
            else if (len == 8) {
                zhushu = 56;
            }
            else if (len == 9) {
                zhushu = 72;
            }
            else if (len == 10) {
                zhushu = 90;
            }
            break;
        case 1000://定位
            var arr = code.split(',');
            for (var i = 0; i < arr.length; i++) {
                zhushu += arr[i].length;
            }
            break;
        case 1001://前三不定位
            zhushu = code.length;
            break;
        case 1010://后三不定位
            zhushu = code.length;
            break;
        case 1011://五星不定位
            zhushu = code.length;
            break;
        case 1010100://任三复
            var count = 1; var num = 0;
            var ccc = new Array();
            var carr = code.split(',');
            for (var i = 0; i < carr.length; i++) {
                if (carr[i].length > 0) {
                    ccc[num] = carr[i].length;
                    num += 1;
                }
            }
             
            for (var i = 0; i < ccc.length; i++) {
                count = count * ccc[i];
            }
            zhushu = count;
            break;
        case 1010101: //任三单
            code = code.replace(/\s/g, "");
            code = code.replace(/(^,)|(,$)/g, "");
            var sTmp = code.replace(/,/g, "");
            var reg = /^\d+$/g; 
            var flg = true; var count = 0;
            var carr = code.split(',');
            for (var i = 0; i < carr.length; i++) {
                var cTmp = $.trim(carr[i]); 
                count += 1;
            }
              zhushu = count; 
              break;
        case 1010110://任三组三
            var len = 2;
            var cLen = code.length; 
            var n = cLen;
            var m = len;
            var n_jc = JieCheng(n);
            var n_m = n - m;
            var n_m_jc = JieCheng(n_m);
            var m_jc = JieCheng(m);
            //乘以2是因为有顺序要求，反过来也算，所以加一倍，就是乘以2
            //任三组六不按顺序，所以不用乘以2
            var beishu = len == 2 ? 2 : 1;
            var result = (n_jc / (n_m_jc * m_jc)) * beishu;
            break;
        default:
            break;
    } 
    return zhushu;
}



//阶乘
function JieCheng (n) {
    return (n <= 1) ? 1 : n * JieCheng(n - 1);
}