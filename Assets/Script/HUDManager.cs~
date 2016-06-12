using UnityEngine;
using System.Collections;
using System;

public class HUDManager : MonoBehaviour
{

	public string bundleURL;
	public string assetName;

	IEnumerator Start ()
	{
		// Download the file from the URL. It will not be saved in the Cache
		using (WWW www = new WWW (bundleURL)) {
			yield return www;
			if (www.error != null)
				throw new Exception ("WWW download had an error:" + www.error);
			AssetBundle bundle = www.assetBundle;
			if (assetName == "")
				Instantiate (bundle.mainAsset);
			else
				Instantiate (bundle.LoadAsset (assetName));
			// Unload the AssetBundles compressed contents to conserve memory
			bundle.Unload (false);

		}
	}
}

