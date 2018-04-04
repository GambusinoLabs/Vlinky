using UnityEngine;

public class GroundGenerator : MonoBehaviour {
	// Code for the button "Generate". Calls GenerateLevel() method.
    [InspectorButton("GenerateLevel")]
    public bool generate;

    // Code for the button "Delete". Calls DeleteGround() method.
    [InspectorButton("DeleteGround")]
	public bool delete;

	[Header("Settings")]
	[Tooltip("Ground size (in tiles)")]
	public int floorTiles = 30;
	[Tooltip("Left and right margins from ground to the borders of the screen (in tiles)")]
	public float padding = 1.0f;
    [Tooltip("Drag here the desired parent for the ground (Maybe an empty Game Object Scenario or Terrain). Empty por none.")]
	public Transform groundParent; 

	[Space(20)]
	[Header("Dependencies")]
    [Tooltip("Drag here the desired floor block prefab")]
	public GameObject FloorTilePrefab;
    [Tooltip("Drag here the level camera")]
	public Camera MyCamera;

	// Counter for tiles naming
    int spawnedTiles = 0;

	// Spawns the floor tiles centered on (0, 0) under the parent "Ground". Then parents ground with groundParent if setted. After all, fits the camera.
    private void GenerateLevel(){
		if (floorTiles < 1)
			throw new UnityException("Floor tiles must be at least 1");

        if (padding < 0)
            throw new UnityException("Padding must be positive");
		
		spawnedTiles = 0;
		DeleteGround();
        GameObject parent = new GameObject("Ground");

		// Do the math to get the position of the first tile starting on the left and then spawn the tiles until the desired size (floorTiles)
        Vector2 firstTilePosition = Vector2.zero + Vector2.right * FloorTilePrefab.transform.localScale.x / 2 + Vector2.left * FloorTilePrefab.transform.localScale.x * floorTiles / 2;
        for (int i = 0; i < floorTiles; i++)
        	Instantiate(FloorTilePrefab, firstTilePosition + Vector2.right * FloorTilePrefab.transform.localScale.x * i, Quaternion.identity, parent.transform).name = FloorTilePrefab.name + " " + GetNewTileNumber();

        if (groundParent != null)
            parent.transform.parent = groundParent;

		FitCameraToTiles(firstTilePosition, firstTilePosition + Vector2.right * FloorTilePrefab.transform.localScale.x * floorTiles, - FloorTilePrefab.transform.localScale.y/2);
	}

	// Fits the camera to view from the givens leftBottom to the rightBottom, offseting in vertical (to fit all the ground and not only the half)
	private void FitCameraToTiles(Vector2 leftBottom, Vector2 rightBottom, float verticalOffset = 0.0f){
		// Orto size
		Vector2 leftBottomScreen = MyCamera.ScreenToWorldPoint(new Vector2(0.0f,0.0f));
		Vector2 rightBottomScreen = MyCamera.ScreenToWorldPoint(new Vector2(MyCamera.pixelWidth, 0.0f));
		float currentDistanceView = Vector2.Distance(leftBottomScreen, rightBottomScreen);
		float wantedDistanceView = Vector2.Distance(leftBottom + Vector2.left * padding, rightBottom + Vector2.right * padding);
		MyCamera.orthographicSize = wantedDistanceView / currentDistanceView * MyCamera.orthographicSize;

        // Move camera
        Vector2 leftTopScreen = MyCamera.ScreenToWorldPoint(new Vector2(0.0f, MyCamera.pixelHeight));
        leftBottomScreen = MyCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));
		float cameraVerticalTranslation = Vector2.Distance(leftBottomScreen, leftTopScreen) / 2;
        MyCamera.transform.position = new Vector3(0.0f, cameraVerticalTranslation + verticalOffset, -10.0f);
	}

	// Returns the string of the current spawning tile number
	string GetNewTileNumber(){
		string numberString = spawnedTiles.ToString();
		spawnedTiles++;
		return numberString;
	}

	// Delete the ground
    private void DeleteGround()
    {
        DestroyImmediate(GameObject.Find("Ground"));
    }
}