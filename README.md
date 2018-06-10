# 彩票项目
彩票项目，学习用，asp.net core+postgresql+dapper+sql拼接  有空就做做，目前也就做到了整个项目的1%  

界面：
 ![前台1](http://ohpxbzczu.bkt.clouddn.com/wlgj1.png)
 ![前台2](http://ohpxbzczu.bkt.clouddn.com/wlgj2.png)
 ![前台2](http://ohpxbzczu.bkt.clouddn.com/wlgj3.png)
 ![前台2](http://ohpxbzczu.bkt.clouddn.com/wlgj4.png)

思路： 
 1.把所有期号及所在时间段都加到数据库中 
 2.前台下注传期号和下注金额，判断期号是否是在当前时间段，是的话插入到下注表 
 3.做一个控制台程序，用AngleSharp取官网的页面HTML代码，从中分析出某一期的开奖号，再插入到数据库，然后再循环下注表中当前期的所有下注，判断是否中奖，中奖则给账户余额加上中奖金额 
 4.部署的时候用windows的计划任务，设置一定时间运行一次第三步中的控制台程序，这样就能实现官方开奖后我们这也能得到开奖结果了，顶多就延迟个几十秒...  
 
难题： 
 因为是抓取官方HTML页面，所以有时经常是抓取不到开奖号的，网上那个‘澳门首家网上XXX’的应该是有别的渠道可以取得开奖号的...  
 
更新日志： 
 2018年06月10日  
  PK10下注页面下注代码写得一点点  
  
 2018年04月30日  
  前台文章的news/onepage页面做好，后台也做好  
  
 2018年04月09日  
  创建项目框架，把几个类库都 事先建立好，用asp.net core来做
