using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicMeshCutter
{

    [RequireComponent(typeof(LineRenderer))]
    public class MouseBehaviour : CutterBehaviour
    {
        public LineRenderer LR => GetComponent<LineRenderer>();
        private Vector3 _from;
        private Vector3 _to;
        private bool _isDragging;

        private float Distance;

        

        protected override void Update()
        {
            base.Update();

            if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;

                var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 0.05f);
                _from = Camera.main.ScreenToWorldPoint(mousePos);

                

                
            }

            if (_isDragging)
            {
                var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 0.05f);
                _to = Camera.main.ScreenToWorldPoint(mousePos);
                VisualizeLine(true);
                

            }
            else
            {
                VisualizeLine(false);
            }

            if (Input.GetMouseButtonUp(0) && _isDragging)
            {
                Vector3[] positions = new Vector3[LR.positionCount];

                LR.GetPositions(positions);

                foreach (var position in positions)
                {
                    Debug.Log(position);
                }

                RaycastHit[] hits;
                hits = Physics.RaycastAll(origin: new Vector3(positions[0].x, positions[0].y, 1), direction: new Vector3(positions[1].x, positions[1].y, 1), maxDistance: Vector3.Distance(positions[0], positions[1]));

                Debug.Log(hits.Length);

                Debug.DrawRay(start: new Vector3(positions[0].x, positions[0].y, 1), dir: new Vector3(positions[0].x, positions[0].y, 1) + new Vector3(positions[1].x, positions[1].y, 1), color: Color.red, duration: 3);

                Cut();
                _isDragging = false;
            }
        }

        private void Cut()
        {
            Plane plane = new Plane(_from, _to, Camera.main.transform.position);

            var roots = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var root in roots)
            {
                if (!root.activeInHierarchy)
                    continue;
                var targets = root.GetComponentsInChildren<MeshTarget>();
                foreach (var target in targets)
                {
                    Cut(target, _to, plane.normal, null, OnCreated);
                }
            }
        }

        void OnCreated(Info info, MeshCreationData cData)
        {
            MeshCreation.TranslateCreatedObjects(info, cData.CreatedObjects, cData.CreatedTargets, Separation);
        }
        private void VisualizeLine(bool value)
        {
            if (LR == null)
                return;

            LR.enabled = value;

            

            if (value)
            {
                LR.positionCount = 2;
                LR.SetPosition(0, _from);
                LR.SetPosition(1, _to);
            }
        }

    }

}