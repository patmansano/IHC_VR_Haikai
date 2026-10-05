using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.IO;

public static class HaikaiRoomBuilder
{
    [MenuItem("IHC/Build Isolation Room V3")]
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
            "V3_Wall",
            new Color(0.32f, 0.31f, 0.29f)
        );

        Material floor = Mat(
            "V3_Floor",
            new Color(0.16f, 0.11f, 0.08f)
        );

        Material ceiling = Mat(
            "V3_Ceiling",
            new Color(0.20f, 0.20f, 0.19f)
        );

        Material wood = Mat(
            "V3_Wood",
            new Color(0.24f, 0.12f, 0.055f)
        );

        Material mattress = Mat(
            "V3_Mattress",
            new Color(0.52f, 0.50f, 0.46f)
        );

        Material sheet = Mat(
            "V3_Sheet",
            new Color(0.34f, 0.38f, 0.40f)
        );

        Material curtain = Mat(
            "V3_Curtain",
            new Color(0.12f, 0.14f, 0.17f)
        );

        Material black = Mat(
            "V3_Black",
            new Color(0.025f, 0.025f, 0.03f)
        );

        Material monitor = Mat(
            "V3_Monitor",
            new Color(0.12f, 0.28f, 0.40f),
            true
        );

        Material metal = Mat(
            "V3_Metal",
            new Color(0.15f, 0.15f, 0.16f)
        );

        Material clothes = Mat(
            "V3_Clothes",
            new Color(0.17f, 0.19f, 0.22f)
        );

        Material paper = Mat(
            "V3_Paper",
            new Color(0.62f, 0.60f, 0.52f)
        );

        Material glass = Mat(
            "V3_Glass",
            new Color(0.07f, 0.10f, 0.13f)
        );

        // =========================================================
        // ROOTS
        // =========================================================

        GameObject environment = Root("Environment");
        GameObject furniture = Root("Furniture");
        GameObject clutter = Root("Clutter");
        GameObject lighting = Root("Lighting");

        // =========================================================
        // ROOM
        //
        // Width  = 10 m
        // Length = 9 m
        // Height = 3.2 m
        // =========================================================

        Cube(
            "Floor",
            new Vector3(0, -0.10f, 0),
            new Vector3(10, 0.20f, 9),
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

        // Left wall
        Cube(
            "Wall_Left",
            new Vector3(-5, 1.6f, 0),
            new Vector3(0.20f, 3.2f, 9),
            wall,
            environment.transform
        );

        // Right wall
        Cube(
            "Wall_Right",
            new Vector3(5, 1.6f, 0),
            new Vector3(0.20f, 3.2f, 9),
            wall,
            environment.transform
        );

        // Front wall
        Cube(
            "Wall_Front",
            new Vector3(0, 1.6f, 4.5f),
            new Vector3(10, 3.2f, 0.20f),
            wall,
            environment.transform
        );

        // Back wall divided around window.
        Cube(
            "Wall_Back_Left",
            new Vector3(-3.65f, 1.6f, -4.5f),
            new Vector3(2.7f, 3.2f, 0.20f),
            wall,
            environment.transform
        );

        Cube(
            "Wall_Back_Right",
            new Vector3(3.65f, 1.6f, -4.5f),
            new Vector3(2.7f, 3.2f, 0.20f),
            wall,
            environment.transform
        );

        Cube(
            "Wall_Back_Bottom",
            new Vector3(0, 0.45f, -4.5f),
            new Vector3(4.6f, 0.9f, 0.20f),
            wall,
            environment.transform
        );

        Cube(
            "Wall_Back_Top",
            new Vector3(0, 2.85f, -4.5f),
            new Vector3(4.6f, 0.7f, 0.20f),
            wall,
            environment.transform
        );

        // =========================================================
        // WINDOW
        // =========================================================

        Cube(
            "Window_Glass",
            new Vector3(0, 1.75f, -4.56f),
            new Vector3(4.4f, 1.7f, 0.06f),
            glass,
            furniture.transform
        );

        // Window frame
        Cube(
            "Window_Frame_Top",
            new Vector3(0, 2.65f, -4.40f),
            new Vector3(4.7f, 0.12f, 0.12f),
            wood,
            furniture.transform
        );

        Cube(
            "Window_Frame_Bottom",
            new Vector3(0, 0.85f, -4.40f),
            new Vector3(4.7f, 0.12f, 0.12f),
            wood,
            furniture.transform
        );

        Cube(
            "Window_Frame_Left",
            new Vector3(-2.25f, 1.75f, -4.40f),
            new Vector3(0.12f, 1.9f, 0.12f),
            wood,
            furniture.transform
        );

        Cube(
            "Window_Frame_Right",
            new Vector3(2.25f, 1.75f, -4.40f),
            new Vector3(0.12f, 1.9f, 0.12f),
            wood,
            furniture.transform
        );

        Cube(
            "Window_Frame_Center",
            new Vector3(0, 1.75f, -4.39f),
            new Vector3(0.08f, 1.75f, 0.10f),
            wood,
            furniture.transform
        );

        // Curtain rod
        Cube(
            "Curtain_Rod",
            new Vector3(0, 2.85f, -4.05f),
            new Vector3(5.4f, 0.08f, 0.08f),
            metal,
            furniture.transform
        );

        // Curtains leave a narrow opening in the center.
        Cube(
            "Curtain_Left",
            new Vector3(-1.35f, 1.80f, -4.02f),
            new Vector3(2.45f, 2.05f, 0.10f),
            curtain,
            furniture.transform
        );

        Cube(
            "Curtain_Right",
            new Vector3(1.35f, 1.80f, -4.02f),
            new Vector3(2.45f, 2.05f, 0.10f),
            curtain,
            furniture.transform
        );

        // =========================================================
        // WOODEN BED
        // =========================================================

        GameObject bed = Root("Wooden_Bed");
        bed.transform.parent = furniture.transform;

        Vector3 bp = new Vector3(-2.7f, 0, -0.2f);

        Cube(
            "Bed_Frame",
            bp + new Vector3(0, 0.40f, 0),
            new Vector3(2.5f, 0.30f, 4.3f),
            wood,
            bed.transform
        );

        Cube(
            "Mattress",
            bp + new Vector3(0, 0.68f, 0),
            new Vector3(2.25f, 0.35f, 4.0f),
            mattress,
            bed.transform
        );

        // Headboard
        Cube(
            "Headboard_Left",
            bp + new Vector3(-1.10f, 1.15f, -2.0f),
            new Vector3(0.18f, 1.8f, 0.18f),
            wood,
            bed.transform
        );

        Cube(
            "Headboard_Right",
            bp + new Vector3(1.10f, 1.15f, -2.0f),
            new Vector3(0.18f, 1.8f, 0.18f),
            wood,
            bed.transform
        );

        Cube(
            "Headboard_Top",
            bp + new Vector3(0, 1.85f, -2.0f),
            new Vector3(2.35f, 0.18f, 0.18f),
            wood,
            bed.transform
        );

        for (int i = -2; i <= 2; i++)
        {
            Cube(
                "Headboard_Slat_" + i,
                bp + new Vector3(i * 0.42f, 1.30f, -2.0f),
                new Vector3(0.10f, 1.0f, 0.12f),
                wood,
                bed.transform
            );
        }

        // Footboard
        Cube(
            "Footboard",
            bp + new Vector3(0, 0.85f, 2.0f),
            new Vector3(2.4f, 0.85f, 0.16f),
            wood,
            bed.transform
        );

        // Pillow 1
        CubeRot(
            "Pillow_01",
            bp + new Vector3(-0.48f, 0.98f, -1.25f),
            new Vector3(0.95f, 0.20f, 0.62f),
            new Vector3(0, -12, 5),
            sheet,
            bed.transform
        );

        // Pillow 2 - deliberately misaligned
        CubeRot(
            "Pillow_02",
            bp + new Vector3(0.50f, 0.96f, -1.15f),
            new Vector3(0.90f, 0.20f, 0.62f),
            new Vector3(0, 18, -6),
            sheet,
            bed.transform
        );

        // Crude blanket, intentionally crooked
        CubeRot(
            "Blanket",
            bp + new Vector3(0.10f, 0.92f, 0.65f),
            new Vector3(2.05f, 0.10f, 1.85f),
            new Vector3(0, 5, 3),
            sheet,
            bed.transform
        );

        // =========================================================
        // DESK
        // =========================================================

        GameObject desk = Root("Computer_Desk");
        desk.transform.parent = furniture.transform;

        Vector3 dp = new Vector3(2.75f, 0, -1.45f);

        Cube(
            "Desk_Top",
            dp + new Vector3(0, 0.85f, 0),
            new Vector3(3.0f, 0.15f, 1.35f),
            wood,
            desk.transform
        );

        DeskLeg(dp, -1.30f, -0.50f, wood, desk.transform, "Leg_1");
        DeskLeg(dp,  1.30f, -0.50f, wood, desk.transform, "Leg_2");
        DeskLeg(dp, -1.30f,  0.50f, wood, desk.transform, "Leg_3");
        DeskLeg(dp,  1.30f,  0.50f, wood, desk.transform, "Leg_4");

        // Monitor
        Cube(
            "Monitor",
            dp + new Vector3(0, 1.65f, -0.15f),
            new Vector3(1.75f, 1.0f, 0.12f),
            black,
            desk.transform
        );

        Cube(
            "Monitor_Screen",
            dp + new Vector3(0, 1.65f, -0.215f),
            new Vector3(1.58f, 0.83f, 0.025f),
            monitor,
            desk.transform
        );

        Cube(
            "Monitor_Stand",
            dp + new Vector3(0, 1.10f, -0.10f),
            new Vector3(0.12f, 0.45f, 0.12f),
            metal,
            desk.transform
        );

        Cube(
            "Monitor_Base",
            dp + new Vector3(0, 0.91f, -0.05f),
            new Vector3(0.65f, 0.06f, 0.38f),
            metal,
            desk.transform
        );

        // Keyboard
        CubeRot(
            "Keyboard",
            dp + new Vector3(0, 0.98f, 0.35f),
            new Vector3(1.25f, 0.07f, 0.38f),
            new Vector3(0, -4, 0),
            black,
            desk.transform
        );

        // Cup
        Cylinder(
            "Cup",
            dp + new Vector3(1.05f, 1.08f, 0.22f),
            new Vector3(0.16f, 0.25f, 0.16f),
            paper,
            desk.transform
        );

        // Sanitizer bottle
        Cube(
            "Sanitizer",
            dp + new Vector3(-1.05f, 1.10f, 0.25f),
            new Vector3(0.22f, 0.42f, 0.18f),
            glass,
            desk.transform
        );

        // Mask on desk
        CubeRot(
            "Mask",
            dp + new Vector3(-0.65f, 0.96f, 0.42f),
            new Vector3(0.45f, 0.025f, 0.24f),
            new Vector3(0, 18, 0),
            sheet,
            desk.transform
        );

        // =========================================================
        // CHAIR - deliberately crooked
        // =========================================================

        GameObject chair = Root("Chair");
        chair.transform.parent = furniture.transform;
        chair.transform.position = new Vector3(2.6f, 0, 0.15f);
        chair.transform.rotation = Quaternion.Euler(0, -18, 0);

        Cube(
            "Chair_Seat",
            chair.transform.position + new Vector3(0, 0.55f, 0),
            new Vector3(1.0f, 0.15f, 1.0f),
            black,
            chair.transform
        );

        Cube(
            "Chair_Back",
            chair.transform.position + new Vector3(0, 1.15f, 0.42f),
            new Vector3(1.0f, 1.15f, 0.15f),
            black,
            chair.transform
        );

        // =========================================================
        // CLOSED DOOR
        // =========================================================

        Cube(
            "Closed_Door",
            new Vector3(3.35f, 1.25f, 4.37f),
            new Vector3(2.0f, 2.5f, 0.16f),
            wood,
            furniture.transform
        );

        Sphere(
            "Door_Knob",
            new Vector3(2.65f, 1.25f, 4.24f),
            new Vector3(0.14f, 0.14f, 0.14f),
            metal,
            furniture.transform
        );

        // =========================================================
        // CEILING FAN
        // =========================================================

        GameObject fan = Root("Ceiling_Fan");
        fan.transform.parent = furniture.transform;

        Cylinder(
            "Fan_Rod",
            new Vector3(0, 2.80f, 0),
            new Vector3(0.09f, 0.38f, 0.09f),
            metal,
            fan.transform
        );

        Cylinder(
            "Fan_Motor",
            new Vector3(0, 2.55f, 0),
            new Vector3(0.32f, 0.22f, 0.32f),
            metal,
            fan.transform
        );

        for (int i = 0; i < 4; i++)
        {
            GameObject blade = CubeRot(
                "Fan_Blade_" + i,
                new Vector3(0, 2.53f, 0),
                new Vector3(2.5f, 0.07f, 0.34f),
                new Vector3(0, i * 90, 0),
                black,
                fan.transform
            );
        }

        // =========================================================
        // CLUTTER
        // =========================================================

        // Clothing on floor
        CubeRot(
            "Clothes_01",
            new Vector3(-0.50f, 0.08f, 2.35f),
            new Vector3(1.1f, 0.10f, 0.65f),
            new Vector3(0, 28, 4),
            clothes,
            clutter.transform
        );

        CubeRot(
            "Clothes_02",
            new Vector3(0.45f, 0.07f, 2.65f),
            new Vector3(0.75f, 0.08f, 0.55f),
            new Vector3(0, -17, -3),
            clothes,
            clutter.transform
        );

        // Books / notebooks
        CubeRot(
            "Book_01",
            new Vector3(1.1f, 0.10f, 3.1f),
            new Vector3(0.65f, 0.12f, 0.90f),
            new Vector3(0, 22, 0),
            paper,
            clutter.transform
        );

        CubeRot(
            "Book_02",
            new Vector3(1.18f, 0.20f, 3.08f),
            new Vector3(0.62f, 0.10f, 0.86f),
            new Vector3(0, 28, 0),
            clothes,
            clutter.transform
        );

        // Cardboard box
        Cube(
            "Box",
            new Vector3(-4.15f, 0.38f, 3.35f),
            new Vector3(1.0f, 0.75f, 1.1f),
            wood,
            clutter.transform
        );

        // Trash bin
        Cylinder(
            "Trash_Bin",
            new Vector3(4.15f, 0.35f, 2.7f),
            new Vector3(0.45f, 0.70f, 0.45f),
            black,
            clutter.transform
        );

        // =========================================================
        // LIGHTING
        // =========================================================

        // Weak ambient light
        RenderSettings.ambientMode =
            UnityEngine.Rendering.AmbientMode.Flat;

        RenderSettings.ambientLight =
            new Color(0.035f, 0.04f, 0.05f);

        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Exponential;
        RenderSettings.fogDensity = 0.012f;
        RenderSettings.fogColor =
            new Color(0.025f, 0.03f, 0.04f);

        // Light from the window opening
        GameObject windowLight = new GameObject("Window_Light");
        windowLight.transform.parent = lighting.transform;
        windowLight.transform.position =
            new Vector3(0, 1.9f, -3.7f);
        windowLight.transform.rotation =
            Quaternion.Euler(22, 0, 0);

        Light wl = windowLight.AddComponent<Light>();
        wl.type = LightType.Spot;
        wl.color = new Color(0.60f, 0.67f, 0.72f);
        wl.intensity = 5.0f;
        wl.range = 7f;
        wl.spotAngle = 26f;
        wl.shadows = LightShadows.Soft;

        // Monitor glow
        GameObject monitorLight =
            new GameObject("Monitor_Glow");

        monitorLight.transform.parent = lighting.transform;
        monitorLight.transform.position =
            new Vector3(2.75f, 1.65f, -0.75f);

        Light ml = monitorLight.AddComponent<Light>();
        ml.type = LightType.Point;
        ml.color = new Color(0.18f, 0.40f, 0.65f);
        ml.intensity = 2.5f;
        ml.range = 3.5f;
        ml.shadows = LightShadows.Soft;

        // Very weak room fill
        GameObject fill = new GameObject("Room_Fill");
        fill.transform.parent = lighting.transform;
        fill.transform.position =
            new Vector3(-1.0f, 2.3f, 1.8f);

        Light fl = fill.AddComponent<Light>();
        fl.type = LightType.Point;
        fl.color = new Color(0.28f, 0.25f, 0.22f);
        fl.intensity = 0.65f;
        fl.range = 6f;

        // =========================================================
        // PLAYER
        // =========================================================

        GameObject player = new GameObject("Player");
        player.transform.position =
            new Vector3(0.3f, 0.10f, 2.6f);

        CharacterController controller =
            player.AddComponent<CharacterController>();

        controller.height = 1.8f;
        controller.radius = 0.32f;
        controller.center = new Vector3(0, 0.9f, 0);

        player.AddComponent<SimpleFirstPersonController>();

        GameObject cameraObj = new GameObject("Main Camera");
        cameraObj.tag = "MainCamera";
        cameraObj.transform.parent = player.transform;
        cameraObj.transform.localPosition =
            new Vector3(0, 1.55f, 0);
        cameraObj.transform.localRotation =
            Quaternion.Euler(0, 180, 0);

        Camera camera = cameraObj.AddComponent<Camera>();
        camera.fieldOfView = 65;
        camera.nearClipPlane = 0.05f;

        cameraObj.AddComponent<AudioListener>();

        // =========================================================
        // SAVE
        // =========================================================

        string scenePath =
            "Assets/Scenes/HaikaiRoom_V3.unity";

        EditorSceneManager.SaveScene(scene, scenePath);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log(
            "HAIKAI ROOM V3 SUCCESS: " + scenePath
        );
    }

    // =============================================================
    // HELPERS
    // =============================================================

    static GameObject Root(string name)
    {
        return new GameObject(name);
    }

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
        obj.transform.parent = parent;

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
            Cube(name, position, scale, material, parent);

        obj.transform.rotation =
            Quaternion.Euler(rotation);

        return obj;
    }

    static void Cylinder(
        string name,
        Vector3 position,
        Vector3 scale,
        Material material,
        Transform parent
    )
    {
        GameObject obj =
            GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        obj.name = name;
        obj.transform.position = position;
        obj.transform.localScale = scale;
        obj.transform.parent = parent;

        obj.GetComponent<Renderer>().sharedMaterial =
            material;
    }

    static void Sphere(
        string name,
        Vector3 position,
        Vector3 scale,
        Material material,
        Transform parent
    )
    {
        GameObject obj =
            GameObject.CreatePrimitive(PrimitiveType.Sphere);

        obj.name = name;
        obj.transform.position = position;
        obj.transform.localScale = scale;
        obj.transform.parent = parent;

        obj.GetComponent<Renderer>().sharedMaterial =
            material;
    }

    static void DeskLeg(
        Vector3 origin,
        float x,
        float z,
        Material material,
        Transform parent,
        string name
    )
    {
        Cube(
            name,
            origin + new Vector3(x, 0.42f, z),
            new Vector3(0.12f, 0.84f, 0.12f),
            material,
            parent
        );
    }
}
