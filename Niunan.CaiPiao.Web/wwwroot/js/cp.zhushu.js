//ssc各个玩法注数
jQuery.fn.extend({
    /// <summary>
    /// 从n个数中取m个数组合
    /// </summary>
    /// <param name="str">源字符串</param>
    /// <param name="num">要取出m个数组合</param>
    Arrangement: function (str, num) {
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
    },
    //时时彩单式注数(code-购买的号码，len-指定的长度)
    SSC_DanshiZhushu: function (code, len) {
        var zhushu = 0;
        var arr = code.split(',');
        if (arr.length > 0) {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length != len || isNaN(arr[i])) {
                    return 0;
                }
            }
            zhushu = arr.length;
        }
        return zhushu;
    }, 
    //时时彩复式注数
    SSC_FushiZhushu: function (code, len) {
        var zhushu = 1;
        var arr = code.split(',');
        if (arr.length == len) {
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    zhushu = zhushu * arr[i].length;
                }
                else {
                    return 0;
                }
            }
        }
        else {
            zhushu = 0;
        }
        return zhushu;
    },
    //北京PK拾复式计算注数
    PK10_FushiZhushu: function (code,len) {
        var zhushu = 1;
        var arr = code.split('|');
        if (arr.length == len) {
            for (var i = 0; i < arr.length; i++) {
                var arr2 = arr[i].split(',')
                if (arr2.length > 0) {
                    zhushu = zhushu * arr2.length;
                }
                else {
                    return 0;
                }
            }
        }
        else {
            zhushu = 0;
        }
        return zhushu;
    },
    //北京PK拾单式计算注数
    PK10_DashiZhushu: function (code, len) {
        var zhushu = 1;
        var arr = code.split('|');
        if (arr.length == len) {
            zhushu = 1;
        }
        else {
            zhushu = 0;
        }
        return zhushu;
    },
    //定位注数计算
    SSC_DingweiZhushu: function (code, len) {
        var zhushu = 0;
        var arr = code.split(',');
        if (arr.length != len)
            return 0;
        for (var i = 0; i < arr.length; i++) {
            zhushu += arr[i].length;
        }
        return zhushu;
    },
    //五星直选复式
    Wuxing_ZhixuanFushi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_FushiZhushu(code, 5);
        return zhushu;
    },
    //五星直选单式
    Wuxing_ZhixuanDanshi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_DanshiZhushu(code, 5);
        return zhushu;
    },
    //四星直选复式
    Sixing_ZhixuanFushi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_FushiZhushu(code, 4);
        return zhushu;
    },
    //四星直选单式
    Sixing_ZhixuanDanshi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_DanshiZhushu(code, 4);
        return zhushu;
    },
    //三星直选复式
    Sanxing_ZhixuanFushi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_FushiZhushu(code, 3);
        return zhushu;
    },
    //三星直选单式
    Sanxing_ZhixuanDanshi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_DanshiZhushu(code, 3);
        return zhushu;
    },
    //组三
    Sanxing_Zusan: function (code) {
        var zhushu = 0;
        if (!isNaN(code) && parseInt(code) > 0 && code.length > 1) {
            zhushu = code.length * (code.length - 1);
        }
        return zhushu;
    },
    //组六
    Sanxing_Zuliu: function (code) {
        var zhushu = 0;
        if (!isNaN(code) && code.length >= 3) {
            zhushu = $().Arrangement(code, 3);
        }
        return zhushu;
    },
    //三星混合组选
    Sanxing_Hunhezuxuan: function (code) {
        var zhushu = 0;
        var arr = code.split(",");
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == "000" || arr[i] == "111" || arr[i] == "222" || arr[i] == "333" || arr[i] == "444" || arr[i] == "555" || arr[i] == "666" || arr[i] == "777" || arr[i] == "888" || arr[i] == "999") {
                return 0;
            }
        }
        zhushu = $().SSC_DanshiZhushu(code, 3);
        return zhushu;
    },
    //二星直选复式
    Erxing_ZhixuanFushi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_FushiZhushu(code, 2);
        return zhushu;
    },
    //二星直选单式
    Erxing_ZhixuanDanshi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_DanshiZhushu(code, 2);
        return zhushu;
    },
    //二星组选复式
    Erxing_ZuxuanFushi: function (code) {
        var zhushu = 0;
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
        return zhushu;
    },
    //二星组选单式
    Erxing_ZuxuanDanshi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_DanshiZhushu(code, 2);
        return zhushu;
    },
    //五星定位
    Wuxing_Dingwei: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_DingweiZhushu(code, 5);
        return zhushu;
    },
    //三星定位
    Sanxing_Dingwei: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_DingweiZhushu(code, 3);
        return zhushu;
    },
    //三星不定位
    Sanxing_Budingwei: function (code) {
        var zhushu = 0;
        zhushu = code.length;
        return zhushu;
    },
    //五星不定位(方法名称怎么和三星不定位的一样？我改为五星了)
    Wuxing_Budingwei: function (code) {
        var zhushu = 0;
        zhushu = code.length;
        return zhushu;
    },
    //JS将字符串直接切成数组，再以某字符组合，代码留此备用：
	//var codeArr = code.match(/./g); //code如：2325678
	//var newocde = codeArr.join(","); //结果:2,3,2,5,6,7,8
