using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjectlndieFram
{
    public partial class Player : ViewController
    {
        public Grid grid;
        public Tilemap tilemap;

        void Start()
        {
            // Code Here
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                var cellPosition = grid.WorldToCell(transform.position);
                var tile = tilemap.GetTile(cellPosition);
                tilemap.SetTile(cellPosition, null);
            }
        }
    }
}