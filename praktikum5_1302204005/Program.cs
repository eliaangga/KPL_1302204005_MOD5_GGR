using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktikum5_1302204005 {
    internal class Program {
        static void Main(string[] args) {
            VideoSayaTubeGanteng s = new VideoSayaTubeGanteng("Review The Adam Project oleh Elia Angga");
            VideoSayaTubeGanteng s1 = new VideoSayaTubeGanteng("Review Film Business Proposal oleh Elia Angga");
            VideoSayaUserLaku ss = new VideoSayaUserLaku("Elia Angga");
            s.IncreasePlayCount(1);
            s1.IncreasePlayCount(3);
            ss.AddVideo(s);
            ss.AddVideo(s1);

            s.PrintVideoDetails();

            ss.PrintAllVideoPlaycount();
        }
    }


    internal class VideoSayaTubeGanteng {
        private int id;
        private String title;
        private int playCount;

        public VideoSayaTubeGanteng(String title) {

            //random number
            Random random = new Random();
            this.id = random.Next(10000, 99999);

            //null with max value
            if (title == "")
                throw new NullReferenceException("title tidak diperbolehkan bernilai null");
            if (title.Length > 100)
                throw new Exception("panjang text maximal bernilai 100");

            this.title = title;


            this.playCount = 0;
        }

        public void IncreasePlayCount(int a) {
            this.playCount = a;
        }

        public int getPlayCount() {
            return this.playCount;
        }

        public String getTitle() {
            return this.title;
        }

        public void PrintVideoDetails() {
            for (int i = 0; i < playCount; i++) {

                Console.WriteLine("ID Video : " + this.id);
                Console.WriteLine("Judul Video : " + this.title);
                Console.WriteLine("Playcount Video : " + (i + 1));
                Console.WriteLine();
            }
        }
    }

     internal class VideoSayaUserLaku {
        
        private int id;
        private List<VideoSayaTubeGanteng> uploadedVideos;
        private string Username;

        public VideoSayaUserLaku(String username) {
            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.uploadedVideos = new List<VideoSayaTubeGanteng>();
            this.Username = username;
        }

        public int GetTotalVideoPlayCount() {
            int total = 0;
            for (int i = 0; i < uploadedVideos.Count; i++)
                total = total + uploadedVideos[i].getPlayCount();
            return total;
        }

        public void AddVideo(VideoSayaTubeGanteng a) {
            uploadedVideos.Add(a);
        }

        public void PrintAllVideoPlaycount() {
            Console.WriteLine("User : " + this.Username);
            for (int i = 0; i < uploadedVideos.Count; i++)
                Console.WriteLine("Video " + (i + 1) + " Judul: " + uploadedVideos[i].getTitle());
            Console.WriteLine();
            Console.WriteLine("Total playcount : " + GetTotalVideoPlayCount());
        }
    }
}