//ADD-----------------------------------------------------------------
    //code:选择的号码； len:单注号码必须的长度； typ:三个值 > x为任二组选；d为任二单；f为任二复
	//也可用于任三
	SSC_RenxuanRenEr: function (code, len, typ) {
		if(typ=="x"){
			//任二组选
			var cLen = code.length;
			if(cLen<len){return 0;}
			if(cLen>10){return 0;}
			var n = cLen;
			var m = len;
			var n_jc = $().JieCheng(n);
			var n_m = n-m;
			var n_m_jc = $().JieCheng(n_m);
			var m_jc = $().JieCheng(m);
			//乘以2是因为有顺序要求，反过来也算，所以加一倍，就是乘以2
			//任三组六不按顺序，所以不用乘以2
			var beishu = len==2 ? 2 : 1;
			var result = (n_jc / (n_m_jc * m_jc)) * beishu;
			return result;
		}
		else if(typ=="d"){
			//任二单
			code = code.replace(/\s/g, "");
			code = code.replace(/(^,)|(,$)/g, "");
			var sTmp = code.replace(/,/g, "");
			var reg = /^\d+$/g;
			if (!reg.test(sTmp)) {return 0;}
			var flg = true; var count = 0;
			var carr = code.split(',');
			for (var i = 0; i < carr.length; i++) {
				var cTmp = $.trim(carr[i]);
				if(cTmp.length!=len){
					flg = false;
				}
				count += 1;
			}
			if(!flg){return 0;}else{return count;}
		}
		else if(typ=="f"){
			//任二复
			var count = 1; var num = 0;
			var ccc = new Array();
			var carr = code.split(',');
			for (var i = 0; i < carr.length; i++) {
				if(carr[i].length>0){
					ccc[num] = carr[i].length;
					num += 1;
				}
			}
			if(num!=len){return 0;}
			for (var i = 0; i < ccc.length; i++) {
				count = count * ccc[i];
			}
			return count;
		}
		else{
			return 0;
		}
	},
	SSC_RenxuanDwBdw: function (code, len) {
		var count = 0;
		var carr = code.split(',');
		for (var i = 0; i < carr.length; i++) {
			count += carr[i].length;
		}
		if(count<len){return 0;}
		return count;
	},
	SSC_Zhuang_xian_He: function (code, len) {
		var cLen = code.length;
		if(cLen<len){return 0;}
		return cLen;
	},
