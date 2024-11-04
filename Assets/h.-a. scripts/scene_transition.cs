using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class scene_transition : MonoBehaviour
{
    
    // Past and future scene Index are the numbers the two scene's are assigned in build settings
    private const int pastSceneIndex=1;
    private const int futureSceneIndex=2;
    private InputAction NextLineAction; 
    
    // Start is called before the first frame update
    void Start()
    {
        //this and InputAction are for testing the LoadScene function
        NextLineAction = new InputAction(binding: "<Keyboard>/o"); 
        NextLineAction.performed += ctx => TimeTravel();
        NextLineAction.Enable();
    }

    //This loads a scene bassed on index number
    public void LoadScene(int Scene)
    {
        SceneManager.LoadScene(sceneBuildIndex: Scene);
    }

    //this function moves between the past scene and the future scene and can be called from other scribts
    public void TimeTravel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (currentSceneIndex)
        {
            case pastSceneIndex:
                LoadScene(futureSceneIndex);
                break;
            case futureSceneIndex:
                LoadScene(pastSceneIndex);
                break;
        }
    }
    
    // this is also only for testing
    private void OnDestroy()
    {
        NextLineAction.Disable();
    }
}
