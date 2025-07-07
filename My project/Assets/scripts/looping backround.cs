using UnityEngine;

public class loopingbackround : MonoBehaviour
{
  
    public float backgroundSpeed;
    public Renderer backroundRenderer;

    // Update is called once per frame
    void Update()
    {
        backroundRenderer.material.mainTextureOffset += new Vector2(0, backgroundSpeed * Time.deltaTime);
    }
}
