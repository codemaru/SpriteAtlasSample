using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

// Base codes from "Unite Europe 2017 - What's new for 2D in Unity?"
public class DressMeUpSync : MonoBehaviour {

    static WWW loader;
    [SerializeField] string atlasName;
    [SerializeField] string variantName;

	// Use this for initialization
	void Start () {
        string fullpath = "file://" + Application.streamingAssetsPath + "/AssetBundles/atlas." + variantName;

        if (loader == null)
            loader = new WWW(fullpath);

        StartCoroutine( LoadSprites(variantName));
	}
	
    IEnumerator LoadSprites( string variantName) {
        yield return loader;

        string fullpath = atlasName + "." + variantName;
        SpriteAtlas atlas = loader.assetBundle.LoadAsset<SpriteAtlas>(fullpath);
        foreach( Transform child in transform) {
            Sprite sprite = atlas.GetSprite(child.gameObject.name);
            if (sprite)
                child.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
