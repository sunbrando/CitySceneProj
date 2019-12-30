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
		HUDBrowser.RegisterFunction("cityscene", args => LoadCityScene());
    }


    public void LoadCityScene()
    {
        SceneManager.LoadScene("City");
    }
}
