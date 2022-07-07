using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;
using UnityEngine.EventSystems;


#if UNITY_EDITOR
    using Input = GoogleARCore.InstantPreviewInput;
#endif

public class ARController : MonoBehaviour
{

    public Camera ARCamera;

    public GameObject Dormitory;

    public GameObject HSE;

    public GameObject Mall;

    private const float k_PrefabRotation = 180.0f;

    //Проверка, что объекты не накладываются
    private Vector3 checkPlace;
    private Vector3 checkOtherPlace;


    public bool dormitoryPlace = false;

    public bool HSEPlace = false;

    public bool MallPlace = false;


    public void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void Update()
    {

        if(dormitoryPlace == true && HSEPlace == true && MallPlace == true)
        {
            return;
        }
        //Проверка на то, что пользователь не нажал на экран
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        // Не обрабатывать ввод, если пользователь попадает на UI
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }


        // Raycast для поиска плоскостей
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            // Проверяем, что нажатие произошло с обратной стороны плоскости и не создаем якорь в данном случае
            if ((hit.Trackable is DetectedPlane) &&
                Vector3.Dot(ARCamera.transform.position - hit.Pose.position,
                    hit.Pose.rotation * Vector3.up) < 0)
            {
                Debug.Log("Hit at back of the current DetectedPlane");
            }
            else
            {
                // Выбираем prefab на основе того какие из объектов уже помещены, учитывая, что размещение возможно только на полу
                if (hit.Trackable is DetectedPlane)
                {

                    DetectedPlane detectedPlane = hit.Trackable as DetectedPlane;
                    if (detectedPlane.PlaneType != DetectedPlaneType.Vertical)
                    {
                        //checkPlace = new Vector3(hit.Pose.position.x, hit.Pose.position.y, hit.Pose.position.z);
                        if (dormitoryPlace == false)
                        {
                            dormitoryPlace = true;

                            Dormitory.SetActive(true);

                            checkPlace = new Vector3(hit.Pose.position.x, hit.Pose.position.y, hit.Pose.position.z);
                            Dormitory.transform.position = checkPlace;

                            // Создаем якорь, чтобы позволить ARCore отслеживать точку попадания
                            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                            // Делаем объект дочерним к якорю
                            Dormitory.transform.parent = anchor.transform;
                        }
                        else if (HSEPlace == false)
                        {
                            if ((((hit.Pose.position.x - Dormitory.transform.localScale.x / 2) > (checkPlace.x + 2.5 * HSE.transform.localScale.x)) ||
                            ((hit.Pose.position.x + Dormitory.transform.localScale.x / 2) < (checkPlace.x - 2.5 * HSE.transform.localScale.x)))
                            && (((hit.Pose.position.z - Dormitory.transform.localScale.z / 2) > (checkPlace.z + 2.5 * HSE.transform.localScale.z)) ||
                            ((hit.Pose.position.z + Dormitory.transform.localScale.z / 2) < (checkPlace.z - 2.5 * HSE.transform.localScale.z))))
                            {
                                HSEPlace = true;

                                HSE.SetActive(true);
                                checkOtherPlace = new Vector3(hit.Pose.position.x, hit.Pose.position.y, hit.Pose.position.z);
                                HSE.transform.position = checkOtherPlace;

                                // Создаем якорь, чтобы позволить ARCore отслеживать точку попадания
                                var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                                // Делаем объект дочерним к якорю
                                HSE.transform.parent = anchor.transform;
                            }
                        }
                        else if ((((hit.Pose.position.x - Dormitory.transform.localScale.x / 2) > (checkPlace.x + 2 * Mall.transform.localScale.x)) ||
                            ((hit.Pose.position.x + Dormitory.transform.localScale.x / 2) < (checkPlace.x - 2 * Mall.transform.localScale.x)))
                            && (((hit.Pose.position.z - Dormitory.transform.localScale.z / 2) > (checkPlace.z + 3 * Mall.transform.localScale.z)) ||
                            ((hit.Pose.position.z + Dormitory.transform.localScale.z / 2) < (checkPlace.z - 3 * Mall.transform.localScale.z))))
                        {
                            if ((((hit.Pose.position.x - HSE.transform.localScale.x / 2) > (checkOtherPlace.x + 2 * Mall.transform.localScale.x)) ||
                            ((hit.Pose.position.x + HSE.transform.localScale.x / 2) < (checkOtherPlace.x - 2 * Mall.transform.localScale.x)))
                            && (((hit.Pose.position.z - HSE.transform.localScale.z / 2) > (checkOtherPlace.z + 3 * Mall.transform.localScale.z)) ||
                            ((hit.Pose.position.z + HSE.transform.localScale.z / 2) < (checkOtherPlace.z - 3 * Mall.transform.localScale.z))))
                            {
                                MallPlace = true;

                                Mall.SetActive(true);

                                Mall.transform.position = new Vector3(hit.Pose.position.x, hit.Pose.position.y, hit.Pose.position.z);

                                // Создаем якорь, чтобы позволить ARCore отслеживать точку попадания
                                var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                                // Делаем объект дочерним к якорю
                                Mall.transform.parent = anchor.transform;
                            }

                        }
                        
                    }
                    
                }

               
            }
        }
    }

    /*
    private void _UpdateApplicationLifecycle()
    {
        // Exit the app when the 'back' button is pressed.
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Only allow the screen to sleep when not tracking.
        if (Session.Status != SessionStatus.Tracking)
        {
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
        }
        else
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        if (m_IsQuitting)
        {
            return;
        }

        // Quit if ARCore was unable to connect and give Unity some time for the toast to
        // appear.
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            _ShowAndroidToastMessage("Camera permission is needed to run this application.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }
        else if (Session.Status.IsError())
        {
            _ShowAndroidToastMessage(
                "ARCore encountered a problem connecting.  Please start the app again.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }

    }*/

   // private void _DoQuit()
    //{
      //  Application.Quit();
   // }

    /*private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity =
            unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject =
                    toastClass.CallStatic<AndroidJavaObject>(
                        "makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }*/

    /*
    //We will fill this list with the planes that ARCore detected in the current frame
    private List<DetectedPlane> m_NewTrackedPlanes = new List<DetectedPlane>();

    public GameObject GridPrefab;

    public GameObject Dormitory;

    ///public GameObject HSE;

    public GameObject ARCamera;



    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {




        /////////////////////////////////////////////////////////////////////// Line between two codes for two tests
        //Check ARCore session status
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        //The following function will fill m_NewTrackedPlanes with the planes that ARCore detected in the current frame
        Session.GetTrackables<DetectedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);

        //Instantiate a Grid for each DetectedPlane in m_NewTrackedPlanes
        for (int i = 0; i < m_NewTrackedPlanes.Count; ++i)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);

            //This function will set the position of grid and modify the vertices of the attached mesh
            grid.GetComponent<GridVisualiser>().Initialize(m_NewTrackedPlanes[i]);

            //Check if the user touches the screen 
            Touch touch;
            if(Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
            {
               // Debag(Input.touchCount);
               // Dormitory.transform.localScale *= 0.1f;
                return;
            }

            Dormitory.transform.localScale *= 0.2f;

            //Check if the user touched any of the tracked planes
            TrackableHit hit;
            if(Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit))
            {
                //Dormitory.transform.localScale *= 0.1f;
                //Place the model on top of the tracked plane that we touched

                //Enable the model
                Dormitory.SetActive(true);

               // HSE.SetActive(true);

                //Create a new Anchor
                Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

                //Set the position of the portal to be the same as the hit position
                Dormitory.transform.position = hit.Pose.position;
                Dormitory.transform.rotation = hit.Pose.rotation;

                //HSE.transform.position = hit.Pose.position;
                //HSE.transform.rotation = hit.Pose.rotation;

                //Dormitory to face the camera
                Vector3 cameraPosition = ARCamera.transform.position;

                //Dormitory should only rotate around the Y axis
                cameraPosition.y = hit.Pose.position.y;

                //Rotate the dormitory to face the camera
                Dormitory.transform.LookAt(cameraPosition, Dormitory.transform.up);

                //HSE.transform.LookAt(cameraPosition, Dormitory.transform.up);

                //ARCore will keep understanding the world and update the anchors accordingly hence we need to attach our model to the anchor
                Dormitory.transform.parent = anchor.transform;

                //HSE.transform.parent = anchor.transform;

            }
        }
    }*/
}
