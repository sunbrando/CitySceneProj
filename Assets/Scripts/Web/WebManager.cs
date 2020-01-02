using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenFulcrum.EmbeddedBrowser;
using UnityEngine.SceneManagement;

public class WebManager : MonoBehaviour
{
    public static WebManager Instance { get; private set; }

	private bool haveMouse = false;

	public PointerUIGUI hud;

	public Browser HUDBrowser { get; private set; }

	public void Awake() {
		Instance = this;
	}

	public void Start() {
		HUDBrowser = hud.GetComponent<Browser>();

		BrowserCursor cursor = HUDBrowser.UIHandler.BrowserCursor;
		cursor.cursorChange += CursorChange;

		if (CtrlModel.sceneOrUI == SceneOrUI.Main)
		{
			HUDBrowser.Url = "localGame://index.html";
		}
		else if (CtrlModel.sceneOrUI == SceneOrUI.ZhaoCha)
		{
			HUDBrowser.Url = "localGame://zhaocha.html";
		}
		else if (CtrlModel.sceneOrUI == SceneOrUI.WenJuan)
		{
			HUDBrowser.Url = "localGame://wenjuan.html";
		}
    }

 	void CursorChange()
	 {
		HUDBrowser.RegisterFunction("cityscene", args => LoadCityScene());
	 }

    public void LoadCityScene()
    {
		CtrlModel.sceneOrUI = SceneOrUI.Scene;
        SceneManager.LoadScene("City");
    }
}
