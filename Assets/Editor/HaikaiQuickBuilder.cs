using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.IO;

public static class HaikaiQuickBuilder
{
    const string PACK =
        "Assets/BasicBedroomPack-Mavi3D/Prefabs/Buil-In/";

    [MenuItem("IHC/Build FINAL Isolation Room")]
    public static void Build()
    {
        Scene scene = EditorSceneManager.NewScene(
            NewSceneSetup.EmptyScene,
            NewSceneMode.Single
        );

        Directory.CreateDirectory("Assets/Scenes");
        Directory.CreateDirectory("Assets/Materials");

        // =========================================================
        // MATERIALS
        // =========================================================

        Material wall = Mat(
            "Final_Wall",
            new Color(0.34f, 0.33f, 0.31f)
        );

        Material floor = Mat(
            "Final_Floor",
            new Color(0.17f, 0.12f, 0.09f)
        );

        Material ceiling = Mat(
            "Final_Ceiling",
            new Color(0.28f, 0.28f, 0.27f)
        );

        Material dark = Mat(
            "Final_Dark",
            new Color(0.035f, 0.035f, 0.04f)
        );

        Material curtain = Mat(
            "Final_Curtain",
            new Color(0.10f, 0.12f, 0.15f)
        );

        Material bathroom = Mat(
            "Final_Bathroom",
            new Color(0.42f, 0.43f, 0.42f)
        );

        Material white = Mat(
            "Final_White",
            new Color(0.72f, 0.72f, 0.68f)
        );

        Material screen = Mat(
            "Final_Screen",
            new Color(0.10f, 0.30f, 0.50f),
            true
        );

        // =========================================================
        // ROOTS
        // =========================================================

        GameObject environment = new GameObject("Environment");
        GameObject furniture = new GameObject("Furniture");
        GameObject atmosphere = new GameObject("Atmosphere");

        // =========================================================
        // MAIN ROOM - 10 x 9 m
        // =========================================================

        Cube(
            "Floor",
            new Vector3(0, -0.1f, 0),
            new Vector3(10, 0.2f, 9),
            floor,
            environment.transform
        );

        Cube(
            "Ceiling",
            new Vector3(0, 3.25f, 0),
            new Vector3(10, 0.15f, 9),
            ceiling,
            environment.transform
        );

        Cube(
            "Wall_Left",
            new Vector3(-5, 1.6f, 0),
            new Vector3(.2f, 3.2f, 9),
            wall,
            environment.transform
        );

        Cube(
            "Wall_Right",
            new Vector3(5, 1.6f, 0),
            new Vector3(.2f, 3.2f, 9),
            wall,
            environment.transform
        );

        // Front wall split to leave entrance.
        Cube(
            "Front_Left",
            new Vector3(-1.25f, 1.6f, 4.5f),
            new Vector3(7.5f, 3.2f, .2f),
            wall,
            environment.transform
        );

        Cube(
            "Front_Right",
            new Vector3(4.6f, 1.6f, 4.5f),
            new Vector3(.8f, 3.2f, .2f),
            wall,
            environment.transform
        );

        Cube(
            "Front_AboveDoor",
            new Vector3(3.35f, 2.85f, 4.5f),
            new Vector3(1.9f, .7f, .2f),
            wall,
            environment.transform
        );

        // Back wall
        Cube(
            "Back_Left",
            new Vector3(-3.7f, 1.6f, -4.5f),
            new Vector3(2.6f, 3.2f, .2f),
            wall,
            environment.transform
        );

        Cube(
            "Back_Right",
            new Vector3(3.7f, 1.6f, -4.5f),
            new Vector3(2.6f, 3.2f, .2f),
            wall,
            environment.transform
        );

        Cube(
            "Back_Bottom",
            new Vector3(0, .45f, -4.5f),
            new Vector3(4.8f, .9f, .2f),
            wall,
            environment.transform
        );

        Cube(
            "Back_Top",
            new Vector3(0, 2.85f, -4.5f),
            new Vector3(4.8f, .7f, .2f),
            wall,
            environment.transform
        );

        // Small threshold outside the room.
        Cube(
            "Entrance_Threshold",
            new Vector3(3.35f, -.1f, 5.1f),
            new Vector3(2.5f, .2f, 1.4f),
            floor,
            environment.transform
        );

        // =========================================================
        // PREFABS FROM BASIC BEDROOM PACK
        // =========================================================

        // BED
        GameObject bed = Prefab(
            "Bed.prefab",
            "Bed",
            new Vector3(-1.2f, 0, .25f),
            new Vector3(0, 0, 0),
            furniture.transform
        );

        // CLOSET / DRESSER
        GameObject closet = Prefab(
            "Closet.prefab",
            "Closet",
            new Vector3(-4.25f, 0, -2.5f),
            new Vector3(0, 90, 0),
            furniture.transform
        );

        // DESK
        GameObject table = Prefab(
            "Table.prefab",
            "Desk",
            new Vector3(3.65f, 0, -2.35f),
            new Vector3(0, 180, 0),
            furniture.transform
        );

        // TV directly opposite bed
        GameObject tv = Prefab(
            "TV.prefab",
            "TV_Opposite_Bed",
            new Vector3(-1.2f, 1.35f, 4.30f),
            new Vector3(0, 180, 0),
            furniture.transform
        );

        // WINDOW
        GameObject window = Prefab(
            "Window.prefab",
            "Window",
            new Vector3(0, 1.7f, -4.38f),
            new Vector3(0, 0, 0),
            furniture.transform
        );

        // LAMP
        Prefab(
            "Lamp.prefab",
            "Bedroom_Lamp",
            new Vector3(3.8f, .9f, -2.1f),
            Vector3.zero,
            furniture.transform
        );

        // =========================================================
        // CURTAINS
        // =========================================================

        Cube(
            "Curtain_Rod",
            new Vector3(0, 2.85f, -4.05f),
            new Vector3(5.1f, .07f, .07f),
            dark,
            furniture.transform
        );

        // Leave a narrow central slit.
        Cube(
            "Curtain_Left",
            new Vector3(-1.32f, 1.82f, -4.0f),
            new Vector3(2.45f, 2.0f, .08f),
            curtain,
            furniture.transform
        );

        Cube(
            "Curtain_Right",
            new Vector3(1.32f, 1.82f, -4.0f),
            new Vector3(2.45f, 2.0f, .08f),
            curtain,
            furniture.transform
        );

        // =========================================================
        // COMPUTER ON DESK
        // =========================================================

        Cube(
            "Computer_Monitor",
            new Vector3(3.65f, 1.45f, -2.55f),
            new Vector3(1.35f, .8f, .10f),
            dark,
            furniture.transform
        );

        Cube(
            "Computer_Screen",
            new Vector3(3.65f, 1.45f, -2.61f),
            new Vector3(1.20f, .66f, .02f),
            screen,
            furniture.transform
        );

        Cube(
            "Keyboard",
            new Vector3(3.65f, .90f, -1.85f),
            new Vector3(1.1f, .05f, .38f),
            dark,
            furniture.transform
        );

        // =========================================================
        // PRIVATE BATHROOM
        // Front-left corner.
        // =========================================================

        GameObject wc = new GameObject("Private_Bathroom");

        Cube(
            "Bathroom_Partition",
            new Vector3(-3.15f, 1.6f, 2.15f),
            new Vector3(3.7f, 3.2f, .15f),
            wall,
            wc.transform
        );

        Cube(
            "Bathroom_Side",
            new Vector3(-1.35f, 1.6f, 3.35f),
            new Vector3(.15f, 3.2f, 2.4f),
            wall,
            wc.transform
        );

        Cube(
            "Bathroom_Floor",
            new Vector3(-3.2f, .015f, 3.35f),
            new Vector3(3.5f, .03f, 2.2f),
            bathroom,
            wc.transform
        );

        // Simple toilet
        Cube(
            "Toilet_Base",
            new Vector3(-4.15f, .35f, 3.55f),
            new Vector3(.65f, .70f, .85f),
            white,
            wc.transform
        );

        Cube(
            "Toilet_Tank",
            new Vector3(-4.15f, .72f, 4.0f),
            new Vector3(.72f, .75f, .30f),
            white,
            wc.transform
        );

        // Sink
        Cube(
            "Sink",
            new Vector3(-2.15f, .85f, 3.75f),
            new Vector3(1.05f, .20f, .55f),
            white,
            wc.transform
        );

        Cube(
            "Sink_Pedestal",
            new Vector3(-2.15f, .40f, 3.82f),
            new Vector3(.35f, .8f, .30f),
            white,
            wc.transform
        );

        Prefab(
            "Mirror.prefab",
            "Bathroom_Mirror",
            new Vector3(-2.15f, 1.75f, 4.30f),
            new Vector3(0, 180, 0),
            wc.transform
        );

        // =========================================================
        // CEILING FAN
        // =========================================================

        GameObject fan = new GameObject("Ceiling_Fan");

        Cylinder(
            "Fan_Rod",
            new Vector3(0, 2.90f, 0),
            new Vector3(.05f, .18f, .05f),
            dark,
            fan.transform
        );

        Cylinder(
            "Fan_Motor",
            new Vector3(0, 2.65f, 0),
            new Vector3(.22f, .14f, .22f),
            dark,
            fan.transform
        );

        GameObject rotating =
            new GameObject("Fan_Rotating_Blades");

        rotating.transform.parent = fan.transform;
        rotating.transform.position =
            new Vector3(0, 2.62f, 0);

        rotating.AddComponent<FanRotation>();

        for (int i = 0; i < 4; i++)
        {
            float angle = i * 90f;

            GameObject blade =
                GameObject.CreatePrimitive(PrimitiveType.Cube);

            blade.name = "Fan_Blade_" + (i + 1);
            blade.transform.parent = rotating.transform;

            Vector3 direction =
                Quaternion.Euler(0, angle, 0) *
                Vector3.right;

            blade.transform.localPosition =
                direction * .75f;

            blade.transform.localRotation =
                Quaternion.Euler(0, angle, 0);

            blade.transform.localScale =
                new Vector3(1.15f, .035f, .23f);

            blade.GetComponent<Renderer>().sharedMaterial =
                dark;
        }

        // =========================================================
        // CLUTTER - PANDEMIC / ISOLATION
        // =========================================================

        CubeRot(
            "Clothes_Floor_01",
            new Vector3(.7f, .06f, 2.2f),
            new Vector3(.9f, .08f, .55f),
            new Vector3(0, 25, 0),
            dark,
            atmosphere.transform
        );

        CubeRot(
            "Clothes_Floor_02",
            new Vector3(1.4f, .06f, 1.7f),
            new Vector3(.65f, .07f, .45f),
            new Vector3(0, -20, 0),
            dark,
            atmosphere.transform
        );

        Cube(
            "Sanitizer",
            new Vector3(4.05f, 1.0f, -2.0f),
            new Vector3(.18f, .35f, .15f),
            white,
            atmosphere.transform
        );

        CubeRot(
            "Mask",
            new Vector3(3.25f, .95f, -1.85f),
            new Vector3(.40f, .025f, .22f),
            new Vector3(0, 15, 0),
            white,
            atmosphere.transform
        );

        // =========================================================
        // LIGHTING
        // =========================================================

        RenderSettings.ambientMode =
            UnityEngine.Rendering.AmbientMode.Flat;

        // Dark, but visible enough for recording.
        RenderSettings.ambientLight =
            new Color(.09f, .095f, .11f);

        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Exponential;
        RenderSettings.fogDensity = .006f;
        RenderSettings.fogColor =
            new Color(.035f, .04f, .055f);

        // Cold window light.
        Light windowLight = NewLight(
            "Window_Light",
            new Vector3(0, 2.0f, -3.6f),
            new Color(.55f, .65f, .78f),
            4.5f,
            8f,
            LightType.Point,
            atmosphere.transform
        );

        windowLight.shadows = LightShadows.Soft;

        // Computer glow.
        Light computerLight = NewLight(
            "Computer_Glow",
            new Vector3(3.55f, 1.45f, -1.9f),
            new Color(.18f, .38f, .70f),
            3.0f,
            4f,
            LightType.Point,
            atmosphere.transform
        );

        // General visibility for video.
        Light fill = NewLight(
            "Room_Fill",
            new Vector3(0, 2.25f, 1.0f),
            new Color(.38f, .34f, .30f),
            1.5f,
            8f,
            LightType.Point,
            atmosphere.transform
        );

        // Bathroom light.
        NewLight(
            "Bathroom_Light",
            new Vector3(-3.2f, 2.5f, 3.4f),
            new Color(.65f, .62f, .52f),
            1.4f,
            3.5f,
            LightType.Point,
            atmosphere.transform
        );

        // =========================================================
        // PLAYER - STARTS AT ENTRANCE
        // =========================================================

        GameObject player = new GameObject("Player");

        player.transform.position =
            new Vector3(3.35f, .10f, 5.25f);

        CharacterController controller =
            player.AddComponent<CharacterController>();

        controller.height = 1.8f;
        controller.radius = .32f;
        controller.center = new Vector3(0, .9f, 0);

        player.AddComponent<SimpleFirstPersonController>();

        GameObject cameraObj =
            new GameObject("Main Camera");

        cameraObj.tag = "MainCamera";
        cameraObj.transform.parent = player.transform;

        cameraObj.transform.localPosition =
            new Vector3(0, 1.55f, 0);

        // Looking into the room.
        cameraObj.transform.localRotation =
            Quaternion.Euler(0, 180, 0);

        Camera cam = cameraObj.AddComponent<Camera>();
        cam.fieldOfView = 65;
        cam.nearClipPlane = .05f;

        cameraObj.AddComponent<AudioListener>();

        // =========================================================
        // SAVE
        // =========================================================

        string scenePath =
            "Assets/Scenes/HaikaiRoom_V3.unity";

        EditorSceneManager.SaveScene(scene, scenePath);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Selection.activeGameObject = player;

        Debug.Log(
            "FINAL HAIKAI ROOM CREATED: " + scenePath
        );
    }

