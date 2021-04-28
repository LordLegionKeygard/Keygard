using UnityEngine;
using UnityEngine.UI;

public class TeleportButton : MonoBehaviour
{
    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Teleport);
    }

    private void Teleport()
    {
        FindObjectOfType<PlayerController>().TeleportToFinish();
    }
}
