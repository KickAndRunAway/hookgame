using UnityEngine;
using Cinemachine;

public class DisableCinemachine : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public UIManager uim;

    void Start()
    {
        if (uim.isGameOver)
        {
            virtualCamera.enabled = false;
        }
    }
}