//ADD------------------------------------------------
    //任三复
	Ssc_RenSanZhixuanFushi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanRenEr(code, 3, "f"); //使用任二的方法
        return zhushu;
	},
	//任三单
    Ssc_RenSanZhixuanDanshi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanRenEr(code, 3, "d"); //使用任二的方法
        return zhushu;
    },
    //任三组三
	Ssc_RenAsSan_ZuSan: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanRenEr(code, 2, "x"); //使用任二的方法
        return zhushu;
	},
    //任三组六
	Ssc_RenAsSan_ZuLiu: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanRenEr(code, 3, "x"); //使用任二的方法
        return zhushu;
	},
    //任三组选
	Ssc_RenAsSan_ZuXuan: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanRenEr(code, 3, "d"); //使用任二的方法
        return zhushu;
	},
    //任二复
	Ssc_RenErZhixuanFushi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanRenEr(code, 2, "f");
        return zhushu;
	},
    //任二单
	Ssc_RenErZhixuanDanshi: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanRenEr(code, 2, "d");
        return zhushu;
	},
	//任二组选
	Ssc_RenErZuxuan: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanRenEr(code, 2, "x");
        return zhushu;
	},
	//任选定位
	Ssc_Renxuandingwei: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanDwBdw(code, 1);
        return zhushu;
	},
	//任选不定位
	Ssc_RenxuanBudingwei: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_RenxuanDwBdw(code, 1);
        return zhushu;
	},
	//庄闲和
	Ssc_Zhuangxian: function (code) {
        var zhushu = 0;
        zhushu = $().SSC_Zhuang_xian_He(code, 1);
        return zhushu;
	},
	//阶乘
	JieCheng: function (n) {
		return ( n <= 1 ) ? 1 : n * $().JieCheng( n-1 );
	}
});

