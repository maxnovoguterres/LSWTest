using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsSection : Section
{
    public GameObject player;
    public GameObject camera;

    public void OnCLickOkButton()
    {
        player.SetActive(true);
        camera.SetActive(true);
        HideSection();
    }
}
