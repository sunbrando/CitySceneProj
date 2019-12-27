using UnityEngine;
using UnityEngine.AI;

public class MeshlinksDemo : MonoBehaviour
{

    NavMeshAgent mr;   //声明变量
                       // Use this for initialization
    void Start()
    {
        //获取到自身的NavMeshAgent组件
        mr = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Update");

            //获取鼠标点击的点，
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;  //声明RacastHit类型
            if (Physics.Raycast(ray, out rayhit))
            {
                Debug.Log(rayhit.transform.name);
                if (rayhit.transform.name == "road") //判断是不是点击地面
                {
                    //鼠标点击的点赋值给目标点
                    mr.SetDestination(rayhit.point);
                }
            }
        }

    }
}
