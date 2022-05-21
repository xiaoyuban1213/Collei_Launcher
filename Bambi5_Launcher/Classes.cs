using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Bambi5_Launcher;
using System.Threading.Tasks;

public static class Classes
{
    /// <summary>
    /// 16进制原码字符串转字节数组
    /// </summary>
    /// <param name="hexString">"AABBCC"或"AA BB CC"格式的字符串</param>
    /// <returns></returns>
    public static byte[] ConvertHexStringToBytes(string hexString)
    {
        try
        {
            hexString = hexString.Replace(" ", "");
            if (hexString.Length % 2 != 0)
            {
                MessageBox.Show("参数长度不正确", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "在转换byte[]时出现错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
    public static bool DebugBuild(Assembly assembly)
    {
        foreach (object attribute in assembly.GetCustomAttributes(false))
        {
            if (attribute is DebuggableAttribute)
            {
                DebuggableAttribute _attribute = attribute as DebuggableAttribute;

                return _attribute.IsJITTrackingEnabled;
            }
        }
        return false;
    }
    public static string ConvertJsonString(string str)
    {
        //格式化json字符串
        JsonSerializer serializer = new JsonSerializer();
        TextReader tr = new StringReader(str);
        JsonTextReader jtr = new JsonTextReader(tr);
        object obj = serializer.Deserialize(jtr);
        if (obj != null)
        {
            StringWriter textWriter = new StringWriter();
            JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
            {
                Formatting = Formatting.Indented,
                Indentation = 4,
                IndentChar = ' '
            };
            serializer.Serialize(jsonWriter, obj);
            return textWriter.ToString();
        }
        else
        {
            return str;
        }
    }
    /// <summary>
    /// 将文件大小(字节)转换为最适合的显示方式
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public static string ConvertFileSize(long size)
    {
        string result = "0KB";
        int filelength = size.ToString().Length;
        if (filelength < 4)
            result = size + "byte";
        else if (filelength < 7)
            result = Math.Round(Convert.ToDouble(size / 1024d), 2) + "KB";
        else if (filelength < 10)
            result = Math.Round(Convert.ToDouble(size / 1024d / 1024), 2) + "MB";
        else if (filelength < 13)
            result = Math.Round(Convert.ToDouble(size / 1024d / 1024 / 1024), 2) + "GB";
        else
            result = Math.Round(Convert.ToDouble(size / 1024d / 1024 / 1024 / 1024), 2) + "TB";
        return result;
    }

    /// <summary>
    /// 指定Post地址使用Get 方式获取全部字符串
    /// </summary>
    /// <param name="url">请求后台地址</param>
    /// <param name="content">Post提交数据内容(utf-8编码的)</param>
    /// <returns></returns>
    public static string Post(string url, string content)
    {
        try
        {
            SetCertificatePolicy();
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.Timeout = 2000;
            req.ContentType = "application/json";
            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        catch (Exception e)
        {
            Debug.Print(e.Message);
            return null;
        }
    }
    /// <summary>
    /// 获取当前的时间戳
    /// </summary>
    /// <returns></returns>
    public static string Timestamp()
    {
        long ts = ConvertDateTimeToInt(DateTime.Now);
        return ts.ToString();
    }

    /// <summary>  
    /// 将c# DateTime时间格式转换为Unix时间戳格式  
    /// </summary>  
    /// <param name="time">时间</param>  
    /// <returns>long</returns>  
    public static long ConvertDateTimeToInt(System.DateTime time)
    {
        //System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
        //long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
        long t = (time.Ticks - 621356256000000000) / 10000;
        return t;
    }
    public static DateTime getdate(long jsTimeStamp)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
        DateTime dt = startTime.AddMilliseconds(jsTimeStamp);
        return dt;
        //System.Console.WriteLine(dt.ToString("yyyy/MM/dd HH:mm:ss:ffff"));
    }
    /// <summary>
    /// 设置证书安全性
    /// </summary>
    public static void SetCertificatePolicy()
    {
        ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
    }

    ///  <summary>
    ///  远程证书验证
    ///  </summary>
    public static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
    {
        return true;
    }
    public static string Get(string url)
    {
        try
        {
            SetCertificatePolicy();
            DateTime st = DateTime.Now;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 3000;
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var text = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Debug.WriteLine(Classes.ConvertDateTimeToInt(response.LastModified) - Classes.ConvertDateTimeToInt(st)+"ms");
            response.Close();
            return text;
        }
        catch(Exception e)
        {
            Debug.Print(e.Message);
            return null;
        }
    }
    public static Index_Get Get_for_Index(string url)
    {
        var tk = Task.Run(() =>
        {
            SetCertificatePolicy();
            DateTime st = DateTime.Now;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 3000;
            request.ContentType = "application/json";
            Index_Get res = new Index_Get();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var text = new StreamReader(response.GetResponseStream()).ReadToEnd();
                res.Result = text;
                res.Use_time = Classes.ConvertDateTimeToInt(response.LastModified) - Classes.ConvertDateTimeToInt(st);
                res.StatusCode = response.StatusCode;
                response.Close();
                return res;
            }
            catch (WebException ex)
            {

                if (ex.Response == null)
                {
                    res.Result = ex.Message;
                    res.Use_time = -1;
                    Console.WriteLine("ex.Response == null");
                    return res;
                }
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                res.Use_time = Classes.ConvertDateTimeToInt(response.LastModified) - Classes.ConvertDateTimeToInt(st);
                res.StatusCode = response.StatusCode;
                res.Result = response.StatusDescription;
                Console.WriteLine("错误码:" + (int)response.StatusCode);
                Console.WriteLine("错误码描述:" + response.StatusDescription);
                return res;
            }
            catch (Exception e)
            {
                res.Use_time = -2;
                res.Result = e.Message; ;
                Debug.Print(e.Message);
                return null;
            }
        });
        tk.Wait(3000);
        return tk.Result;

    }
}

