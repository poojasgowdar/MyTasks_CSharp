using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyInjection
{
   public interface ISpeaker
   {
        void PlaySound();
   }

   public class BluetoothSpeaker : ISpeaker
   {
       public void PlaySound()
       {
            Console.WriteLine("Speakers are Good");
       }
   }
   
    public class MusicPlayer
    {
        public ISpeaker Speaker { get; set; }
        public void PlayMusic()
        {
            if (Speaker != null)
            {
                Speaker.PlaySound();
            }
            Console.WriteLine("No Speakers are not good");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicPlayer player = new MusicPlayer();
            player.PlayMusic();

            player.Speaker = new BluetoothSpeaker(); 
            player.PlayMusic();
            Console.ReadKey();
        }
    }
}
