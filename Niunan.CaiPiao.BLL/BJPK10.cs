using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using Niunan.CaiPiao.Model;

namespace Niunan.CaiPiao.BLL
{
    /// <summary>
    /// 北京PK10
    /// </summary>
    public class BJPK10 : ICaiPiaoBLL
    {
        public string ConnStr { set; get; }

        public string DuiJiang(int xiazhuid)
        {
            throw new NotImplementedException();
        }

        public Model.CaiPiao GetCurrentModel()
        {
            throw new NotImplementedException();
        }

        public Model.CaiPiao GetModel(string qihao)
        {
            throw new NotImplementedException();
        }

        public async Task<string> InsertKJCodeAsync(bool onlyfirst = false, string url = "http://www.bwlc.net/bulletin/trax.html?page=1")
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = url;
            StringBuilder sb = new StringBuilder();
            DAL.QihaoinfoDAL qhdal = new DAL.QihaoinfoDAL() { ConnStr = ConnStr };
            int czid = 5;
            string czname = "北京PK拾";
            using (var document = await BrowsingContext.New(config).OpenAsync(address))
            {
                string allhtml = document.QuerySelector("body").InnerHtml;

                //   Util.Log.Info($"开始抓取开奖号，远程返回的HTML：{allhtml} <br /> \r\n");

                var cellSelector = "table.tb tr";
                var cells = document.QuerySelectorAll(cellSelector);



                foreach (var item in cells)
                {
                    string qihao = "";
                    string kjcode = "";
                    string kjtime = "";

                    if (item.InnerHtml.Contains("td"))
                    {
                        qihao = item.QuerySelector("td:nth-child(1)").TextContent;
                        kjcode = item.QuerySelector("td:nth-child(2)").TextContent;
                        kjtime = item.QuerySelector("td:nth-child(3)").TextContent;

                        Model.Qihaoinfo qihaoinfo = qhdal.GetModelByCond($"qihao='{qihao}' and czid={czid}");


                        if (qihaoinfo != null && !string.IsNullOrEmpty(qihaoinfo.kjcode))
                        {
                            sb.Append($"期号：{qihao}<span style='color:red;'>已存在</span><br /> \r\n");
                            if (onlyfirst)
                            {
                                break;
                            }
                            continue;
                        }

                        DateTime d = DateTime.Parse(kjtime);

 

                        if (qihaoinfo == null)
                        {
                            qhdal.Add(new Qihaoinfo()
                            {
                                czid = czid,
                                czname = czname,
                                createtime = DateTime.Now,
                                kjtime = d,
                                starttime = d.AddMinutes(-5),
                                endtime = d.AddMinutes(-1),
                                qihao = qihao, 
                                kjcode = kjcode, 
                            });
                        }
                        else
                        {
                            //期号存在，开奖号为空，修改
                            qihaoinfo.kjcode = kjcode; 
                            qhdal.Update(qihaoinfo);

                        }



                        sb.Append($"[{czname}],期号：{qihao}，开奖号：{kjcode}，开奖时间 ：{kjtime} <span style='color:green'>已插入</span><br /> \r\n");

                        #region 兑奖
                        sb.Append($"兑奖结果：<br />\r\n");
                        //List<Model.Xiazhuinfo> list_xiazhu = xzdal.GetListArray($"czid=1 and qihao='{qihao}'", "id");
                        //foreach (var xz in list_xiazhu)
                        //{
                        //    try
                        //    {
                        //        string str = this.DuiJiang(xz.id);
                        //        //   sb.Append(str + "<br />\r\n");  前台用户也能采集，不显示每张跟单的兑奖结果
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        //   sb.Append($"跟单【{xz.id}】兑奖出错【{ex.Message}】<br />\r\n");
                        //        //  Util.Log.Error($"跟单【{xz.id}】兑奖出错【{ex.Message}】<br />\r\n");
                        //    }
                        //}
                        #endregion

                        if (onlyfirst)
                        {
                            break;
                        }
                    }


                }

                //document.Close();
                //document.Dispose();
            }
            return sb.ToString();
        }

        public Task<string> InsertQiHao(string qihao, DateTime starttime, int qishu)
        {
            throw new NotImplementedException();
        }
    }
}
