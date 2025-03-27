using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject UIStuff;

    public void HideUI()
    {
        UIStuff.SetActive(false);
    }
}