//11x5注数
jQuery.fn.extend({
    /// <summary>
    /// 前三组选复试，前二组选复试， 从N个数中取m个数的组合 公式：n!/((n-m)!*m!)
    /// </summary>
    /// <param name="numberCount">n个数</param>
    /// <param name="selectCount">取m个数</param>
    Combination: function (n, m) {
        var result = 0;
        var count = 1;
        var sub = n - m + 1;
        //n!/(n-m)!
        for (var i = sub; i <= n; i++) {
            count = count * i;
        }
        //m!
        var count2 = 1;
        for (var j = 1; j <= m; j++) {
            count2 = count2 * j;
        }
        //n!/((n-m)!*m!)
        result = count / count2;
        return result;
    },
    /// <summary>
    /// 从两个数组中取共同存在的号码个数
    /// </summary>
    /// <returns></returns>
    GetRepeatCount: function (arr1, arr2) {
        var result = 0;
        if (arr1.length <= 0 || arr2.length <= 0) {
            return 0;
        }
        for (var i = 0; i < arr1.length; i++) {
            for (var j = 0; j < arr2.length; j++) {
                if (arr1[i].toString() == arr2[j].toString()) {
                    result += 1;
                }
            }
        }
        return result;
    },
    /// <summary>
    /// 从三个数组中取共同存在的号码个数
    /// </summary>
    GetRepeatCount2: function (arr1, arr2, arr3) {
        var result = 0;
        if (arr1.length <= 0 || arr2.length <= 0 || arr3.length <= 0) {
            return 0;
        }
        for (var i = 0; i < arr1.length; i++) {
            for (var j = 0; j < arr2.length; j++) {
                if (arr1[i].toString() == arr2[j].toString()) {
                    for (var k = 0; k < arr3.length; k++) {
                        if (arr1[i].toString() == arr2[j].toString() && arr1[i].toString() == arr3[k].toString()) {
                            result += 1;
                        }
                    }
                }
            }
        }
        return result;
    },
    //单式注数
    X5_Danshi: function (code, len) {
        var zhushu = 0;
        var arr = code.split('|');
        for (var i = 0; i < arr.length; i++) {
            var arri = arr[i].split(',');
            if (arri.length != len) {
                return 0;
            }
            for (var j = 0; j < arri.length; j++) {
                if (isNaN(arri[j])) {
                    return 0;
                }
            }
        }
        zhushu = arr.length;
        return zhushu;
    },
    //三码直选复式
    Sanma_ZhixuanFushi: function (code) { 
        var zhushu = 0;
        var codeList = code.split('|');
        if (codeList.length != 3) {
            return 0;
        }
        var code1Count = 0;
        var code2Count = 0;
        var code3Count = 0;
        var arr1 = new Array();
        var arr2 = new Array();
        var arr3 = new Array();
        arr1 = codeList[0].split(',');
        arr2 = codeList[1].split(',');
        arr3 = codeList[2].split(',');

        code1Count = arr1.length;
        code2Count = arr2.length;
        code3Count = arr3.length;
        var count23 = 0;
        var count13 = 0;
        var count12 = 0;
        var count123 = 0;
        count23 = $().GetRepeatCount(arr2, arr3);
        count13 = $().GetRepeatCount(arr1, arr3);
        count12 = $().GetRepeatCount(arr1, arr2);
        count123 = $().GetRepeatCount2(arr1, arr2, arr3);
        zhushu = code1Count * code2Count * code3Count - code1Count * count23 - code2Count * count13 - code3Count * count12 + 2 * count123;
   
        return zhushu;
    },
    //三码直选单式
    Sanma_ZhixuanDanshi: function (code) {
        var zhushu = 0;
        zhushu = $().X5_Danshi(code, 3);
        return zhushu;
    },
    //二码直选复式
    Erma_ZhixuanFushi: function (code) {
        var zhushu = 0;
        var codeList = code.split('|');
        if (codeList.length != 2) {
            return 0;
        }
        var code1Count = 0;
        var code2Count = 0;
        var arr1 = new Array();
        var arr2 = new Array();
        arr1 = codeList[0].split(',');
        arr2 = codeList[1].split(',');
        if (arr1.length == 0 || arr2.length == 0) {
            return 0;
        }
        code1Count = arr1.length;
        code2Count = arr2.length;
        var count12 = 0;
        count12 = $().GetRepeatCount(arr1, arr2);
        zhushu = code1Count * code2Count - count12;
        return zhushu;
    },
    //二码直选单式
    Erma_ZhixuanDanshi: function (code) {
        var zhushu = 0;
        zhushu = $().X5_Danshi(code, 2);
        return zhushu;
    },
    //二码组选复式
    Erma_ZuxuanFushi: function (code) {
        var zhushu = 0;
        var arr = new Array();
        arr = code.split(',');
        if (arr.length < 2) {
            return 0;
        }
        zhushu = $().Combination(arr.length, 2);
        return zhushu;
    },
    //三码组选复式
    Sanma_ZuxuanFushi: function (code) {
        var zhushu = 0;
        var arr = new Array();
        arr = code.split(',');
        if (arr.length < 3) {
            return 0;
        }
        zhushu = $().Combination(arr.length, 3);
        return zhushu;
    },
    //定位
    X5_Dingwei: function (code) {
        var zhushu = 0;
        var arr = code.split('|');
        if (arr.length <= 0) {
            return 0;
        }
        for (var i = 0; i < arr.length; i++) {
            if (arr[i].length > 0) {
                var wc = arr[i].split(',');
                zhushu += wc.length;
            }
        }
        return zhushu;
    },
    //任选复式
    X5_RenxuanFushi: function (code, len) {
        var zhushu = 0;
        var arr = code.split(',');
        if (arr.length < len) {
            return 0;
        }
        zhushu = $().Combination(arr.length, len);
        return zhushu;
    },
    //任选单式
    X5_RenxuanDanshi: function (code, len) {
        var zhushu = 0;
        var arr = code.split('|');
        for (var i = 0; i < arr.length; i++) {
            var arri = arr[i].split(',');
            if (arri.length != len) {
                return 0;
            }
            for (var j = 0; j < arri.length; j++) {
                if (isNaN(arri[j])) {
                    return 0;
                }
            }
        }
        zhushu = arr.length;
        return zhushu;
    }
});

