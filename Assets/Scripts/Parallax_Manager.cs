
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [System.Serializable]  // what does this do im not sure.. 
    public class ParallaxLayer
    {
        public Transform layer;
        public float parallaxFactor;  //range 0-1. 
    }

    public ParallaxLayer[] layers;
    public Transform camTransform;
    private Vector3 cameraLastPosition;
    private bool isFirstFrame = true;
    void Start()
    { 
        cameraLastPosition = camTransform.position;
    }


    void LateUpdate()
    {
        if (isFirstFrame)
        {
            cameraLastPosition = camTransform.position;
            isFirstFrame = false;
            return;
        }
        Vector3 camDelta = camTransform.position - cameraLastPosition;

        foreach (ParallaxLayer layer in layers  )
        {
            float moveX = camDelta.x * layer.parallaxFactor;
            float moveY = camDelta.y * layer.parallaxFactor;

            layer.layer.position += new Vector3(moveX, moveY, 0);

        }

        cameraLastPosition = camTransform.position;
    }
}
