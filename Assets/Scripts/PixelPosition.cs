using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PixelInfo
{
    public Vector3 position;

    public PixelInfo()
    {
        
    }
    public PixelInfo(Vector3 pos)
    {
        this.position = pos;
        
    }
}
