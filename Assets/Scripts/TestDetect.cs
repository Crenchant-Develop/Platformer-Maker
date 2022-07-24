using System;
using UnityEngine;
using static UnityEngine.Physics2D;

//! 테스트 스크립트.

class TestDetect : MonoBehaviour
{

    [SerializeField]
    float distance = 3f;

    [SerializeField]
    LayerMask[] detectableLayers;
    LayerMask detectableLayer;

    void Awake()
    {
        for (var i = 0; i < detectableLayers.Length; i++)
        {
            detectableLayer += detectableLayers[i];
        }
    }

    // public void AddLayer(LayerMask addLayer)
    // {
    //     detectableLayer += addLayer;
    // }

    // public void RemoveLayer(LayerMask removeLayer)
    // {
    //     detectableLayer -=removeLayer; 
    // }

    bool IsWallDetected
    {
        get
        {
            //! 여러 방향에서 레이캐스트 감지하는거 나중에 알아보기.

            return Raycast(transform.position, Vector2.up, distance, detectableLayer);
            // return Raycast(transform.position, Vector3.up, distance, LayerMask.NameToLayer("TransparentFX"));
        }
    }


    void Update()
    {
        Debug.Log(IsWallDetected);

        if (IsWallDetected)
        {
            Debug.Log($"충돌!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }
}