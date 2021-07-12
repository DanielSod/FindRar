using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindRarCon.Models
{
    public class YesOrNo
    {

        public static string YorN = "Y/N?";


        public bool AnswerYesOrNo()
        {
            Console.WriteLine("Admit answer Y/N:");
            YorN = Console.ReadLine();
            YorN.ToLower();
            if (YorN == "y")
            {
                return true;
            }
            else if (YorN == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Answer with y for yes");
                Console.WriteLine("         or n for no");
                Thread.Sleep(1000);
                return false;
            }

            
        }
    }
}
