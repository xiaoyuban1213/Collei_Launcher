using Fiddler;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Collei_Launcher
{
    public class Proxy_Mgr
    {
        public Proxy_Mgr(Index_Form index)
        {
            Index = index;
            handler = new SessionStateHandler(Index.On_BeforeRequest);
        }
        public Index_Form Index { get; set; }
        //初始化Fiddler
        public X509Certificate2 oRootCert;
        public SessionStateHandler handler;
        public Task Run_Fiddler()
        {
            var tk = Task.Run(() =>
            {
                ushort proxy_port = Main_Form.form.lc.config.ProxyPort;
                try
                {
                    Stop().Wait();
                    //绑定事件处理————当发起请求之前

                    FiddlerApplication.BeforeRequest += handler;
                    //-----------处理证书-----------
                    //伪造的证书
                    //如果没有伪造过证书并把伪造的证书加入本机证书库中
                    if (CertMaker.GetRootCertificate()==null)
                    {
                        Debug.Print("未找到证书");
                        //创建伪造证书
                        CertMaker.createRootCert();
                        //重新获取
                        oRootCert = CertMaker.GetRootCertificate();
                        Add_Cert(oRootCert);
                    }
                    else
                    {
                    
                        Debug.Print("已找到证书");
                        //以前伪造过证书，并且本地证书库中保存过伪造的证书
                        oRootCert = CertMaker.GetRootCertificate();
                    }
                    //-----------------------------

                    //指定伪造证书
                    FiddlerApplication.oDefaultClientCertificate = oRootCert;
                    //忽略服务器证书错误
                    CONFIG.IgnoreServerCertErrors = true;
                    FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
                    Fiddler.FiddlerCoreStartupSettingsBuilder settings =
                    new Fiddler.FiddlerCoreStartupSettingsBuilder()
                    .DecryptSSL()
                    .ListenOnPort(proxy_port)
                    .AllowRemoteClients();
                    //启动代理服务
                    FiddlerApplication.Startup(settings.Build());
                    int iport = proxy_port - 1;
                    if (proxy_port == 1)
                    {
                        iport = proxy_port + 1;
                    }
                    //创建https代理
                    FiddlerApplication.CreateProxyEndpoint(iport, true, oRootCert);
                }
                catch (Exception e)
                {
                    Program.Application_Exception(e);
                }
            });
            return tk;
        }
        public string host;


        public Task Stop()
        {
            return Task.Run(() =>
             {
                 FiddlerApplication.BeforeRequest -= handler;
                 FiddlerApplication.Shutdown();
                 Remove_Cert(oRootCert);
             });
        }
        public void Add_Cert(X509Certificate2 cert)
        {
            if (cert == null)
                return;
            X509Store certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadWrite);
            try
            {
                //将伪造的证书加入到本地的证书库
                certStore.Add(cert);
            }
            finally
            {
                certStore.Close();
            }
        }
        public void Remove_Cert(X509Certificate2 cert)
        {
            if(cert ==null)
                return;
            X509Store certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadWrite);
            try
            {
                //将伪造的证书刪除
                if(certStore.Certificates.Contains(cert))
                certStore.Remove(cert);
            }
            finally
            {
                certStore.Close();
            }
        }

    }
}
