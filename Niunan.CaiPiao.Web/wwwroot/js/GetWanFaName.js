//根据玩法ID取玩法名称
function GetWanFaName(wfid) {
    var wfname = ''; 
    switch (parseInt(wfid)) {
        case 0:
            wfname = '前三直选复式';
            break;
        case 1:
            wfname = '前三直选单式';
            break;
        case 10:
            wfname = '前三组三';
            break;
        case 11:
            wfname = '前三组六';
            break;
        case 100:
            wfname = '前三组选复式';
            break;
        case 101:
            wfname = '前二直选复式';
            break;
        case 110:
            wfname = '前二直选单式';
            break;
        case 111:
            wfname = '前二组选复式';
            break;
        case 1000:
            wfname = '五星定位';
            break;
        case 1001:
            wfname = '前三不定位';
            break;
        case 1010:
            wfname = '后三不定位';
            break;
        case 1011:
            wfname = '五星不定位';
            break;
        case 1100:
            wfname = '任庄任闲';
            break;
        case 1101:
            wfname = '组三(3D)';
            break;
        case 1110:
            wfname = '组六(3D)';
            break;
        case 1111:
            wfname = '后二直选单式(3D)';
            break;
        case 10000:
            wfname = '后二直选复式(3D)';
            break;
        case 10001:
            wfname = '后二组选(3D)';
            break;
        case 10010:
            wfname = '不定位(3D)';
            break;
        case 10011:
            wfname = '三星直选单式(3D)';
            break;
        case 10100:
            wfname = '三星直选复式(3D)';
            break;
        case 10101:
            wfname = '三星定位(3D)';
            break;
        case 10110:
            wfname = '组选(3D)';
            break;
        case 10111:
            wfname = '庄闲(3D)';
            break;
        case 11000:
            wfname = '庄闲(奖金)';
            break;
        case 11001:
            wfname = '和(奖金)';
            break;
        case 11010:
            wfname = '49选1';
            break;
        case 11011:
            wfname = 'x5_前三直选复式';
            break;
        case 11100:
            wfname = 'x5_前三直选单式';
            break;
        case 11101:
            wfname = 'x5_前三组选复式';
            break;
        case 11110:
            wfname = 'x5_前三组选单式';
            break;
        case 11111:
            wfname = 'x5_前二直选复式';
            break;
        case 100000:
            wfname = 'x5_前二直选单式';
            break;
        case 100001:
            wfname = 'x5_前二组选复式';
            break;
        case 100010:
            wfname = 'x5_前二组选单式';
            break;
        case 100011:
            wfname = 'x5_定单双';
            break;
        case 100100:
            wfname = 'x5_猜中位';
            break;
        case 100101:
            wfname = 'x5_前三不定位';
            break;
        case 100110:
            wfname = 'x5_前三定位胆';
            break;
        case 100111:
            wfname = 'x5_任选1';
            break;
        case 101000:
            wfname = 'x5_任选2';
            break;
        case 101001:
            wfname = 'x5_任选3';
            break;
        case 101010:
            wfname = 'x5_任选4';
            break;
        case 101011:
            wfname = 'x5_任选5';
            break;
        case 101100:
            wfname = 'x5_任选6';
            break;
        case 101101:
            wfname = 'x5_任选7';
            break;
        case 101110:
            wfname = 'x5_任选8';
            break;
        case 1010100:
            wfname = 'ssc_任三直选复式';
            break;
        case 1010101:
            wfname = 'ssc_任三直选单式';
            break;
        case 1010110:
            wfname = 'ssc_任三组三';
            break;
        case 1010111:
            wfname = 'ssc_任三组六';
            break;
        case 1011000:
            wfname = 'ssc_任三组选';
            break;
        case 1011001:
            wfname = 'ssc_任二直选复式';
            break;
        case 1011010:
            wfname = 'ssc_任二直选单式';
            break;
        case 1011011:
            wfname = 'ssc_任二组选';
            break;
        case 1011100:
            wfname = '五星直选复式';
            break;
        case 1011101:
            wfname = '五星直选单式';
            break;
        case 1011110:
            wfname = '五星直选组合';
            break;
        case 1011111:
            wfname = '五星组选120';
            break;
        case 1100000:
            wfname = '五星组选60';
            break;
        case 1100001:
            wfname = '五星组选30';
            break;
        case 1100010:
            wfname = '五星组选10';
            break;
        case 1100011:
            wfname = '五星组选5';
            break;
        case 1100100:
            wfname = '后四直选复式';
            break;
        case 1100101:
            wfname = '后四直选单式';
            break;
        case 1100110:
            wfname = '后四直选组合';
            break;
        case 1100111:
            wfname = '后四组选24';
            break;
        case 1101000:
            wfname = '后四组选12';
            break;
        case 1101001:
            wfname = '后四组选6';
            break;
        case 1101010:
            wfname = '后四组选4';
            break;
        case 1101011:
            wfname = '前三直选和值';
            break;
        case 1101100:
            wfname = '前三直选跨度';
            break;
        case 1101101:
            wfname = '前三直选组合';
            break;
        case 1101110:
            wfname = '前三组选和值';
            break;
        case 1101111:
            wfname = '前三组三单式';
            break;
        case 1110000:
            wfname = '前三组六单式';
            break;
        case 1110001:
            wfname = '前三组选包胆';
            break;
        case 1110010:
            wfname = '前三和值尾数';
            break;
        case 1110011:
            wfname = '前三特殊号码';
            break;
        case 1110100:
            wfname = '前二直选和值';
            break;
        case 1110101:
            wfname = '前二直选跨度';
            break;
        case 1110110:
            wfname = '前二组选单式';
            break;
        case 1110111:
            wfname = '前二组选和值';
            break;
        case 1111000:
            wfname = '前二组选包胆';
            break;
        case 1111001:
            wfname = '后三一码不定位';
            break;
        case 1111010:
            wfname = '后三二码不定位';
            break;
        case 1111011:
            wfname = '前三一码不定位';
            break;
        case 1111100:
            wfname = '前三二码不定位 ';
            break;
        case 1111101:
            wfname = '四星一码不定位';
            break;
        case 1111110:
            wfname = '四星二码不定位';
            break;
        case 1111111:
            wfname = '五星二码不定位';
            break;
        case 10000000:
            wfname = '五星三码不定位';
            break;
        case 10000001:
            wfname = '后二大小单双';
            break;
        case 10000010:
            wfname = '后三大小单双';
            break;
        case 10000011:
            wfname = '前二大小单双';
            break;
        case 10000100:
            wfname = '前三大小单双';
            break;
        case 10000101:
            wfname = '五码趣味三星';
            break;
        case 10000110:
            wfname = '四码趣味三星';
            break;
        case 10000111:
            wfname = '后三趣味二星';
            break;
        case 10001000:
            wfname = '前三趣味二星';
            break;
        case 10001001:
            wfname = '五码区间三星';
            break;
        case 10001010:
            wfname = '四码区间三星';
            break;
        case 10001011:
            wfname = '后三区间二星';
            break;
        case 10001100:
            wfname = '前三区间二星';
            break;
        case 10001101:
            wfname = '一帆风顺';
            break;
        case 10001110:
            wfname = '好事成双';
            break;
        case 10001111:
            wfname = '三星报喜';
            break;
        case 10010000:
            wfname = '四季发财';
            break;
        case 10010001:
            wfname = '中三直选复式';
            break;
        case 10010010:
            wfname = '中三直选单式';
            break;
        case 10010011:
            wfname = '中三组三';
            break;
        case 10010100:
            wfname = '中三组六';
            break;
        case 10010101:
            wfname = '中三组选复式';
            break;
        case 10010110:
            wfname = '中三直选和值';
            break;
        case 10010111:
            wfname = '中三直选跨度';
            break;
        case 10011000:
            wfname = '中三直选组合';
            break;
        case 10011001:
            wfname = '中三组选和值';
            break;
        case 10011010:
            wfname = '中三组三单式';
            break;
        case 10011011:
            wfname = '中三组六单式';
            break;
        case 10011100:
            wfname = '中三组选包胆';
            break;
        case 10011101:
            wfname = '中三和值尾数';
            break;
        case 10011110:
            wfname = '中三特殊号码';
            break;
        case 10011111:
            wfname = '后三直选复式';
            break;
        case 10100000:
            wfname = '后三组三';
            break;
        case 10100001:
            wfname = '后三组六';
            break;
        case 10100010:
            wfname = '后三组选复式';
            break;
        case 10100011:
            wfname = '后三直选和值';
            break;
        case 10100100:
            wfname = '后三直选跨度';
            break;
        case 10100101:
            wfname = '后三直选组合';
            break;
        case 10100110:
            wfname = '后三组选和值';
            break;
        case 10100111:
            wfname = '后三组三单式';
            break;
        case 10101000:
            wfname = '后三组六单式';
            break;
        case 10101001:
            wfname = '后三组选包胆';
            break;
        case 10101010:
            wfname = '后三和值尾数';
            break;
        case 10101011:
            wfname = '后三特殊号码';
            break;
        case 10101100:
            wfname = '后三直选单式';
            break;
        case 10101101:
            wfname = '前三混合组选';
            break;
        case 10101110:
            wfname = '中三混合组选';
            break;
        case 10101111:
            wfname = '后三混合组选';
            break;
        case 10110000:
            wfname = '后二直选复式';
            break;
        case 10110001:
            wfname = '后二直选单式';
            break;
        case 10110010:
            wfname = '后二组选复式';
            break;
        case 10110011:
            wfname = '后二直选和值';
            break;
        case 10110100:
            wfname = '后二直选跨度';
            break;
        case 10110101:
            wfname = '后二组选单式';
            break;
        case 10110110:
            wfname = '后二组选和值';
            break;
        case 10110111:
            wfname = '后二组选包胆';
            break;
        case 10111000:
            wfname = '五星组选20';
            break;
        case 10111001:
            wfname = '三星直选和值';
            break;
        case 10111010:
            wfname = '三星组选和值';
            break;
        case 10111011:
            wfname = '三星混合组选';
            break;
        case 10111100:
            wfname = '前二直选复式';
            break;
        case 10111101:
            wfname = '前二组选复式';
            break;
        case 10111110:
            wfname = '一码不定位';
            break;
        case 10111111:
            wfname = '二码不定位';
            break;
        case 11000000:
            wfname = '前二大小单双';
            break;
        case 11000001:
            wfname = '后二大小单双';
            break;
        case 11000010:
            wfname = '前三组选胆拖';
            break;
        case 11000011:
            wfname = '前二组选胆拖';
            break;
        case 11000100:
            wfname = 'x5_任选1单式';
            break;
        case 11000101:
            wfname = 'x5_任选2单式';
            break;
        case 11000110:
            wfname = 'x5_任选3单式';
            break;
        case 11000111:
            wfname = 'x5_任选4单式';
            break;
        case 11001000:
            wfname = 'x5_任选5单式';
            break;
        case 11001001:
            wfname = 'x5_任选6单式';
            break;
        case 11001010:
            wfname = 'x5_任选7单式';
            break;
        case 11001011:
            wfname = 'x5_任选8单式';
            break;
        case 11001100:
            wfname = 'x5_任选单式';
            break;
        case 11001101:
            wfname = '任选二胆拖';
            break;
        case 11001110:
            wfname = '任选三胆拖';
            break;
        case 11001111:
            wfname = '任选四胆拖';
            break;
        case 11010000:
            wfname = '任选五胆拖';
            break;
        case 11010001:
            wfname = '任选六胆拖';
            break;
        case 11010010:
            wfname = '任选七胆拖';
            break;
        case 11010011:
            wfname = '任选八胆拖';
            break;
        case 11010100:
            wfname = '直选复式';
            break;
        case 11010101:
            wfname = '直选单式';
            break;
        case 11010110:
            wfname = '直选和值';
            break;
        case 11010111:
            wfname = '组三';
            break;
        case 11011000:
            wfname = '组六';
            break;
        case 11011001:
            wfname = '混合组选';
            break;
        case 11011010:
            wfname = '组选和值';
            break;
        case 11011011:
            wfname = '组三单式';
            break;
        case 11011100:
            wfname = '组六单式';
            break;
        case 11011101:
            wfname = '一码不定位';
            break;
        case 11011110:
            wfname = '定位胆';
            break;
        case 11011111:
            wfname = '后二直选复式';
            break;
        case 11100000:
            wfname = '后二直选单式';
            break;
        case 11100001:
            wfname = '后二组选复式';
            break;
        case 11100010:
            wfname = '后二组选单式';
            break;
        case 11100011:
            wfname = '前二直选复式';
            break;
        case 11100100:
            wfname = '前二直选单式';
            break;
        case 11100101:
            wfname = '前二组选复式';
            break;
        case 11100110:
            wfname = '前二组选单式';
            break;
        case 11100111:
            wfname = '组三单式';
            break;
        case 11101000:
            wfname = '组六单式';
            break;
        case 11101001:
            wfname = '前四直选复式';
            break;
        case 11101010:
            wfname = '前四直选单式';
            break;
        case 11101011:
            wfname = '前四直选组合';
            break;
        case 11101100:
            wfname = '前四组选24';
            break;
        case 11101101:
            wfname = '前四组选12';
            break;
        case 11101110:
            wfname = '前四组选6';
            break;
        case 11101111:
            wfname = '前四组选4';
            break;
        case 11110000:
            wfname = 'x5_中三直选复式';
            break;
        case 11110001:
            wfname = 'x5_中三直选单式';
            break;
        case 11110010:
            wfname = 'x5_中三组选复式';
            break;
        case 11110011:
            wfname = 'x5_中三组选单式';
            break;
        case 11110100:
            wfname = 'x5_中三组选胆拖';
            break;
        case 11110101:
            wfname = 'x5_后三直选复式';
            break;
        case 11110110:
            wfname = 'x5_后三直选单式';
            break;
        case 11110111:
            wfname = 'x5_后三组选复式';
            break;
        case 11111000:
            wfname = 'x5_后三组选单式';
            break;
        case 11111001:
            wfname = 'x5_后三组选胆拖';
            break;
        case 11111010:
            wfname = 'x5_后二直选复式';
            break;
        case 11111011:
            wfname = 'x5_后二直选单式';
            break;
        case 11111100:
            wfname = 'x5_后二组选复式';
            break;
        case 11111101:
            wfname = 'x5_后二组选单式';
            break;
        case 11111110:
            wfname = 'x5_后二组选胆拖';
            break;
        case 11111111:
            wfname = '前二直选单式';
            break;
        case 20000000:
            wfname = 'pk拾普通下注复式';
            break;
        case 20000101:
            wfname = 'pk拾猜冠军';
            break;
        case 20000201:
            wfname = 'pk拾猜前二单式';
            break;
        case 20000202:
            wfname = 'pk拾猜前二复式';
            break;
        case 20000301:
            wfname = 'pk拾猜前三单式';
            break;
        case 20000302:
            wfname = 'pk拾猜前三复式';
            break;
        case 20000401:
            wfname = 'pk拾猜前四单式';
            break;
        case 20000402:
            wfname = 'pk拾猜前四复式';
            break;
        case 20000501:
            wfname = 'pk拾猜前五单式';
            break;
        case 20000502:
            wfname = 'pk拾猜前五复式';
            break;
        case 20000601:
            wfname = 'pk拾猜前六单式';
            break;
        case 20000602:
            wfname = 'pk拾猜前六复式';
            break;
        case 20000701:
            wfname = 'pk拾定位胆1-5';
            break;
        case 20000702:
            wfname = 'pk拾定位胆6-10';
            break;
        case 20000801:
            wfname = 'pk拾大小单双冠军';
            break;
        case 20000802:
            wfname = 'pk拾大小单双亚军';
            break;
        case 20000803:
            wfname = 'pk拾大小单双季军';
            break;
        case 20000901:
            wfname = 'pk拾龙虎冠军';
            break;
        case 20000902:
            wfname = 'pk拾龙虎亚军';
            break;
        case 20000903:
            wfname = 'pk拾龙虎季军';
            break;
        case 20000904:
            wfname = 'pk拾龙虎第四名';
            break;
        case 20000905:
            wfname = 'pk拾龙虎第五名';
            break;
        case 20001001:
            wfname = 'pk拾和值冠亚';
            break;
        case 20001002:
            wfname = 'pk拾和值中二';
            break;
        case 20001003:
            wfname = 'pk拾和值后二';
            break;
        case 20001004:
            wfname = 'pk拾和值前三';
            break;
        case 20001005:
            wfname = 'pk拾和值后三';
            break;
        case 100000000:
            wfname = '任三直选复式';
            break;
        case 100000001:
            wfname = '任三直选单式';
            break;
        case 100000010:
            wfname = '任三组三';
            break;
        case 100000011:
            wfname = '任三组六';
            break;
        case 100000100:
            wfname = '任三混合组选';
            break;
        case 100000101:
            wfname = '任二直选复式';
            break;
        case 100000110:
            wfname = '任二直选单式';
            break;
        case 100000111:
            wfname = '任二组选复式';
            break;
        case 100001000:
            wfname = '任二组选单式';
            break;
        case 100001001:
            wfname = '和值';
            break;
        case 100001010:
            wfname = '三同号通选';
            break;
        case 100001011:
            wfname = '三同号单选';
            break;
        case 100001100:
            wfname = '二同号复选';
            break;
        case 100001101:
            wfname = '二同号单选';
            break;
        case 100001110:
            wfname = '三不同号';
            break;
        case 100001111:
            wfname = '二不同号';
            break;
        case 100010000:
            wfname = '三连号通选';
            break;
        case 100010001:
            wfname = 'ssc_任意定位';
            break;
        case 100010010:
            wfname = 'ssc_任不定位';
            break;
        case 100010011:
            wfname = 'ssc_任庄任闲';
            break;
        case 200001001:
            wfname = '广西快十_和值_单';
            break;
        case 200001002:
            wfname = '广西快十_和值_双';
            break;
        case 200001003:
            wfname = '广西快十_和值_大';
            break;
        case 200001004:
            wfname = '广西快十_和值_小';
            break;
        case 200001005:
            wfname = '广西快十_和值_尾大';
            break;
        case 200001006:
            wfname = '广西快十_和值_尾小';
            break;
        case 200001007:
            wfname = '广西快十_和值_龙';
            break;
        case 200001008:
            wfname = '广西快十_和值_虎';
            break;
        case 200001009:
            wfname = '广西快十_平码一_单';
            break;
        case 200001010:
            wfname = '广西快十_平码一_双';
            break;
        case 200001011:
            wfname = '广西快十_平码一_大';
            break;
        case 200001012:
            wfname = '广西快十_平码一_小';
            break;
        case 200001013:
            wfname = '广西快十_平码一_红';
            break;
        case 200001014:
            wfname = '广西快十_平码一_绿';
            break;
        case 200001015:
            wfname = '广西快十_平码一_蓝';
            break;
        case 200001016:
            wfname = '广西快十_平码一_尾大';
            break;
        case 200001017:
            wfname = '广西快十_平码一_尾小';
            break;
        case 200001018:
            wfname = '广西快十_平码一_合单';
            break;
        case 200001019:
            wfname = '广西快十_平码一_合双';
            break;
        case 200001020:
            wfname = '广西快十_平码一_福';
            break;
        case 200001021:
            wfname = '广西快十_平码一_禄';
            break;
        case 200001022:
            wfname = '广西快十_平码一_寿';
            break;
        case 200001023:
            wfname = '广西快十_平码一_喜';
            break;
        case 200001024:
            wfname = '广西快十_平码二_单';
            break;
        case 200001025:
            wfname = '广西快十_平码二_双';
            break;
        case 200001026:
            wfname = '广西快十_平码二_大';
            break;
        case 200001027:
            wfname = '广西快十_平码二_小';
            break;
        case 200001028:
            wfname = '广西快十_平码二_红';
            break;
        case 200001029:
            wfname = '广西快十_平码二_绿';
            break;
        case 200001030:
            wfname = '广西快十_平码二_蓝';
            break;
        case 200001031:
            wfname = '广西快十_平码二_尾大';
            break;
        case 200001032:
            wfname = '广西快十_平码二_尾小';
            break;
        case 200001033:
            wfname = '广西快十_平码二_合单';
            break;
        case 200001034:
            wfname = '广西快十_平码二_合双';
            break;
        case 200001035:
            wfname = '广西快十_平码二_福';
            break;
        case 200001036:
            wfname = '广西快十_平码二_禄';
            break;
        case 200001037:
            wfname = '广西快十_平码二_寿';
            break;
        case 200001038:
            wfname = '广西快十_平码二_喜';
            break;
        case 200001039:
            wfname = '广西快十_平码三_单';
            break;
        case 200001040:
            wfname = '广西快十_平码三_双';
            break;
        case 200001041:
            wfname = '广西快十_平码三_大';
            break;
        case 200001042:
            wfname = '广西快十_平码三_小';
            break;
        case 200001043:
            wfname = '广西快十_平码三_红';
            break;
        case 200001044:
            wfname = '广西快十_平码三_绿';
            break;
        case 200001045:
            wfname = '广西快十_平码三_蓝';
            break;
        case 200001046:
            wfname = '广西快十_平码三_尾大';
            break;
        case 200001047:
            wfname = '广西快十_平码三_尾小';
            break;
        case 200001048:
            wfname = '广西快十_平码三_合单';
            break;
        case 200001049:
            wfname = '广西快十_平码三_合双';
            break;
        case 200001050:
            wfname = '广西快十_平码三_福';
            break;
        case 200001051:
            wfname = '广西快十_平码三_禄';
            break;
        case 200001052:
            wfname = '广西快十_平码三_寿';
            break;
        case 200001053:
            wfname = '广西快十_平码三_喜';
            break;
        case 200001054:
            wfname = '广西快十_平码四_单';
            break;
        case 200001055:
            wfname = '广西快十_平码四_双';
            break;
        case 200001056:
            wfname = '广西快十_平码四_大';
            break;
        case 200001057:
            wfname = '广西快十_平码四_小';
            break;
        case 200001058:
            wfname = '广西快十_平码四_红';
            break;
        case 200001059:
            wfname = '广西快十_平码四_绿';
            break;
        case 200001060:
            wfname = '广西快十_平码四_蓝';
            break;
        case 200001061:
            wfname = '广西快十_平码四_尾大';
            break;
        case 200001062:
            wfname = '广西快十_平码四_尾小';
            break;
        case 200001063:
            wfname = '广西快十_平码四_合单';
            break;
        case 200001064:
            wfname = '广西快十_平码四_合双';
            break;
        case 200001065:
            wfname = '广西快十_平码四_福';
            break;
        case 200001066:
            wfname = '广西快十_平码四_禄';
            break;
        case 200001067:
            wfname = '广西快十_平码四_寿';
            break;
        case 200001068:
            wfname = '广西快十_平码四_喜';
            break;
        case 200001069:
            wfname = '广西快十_特码_单';
            break;
        case 200001070:
            wfname = '广西快十_特码_双';
            break;
        case 200001071:
            wfname = '广西快十_特码_大';
            break;
        case 200001072:
            wfname = '广西快十_特码_小';
            break;
        case 200001073:
            wfname = '广西快十_特码_红';
            break;
        case 200001074:
            wfname = '广西快十_特码_绿';
            break;
        case 200001075:
            wfname = '广西快十_特码_蓝';
            break;
        case 200001076:
            wfname = '广西快十_特码_尾大';
            break;
        case 200001077:
            wfname = '广西快十_特码_尾小';
            break;
        case 200001078:
            wfname = '广西快十_特码_合单';
            break;
        case 200001079:
            wfname = '广西快十_特码_合双';
            break;
        case 200001080:
            wfname = '广西快十_特码_福';
            break;
        case 200001081:
            wfname = '广西快十_特码_禄';
            break;
        case 200001082:
            wfname = '广西快十_特码_寿';
            break;
        case 200001083:
            wfname = '广西快十_特码_喜';
            break;
        case 200002001:
            wfname = '广西快十_幸运投注_平码一';
            break;
        case 200002002:
            wfname = '广西快十_幸运投注_平码二';
            break;
        case 200002003:
            wfname = '广西快十_幸运投注_平码三';
            break;
        case 200002004:
            wfname = '广西快十_幸运投注_平码四';
            break;
        case 200002005:
            wfname = '广西快十_幸运投注_特码';
            break;
        case 200002006:
            wfname = '广西快十_幸运投注_一中一';
            break;
        case 200002007:
            wfname = '广西快十_幸运投注_二中二';
            break;
        case 200002008:
            wfname = '广西快十_幸运投注_三中二';
            break;
        case 200002009:
            wfname = '广西快十_幸运投注_三中三';
            break;
        case 200002010:
            wfname = '广西快十_幸运投注_四中三';
            break;
        case 200002011:
            wfname = '广西快十_幸运投注_五中三';
            break;
        case 200003001:
            wfname = '广西快十_不中投注_三不中';
            break;
        case 200003002:
            wfname = '广西快十_不中投注_四不中';
            break;
        case 200003003:
            wfname = '广西快十_不中投注_五不中';
            break;
        case 200003004:
            wfname = '广西快十_不中投注_六不中';
            break;
        case 200003005:
            wfname = '广西快十_不中投注_七不中';
            break;
        case 200003006:
            wfname = '广西快十_不中投注_八不中';
            break;
        case 200003007:
            wfname = '广西快十_不中投注_九不中';
            break;
        case 200004001:
            wfname = '广西快十_连赢投注_三连赢';
            break;
        case 200004002:
            wfname = '广西快十_连赢投注_四连赢';
            break;
        case 200004003:
            wfname = '广西快十_连赢投注_五连赢';
            break;
        case 200004004:
            wfname = '广西快十_连赢投注_六连赢';
            break;
        case 200005001:
            wfname = '广西快十_复工投注_复式一中一';
            break;
        case 200005002:
            wfname = '广西快十_复工投注_复式二中二';
            break;
        case 200005003:
            wfname = '广西快十_复工投注_复式三中三';
            break;
        case 201001001:
            wfname = '广西快三_总和_单';
            break;
        case 201001002:
            wfname = '广西快三_总和_双';
            break;
        case 201001003:
            wfname = '广西快三_总和_大';
            break;
        case 201001004:
            wfname = '广西快三_总和_小';
            break;
        case 201001005:
            wfname = '广西快三_总和_豹子';
            break;
        case 201001006:
            wfname = '广西快三_第一球_1';
            break;
        case 201001007:
            wfname = '广西快三_第一球_2';
            break;
        case 201001008:
            wfname = '广西快三_第一球_3';
            break;
        case 201001009:
            wfname = '广西快三_第一球_4';
            break;
        case 201001010:
            wfname = '广西快三_第一球_5';
            break;
        case 201001011:
            wfname = '广西快三_第一球_6';
            break;
        case 201001012:
            wfname = '广西快三_第一球_单';
            break;
        case 201001013:
            wfname = '广西快三_第一球_双';
            break;
        case 201001014:
            wfname = '广西快三_第一球_大';
            break;
        case 201001015:
            wfname = '广西快三_第一球_小';
            break;
        case 201001016:
            wfname = '广西快三_第二球_1';
            break;
        case 201001017:
            wfname = '广西快三_第二球_2';
            break;
        case 201001018:
            wfname = '广西快三_第二球_3';
            break;
        case 201001019:
            wfname = '广西快三_第二球_4';
            break;
        case 201001020:
            wfname = '广西快三_第二球_5';
            break;
        case 201001021:
            wfname = '广西快三_第二球_6';
            break;
        case 201001022:
            wfname = '广西快三_第二球_单';
            break;
        case 201001023:
            wfname = '广西快三_第二球_双';
            break;
        case 201001024:
            wfname = '广西快三_第二球_大';
            break;
        case 201001025:
            wfname = '广西快三_第二球_小';
            break;
        case 201001026:
            wfname = '广西快三_第三球_1';
            break;
        case 201001027:
            wfname = '广西快三_第三球_2';
            break;
        case 201001028:
            wfname = '广西快三_第三球_3';
            break;
        case 201001029:
            wfname = '广西快三_第三球_4';
            break;
        case 201001030:
            wfname = '广西快三_第三球_5';
            break;
        case 201001031:
            wfname = '广西快三_第三球_6';
            break;
        case 201001032:
            wfname = '广西快三_第三球_单';
            break;
        case 201001033:
            wfname = '广西快三_第三球_双';
            break;
        case 201001034:
            wfname = '广西快三_第三球_大';
            break;
        case 201001035:
            wfname = '广西快三_第三球_小';
            break;
        default:
            break;
    }
    return wfname;
}