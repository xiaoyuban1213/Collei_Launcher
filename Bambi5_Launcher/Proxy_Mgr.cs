using Fiddler;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Bambi5_Launcher
{
    public class Proxy_Mgr
    {
        //初始化Fiddler
        public Task Run_Fiddler(ushort proxy_port)
        {
            var tk = Task.Run(() =>
            {
                try
                {
                    Stop().Wait();
                    if (FiddlerApplication.IsStarted())
                    {
                        Stop().Wait();
                    }
                    //绑定事件处理————当发起请求之前

                    FiddlerApplication.BeforeRequest += new SessionStateHandler(On_BeforeRequest);
                    //-----------处理证书-----------
                    //伪造的证书
                    X509Certificate2 oRootCert;
                    //如果没有伪造过证书并把伪造的证书加入本机证书库中
                    if (null == CertMaker.GetRootCertificate())
                    {
                        //创建伪造证书
                        CertMaker.createRootCert();

                        //重新获取
                        oRootCert = CertMaker.GetRootCertificate();

                        //打开本地证书库
                        X509Store certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                        certStore.Open(OpenFlags.ReadWrite);
                        try
                        {
                            //将伪造的证书加入到本地的证书库
                            certStore.Add(oRootCert);
                        }
                        finally
                        {
                            certStore.Close();
                        }
                    }
                    else
                    {
                        //以前伪造过证书，并且本地证书库中保存过伪造的证书
                        oRootCert = CertMaker.GetRootCertificate();
                    }

                    //-----------------------------

                    //指定伪造证书
                    FiddlerApplication.oDefaultClientCertificate = oRootCert;
                    //忽略服务器证书错误
                    CONFIG.IgnoreServerCertErrors = true;
                    //信任证书
                    CertMaker.trustRootCert();
                    FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
                    Fiddler.FiddlerCoreStartupSettingsBuilder settings =
                    new Fiddler.FiddlerCoreStartupSettingsBuilder()
                    .DecryptSSL()
                    .RegisterAsSystemProxy()
                    .ListenOnPort(proxy_port);
                    //启动代理服务
                    FiddlerApplication.Startup(settings.Build());
                    int iport = proxy_port - 1;
                    if (proxy_port == 1)
                    {
                        iport = proxy_port + 1;
                    }
                    //创建https代理
                    FiddlerApplication.CreateProxyEndpoint(proxy_port - 1, true, oRootCert);
                }
                catch (Exception e)
                {
                    Program.Application_Exception(e);
                }
            });
            return tk;
        }
        public string host;
        public static void On_BeforeRequest(Session oS)
        {
            if (oS.host.EndsWith(".yuanshen.com") || oS.host.EndsWith(".hoyoverse.com") || oS.host.EndsWith(".mihoyo.com"))
            {
                string ohost = oS.host + ":" + oS.port;
                oS.host = Index_Form.indexf.server.host;
                if (oS.port == 443 || oS.port == 80)
                {
                    oS.port = Index_Form.indexf.server.dispatch;
                }
                Index_Form.indexf.Print_log(ohost + " -> " + oS.host);
            }
            if (oS.port == 22102)
            {
                oS.port = Index_Form.indexf.server.game;
            }
        }


        public Task Stop()
        {
            return Task.Run(() =>
             {
                 FiddlerApplication.Shutdown();
             });
        }
    }
}
