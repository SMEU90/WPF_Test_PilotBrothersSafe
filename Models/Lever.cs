using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Test_PilotBrothersSafe.ViewModels.Base;
using System.Security.Cryptography;

namespace WPF_Test_PilotBrothersSafe.Models
{
    internal class Lever : ViewModel
    {
        public override string ToString()
        {
            return im_lever;
        }
        public Lever(int x, int y)
        {
            RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider();
            byte[] rno = new byte[5];
            rg.GetBytes(rno);
            int randomvalue = BitConverter.ToInt32(rno, 0);
            if (randomvalue % 2 == 0)
            {
                orientation = Orientation.horizontal;
                im_lever = "--";
            }
            else
            {
                orientation = Orientation.vertical;
                im_lever = " |";
            }
            X = x;
            Y = y;
        }
        public Lever(int x, int y, bool flag)
        {
            if (flag)
            {
                orientation = Orientation.vertical;
                im_lever = " |";
            }
            else
            {
                orientation = Orientation.horizontal;
                im_lever = "--";
            }
            X = x;
            Y = y;
        }
        public string im_lever;
        public enum Orientation { vertical, horizontal }
        public Orientation orientation;
        public int X;
        public int Y;
    }
}
