using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.IO;

public static class HaikaiSceneBuilder
{
    [MenuItem("IHC/Build Haikai Scene")]
    public static void Build()
    {
        Directory.CreateDirectory("Assets/Scenes");
        Directory.CreateDirectory("Assets/Materials");

        Scene scene = EditorSceneManager.NewScene(
            NewSceneSetup.EmptyScene,
            NewSceneMode.Single
        );

        // ---------- Materials ----------
        Material floorMat = CreateMaterial(
            "Floor",
            new Color(0.12f, 0.12f, 0.13f)
        );

        Material wallMat = CreateMaterial(
            "Walls",
            new Color(0.22f, 0.23f, 0.25f)
        );

        Material corridorMat = CreateMaterial(
            "Corridor",
            new Color(0.10f, 0.10f, 0.12f)
        );

        Material photo1Mat = CreateMaterial(
            "Photo01_Placeholder",
            new Color(0.65f, 0.65f, 0.65f)
        );

        Material photo2Mat = CreateMaterial(
            "Photo02_Placeholder",
            new Color(0.42f, 0.42f, 0.46f)
        );

        Material photo3Mat = CreateMaterial(
            "Photo03_Placeholder",
            new Color(0.22f, 0.22f, 0.25f)
        );

        // ---------- Root objects ----------
        GameObject environment = new GameObject("Environment");
        GameObject exhibition = new GameObject("Exhibition");
        GameObject lighting = new GameObject("Lighting");

        // ---------- Room 1 ----------
        GameObject room1 = new GameObject("Room_01");
        room1.transform.parent = environment.transform;

        CreateFloor(
            "Floor_Room01",
            new Vector3(0, 0, 0),
            new Vector3(10, 0.2f, 10),
            floorMat,
            room1.transform
        );

        CreateRoomWalls(
            room1.transform,
            new Vector3(0, 0, 0),
            wallMat,
            false,
            true
        );

        // ---------- Corridor 1 ----------
        GameObject corridor1 = new GameObject("Corridor_01");
        corridor1.transform.parent = environment.transform;

        CreateFloor(
            "Floor_Corridor01",
            new Vector3(0, 0, 8),
            new Vector3(4, 0.2f, 6),
            corridorMat,
            corridor1.transform
        );

        CreateWall(
            "Corridor01_Left",
            new Vector3(-2, 1.5f, 8),
            new Vector3(0.2f, 3, 6),
            corridorMat,
            corridor1.transform
        );

        CreateWall(
            "Corridor01_Right",
            new Vector3(2, 1.5f, 8),
            new Vector3(0.2f, 3, 6),
            corridorMat,
            corridor1.transform
        );

        // ---------- Room 2 ----------
        GameObject room2 = new GameObject("Room_02");
        room2.transform.parent = environment.transform;

        CreateFloor(
            "Floor_Room02",
            new Vector3(0, 0, 16),
            new Vector3(10, 0.2f, 10),
            floorMat,
            room2.transform
        );

        CreateRoomWalls(
            room2.transform,
            new Vector3(0, 0, 16),
            wallMat,
            true,
            true
        );

        // ---------- Corridor 2 ----------
        GameObject corridor2 = new GameObject("Corridor_02");
        corridor2.transform.parent = environment.transform;

        CreateFloor(
            "Floor_Corridor02",
            new Vector3(0, 0, 24),
            new Vector3(4, 0.2f, 6),
            corridorMat,
            corridor2.transform
        );

        CreateWall(
            "Corridor02_Left",
            new Vector3(-2, 1.5f, 24),
            new Vector3(0.2f, 3, 6),
            corridorMat,
            corridor2.transform
        );

        CreateWall(
            "Corridor02_Right",
            new Vector3(2, 1.5f, 24),
            new Vector3(0.2f, 3, 6),
            corridorMat,
            corridor2.transform
        );

        // ---------- Room 3 ----------
        GameObject room3 = new GameObject("Room_03");
        room3.transform.parent = environment.transform;

        CreateFloor(
            "Floor_Room03",
            new Vector3(0, 0, 32),
            new Vector3(10, 0.2f, 10),
            floorMat,
            room3.transform
        );

        CreateRoomWalls(
            room3.transform,
            new Vector3(0, 0, 32),
            wallMat,
            true,
            false
        );

        // ---------- Photo placeholders ----------
        CreatePhoto(
            "Photo_01_Placeholder",
            new Vector3(0, 1.8f, 4.85f),
            Quaternion.Euler(0, 180, 0),
            photo1Mat,
            exhibition.transform
        );

        CreatePhoto(
            "Photo_02_Placeholder",
            new Vector3(0, 1.8f, 20.85f),
            Quaternion.Euler(0, 180, 0),
            photo2Mat,
            exhibition.transform
        );

        CreatePhoto(
            "Photo_03_Placeholder",
            new Vector3(0, 1.8f, 36.85f),
            Quaternion.Euler(0, 180, 0),
            photo3Mat,
            exhibition.transform
        );

        // ---------- Lighting ----------
        CreateLight(
            "Room01_Light",
            new Vector3(0, 2.5f, 0),
            3.5f,
            12,
            lighting.transform
        );

        CreateLight(
            "Corridor01_Light",
            new Vector3(0, 2.4f, 8),
            1.6f,
            8,
            lighting.transform
        );

        CreateLight(
            "Room02_Light",
            new Vector3(0, 2.5f, 16),
            2.2f,
            11,
            lighting.transform
        );

        CreateLight(
            "Corridor02_Light",
            new Vector3(0, 2.4f, 24),
            0.9f,
            7,
            lighting.transform
        );

        CreateLight(
            "Room03_Light",
            new Vector3(0, 2.5f, 32),
            1.2f,
            9,
            lighting.transform
        );

        // ---------- Player ----------
        GameObject player = new GameObject("Player");
        player.transform.position = new Vector3(0, 1.1f, -3);

        CharacterController character =
            player.AddComponent<CharacterController>();

        character.height = 1.8f;
        character.radius = 0.35f;
        character.center = new Vector3(0, 0.9f, 0);

        player.AddComponent<SimpleFirstPersonController>();

        GameObject cameraObject = new GameObject("Main Camera");
        cameraObject.tag = "MainCamera";
        cameraObject.transform.parent = player.transform;
        cameraObject.transform.localPosition =
            new Vector3(0, 1.55f, 0);

        Camera camera = cameraObject.AddComponent<Camera>();
        camera.fieldOfView = 65f;

        cameraObject.AddComponent<AudioListener>();

        // ---------- Atmosphere ----------
        RenderSettings.ambientMode =
            UnityEngine.Rendering.AmbientMode.Flat;

        RenderSettings.ambientLight =
            new Color(0.055f, 0.06f, 0.075f);

        RenderSettings.fog = true;
        RenderSettings.fogColor =
            new Color(0.055f, 0.06f, 0.07f);

        RenderSettings.fogMode = FogMode.Exponential;
        RenderSettings.fogDensity = 0.018f;

        // ---------- Save ----------
        EditorSceneManager.SaveScene(
            scene,
            "Assets/Scenes/HaikaiVR.unity"
        );

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log(
            "HAIKAI BUILD SUCCESS: Assets/Scenes/HaikaiVR.unity"
        );
    }

