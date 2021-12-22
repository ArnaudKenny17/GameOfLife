using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway
{
    internal class Game : Generation
    {
        
        public Game(int width,int height,double density) : base(width,height,density)
        {
        }
        public Game(Game obj,string s): base(obj,s)
        {
           
        }
     
    }
}
