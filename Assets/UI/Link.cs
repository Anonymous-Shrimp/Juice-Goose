using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public InputField Field;
    string link;

	public void OpenLinkJS()
	{
        Field.text = link;
		Application.ExternalEval("window.open('"+Field.text+"');");
	}

	public void OpenLinkJSPlugin(string _link)
	{
        link = _link;
		#if !UNITY_EDITOR
		openWindow(Field.text);
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}