//k3注数
jQuery.fn.extend({
    k3_HeZhi: function (code) {
        var zhushu = 0;
        try {
            var arr = code.split(",");
            zhushu = arr.length;
        } catch (e) { }
        return zhushu;
    },
    k3_SanTongHaoTongxuan: function (code) {
        var count = 0;
        if (code == "111,222,333,444,555,666") {
            count = 1;
        }
        return count;
    },
    k3_SanTongHaoDanxuan: function (code) {
        var count = 0;
        var c = code.split(",");
        for (var i = 0; i < c.length; i++) {
            if (c[i] == "111" || c[i] == "222" || c[i] == "333" || c[i] == "444" || c[i] == "555" || c[i] == "666") {
                count += 1;
            }
        }
        return count;
    },
    k3_ErTongHaoFuxuan: function (code) {
        var zhushu = 0;
        try {
            var arr = code.split(",");
            zhushu = arr.length;
        } catch (e) { }
        return zhushu;
    },
    k3_ErTongHaoDanxuan: function (code) {
        var zhushu = 0;
        try {
            var c = code.split("※");
            if (c.length == 2) {
                if (c[0] == "" || c[1] == "") {
                    return 0;
                }
                var c0 = c[0].split(",");
                var c1 = c[1].split(",");
                if (c0.length > 0 && c1.length > 0) {
                    zhushu = c0.length * c1.length;
                }
            }
        } catch (e) { }
        return zhushu;
    },
    k3_SanLianHaoTongxuan: function (code) {
        var zhushu = 0;
        if (code == "123,234,345,456") {
            zhushu = 1;
        }
        return zhushu;
    },
    k3_ErBuTonghao: function (code) {
        var zhushu = 0;
        var c = code.split(",");
        zhushu = $().Combination(c.length, 2);
        return zhushu;
    },
    k3_SanBuTonghao: function (code) {
        var zhushu = 0;
        var c = code.split(",");
        zhushu = $().Combination(c.length, 3);
        return zhushu;
    }
});

