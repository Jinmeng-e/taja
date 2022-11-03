using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private void OnGUI()
    {
        GetKeyInputs();
    }

    private void GetKeyInputs()
    {
        Event e = Event.current;
        if(e == null)
        {
            return;
        }
        if (e.isKey && e.type == EventType.KeyDown && e.keyCode != KeyCode.None)
        {
            Debug.Log("Detected key code: " + e.keyCode);
        }
    }

}
