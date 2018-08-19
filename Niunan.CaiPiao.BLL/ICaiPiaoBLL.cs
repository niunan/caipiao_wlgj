using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niunan.CaiPiao.BLL
{
    /// <summary>
    /// 彩票业务接口
    /// </summary>
    public interface ICaiPiaoBLL
    {
        /// <summary>
        /// 兑奖
        /// </summary>
        /// <param name="xiazhuid">xiazhuinfo表的id</param>
        /// <returns></returns>
        string DuiJiang(int xiazhuid);


        /// <summary>
        /// 根据期号取业务裸体类
        /// </summary>
        /// <param name="qihao"></param>
        /// <returns></returns>
        Model.CaiPiao GetModel(string qihao);

        /// <summary>
        /// 根据当前时间取当前期
        /// </summary>
        /// <returns></returns>
        Model.CaiPiao GetCurrentModel();

        /// <summary>
        /// 
        /// 插入期号表
        /// </summary>
        /// <param name="qihao">开始时间对应的期号</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="qishu">插入几期</param> 
        string   InsertQiHao(string qihao, DateTime starttime, int qishu);

        /// <summary>
        /// 插入开奖号，扒福彩网页面HTML，取最新期号开奖数据插入
        /// </summary>
        ///  <param name="onlyfirst">只插第1期？默认是false</param>
        Task<string> InsertKJCodeAsync(bool onlyfirst = false,string url = "");
    }
}
