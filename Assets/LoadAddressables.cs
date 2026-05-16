using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class LoadAddressables : MonoBehaviour
{
    public AssetReference spherePrefabRef;
    public RawImage img;
    void Start()
    {
        spherePrefabRef.LoadAssetAsync<GameObject>().Completed += (obj) =>
        {
            // 预设
            GameObject spherePrefab = obj.Result;
            // 实例化
            GameObject sphereObj = Instantiate(spherePrefab);
        };
        Addressables.LoadAssetAsync<Texture2D>("Assets/Textures/realLandmine.png").Completed += obj =>
        {
            img.texture = obj.Result;
            img.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        };
    }

}
