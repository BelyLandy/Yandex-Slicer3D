
using UnityEngine;

namespace DynamicMeshCutter
{
    public class PlaneBehaviour : CutterBehaviour
    {
        public float DebugPlaneLength = 2;

        public static bool isPlaneCutted;

        public void Cut()
        {
            isPlaneCutted = true;
            var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var root in roots)
            {
                if (!root.activeInHierarchy)
                    continue;
                var targets = root.GetComponentsInChildren<MeshTarget>();
                foreach (var target in targets)
                {
                    Cut(target, new Vector3(-5.01f, 5.59f, -1.41f), new Vector3(0.24f, 0.01f, -0.97f), null, OnCreated);
                    Debug.Log(transform.position);
                    // new Vector3(-5.01f, 5.59f, -1.41f), new Vector3(0.24f, 0.01f, -0.97f),
                    // new Vector3(-4.74f, 2.09f, 4.2f), new Vector3(0.5f, 0.67f, 0.54f),
                    // new Vector3(-4.14f, -0.46f, 4.88f), new Vector3(0.05f, 1.00f, 0.05f),
                    Debug.Log(transform.forward);
                }
                

            }
            
        }

        public void Cut2()
        {
            isPlaneCutted = true;
            var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var root in roots)
            {
                if (!root.activeInHierarchy)
                    continue;
                var targets = root.GetComponentsInChildren<MeshTarget>();
                
                foreach (var target in targets)
                {
                    Cut(target, new Vector3(-4.74f, 2.09f, 4.2f), new Vector3(0.5f, 0.67f, 0.54f), null, OnCreated);
                    //Debug.Log(transform.position);
                    // new Vector3(-5.01f, 5.59f, -1.41f), new Vector3(0.24f, 0.01f, -0.97f),
                    // new Vector3(-4.74f, 2.09f, 4.2f), new Vector3(0.5f, 0.67f, 0.54f),
                    //
                    //Debug.Log(transform.forward);
                }

            }

        }

        public void Cut3()
        {
            isPlaneCutted = true;
            var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var root in roots)
            {
                if (!root.activeInHierarchy)
                    continue;
                var targets = root.GetComponentsInChildren<MeshTarget>();

                foreach (var target in targets)
                {
                    Cut(target, new Vector3(-4.14f, -0.46f, 4.88f), new Vector3(0.05f, 1.00f, 0.05f), null, OnCreated);
                    //Debug.Log(transform.position);
                    // new Vector3(-5.01f, 5.59f, -1.41f), new Vector3(0.24f, 0.01f, -0.97f),
                    // new Vector3(-4.74f, 2.09f, 4.2f), new Vector3(0.5f, 0.67f, 0.54f),
                    // new Vector3(-4.14f, -0.46f, 4.88f), new Vector3(0.05f, 1.00f, 0.05f),
                    // new Vector3(1.61f, 0.66f, 8.13f), new Vector3(-0.98f, -0.2f, 0.02f),
                    //Debug.Log(transform.forward);
                }

            }

        }
        public void Cut4()
        {
            isPlaneCutted = true;
            var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var root in roots)
            {
                if (!root.activeInHierarchy)
                    continue;
                var targets = root.GetComponentsInChildren<MeshTarget>();

                foreach (var target in targets)
                {
                    Cut(target, new Vector3(1.61f, 0.66f, 8.13f), new Vector3(-0.98f, -0.2f, 0.02f), null, OnCreated);
                    //Debug.Log(transform.position);
                    // new Vector3(-5.01f, 5.59f, -1.41f), new Vector3(0.24f, 0.01f, -0.97f),
                    // new Vector3(-4.74f, 2.09f, 4.2f), new Vector3(0.5f, 0.67f, 0.54f),
                    // new Vector3(-4.14f, -0.46f, 4.88f), new Vector3(0.05f, 1.00f, 0.05f),
                    // new Vector3(1.61f, 0.66f, 8.13f), new Vector3(-0.98f, -0.2f, 0.02f),
                    //Debug.Log(transform.forward);
                }

            }

        }

        void OnCreated(Info info, MeshCreationData cData)
        {
            MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
        }

    }
}