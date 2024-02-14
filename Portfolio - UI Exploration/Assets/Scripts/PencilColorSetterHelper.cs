using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelUtils.Interaction.WorldMouse;

public class PencilColorSetterHelper : MonoBehaviour
{
    [Header("VRDrawController Reference")]
    [SerializeField] VRDrawController drawController;
    // Start is called before the first frame update
    [Header("Color Pallete")]
    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    [SerializeField] Color color4;
    [SerializeField] Color color5;
    
    public void setLineColor(Color color)
    {
        drawController.setLineColor(color);
    }

    public void setLineColor1()
    {
        setLineColor(color1);
    }

    public void setLineColor2()
    {
        setLineColor(color2);
    }

    public void setLineColor3()
    {
        setLineColor(color3);
    }

    public void setLineColor4()
    {
        setLineColor(color4);
    }

    public void setLineColor5()
    {
        setLineColor(color5);
    }

}