    static Material CreateMaterial(
        string name,
        Color color
    )
    {
        string path =
            "Assets/Materials/" + name + ".mat";

        Material existing =
            AssetDatabase.LoadAssetAtPath<Material>(path);

        if (existing != null)
            return existing;

        Shader shader =
            Shader.Find("Universal Render Pipeline/Lit");

        if (shader == null)
            shader = Shader.Find("Standard");

        Material material =
            new Material(shader);

        material.color = color;

        AssetDatabase.CreateAsset(
            material,
            path
        );

        return material;
    }

    static void CreateFloor(
        string name,
        Vector3 position,
        Vector3 scale,
        Material material,
        Transform parent
    )
    {
        GameObject obj =
            GameObject.CreatePrimitive(PrimitiveType.Cube);

        obj.name = name;
        obj.transform.position = position;
        obj.transform.localScale = scale;
        obj.transform.parent = parent;

        obj.GetComponent<Renderer>().sharedMaterial =
            material;
    }

    static void CreateWall(
        string name,
        Vector3 position,
        Vector3 scale,
        Material material,
        Transform parent
    )
    {
        GameObject obj =
            GameObject.CreatePrimitive(PrimitiveType.Cube);

        obj.name = name;
        obj.transform.position = position;
        obj.transform.localScale = scale;
        obj.transform.parent = parent;

        obj.GetComponent<Renderer>().sharedMaterial =
            material;
    }

