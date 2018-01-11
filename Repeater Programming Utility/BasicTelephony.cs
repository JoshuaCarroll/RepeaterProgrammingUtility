using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;


public class BasicTelephony
{
    private Dictionary<string, DTMF> _dtmfTones = new Dictionary<string, DTMF>();
    public Dictionary<string, DTMF> DTMFTones
    {
        get { return _dtmfTones; }
    }

    public BasicTelephony()
    {
        DTMF d;

        d = new DTMF();
        d.Digit = "1";
        d.Frequency1 = 697;
        d.Frequency2 = 1209;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "2";
        d.Frequency1 = 697;
        d.Frequency2 = 1336;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "3";
        d.Frequency1 = 697;
        d.Frequency2 = 1477;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "4";
        d.Frequency1 = 770;
        d.Frequency2 = 1209;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "5";
        d.Frequency1 = 770;
        d.Frequency2 = 1336;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "6";
        d.Frequency1 = 770;
        d.Frequency2 = 1477;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "7";
        d.Frequency1 = 852;
        d.Frequency2 = 1209;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "8";
        d.Frequency1 = 852;
        d.Frequency2 = 1336;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "9";
        d.Frequency1 = 852;
        d.Frequency2 = 1477;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "0";
        d.Frequency1 = 941;
        d.Frequency2 = 1336;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "A";
        d.Frequency1 = 697;
        d.Frequency2 = 1633;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "B";
        d.Frequency1 = 770;
        d.Frequency2 = 1633;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "C";
        d.Frequency1 = 852;
        d.Frequency2 = 1633;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "D";
        d.Frequency1 = 941;
        d.Frequency2 = 1633;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "#";
        d.Frequency1 = 941;
        d.Frequency2 = 1477;
        _dtmfTones.Add(d.Digit, d);

        d = new DTMF();
        d.Digit = "*";
        d.Frequency1 = 941;
        d.Frequency2 = 1209;
        _dtmfTones.Add(d.Digit, d);

    }

    public byte[] WriteWAVFile(int SampleRate, int bitSamples, int totalChannels, MemoryStream Data)
    {
        MemoryStream bw = new MemoryStream();
        //RIFF HEADER
        bw.Write(ASCIIEncoding.ASCII.GetBytes("RIFF"), 0, 4);
        bw.Write(BitConverter.GetBytes((Int32)(Data.Length + 36)), 0, 4);
        bw.Write(ASCIIEncoding.ASCII.GetBytes("WAVE".ToCharArray()), 0, 4);

        // SUBCHUNK
        bw.Write(ASCIIEncoding.ASCII.GetBytes("fmt ".ToCharArray()), 0, 4);
        bw.Write(BitConverter.GetBytes((Int32)16), 0, 4); // Chunk size = 16 para PCM
        bw.Write(BitConverter.GetBytes((Int16)1), 0, 2); // Audio Format: 1 - PCM 6 - A-law 7-u law
        bw.Write(BitConverter.GetBytes((Int16)totalChannels), 0, 2); // 1 - Mono, 2 - Stereo
        bw.Write(BitConverter.GetBytes((Int32)SampleRate), 0, 4);
        bw.Write(BitConverter.GetBytes((Int32)(SampleRate * ((bitSamples * totalChannels) / 8))), 0, 4); // ByteRate
        bw.Write(BitConverter.GetBytes((Int16)(totalChannels * bitSamples / 8)), 0, 2);
        bw.Write(BitConverter.GetBytes((Int16)bitSamples), 0, 2);

        // DATA CHUNK
        bw.Write(ASCIIEncoding.ASCII.GetBytes("data".ToCharArray()), 0, 4);
        bw.Write(BitConverter.GetBytes((Int32)Data.Length), 0, 4);

        Data.Position = 0;
        byte[] BufferData = new byte[Data.Length];
        Data.Read(BufferData, 0, (int)Data.Length);
        bw.Write(BufferData, 0, (int)Data.Length);

        Data.Close();

        bw.Position = 0;
        BufferData = new byte[bw.Length];
        bw.Read(BufferData, 0, (int)bw.Length);
        bw.Close();
        return BufferData;
    }

    public MemoryStream GenerateDTMF(string CompleteNumber, int DelayBetweenDigits, int DTMFDelay, int SampleRate, int BitSample)
    {
        string CurrentNumber = "0";
        DTMF d;
        MemoryStream bw = new MemoryStream();
        for (int i = 0; i < CompleteNumber.Length; i++)
        {
            CurrentNumber = CompleteNumber.Substring(i, 1);
            d = _dtmfTones[CurrentNumber];

            double xStep1 = ((2.0 * Math.PI) / SampleRate) * d.Frequency1;
            double xStep2 = ((2.0 * Math.PI) / SampleRate) * d.Frequency2;

            short yValue = 0;
            double xValue1 = 0;
            double xValue2 = 0;
            double Volume = 0;

            if(BitSample == 16) Volume = 30000;
            else Volume = 126;
            for (int j = 0; j < (DTMFDelay * SampleRate) / 1000; j++)
            {
                xValue1 += xStep1;
                xValue2 += xStep2;
                yValue = (short)( (Math.Sin(xValue1) * (Volume/2))  + (Math.Sin(xValue2) * (Volume/2)));
                
                if (BitSample == 16)
                {
                    bw.Write(BitConverter.GetBytes(yValue), 0, 2);
                }
                else
                {
                    yValue = (short)(yValue + 128);
                    bw.WriteByte((byte)yValue);
                }
            }
            for (int j = 0; j < (DelayBetweenDigits * SampleRate) / 1000; j++)
            {
                if (BitSample == 16)
                {
                    bw.WriteByte(0);
                }
                else
                {
                    bw.WriteByte(127);
                }
            }
        }
        
        bw.Position = 0;
        return (bw);
    }

}

public struct DTMF
{
    private string digit;
    public string Digit
    {
        get
        {
            return digit;
        }
        set
        {
            if ((value.Length == 1) && ("0123456789abcdABCD*#".Contains(value.ToUpper())))
            {
                digit = value.ToUpper();
            }
        }
    }
    public int Frequency1;
    public int Frequency2;
}
