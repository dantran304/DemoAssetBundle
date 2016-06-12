using UnityEngine;
using System.Collections;
using System;

public class HUDManager : MonoBehaviour
{

	public string bundleURL;
	public string assetName_Image;

	public GameObject sprite2D;

	Sprite _image;


	// Load Image
	public void LoadImage ()
	{
		StartCoroutine (iLoadImage ());
	}


	IEnumerator iLoadImage ()
	{
		// Download the file from the URL. It will not be saved in the Cache
		using (WWW www = new WWW (bundleURL)) {
			yield return www;
			if (www.error != null)
				throw new Exception ("WWW download had an error:" + www.error);
			AssetBundle bundle = www.assetBundle;

//			if (assetName_Image == "")
//				Instantiate (bundle.mainAsset);
//			else
//				Instantiate (bundle.LoadAsset (assetName_Image));

			//lấy ảnh từ bundle
			Sprite im = bundle.LoadAsset<Sprite> (assetName_Image);

			Debug.Log (im);

			_image = Instantiate (im) as Sprite;

			//load vào đối tượng
			sprite2D.GetComponent<SpriteRenderer> ().sprite = _image;

			// Unload the AssetBundles compressed contents to conserve memory
			bundle.Unload (false);

		}
	}
}

