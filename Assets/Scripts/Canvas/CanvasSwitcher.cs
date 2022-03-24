using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;

    CanvasManager canvasManager;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);        //This OnButtonClicked Function will trigger everytime the Button is clicked
        canvasManager = CanvasManager.GetInstance();
    }


    void OnButtonClicked()
    {
        canvasManager.SwitchCanvas(desiredCanvasType);
    }
}
