//根据玩法ID取下注号，如果返回的code中含有error的即为出错，如error:下注号错误
 
function GetXiaZhuCode(wfid) {
    var code = ''; 
    switch (parseInt(wfid)) {
        case 1011100: //五星直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                if (one === '') {
                    code = 'error:必须选完五个下注号';
                    return false;
                }
                code += one + ',';
            })
            if (!(code.indexOf('error')>-1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 1011101://五星直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ","); 
            //验证每一注是否正确每一项应该只有5位，如12345
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{5}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的五个号，如12345";
            }else{
                code = arr_out.join(',');
            }
            break;
        case 11101001: //前四直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                if (one === '') {
                    code = 'error:必须选完四个下注号';
                    return false;
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 1100100://后四直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                if (one === '') {
                    code = 'error:必须选完四个下注号';
                    return false;
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 11101010://前四直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ","); 
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{4}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的四个号，如1234";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 1100101://后四直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            //验证每一注是否正确每一项应该只有5位，如12345
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{4}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的四个号，如1234";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 0: //前三直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                if (one === '') {
                    code = 'error:必须选完三个下注号';
                    return false;
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 1: //前三直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{3}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的三个号，如123";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 10010001://中三直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                if (one === '') {
                    code = 'error:必须选完三个下注号';
                    return false;
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 10010010://中三直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{3}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的三个号，如123";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 10011111://后三直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                if (one === '') {
                    code = 'error:必须选完三个下注号';
                    return false;
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 10101100://后三直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{3}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的三个号，如123";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 11://前三组六
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                }); 
                code = one;
            })
            if (code.length < 3) {
                code = "error:至少选择三个号码";
            }
            break;
        case 10://前三组三
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 2) {
                code = "error:至少选择两个号码";
            }
            break;
        case 10100001://后三组六
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 3) {
                code = "error:至少选择三个号码";
            }
            break;
        case 10100000://后三组三
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 2) {
                code = "error:至少选择两个号码";
            }
            break;
        case 10101101://前三混合组选
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{3}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的三个号，如123";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 10101111://后三混合组选
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{3}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的三个号，如123";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 101://前二直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                if (one === '') {
                    code = 'error:必须选完两个下注号';
                    return false;
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 110://前二直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ","); 
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的两个号，如12";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 10110000://后二直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                if (one === '') {
                    code = 'error:必须选完两个下注号';
                    return false;
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 10110001://后二直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的两个号，如12";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 111://前二组选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 2) {
                code = "error:至少选择两个号码";
            }
            break;
        case 10110010://后二组选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 2) {
                code = "error:至少选择两个号码";
            }
            break;
        case 1000://定位
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                }); 
                code += one + ',';
            }) 
            code = code.substring(0, code.length - 1); 
            break;
        case 1001://前三不定位
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 1) {
                code = "error:至少选择一个号码";
            }
            break;
        case 1010://后三不定位  
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    
                    var clas = $(this).attr("class"); 
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            }) 
            if (code.length < 1) {
                code = "error:至少选择一个号码";
            }
            break;
        case 1011://五星不定位
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 1) {
                code = "error:至少选择一个号码";
            }
            break;
        case 1010100://任三复
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code += one + ',';
            })
            code = code.substring(0, code.length - 1); 
            var arr = code.split(',');
            var count = 0;
            for (var a in arr) { 
                if (arr[a] != '') { count++;}
            } 
            if (count != 3) {
                code = "error:只能选择三个位置进行任选";
            }
            break;
        case 1010101://任三单
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ","); 
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{3}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的三个号，如123";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 1010110://任三组三
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 2) {
                code = "error:至少选择两个号码";
            }
            break;
        case 1010111://任三组六
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 3) {
                code = "error:至少选择三个号码";
            }
            break;
        case 1011000://任三组选
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ","); 
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{3}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的三个号，如123";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 1011001://任二复
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code += one + ',';
            })
            code = code.substring(0, code.length - 1);
            var arr = code.split(',');
            var count = 0;
            for (var a in arr) {
                if (arr[a] != '') { count++; }
            }
            if (count != 2) {
                code = "error:只能选择二个位置进行任选";
            }
            break;
        case 1011010://任二单
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的二个号，如12";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 1011011://任二组选
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 2) {
                code = "error:至少选择两个号码";
            }
            break;
        case 100010001://任选-定位
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code += one + ',';
            })
            code = code.substring(0, code.length - 1); 
            break;
        case 100010011://庄闲和
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code = one;
            })
            if (code.length < 1) {
                code = "error:至少选择一个号码";
            }
            break;
        case 11011://11选5，前三直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = ''; 
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ",";  
                    }
                });
                if (one === '') {
                    code = 'error:必须选完3个下注号';
                    return false;
                } else {
                    one = one.substring(0, one.length - 1); 
                }
                code += one + '|';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 11100: //11选5，前三直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02,03";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11101://11选5，前三组选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ",";
                        count++;
                    }
                });
                if (count < 3) {
                    code = 'error:至少选3个下注号';
                    return false;
                } else {
                    code = one;
                }
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 11110101://11选5,后三直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = ''; 
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ",";  
                    }
                });
                if (one === '') {
                    code = 'error:必须选完3个下注号';
                    return false;
                } else {
                    one = one.substring(0, one.length - 1); 
                }
                code += one + '|';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 11110110://11选5，后三直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02,03";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11110111://11选5，后三组选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ",";
                        count++;
                    }
                });
                if (count < 3) {
                    code = 'error:至少选3个下注号';
                    return false;
                } else {
                    code = one;
                }
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 11111://11选5，前二直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = ''; 
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ",";  
                    }
                });
                if (one === '') {
                    code = 'error:必须选完2个下注号';
                    return false;
                } else {
                    one = one.substring(0, one.length - 1); 
                }
                code += one + '|';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 100000://11选5，前二直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 100001://11选5，前二组选复式
             $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ",";
                        count++;
                    }
                });
                if (count < 2) {
                    code = 'error:至少选2个下注号';
                    return false;
                } else {
                    code = one;
                }
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 11111010://11选5，后二直选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = ''; 
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ",";  
                    }
                });
                if (one === '') {
                    code = 'error:必须选完2个下注号';
                    return false;
                } else {
                    one = one.substring(0, one.length - 1); 
                }
                code += one + '|';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 11111011://11选5，后二直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11111100://11选5，后二组选复式
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ",";
                        count++;
                    }
                });
                if (count < 2) {
                    code = 'error:至少选2个下注号';
                    return false;
                } else {
                    code = one;
                }
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 100110://11选5，定位
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text()+',';
                    }
                }); 
                if(one!=''){
                    one = one.substring(0,one.length-1);
                }
                code += one + '|';
            }) 
            code = code.substring(0, code.length - 1); 
            break;
        case 100111://11选5，任选复式任选1
            code = renxuanfushi_11x5(wfid,1);
            break;
        case 101000://11选5，任选复式任选2
            code = renxuanfushi_11x5(wfid,2);
            break;
        case 101001://11选5，任选复式任选3
            code = renxuanfushi_11x5(wfid,3);
            break;
        case 101010://11选5，任选复式任选4
            code = renxuanfushi_11x5(wfid,4);
            break;
        case 101011://11选5，任选复式任选5
            code = renxuanfushi_11x5(wfid,5);
            break;
        case 101100://11选5，任选复式任选6
            code = renxuanfushi_11x5(wfid,6);
            break;
        case 101101://11选5，任选复式任选7
            code = renxuanfushi_11x5(wfid,7);
            break;
        case 101110://11选5，任选复式任选8
            code = renxuanfushi_11x5(wfid,8);
            break;
        case 11000100://11选5，任选单式任选1
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11000101://11选5，任选单式任选2
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11000110://11选5，任选单式任选3
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02,03";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11000111://11选5，任选单式任选4
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2},\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02,03,04";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11001000://11选5，任选单式任选5
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2},\d{2},\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02,03,04,05";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11001001://11选5，任选单式任选6
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2},\d{2},\d{2},\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02,03,04,05,06";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11001010://11选5，任选单式任选7
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2},\d{2},\d{2},\d{2},\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02,03,04,05,06,07";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 11001011://11选5，任选单式任选8
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, "|"); 
            var arr_out = new Array();
            var arr = code.split('|');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2},\d{2},\d{2},\d{2},\d{2},\d{2},\d{2},\d{2}$/g 
                if (reg2.test(one)) { 
                    arr_out.push(one);
                }
            } 
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，每行输入示例如：01,02,03,04,05,06,07,08";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 100001001://快三-和值
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ',';
                        count++;
                    }
                });
                if (count < 1) {
                    code = 'error:至少选1个下注号';
                    return false;
                } else {
                    one = one.substring(0,one.length - 1);
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 100001010://快三，三同号通选
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ',';
                        count++;
                    }
                });
                if (count < 1) {
                    code = 'error:至少选1个下注号';
                    return false;
                } else {
                    code = "111,222,333,444,555,666";
                } 
            })
            break;
        case 100001011://快三 ，三同号单选
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ',';
                        count++;
                    }
                });
                if (count < 1) {
                    code = 'error:至少选1个下注号';
                    return false;
                } else {
                    one = one.substring(0, one.length - 1);
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 100001100://快三，二同号复选
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ',';
                        count++;
                    }
                });
                if (count < 1) {
                    code = 'error:至少选1个下注号';
                    return false;
                } else {
                    one = one.substring(0, one.length - 1);
                }
                code += one + ',';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 100001101://快三，二同号单选
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ',';
                        count++;
                    }
                });
                if (count < 1) {
                    code = 'error:至少选1个下注号';
                    return false;
                } else {
                    one = one.substring(0, one.length - 1);
                }
                code += one + '※';
            })
            if (!(code.indexOf('error') > -1)) {
                code = code.substring(0, code.length - 1);
            }
            break;
        case 100001110://快三，三不同号
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ',';
                        count++;
                    }
                });
                if (count < 3) {
                    code = 'error:至少选3个下注号';
                    return false;
                } else {
                    one = one.substring(0, one.length - 1);
                }
                code = one ;
            }) 
            break;
        case 100001111://快三，二不同号
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ',';
                        count++;
                    }
                });
                if (count < 2) {
                    code = 'error:至少选2个下注号';
                    return false;
                } else {
                    one = one.substring(0, one.length - 1);
                }
                code = one;
            }) 
            break;
        case 100010000://快三，三连号通选
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                var count = 0;
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text() + ',';
                        count++;
                    }
                });
                if (count < 1) {
                    code = 'error:至少选1个下注号';
                    return false;
                } else {
                    code = "123,234,345,456";
                }
            })
            break;
        case 10100://排列三，三星直选复式
            code = more_hang(wfid, '', ','); 
            break;
        case 10011://排列三，三星直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ","); 
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{3}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的三个号，如123";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 1110://排列三，后三组六
            code = one_hang(wfid, 3, '');
            break;
        case 1101://排列三，后三组三
            code = one_hang(wfid,2,'');
            break;
        case 10111011://排列三，后三混合组选
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{3}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的三个号，如123";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 10111100://排列三，前二直选复式
            code = more_hang(wfid, '', ',');
            break;
        case 11111111://排列三，前二直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的2个号，如12";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 10000://排列三，后二直选复式
            code = more_hang(wfid, '', ',');
            break;
        case 1111://排列三，后二直选单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，一行只能输入连续的2个号，如12";
            } else {
                code = arr_out.join(',');
            }
            break;
        case 10111101://排列三，前二组选复式
            code = one_hang(wfid, 2, '');
            break;
        case 10001://排列三，后二组选复式
            code = one_hang(wfid, 2, '');
            break;
        case 10101://排列三，定位
            $('#xiazhu-' + wfid + ' .row').each(function () {
                var one = '';
                $(this).find('.balls .item').each(function () {
                    var clas = $(this).attr("class");
                    if (clas.indexOf('selected') > -1) {
                        one += $(this).text();
                    }
                });
                code += one + ',';
            })
            code = code.substring(0, code.length - 1); 
            break;
        case 10010://排列三，不定位
            code = one_hang(wfid, 1, '');
            break;
        case 20000101://PK10猜冠军
            code = one_hang(wfid, 1, ',');
            break;
        case 20000202://PK10猜前二复式
            code = more_hang(wfid,',','|');
            break;
        case 20000201://PK10猜前二单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2} \d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，输入示例如：01 02";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 20000302://PK10猜前三复式
            code = more_hang(wfid,',','|');
            break;
        case 20000301://PK10猜前三单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2} \d{2} \d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，输入示例如：01 02 03";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 20000402://PK10猜前四复式
            code = more_hang(wfid,',','|');
            break;
        case 20000401://PK10猜前四单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2} \d{2} \d{2} \d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，输入示例如：01 02 03 04";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 20000502:////PK10猜前五复式
            code = more_hang(wfid,',','|');
            break;
        case 20000501:////PK10猜前五单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2} \d{2} \d{2} \d{2} \d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，输入示例如：01 02 03 04 05";
            } else {
                code = arr_out.join('|');
            }
            break; 
        case 20000602://PK10猜前六复式
            code = more_hang(wfid,',','|');
            break;
        case 20000601://PK10猜前六单式
            var text = $('#xiazhu-' + wfid + ' .row textarea').val();
            var reg = /[\+\s\t\n \r\.]+/g;
            code = text.replace(reg, ",");
            var arr_out = new Array();
            var arr = code.split(',');
            for (var key in arr) {
                var one = arr[key];
                var reg2 = /^\d{2} \d{2} \d{2} \d{2} \d{2} \d{2}$/g
                if (reg2.test(one)) {
                    arr_out.push(one);
                }
            }
            if (arr_out.length == 0) {
                code = "error:下注号输入错误，输入示例如：01 02 03 04 05 06";
            } else {
                code = arr_out.join('|');
            }
            break;
        case 20000701://PK10, 1-5定位胆
            code = more_hang(wfid,',','|');
            break;
        case 20000702://pk10 6-10定位胆
            code = more_hang(wfid, ',', '|');
            break;
        case 20000801://pk10 冠军大小单双
            code = one_hang(wfid, 1, ',');
            break;
        case 20000802://pk10 亚军大小单双
            code = one_hang(wfid, 1, ',');
            break;
        case 20000803://pk10 季军大小单双
            code = one_hang(wfid, 1, ',');
            break;
        case 20000901://pk10 冠军龙虎
            code = one_hang(wfid, 1, ',');
            break;
        case 20000902://pk10 亚军龙虎
            code = one_hang(wfid, 1, ',');
            break;
        case 20000903://pk10 季军龙虎
            code = one_hang(wfid, 1, ',');
            break;
        case 20000904://pk10 第四名龙虎
            code = one_hang(wfid, 1, ',');
            break;
        case 20000905://pk10 第五名龙虎
            code = one_hang(wfid, 1, ',');
            break;
        case 20001001://pk10 冠亚和值
            code = one_hang(wfid,1,',');
            break;
        case 20001002://pk10 中二和值
            code = one_hang(wfid, 1, ',');
            break;
        case 20001003://pk10 后二和值
            code = one_hang(wfid, 1, ',');
            break;
        case 20001004://pk10 前三和值
            code = one_hang(wfid, 1, ',');
            break;
        case 20001005://pk10 后三和值
            code = one_hang(wfid, 1, ',');
            break;
        default:
            code = "error:本玩法正在开发中...";
            break;
    }
    

    return code;
}

