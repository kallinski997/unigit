using UnityEngine;

namespace UniGit.AIAssistant.Editor
{
    /// <summary>
    /// Provides code snippets for common Unity patterns
    /// </summary>
    public static class CodeSnippets
    {
        public static string GetBasicScript()
        {
            return @"using UnityEngine;

public class NewBehaviour : MonoBehaviour
{
    void Start()
    {
        // Called when the script is first initialized
    }

    void Update()
    {
        // Called once per frame
    }
}";
        }

        public static string GetMovementScript()
        {
            return @"using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input
        float horizontal = Input.GetAxis(""Horizontal"");
        float vertical = Input.GetAxis(""Vertical"");

        // Calculate movement
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed;
        
        // Apply movement
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}";
        }

        public static string GetRotationScript()
        {
            return @"using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        // Rotate around the specified axis
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}";
        }

        public static string GetTriggerScript()
        {
            return @"using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [Header(""Events"")]
    public UnityEvent onTriggerEntered;
    public UnityEvent onTriggerExited;

    [Header(""Settings"")]
    [SerializeField] private string targetTag = ""Player"";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log($""Trigger entered by {other.name}"");
            onTriggerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log($""Trigger exited by {other.name}"");
            onTriggerExited?.Invoke();
        }
    }
}";
        }

        public static string GetSingletonScript()
        {
            return @"using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject(""GameManager"");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}";
        }

        public static string GetCoroutineExample()
        {
            return @"using UnityEngine;
using System.Collections;

public class CoroutineExample : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DelayedAction());
    }

    IEnumerator DelayedAction()
    {
        Debug.Log(""Starting coroutine"");
        
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);
        
        Debug.Log(""2 seconds have passed"");
        
        // Wait for next frame
        yield return null;
        
        Debug.Log(""Next frame"");
    }
}";
        }

        public static string GetObjectPoolingScript()
        {
            return @"using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;
    
    private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        // Pre-instantiate objects
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        // Find an inactive object in the pool
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // If none available, create a new one
        GameObject newObj = Instantiate(prefab);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}";
        }
    }
}