    static void CreateRoomWalls(
        Transform parent,
        Vector3 center,
        Material material,
        bool openingBack,
        bool openingFront
    )
    {
        CreateWall(
            "Left_Wall",
            center + new Vector3(-5, 1.5f, 0),
            new Vector3(0.2f, 3, 10),
            material,
            parent
        );

        CreateWall(
            "Right_Wall",
            center + new Vector3(5, 1.5f, 0),
            new Vector3(0.2f, 3, 10),
            material,
            parent
        );

        if (!openingBack)
        {
            CreateWall(
                "Back_Wall",
                center + new Vector3(0, 1.5f, -5),
                new Vector3(10, 3, 0.2f),
                material,
                parent
            );
        }
        else
        {
            CreateDoorWall(
                "Back",
                center + new Vector3(0, 0, -5),
                material,
                parent
            );
        }

        if (!openingFront)
        {
            CreateWall(
                "Front_Wall",
                center + new Vector3(0, 1.5f, 5),
                new Vector3(10, 3, 0.2f),
                material,
                parent
            );
        }
        else
        {
            CreateDoorWall(
                "Front",
                center + new Vector3(0, 0, 5),
                material,
                parent
            );
        }
    }

    static void CreateDoorWall(
        string prefix,
        Vector3 center,
        Material material,
        Transform parent
    )
    {
        CreateWall(
            prefix + "_Wall_Left",
            center + new Vector3(-3.5f, 1.5f, 0),
            new Vector3(3, 3, 0.2f),
            material,
            parent
        );

        CreateWall(
            prefix + "_Wall_Right",
            center + new Vector3(3.5f, 1.5f, 0),
            new Vector3(3, 3, 0.2f),
            material,
            parent
        );

        CreateWall(
            prefix + "_Wall_Top",
            center + new Vector3(0, 2.65f, 0),
            new Vector3(4, 0.7f, 0.2f),
            material,
            parent
        );
    }

    static void CreatePhoto(
        string name,
        Vector3 position,
        Quaternion rotation,
        Material material,
        Transform parent
    )
    {
        GameObject photo =
            GameObject.CreatePrimitive(PrimitiveType.Quad);

        photo.name = name;
        photo.transform.position = position;
        photo.transform.rotation = rotation;
        photo.transform.localScale =
            new Vector3(3.2f, 2.1f, 1);

        photo.transform.parent = parent;

        photo.GetComponent<Renderer>().sharedMaterial =
            material;

        Collider collider =
            photo.GetComponent<Collider>();

        if (collider != null)
            Object.DestroyImmediate(collider);
    }

    static void CreateLight(
        string name,
        Vector3 position,
        float intensity,
        float range,
        Transform parent
    )
    {
        GameObject obj =
            new GameObject(name);

        obj.transform.position = position;
        obj.transform.parent = parent;

        Light light = obj.AddComponent<Light>();
        light.type = LightType.Point;
        light.intensity = intensity;
        light.range = range;
        light.shadows = LightShadows.Soft;
    }
}
