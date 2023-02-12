using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapLayoutAssigningTool : EditorWindow
{
    #region variables - logic

    // wczytaj prefab pokoju
    public GameObject roomPrefab;
    Vector3 roomPrefabFloorScale;

    // wczytaj tablicę - układ pokoi
    [Range(10,100)]public int roomLayoutSize = 20;
    bool[,] roomLayout;


    // stwórz pusty obiekt mapa
    private GameObject map;

    #endregion

    #region methods - logic

    // wygeneruj i przypisz do obiektu mapy, układ pokoi na podstawie tablicy układu pokoi



    void CreateAndAssignRooms()
    {
        GameObject[,] rooms = new GameObject[roomLayoutSize, roomLayoutSize];

        for (int i = 0; i < roomLayoutSize; i++)
        {

            for (int j = 0; j < roomLayoutSize; j++)
            {
                if (roomLayout[i, j])
                {
                    rooms[i,j] = Instantiate(roomPrefab, CalculatePosition(i, j), Quaternion.identity);
                    rooms[i,j].transform.parent = map.transform;
                    rooms[i,j].name = $"Room [{i} , {j}]";
                    RemoveWalls(i, j, rooms[i, j]);
                }
            }
        }

    }

    Vector3 CalculatePosition(int _i, int _j)
    {
        Vector3 position = Vector3.zero;
        position.x = (_i - (int)(roomLayoutSize / 2)) * roomPrefabFloorScale.x;
        position.z = (_j - (int)(roomLayoutSize / 2)) * roomPrefabFloorScale.y;
        return position;
    }

    void RemoveWalls(int _i, int _j, GameObject obj)    // 19,0 -> wall 1 & wall 4
    {
        if (_j >= 0 && _j < (roomLayoutSize - 1))
        {
            // sprawdź _j + 1       - "Wall 1"  
            if (roomLayout[_i, _j + 1])
                obj.GetComponentInChildren<Transform>().Find("Wall 1").gameObject.SetActive(false);
        }
        if (_j > 0 && _j <= (roomLayoutSize - 1))
        {
            // sprawdź _j - 1       - "Wall 2"
            if (roomLayout[_i, _j - 1])
                obj.GetComponentInChildren<Transform>().Find("Wall 2").gameObject.SetActive(false);
        }
        if (_i >= 0 && _i < (roomLayoutSize - 1))
        {
            //sprawdź _i - 1        - "Wall 3" 
            if (roomLayout[_i + 1, _j])
                obj.GetComponentInChildren<Transform>().Find("Wall 3").gameObject.SetActive(false);
        }
        if (_i > 0 && _i <= (roomLayoutSize - 1))
        {
            //sprawdź _i + 1        - "Wall 4"
            if(roomLayout[_i - 1, _j])
                obj.GetComponentInChildren<Transform>().Find("Wall 4").gameObject.SetActive(false);
        }
    }



    void GenerateMap()
    {
        map = new GameObject("Map");
        roomPrefabFloorScale = roomPrefab.GetComponentInChildren<Transform>().Find("Floor").transform.lossyScale;
        CreateAndAssignRooms();
    }

    #endregion

    #region methods - tool

    private void Awake()
    {
        roomLayout = new bool[roomLayoutSize, roomLayoutSize];
    }

    [MenuItem("Tools/Map Shaping Tool")]
    public static void ShowWindow()
    {
        MapLayoutAssigningTool window = GetWindow<MapLayoutAssigningTool>("Map Shaping Tool");
        window.minSize = new Vector2(400, 500);
    }

    private void OnGUI()
    {
        if(roomLayout == null)
            roomLayout = new bool[roomLayoutSize, roomLayoutSize];

        for (int i = 0; i < roomLayoutSize; i++)
            for (int j = 0; j < roomLayoutSize; j++)
            {
                roomLayout[i, j] = EditorGUI.Toggle(new Rect(i * 20 + 30, j * 20 + 30, 10, 10), roomLayout[i, j]);
            }

        if (GUILayout.Button("Generate Map"))
        {
            GenerateMap();
        }
    }

    #endregion

}
