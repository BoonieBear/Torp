﻿using System;
using LOUV.Torp.TraceService;
//using LOUV.Torp.ACMP;
using System.Text;
namespace LOUV.Torp.MonTrace
{
    
    /// <summary>
    /// 调用tracefile类生成需要的记录文件，
    /// </summary>
    public class MonTraceService
    {
        private TraceFile _traceFile = TraceFile.GetInstance();
        
        private bool IsCreate = false;
        public string Error
        {
            get { return _traceFile.Errormsg; }
        }

        
        public MonTraceService()
        {

        }


        /// <summary>
        /// 根据运行模式生成不同的记录文件
        /// </summary>
        /// <returns>生成结果</returns>
        public bool CreateService()
        {
            /*
            if (IsCreate)
                return true;
            if (_mode==MonitorMode.SHIP)
            {
                if (_traceFile.CreateFile("Chart", TraceType.String, "Chart", "txt", @"\WORD") == false)
                {
                    return false;
                }
                if (_traceFile.CreateFile("GPS", TraceType.String, "GPS", "gps", @"\GPS") == false)
                {
                    return false;
                }
                if (_traceFile.CreateFile("USBL", TraceType.String, "Usbl", "pos", @"\USBL") == false)
                {
                    return false;
                }
                if (_traceFile.CreateFile("FH", TraceType.String, "FH", "fh", @"\FH") == false)
                {
                    return false;
                }
                //通信数据
                if (_traceFile.CreateFile("XMTFSK", TraceType.Binary, "Fsk", "xfd", @"\XmtFSK") == false)
                {
                    return false;
                }

                if (_traceFile.CreateFile("RECVFSK", TraceType.Binary, "Fsk", "rfd", @"\RECVFSK") == false)
                {
                 
                    return false;
                }
                if (_traceFile.CreateFile("FSKSRC", TraceType.Binary, "Fsk", "src", @"\RECVFSK") == false)
                {

                    return false;
                }
                if (_traceFile.CreateFile("RECVPSK", TraceType.Binary, "Psk", "rpd", @"\RECVPSK") == false)
                {

                    return false;
                }
                if (_traceFile.CreateFile("PSKSRC", TraceType.Binary, "Psk", "src", @"\RECVPSK") == false)
                {

                    return false;
                }
                if (_traceFile.CreateFile("PSKJPC", TraceType.Binary, "Psk", "jpc", @"\RECVPSK") == false)//压缩Jpeg2000
                {

                    return false;
                }
                if (_traceFile.CreateFile("IMG", TraceType.Binary, "Img", "jpg", @"\RECVPSK") == false)//图像
                {

                    return false;
                }
                //水声数据
                if (_traceFile.CreateFile("RECVVOICE", TraceType.SingleBinary, "RecvVoice", "rwav", @"\RecvVoice") == false)
                {
                 
                    return false;
                }
                //录音数据
                if (_traceFile.CreateFile("XMTVOICE", TraceType.SingleBinary, "XmtVoice", "xwav", @"\XmtVoice") == false)
                {
                 
                    return false;
                }
                //航控数据
                if (_traceFile.CreateFile("ACOUSTICTOSAIL", TraceType.SingleBinary, "AcousticData", "ats", @"\AtsData") == false)
                {
                 
                    return false;
                }
            }
            else if (_mode == MonitorMode.SUBMARINE)
            {
                if (_traceFile.CreateFile("Chart", TraceType.String, "Chart", "txt", @"\WORD") == false)
                {
                    return false;
                }

                if (_traceFile.CreateFile("BP", TraceType.SingleBinary, "Bp", "bp", @"\BP") == false)
                {
                    return false;
                }
                if (_traceFile.CreateFile("FH", TraceType.String, "FH", "fh", @"\FH") == false)
                {
                    return false;
                }
                //通信数据
                if (_traceFile.CreateFile("XMTFSK", TraceType.Binary, "Fsk", "xfd", @"\XmtFSK") == false)
                {
                    return false;
                }

                if (_traceFile.CreateFile("RECVFSK", TraceType.Binary, "Fsk", "rfd", @"\RECVFSK") == false)
                {

                    return false;
                }
                if (_traceFile.CreateFile("FSKSRC", TraceType.Binary, "Fsk", "src", @"\RECVFSK") == false)
                {

                    return false;
                }
                if (_traceFile.CreateFile("XMTPSK", TraceType.Binary, "Psk", "xpd", @"\XmtPSK") == false)
                {

                    return false;
                }
                if (_traceFile.CreateFile("XMTIMG", TraceType.Binary, "Psk", "img", @"\XmtPSK") == false)
                {

                    return false;
                }
                //水声数据
                if (_traceFile.CreateFile("RECVVOICE", TraceType.SingleBinary, "RecvVoice", "rwav", @"\RecvVoice") == false)
                {
                    
                    return false;
                }
                //录音数据
                if (_traceFile.CreateFile("XMTVOICE", TraceType.SingleBinary, "XmtVoice", "xwav", @"\XmtVoice") == false)
                {
                    
                    return false;
                }
                //航控数据
                if (_traceFile.CreateFile("SAILTOACOUSTIC", TraceType.SingleBinary, "SailData", "sta", @"\StaData") == false)
                {
                    
                    return false;
                }
                if (_traceFile.CreateFile("ACOUSTICTOSAIL", TraceType.SingleBinary, "AcousticData", "ats", @"\AtsData") == false)
                {
                    
                    return false;
                }
                //ADCP
                if (_traceFile.CreateFile("ADCP", TraceType.SingleBinary, "Adcp", "vlt", @"\ADCP") == false)
                {
                    
                    return false;
                }
                if (_traceFile.CreateFile("BSSS", TraceType.SingleBinary, "Bsss", "bsss", @"\BSSS") == false)
                {

                    return false;
                }
            }
            else//不可能
            {
                return false;
            }*/
            IsCreate = true;
            return true;
        }

        public bool TearDownService()
        {
            IsCreate = false;
            return _traceFile.Close();
        }

        public long Save(string sType, object bTraceBytes)
        {
            long ret = 0;
            try
            {
                switch (_traceFile.GeTraceType(sType))
                {
                    case TraceType.Binary:
                        ret = _traceFile.WriteData(sType, (byte[])bTraceBytes);
                        break;
                    case TraceType.SingleBinary:
                        ret = _traceFile.WriteSingleData(sType, (byte[])bTraceBytes);
                        break;
                    case TraceType.String:
                        ret = _traceFile.WriteString(sType, (string)bTraceBytes);
                        break;
                    default://none
                        ret = 0;
                        break;
                }
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            
            return ret;
           
        }

    }
}
