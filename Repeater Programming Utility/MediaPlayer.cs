using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class MediaPlayer
{
    System.Media.SoundPlayer soundPlayer;
    public MediaPlayer(byte[] buffer)
    {
        MemoryStream memoryStream = new MemoryStream(buffer, true);
        soundPlayer = new System.Media.SoundPlayer(memoryStream);
    }
    public void Play() { soundPlayer.Play(); }
    public void Play(byte[] buffer)
    {
        soundPlayer.Stream.Seek(0, SeekOrigin.Begin);
        soundPlayer.Stream.Write(buffer, 0, buffer.Length);
        soundPlayer.Play();
    }
}
