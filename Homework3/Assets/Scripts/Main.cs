using UnityEngine;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public GameObject[] plane;
    public GameObject[] miniPlane;

    private float[] planePosition = new float[4];

    public float speed;

    private float rotate;
    private float position; 

    public Texture2D yellowTexture;
    public Texture2D greenTexture;
    public Texture2D blueTexture;
    public Texture2D orangeTexture;

    private Vector3 clickPosition;
    private Vector3 direction;

    public Camera mainCamera;
    public Camera miniCamera;
    private int current = 6;

    private int planeType = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        clickPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = eventData.position;
        if (clickPosition.x < currentPosition.x)
        {
            Rotate(-1);
        }
        else if (clickPosition.x > currentPosition.x)
        {
            Rotate(1);
        }
        clickPosition.x = currentPosition.x;
    }
    

    private void Rotate(float sign)
    {
        rotate = speed * Time.deltaTime;
        planePosition[planeType] += sign * rotate;
        plane[planeType].transform.rotation = Quaternion.Euler(180, planePosition[planeType], -180);
    }

    public void Camera(int n)
    {
        if (current + n == 5)
        {
            n = 3;
        }

        if (current + n == 10)
        {
            n = -3;
        }

        planeType += n;
        
        mainCamera.cullingMask |= 1 << current + n;
        mainCamera.cullingMask ^= 1 << current;
        
        miniCamera.cullingMask |= 1 << current+n;
        miniCamera.cullingMask ^= 1 << current;
        
        current += n;
    }

    public void ColorChange(string color)
    {
        Renderer renderer = plane[planeType].GetComponent<Renderer>();
        Renderer renderer1 = miniPlane[planeType].GetComponent<Renderer>();
        Material material = new Material(Shader.Find("Standard"));

        switch (color)
        {
            case "Yellow":
            {
                material.mainTexture = yellowTexture;
                break;
            }
            case "Orange":
            {
                material.mainTexture = orangeTexture;
                break;
            }
            case "Blue":
            {
                material.mainTexture = blueTexture;
                break;
            }
            case "Green":
            {
                material.mainTexture = greenTexture;
                break;
            }
        }

        renderer.material = material;
        renderer1.material = material;
    }
}