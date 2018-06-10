$(function() {
    //header timer
    function getTime() {
        var nowDate = new Date(new Date().getTime() - 43200000),
            nY = nowDate.getFullYear(),
            nM = nowDate.getMonth() + 1,
            nD = nowDate.getDate(),
            nH = nowDate.getHours(),
            nMi = nowDate.getMinutes(),
            nS = nowDate.getSeconds();
        nM = nM < 10 ? '0' + nM : nM;
        nD = nD < 10 ? '0' + nD : nD;
        nH = nH < 10 ? '0' + nH : nH;
        nMi = nMi < 10 ? '0' + nMi : nMi;
        nS = nS < 10 ? '0' + nS : nS;

        var fullTime = nY + '-' + nM + '-' + nD + ' ' + nH + ':' + nMi + ':' + nS;
        $('#nowTime').text(fullTime);
    }

    setInterval(getTime, 1000);

    //active init
    var path = location.pathname,
        navList = $('#nav li');
    if (path.indexOf('partner') > -1) {
        navList.eq(3).addClass('active');
    } else if (path.indexOf('reg') > -1) {
        navList.eq(1).addClass('active');
    } else if (path.indexOf('withdraw') > -1 || path.indexOf('deposit') > -1) {
        navList.eq(4).addClass('active');
    } else if (path.indexOf('activity') > -1) {
        navList.eq(5).addClass('active');
    } else if (path.indexOf('index') > -1) {
        navList.eq(0).addClass('active');
    }

    //nav background
    var nowact = $('#nav .active'),
        nav = $('#nav'),
        gList = $('#gamelist');
    navList.hover(function() {
        $(this).addClass('active').siblings().removeClass('active');
        if ($(this).index() == 2) {
            gList.fadeIn(200);
        }
    }, function() {
        $(this).removeClass('active');
        if ($(this).index() == 2) {
            gList.fadeOut(50);
        }
    })

    nav.on('mouseleave', function() {
        nowact.addClass('active');
    })

    //nav game links
    //var gameBtns = $('#gamelist a');
    //gameBtns.click(function() {
    //    alert('请先登录');
    //})

    

    //index lb
    var unslider = $("#lb_Index").unslider({
            speed: 500,
            delay: 3000,
            keys: true,
            dots: true,
            fluid: false
        });
})
