using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIDataAccessor : MonoBehaviour
{
    public List<Slider> sliders;

    public static UIDataAccessor Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public FlockingForceData GetFlockingForceData()
    {
        return new FlockingForceData(sliders[0].value);
    }

    public CollisionAvoidanceData GetCollisionAvoidanceData()
    {
        return new CollisionAvoidanceData(sliders[1].value, sliders[2].value);
    }

    public GroupingForceData GetGroupingForceData()
    {
        return new GroupingForceData(sliders[3].value, sliders[4].value);
    }

    public ObstacleAvoidanceData GetObstacleAvoidanceData()
    {
        return new ObstacleAvoidanceData(sliders[5].value, sliders[6].value);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
