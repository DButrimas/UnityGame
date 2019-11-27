using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SceneData
{

    public enum enterDirections {UP, DOWN, LEFT, RIGHT };
    public int enterDirection { get; set; }

    public SceneData()
    {
        enterDirection = 3;


    }


}