/* 多行下注号的时候，传入玩法ID，一行内的间隔符，每一行的间隔符 */
function more_hang(wfid, split_char1, split_char2) {
    var code = '';
    $('#xiazhu-' + wfid + ' .row').each(function () {
        var one = '';
        var count = 0;
        $(this).find('.balls .item').each(function () {
            var clas = $(this).attr("class");
            if (clas.indexOf('selected') > -1) {
                one += $(this).text() + split_char1;
                count++;
            }
        });
        if (count < 1) {
            code = 'error:每位至少选择1个下注号';
            return false;
        }
        else {
            if (split_char1 != '') {
                one = one.substring(0, one.length - 1); //分隔符如果不为空则要把最后一个分隔符搞掉
            }
        }
        code += one + split_char2;
    })
    if (!(code.indexOf('error') > -1)) {
        code = code.substring(0, code.length - 1);
    }
    return code;
}

/* 一行下注号的时候，传入玩法ID，至少选择几个下注号 , 每个下注号分隔的符号*/
function one_hang(wfid, min_count, split_char) {
    var code = '';
    $('#xiazhu-' + wfid + ' .row').each(function () {
        var one = '';
        var count = 0;
        $(this).find('.balls .item').each(function () {
            var clas = $(this).attr("class");
            if (clas.indexOf('selected') > -1) {
                one += $(this).text() + split_char;
                count++;
            }
        });
        if (count < min_count) {
            code = 'error:至少选择' + min_count + '个下注号';
            return false;
        }
        else {
            if (split_char != '') {
                one = one.substring(0, one.length - 1); //分隔符如果不为空则要把最后一个分隔符搞掉
            }
        }
        code = one;
    }) 
    return code;
}

/*11选5，任选复式，传入玩法ID，任选X，如任选一则传1，任选二则传2 */
function renxuanfushi_11x5(wfid,len){
    var code='';
    $('#xiazhu-' + wfid + ' .row').each(function () {
        var one = '';
        var count = 0;
        $(this).find('.balls .item').each(function () {
            var clas = $(this).attr("class");
            if (clas.indexOf('selected') > -1) {
                one += $(this).text() + ",";
                count++;
            }
        });
        if (count < len) {
            code = 'error:至少选'+len+'个下注号';
            return false;
        } else {
            code = one;
        }
    })
    if (!(code.indexOf('error') > -1)) {
        code = code.substring(0, code.length - 1);
    }
    return code;
}