//注数工厂类
jQuery.fn.extend({
    ZhushuFactory: function (wfid, code) { 
        var zhushu = 0;
        //五星复式
        if (wfid == 1011100) {
            zhushu = $().Wuxing_ZhixuanFushi(code);
        }
        //五星单式
        else if (wfid == 1011101) {
            zhushu = $().Wuxing_ZhixuanDanshi(code);
        }
        //后前四复式
        else if (wfid == 1100100 || wfid == 11101001) {
            zhushu = $().Sixing_ZhixuanFushi(code);
        }
        //后前四单式
        else if (wfid == 1100101 || wfid == 11101010) {
            zhushu = $().Sixing_ZhixuanDanshi(code);
        }
        //后中前三直选复式
        else if (wfid == 10011111 || wfid == 10010001 || wfid == 0 || wfid == 10100) {
            zhushu = $().Sanxing_ZhixuanFushi(code);
        }
        //后中前三直选单式
        else if (wfid == 10101100 || wfid == 10010010 || wfid == 1 || wfid == 10011) {
            zhushu = $().Sanxing_ZhixuanDanshi(code);
        }
        //后前三组三
        else if (wfid == 10100000 || wfid == 10 || wfid == 1101) {
            zhushu = $().Sanxing_Zusan(code);
        }
        //后前三组六
        else if (wfid == 10100001 || wfid == 11 || wfid == 1110) {
            zhushu = $().Sanxing_Zuliu(code);
        }
        //三星混合组选
        else if (wfid == 10101111 || wfid == 10101101 || wfid == 10111011) {
            zhushu = $().Sanxing_Hunhezuxuan(code);
        }
        //二星直选复式
        else if (wfid == 10110000 || wfid == 101 || wfid == 10000 || wfid == 10111100) {
            zhushu = $().Erxing_ZhixuanFushi(code);
        }
        //二星直选单式
        else if (wfid == 10110001 || wfid == 110 || wfid == 1111 || wfid == 11111111) {
            zhushu = $().Erxing_ZhixuanDanshi(code);
        }
        //二星组选复式
        else if (wfid == 10110010 || wfid == 111 || wfid == 10001 || wfid == 10111101) {
            zhushu = $().Erxing_ZuxuanFushi(code);
        }
        //五星定位
        else if (wfid == 1000) {
            zhushu = $().Wuxing_Dingwei(code);
        }
        //三星定位
        else if (wfid == 10101) {
            zhushu = $().Sanxing_Dingwei(code);
        }
        //三星不定位
        else if (wfid == 1010 || wfid == 1001 || wfid == 10010) {
            zhushu = $().Sanxing_Budingwei(code);
        }
        //五星不定位
        else if (wfid == 1011) {
            zhushu = $().Sanxing_Budingwei(code);
        }
//ADD---------------------------------------------------------
		//任三复
		else if(wfid == 1010100){
			zhushu = $().Ssc_RenSanZhixuanFushi(code);
		}
		//任三单
		else if(wfid == 1010101){
			zhushu = $().Ssc_RenSanZhixuanDanshi(code);
		}
		//任三组三
		else if(wfid == 1010110){
			zhushu = $().Ssc_RenAsSan_ZuSan(code);
		}
		//任三组六
		else if(wfid == 1010111){
			zhushu = $().Ssc_RenAsSan_ZuLiu(code);
		}
		//任三组选
		else if(wfid == 1011000){
			zhushu = $().Ssc_RenAsSan_ZuXuan(code);
		}
		//任二复
		else if(wfid == 1011001){
			zhushu = $().Ssc_RenErZhixuanFushi(code);
		}
		//任二单
		else if(wfid == 1011010){
			zhushu = $().Ssc_RenErZhixuanDanshi(code);
		}
		//任二组选
		else if(wfid == 1011011){
			zhushu = $().Ssc_RenErZuxuan(code);
		}
		//任选定位
		else if(wfid == 100010001){
			zhushu = $().Ssc_Renxuandingwei(code);
		}
		//任选不定位
		else if(wfid == 100010010){
			zhushu = $().Ssc_RenxuanBudingwei(code);
		}
		//庄闲和
		else if (wfid == 100010011){
			zhushu = $().Ssc_Zhuangxian(code);
		}
//11x5
        //前后三直选复式
        else if (wfid == 11011 || wfid == 11110101) {
            zhushu = $().Sanma_ZhixuanFushi(code); 
        }
        //前后三直选单式
        else if (wfid == 11100 || wfid == 11110110) {
            zhushu = $().Sanma_ZhixuanDanshi(code);
        }
        //前后三组选复式
        else if (wfid == 11101 || wfid == 11110111) {
            zhushu = $().Sanma_ZuxuanFushi(code);
        }
        //前后二直选复式
        else if (wfid == 11111 || wfid == 11111010) {
            zhushu = $().Erma_ZhixuanFushi(code);
        }
        //前后二直选单式
        else if (wfid == 100000 || wfid == 11111011) {
            zhushu = $().Erma_ZhixuanDanshi(code);
        }
        //前后二组选复式
        else if (wfid == 100001 || wfid == 11111100) {
            zhushu = $().Erma_ZuxuanFushi(code);
        }
        //定位
        else if (wfid == 100110) {
            zhushu = $().X5_Dingwei(code);
        }
        //任选一
        else if (wfid == 100111) {
            zhushu = $().X5_RenxuanFushi(code, 1);
        }
        //任选2
        else if (wfid == 101000) {
            zhushu = $().X5_RenxuanFushi(code, 2);
        }
        //任选3
        else if (wfid == 101001) {
            zhushu = $().X5_RenxuanFushi(code, 3);
        }
        //任选4
        else if (wfid == 101010) {
            zhushu = $().X5_RenxuanFushi(code, 4);
        }
        //任选5
        else if (wfid == 101011) {
            zhushu = $().X5_RenxuanFushi(code, 5);
        }
        //任选6
        else if (wfid == 101100) {
            zhushu = $().X5_RenxuanFushi(code, 6);
        }
        //任选7
        else if (wfid == 101101) {
            zhushu = $().X5_RenxuanFushi(code, 7);
        }
        //任选8
        else if (wfid == 101110) {
            zhushu = $().X5_RenxuanFushi(code, 8);
        }
        else if (wfid == 20000000) {
            //牛腩新增，北京PK拾 
            zhushu = $().PK10_FushiZhushu(code,10); 
        }
        else if (wfid == 20000101) {
            //北京PK拾猜冠军
            zhushu = $().PK10_FushiZhushu(code, 1);
        } else if (wfid == 20000201) {
            //北京PK拾猜前二单式
            zhushu = $().PK10_DashiZhushu(code, 2);
        } else if (wfid == 20000202) {
            //北京PK拾猜前二复式
            zhushu = $().PK10_FushiZhushu(code, 2);
        } else if (wfid == 20000301) {
            //北京PK拾猜前三单式
            zhushu = $().PK10_DashiZhushu(code, 3);
        } else if (wfid == 20000302) {
            //北京PK拾猜前三复式
            zhushu = $().PK10_FushiZhushu(code, 3);
        } else if (wfid == 20000401) {
            //北京PK拾猜前四单式
            zhushu = $().PK10_DashiZhushu(code, 4);
        } else if (wfid == 20000402) {
            //北京PK拾猜前四复式
            zhushu = $().PK10_FushiZhushu(code,4);
        } else if (wfid == 20000501) {
            //北京PK拾猜前五单式
            zhushu = $().PK10_DashiZhushu(code, 5);
        } else if (wfid == 20000502) {
            //北京PK拾猜前五复式
            zhushu = $().PK10_FushiZhushu(code, 5);
        } else if (wfid == 20000601) {
            //北京PK拾猜前六单式
            zhushu = $().PK10_DashiZhushu(code, 6);
        } else if (wfid == 20000602) {
            //北京PK拾猜前六复式
            zhushu = $().PK10_FushiZhushu(code, 6);
        } else if (wfid == 20000701 || wfid == 20000702) {
            //北京PK拾定位胆
            zhushu = $().PK10_FushiZhushu(code, 5);
        } else if (wfid == 20000801 || wfid == 20000802 || wfid == 20000803 || wfid == 20000901 || wfid == 20000902 || wfid == 20000903 || wfid == 20000904 || wfid == 20000905 || wfid == 20001001 || wfid == 20001002 || wfid == 20001003 || wfid == 20001004 || wfid == 20001005) {
            //北京PK拾大小单双/龙虎/和值
            zhushu = $().PK10_FushiZhushu(code, 1);
        }
            //任选一单式
        else if (wfid == 11000100) {
            zhushu = $().X5_RenxuanDanshi(code, 1);
        }
            //任选2单式
        else if (wfid == 11000101) {
            zhushu = $().X5_RenxuanDanshi(code, 2);
        }
            //任选3单式
        else if (wfid == 11000110) {
            zhushu = $().X5_RenxuanDanshi(code, 3);
        }
            //任选4单式
        else if (wfid == 11000111) {
            zhushu = $().X5_RenxuanDanshi(code, 4);
        }
            //任选5单式
        else if (wfid == 11001000) {
            zhushu = $().X5_RenxuanDanshi(code, 5);
        }
            //任选6单式
        else if (wfid == 11001001) {
            zhushu = $().X5_RenxuanDanshi(code, 6);
        }
            //任选7单式
        else if (wfid == 11001010) {
            zhushu = $().X5_RenxuanDanshi(code, 7);
        }
            //任选8单式
        else if (wfid == 11001011) {
            zhushu = $().X5_RenxuanDanshi(code, 8);
        }
            //k3和值
        else if (wfid == 100001001) {
            zhushu = $().k3_HeZhi(code);
        }
            //k3三同号通选
        else if (wfid == 100001010) {
            zhushu = $().k3_SanTongHaoTongxuan(code);
        }
            //三同号单选
        else if (wfid == 100001011) {
            zhushu = $().k3_SanTongHaoDanxuan(code);
        }
            //二同号复选
        else if (wfid == 100001100) {
            zhushu = $().k3_ErTongHaoFuxuan(code);
        }
            //二同号单选
        else if (wfid == 100001101) {
            zhushu = $().k3_ErTongHaoDanxuan(code);
        }
            //三不同号
        else if (wfid == 100001110) {
            zhushu = $().k3_SanBuTonghao(code);
        }
            //二不同号
        else if (wfid == 100001111) {
            zhushu = $().k3_ErBuTonghao(code);
        }
            //三连号通选
        else if (wfid == 100010000) {
            zhushu = $().k3_SanLianHaoTongxuan(code);
        } else {
            zhushu = 0;
        }
        return zhushu;
    }
});