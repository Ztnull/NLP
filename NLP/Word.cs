using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;

namespace NLP
{
    /// <summary>
    /// 提供中文分词、字词统计等相关功能
    /// </summary>
    public class Word : System.Web.UI.Page
    {
        #region 外部属性

        /// <summary>
        /// 外部词典所在路径
        /// </summary>
        public string DictPath { get; set; }

        /// <summary>
        /// 词典，在分词时作参照物
        /// </summary>
        public DataTable Dict { get; set; }

        /// <summary>
        /// 原始文本，需要被分词的长文本
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 分词的最大长度，如传入4，则分出4、3、2字词，默认值：4
        /// </summary>
        public int WordSize { get; set; }

        #endregion

        #region 外部方法

        #region 向指定词典文件中追加新词语
        /// <summary>
        /// 向指定词典文件中追加新词语
        /// </summary>
        /// <param name="SourceJSON">源词典的JSON形式</param>
        /// <param name="TargetDictPath">目标词典的路径</param>
        public bool UpdateDict(string SourceJSON, string TargetDictPath)
        {
            this.DictPath = TargetDictPath;
            DataTable dtTemp = this._ReadDict();
            List<_DictModel> listSource = _Jss.Deserialize<List<_DictModel>>(SourceJSON);
            List<_DictModel> listResult = new List<_DictModel>();
            if (dtTemp != null && listSource != null)
            {
                //去除在目标词典中重复的词语
                foreach (_DictModel dictModel in listSource)
                {
                    if (dtTemp.Select("DictName='" + dictModel.DictName + "'").Length <= 0)
                    {
                        listResult.Add(dictModel);
                    }
                }
            }
            else
            {
                listResult = listSource;
            }
            string SourceResult = _Jss.Serialize(listResult).Replace(",\"DictCount\":0", "");
            if (SourceResult == "[]")
            {
                SourceResult = "";
            }
            else
            {
                SourceResult = SourceResult.TrimStart('[');
                SourceResult = "," + SourceResult;
            }
            string TargetResult = _GetJsonFromDataTable(dtTemp);
            TargetResult = TargetResult.TrimEnd(']');
            SourceResult = SourceResult.Length < 10 ? "" : SourceResult;
            TargetResult = TargetResult.Length < 10 ? "" : TargetResult;
            string Result = TargetResult + SourceResult;
            if (string.IsNullOrEmpty(SourceResult))
            {
                Result += "]";
            }
            if (string.IsNullOrEmpty(TargetResult))
            {
                Result = Result.TrimStart(',');
                Result = "[" + Result;
            }
            Result = Result.Replace(",\"DictCount\":0", "");
            Result = Result == "[]" ? "" : Result;
            try
            {
                FileStream fs = new FileStream(this.DictPath, FileMode.OpenOrCreate);
                byte[] btResult = System.Text.Encoding.Default.GetBytes(Result);
                fs.Write(btResult, 0, btResult.Length);
                fs.Flush();
                fs.Close();
                fs.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region 将包含自定义词典的内容转换为标准JSON格式
        /// <summary>
        /// 将包含自定义词典的内容转换为标准
        /// </summary>
        /// <param name="SourceDict">自定义词典原始内容，例如：词语1,词语2,...</param>
        /// <returns></returns>
        public string GetDictJson(string SourceDict)
        {
            StringBuilder Result = new StringBuilder();
            SourceDict += " ";
            string Temp;
            string WordTemp = "";
            List<string> listDict = new List<string>();
            for (int i = 0; i < SourceDict.Length; i++)
            {
                Temp = SourceDict.Substring(i, 1);
                if (Temp != "," && Temp != "，" && Temp != "." && Temp != "。" && Temp != ":" && Temp != "：" && Temp != ";" && Temp != "；" && Temp != "!" && Temp != "！" && Temp != "、" && Temp != "'" && Temp != "\"" && Temp != " ")
                {
                    WordTemp += Temp;
                }
                else
                {
                    if (!string.IsNullOrEmpty(WordTemp.Trim()))
                    {
                        listDict.Add(WordTemp);
                    }
                    WordTemp = "";//清空临时词语，准备迎接下一个词语
                }
            }
            if (listDict.Count < 1)
            {
                return "";
            }

            #region 拼装JSON
            Result.Append("[");
            for (int i = 0; i < listDict.Count; i++)
            {
                Result.Append("{\"DictName\":\"");
                Result.Append(listDict[i]);
                Result.Append("\",\"DictAttr\":\"\",\"DictNote\":\"\"},");
            }
            Temp = Result.ToString().TrimEnd(',') + "]";
            #endregion

            return Temp;
        }
        #endregion

        #region 初始化类并加载属性默认值
        /// <summary>
        /// 初始化分词类并加载属性默认值
        /// </summary>
        public Word()
        {
            this.WordSize = 4;
            this.Content = "";
            this.DictPath = System.IO.Directory.GetCurrentDirectory() + "\\Dict.txt";
        }

        /// <summary>
        /// 初始化分词类
        /// </summary>
        /// <param name="WordSize">分词的最大长度，如传入4，则分出4、3、2字词</param>
        /// <param name="Content">原始文本，需要被分词的长文本</param>
        public Word(int WordSize, string Content, string DictPath)
        {
            this.WordSize = 4;
            this.Content = "";
            this.DictPath = DictPath;
        }

        /// <summary>
        /// 获取词语数量
        /// </summary>
        /// <param name="HaveRepeatWord">是否统计重复词语</param>
        /// <returns></returns>
        public int GetWordCount(bool HaveRepeatWord)
        {
            if (HaveRepeatWord)
            {
                return _WordCountHaveRepeate;
            }
            else
            {
                return _WordCountWithoutRepeate;
            }
        }

        #endregion

        #region 获取最终的分词结果，以JSON形式返回各词
        /// <summary>
        /// 获取最终的分词结果，以JSON形式返回各词
        /// </summary>
        /// <param name="ReturnJSON">是否以JSON形式返回分词结果，如果否则以“词语 , 词语 , ...”方式返回结果</param>
        /// <returns>JSON形式的分词结果</returns>
        public string GetWord(bool ReturnJSON)
        {
            string Result = "";
            DataRow[] _ArrDr = null;
            int _DictCount = 0;//词语出现次数
            _DictModel _modelDict;
            List<_DictModel> _ListDict = new List<_DictModel>();
            DataTable _dtTemp = new DataTable();
            DataTable dtResult = new DataTable();
            #region 初始化分词结果的表结构
            _dtTemp.Columns.Add("DictName");
            _dtTemp.Columns.Add("DictAttr");
            _dtTemp.Columns.Add("DictNote");
            dtResult = _dtTemp.Clone();
            dtResult.Columns.Add("DictCount");
            #endregion
            this.Dict = this._ReadDict();//加载外部词典到this.Dict
            if (this.Dict == null)
            {
                Result = "外部词典读取出错！请检查外部词典路径。";
                return Result;
            }
            _ArrSentence = this._GetSentence();//对原文分句，分词程序对原文以句为单位进行分词
            for (int i = 0; i < _ArrSentence.Length; i++)
            //对每条句子循环
            {
                if (_ArrSentence[i].Length >= 1)
                //句子内容不为空时才能进行分词
                {
                    //根据WordSize产生对应数量的占位符，以便对逆向匹配后_ArrSentence中剩余的不足WordSize数量的字符进行词典匹配
                    string _Placeholder = "";
                    for (int L = 1; L <= this.WordSize; L++)
                    {
                        _Placeholder += "■";
                    }
                    _ArrSentence[i] = _Placeholder + _ArrSentence[i];
                    for (int j = _ArrSentence[i].Length - this.WordSize; j >= 0; j--)
                    //在句子内进行分词的循环
                    {
                        int _Temp = j;
                        string _TempWord;
                        for (int k = this.WordSize; k >= 2; k--)
                        //k循环用于取不同长度的词
                        {
                            _TempWord = _ArrSentence[i].Substring(_Temp++, k);
                            //如果在词典中找到了匹配的词，则以DataRow类型放入_ArrDr
                            _ArrDr = this.Dict.Select("DictName='" + _TempWord + "'");
                            if (_ArrDr != null && _ArrDr.Length > 0)
                            {
                                _dtTemp.Rows.Add(_ArrDr[0].ItemArray);
                            }
                        }//for k
                    }//for j
                }//if (_ArrSentence[i].Length > 0)
            }//for i

            //统计词语数量（包含重复词语）
            _WordCountHaveRepeate = _dtTemp.Rows.Count;

            #region 去除重复词语，并统计重复次数，按照重复次数降序排列
            for (int i = 0; i < _dtTemp.Rows.Count; i++)
            {
                //_dtTemp自身查询重复词语，如果查询结果>1则表示有重复词，则记录重复次数并删除重复的DataRow
                _ArrDr = _dtTemp.Select("DictName='" + _dtTemp.Rows[i]["DictName"].ToString() + "'");
                _DictCount = _ArrDr.Length;
                if (_DictCount > 1)
                {
                    for (int j = 1; j < _DictCount; j++)
                    {
                        _dtTemp.Rows.Remove(_ArrDr[j]);//删除重复的DataRow
                    }
                }
                dtResult.Rows.Add(_ArrDr[0].ItemArray);
                dtResult.Rows[i]["DictCount"] = _DictCount;//将词的重复次数添加到DictCount字段
            }
            //根据词的重复次数对结果dtResult表排序
            DataView dvTemp = dtResult.DefaultView;
            dvTemp.Sort = "DictCount DESC , DictName ASC";
            dtResult = dvTemp.ToTable();
            #endregion

            //统计词语数量（不含重复词语）
            _WordCountWithoutRepeate = dtResult.Rows.Count;

            //dtResult是以DataTable形式存储的分词结果，现在将dt转化为list，以便最终转换成JSON输出
            string ResultWordList = "";//如果需要返回词语列表（非JSON结果），则用此变量存储结果并返回
            foreach (DataRow drTemp in dtResult.Rows)
            {
                _modelDict = new _DictModel();
                _modelDict.DictName = drTemp["DictName"].ToString();
                _modelDict.DictAttr = drTemp["DictAttr"].ToString();
                _modelDict.DictNote = drTemp["DictNote"].ToString();
                _modelDict.DictCount = Convert.ToInt32(drTemp["DictCount"]);
                _ListDict.Add(_modelDict);
                ResultWordList += _modelDict.DictName + ",";
            }
            if (dtResult.Rows.Count > 0)
            {
                Result = _Jss.Serialize(_ListDict);//生成JSON结果
                ResultWordList = ResultWordList.TrimEnd(',');//生成词语列表结果
            }
            if (ReturnJSON)
            {
                return Result;//返回JSON结果
            }
            else
            {
                return ResultWordList;//返回词语列表结果
            }
        }
        #endregion

        #endregion

        #region 内部属性

        private int _WordCountHaveRepeate = 0;//词语数量，在调用分词程序后被赋值（统计重复词语）
        private int _WordCountWithoutRepeate = 0;//词语数量，在调用分词程序后被赋值（不统计重复词语，重复的词语只计算1次）

        /// <summary>
        /// 词典——词语数据的实体
        /// </summary>
        private class _DictModel
        {
            public string DictName;
            public string DictAttr;
            public string DictNote;
            public int DictCount;
        }
        private JavaScriptSerializer _Jss = new JavaScriptSerializer();
        private string[] _ArrSentence = { };//总内容首先被分割成句子
        #endregion

        #region 内部方法

        #region 将DataTable类型的词典转换为JSON
        /// <summary>
        /// 将DataTable类型的词典转换为JSON
        /// </summary>
        /// <param name="dtDict">DataTable类型的词典</param>
        /// <returns></returns>
        private string _GetJsonFromDataTable(DataTable dtDict)
        {
            string Result = "";
            try
            {
                if (dtDict.Rows.Count < 1)
                {
                    return Result;
                }
            }
            catch (Exception ex)
            {
                return Result;
            }
            List<_DictModel> ListDict = new List<_DictModel>();
            _DictModel DictModel;
            foreach (DataRow dr in dtDict.Rows)
            {
                DictModel = new _DictModel();
                DictModel.DictName = dr["DictName"].ToString();
                DictModel.DictAttr = dr["DictAttr"].ToString();
                DictModel.DictNote = dr["DictNote"].ToString();
                ListDict.Add(DictModel);
            }
            Result = _Jss.Serialize(ListDict);
            return Result;
        }
        #endregion

        #region 读取词典文件
        /// <summary>
        /// 读取词典文件
        /// </summary>
        /// <returns></returns>
        private DataTable _ReadDict()
        {
            DataTable Result = new DataTable();
            _Jss.MaxJsonLength = Int32.MaxValue;
            //初始化词典DataTable的表结构
            Result.Columns.Add("DictName");
            Result.Columns.Add("DictAttr");
            Result.Columns.Add("DictNote");
            DataRow drTemp = Result.NewRow();//从空表中取一个行结构，生成DataRow
            //从外部词典文件中读取全部词典放入DictJson变量中
            string DictJson = "";
            try
            {
                FileStream fs = new FileStream(this.DictPath, FileMode.Open);
                byte[] bt = new byte[fs.Length];
                DictJson = Encoding.Default.GetString(bt, 0, fs.Read(bt, 0, bt.Length));
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                //读取外部词典文件错误
                Result = null;
                return Result;
            }
            try
            {
                List<_DictModel> listTemp = _Jss.Deserialize<List<_DictModel>>(DictJson);
                foreach (_DictModel modelDict in listTemp)
                {
                    drTemp["DictName"] = modelDict.DictName;
                    drTemp["DictAttr"] = modelDict.DictAttr;
                    drTemp["DictNote"] = modelDict.DictNote;
                    Result.Rows.Add(drTemp.ItemArray);
                }
            }
            catch (Exception ex)
            {
                //反序列化DictJson出错
                Result = null;
                return Result;
            }
            return Result;
        }
        #endregion

        #region 全文分句
        /// <summary>
        /// 全文分句
        /// </summary>
        /// <returns></returns>
        private string[] _GetSentence()
        {
            List<string> Result = new List<string>();
            string Temp;
            StringBuilder Temp2 = new StringBuilder();
            for (int i = 0; i < this.Content.Length; i++)
            {
                Temp = this.Content.Substring(i, 1);
                if (Temp != "," && Temp != "，" && Temp != "." && Temp != "。" && Temp != ":" && Temp != "：" && Temp != ";" && Temp != "；" && Temp != "!" && Temp != "！" && Temp != "、" && Temp != "'" && Temp != "\"" && Temp != " ")
                {
                    Temp2.Append(Temp);
                    if (i == this.Content.Length - 1)
                    {
                        Result.Add(Temp2.ToString());
                    }
                }
                else
                {
                    Result.Add(Temp2.ToString());
                    Temp2.Clear();
                }
            }
            return Result.ToArray();
        }
        #endregion

        #endregion

    }//class

}//namespace