    // =============================================================
    // PREFAB
    // =============================================================

    static GameObject Prefab(
        string file,
        string name,
        Vector3 position,
        Vector3 rotation,
        Transform parent
    )
    {
        GameObject source =
            AssetDatabase.LoadAssetAtPath<GameObject>(
                PACK + file
            );

        if (source == null)
        {
            Debug.LogWarning(
                "Prefab not found: " + PACK + file
            );

            return null;
        }

        GameObject obj =
            (GameObject)PrefabUtility.InstantiatePrefab(source);

        obj.name = name;
        obj.transform.position = position;
        obj.transform.rotation =
            Quaternion.Euler(rotation);

        if (parent != null)
            obj.transform.SetParent(parent, true);

        return obj;
    }

    // =============================================================
    // MATERIAL
    // =============================================================

    static Material Mat(
        string name,
        Color color,
        bool emission = false
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

        Material mat = new Material(shader);
        mat.color = color;

        if (emission)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor(
                "_EmissionColor",
                color * 2.5f
            );
        }

        AssetDatabase.CreateAsset(mat, path);

        return mat;
    }

    // =============================================================
    // PRIMITIVES
    // =============================================================

    static GameObject Cube(
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

        if (parent != null)
            obj.transform.SetParent(parent, true);

        obj.GetComponent<Renderer>().sharedMaterial =
            material;

        return obj;
    }

    static GameObject CubeRot(
        string name,
        Vector3 position,
        Vector3 scale,
        Vector3 rotation,
        Material material,
        Transform parent
    )
    {
        GameObject obj =
            Cube(
                name,
                position,
                scale,
                material,
                parent
            );

        obj.transform.rotation =
            Quaternion.Euler(rotation);

        return obj;
    }

    static GameObject Cylinder(
        string name,
        Vector3 position,
        Vector3 scale,
        Material material,
        Transform parent
    )
    {
        GameObject obj =
            GameObject.CreatePrimitive(
                PrimitiveType.Cylinder
            );

        obj.name = name;
        obj.transform.position = position;
        obj.transform.localScale = scale;

        if (parent != null)
            obj.transform.SetParent(parent, true);

        obj.GetComponent<Renderer>().sharedMaterial =
            material;

        return obj;
    }

    static Light NewLight(
        string name,
        Vector3 position,
        Color color,
        float intensity,
        float range,
        LightType type,
        Transform parent
    )
    {
        GameObject obj = new GameObject(name);

        obj.transform.position = position;

        if (parent != null)
            obj.transform.SetParent(parent, true);

        Light light = obj.AddComponent<Light>();

        light.type = type;
        light.color = color;
        light.intensity = intensity;
        light.range = range;

        return light;
    }
}
