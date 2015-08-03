using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]

public class FireLight : MonoBehaviour
{
    public Light light0;
    public float minTime = 0.25f;
    public float maxTime = 2f;
    public float minSize = 0.25f;
    public float maxSize = 2f;
    public bool enableMoveLight = true;
    public Vector3 movePosition;
    public Vector3 moveArea = Vector3.one;
    public Color[] colors;

    private float lerpTime;
    private float timer;
    private int currentColor;
    private int nextColor;
    private float currentSize;
    private float nextSize;
	// Use this for initialization
	void Start ()
    {
        nextSize = minSize;
        ChangeColor();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (light0 != null && colors.Length > 0)
        {
            light0.color = Color.Lerp(colors[currentColor], colors[nextColor], (Time.time - timer) / lerpTime);
            light0.range = Mathf.Lerp(currentSize, nextSize, (Time.time - timer) / lerpTime);
            if (Time.time - timer >= lerpTime)
            {
                ChangeColor();
            }
        }
	}

    void ChangeColor()
    {
        if (light0 != null && colors.Length>0)
        {
            currentColor = nextColor;
            currentSize = nextSize;
            nextSize = Random.Range(minSize, maxSize);
            nextColor = Random.Range(0, colors.Length);
            lerpTime = Random.Range(minTime, maxTime);
            if (enableMoveLight)
            {
                light0.transform.position = (new Vector3(Random.Range(-moveArea.x / 2f, moveArea.x / 2f), Random.Range(-moveArea.y / 2f, moveArea.y / 2f), Random.Range(-moveArea.z / 2f, moveArea.z / 2f))) + transform.position + movePosition;
            }
            timer = Time.time;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(movePosition+transform.position, moveArea);
    }
}
