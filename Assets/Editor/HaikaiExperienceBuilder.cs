using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.IO;

public static class HaikaiExperienceBuilder
{
    [MenuItem("IHC/Build Haikai Experience V2")]
    public static void Build()
    {
        string sourceScene = "Assets/Scenes/HaikaiVR.unity";
        string targetScene = "Assets/Scenes/HaikaiVR_V2.unity";

        if (!File.Exists(sourceScene))
        {
            Debug.LogError("Base scene not found: " + sourceScene);
            return;
        }

        Scene scene = EditorSceneManager.OpenScene(
            sourceScene,
            OpenSceneMode.Single
        );

        // Remove V2 from previous executions, if any.
        GameObject oldRoot = GameObject.Find("Experience_V2");

        if (oldRoot != null)
            Object.DestroyImmediate(oldRoot);

        GameObject root = new GameObject("Experience_V2");

        GameObject furniture = new GameObject("Furniture");
        furniture.transform.parent = root.transform;

        GameObject narrative = new GameObject("Narrative");
        narrative.transform.parent = root.transform;

        GameObject atmosphere = new GameObject("Atmosphere");
        atmosphere.transform.parent = root.transform;

        // ---------- Materials ----------

        Material bedMat = CreateMaterial(
            "V2_Bed",
            new Color(0.20f, 0.21f, 0.24f)
        );

        Material mattressMat = CreateMaterial(
            "V2_Mattress",
            new Color(0.62f, 0.62f, 0.60f)
        );

        Material pillowMat = CreateMaterial(
            "V2_Pillow",
            new Color(0.73f, 0.73f, 0.70f)
        );

        Material doorMat = CreateMaterial(
            "V2_Door",
            new Color(0.16f, 0.10f, 0.07f)
        );

        Material tableMat = CreateMaterial(
            "V2_Table",
            new Color(0.14f, 0.10f, 0.08f)
        );

        Material darkMat = CreateMaterial(
            "V2_DarkObject",
            new Color(0.06f, 0.06f, 0.07f)
        );

        // ---------- ROOM 1: CONFINEMENT ----------

        CreateBed(
            new Vector3(-2.7f, 0.35f, 1.0f),
            bedMat,
            mattressMat,
            pillowMat,
            furniture.transform,
            "Room01_Bed"
        );

        CreateTable(
            new Vector3(2.8f, 0, 1.7f),
            tableMat,
            furniture.transform,
            "Room01_Table"
        );

        CreateWindow(
            new Vector3(-4.86f, 1.75f, 0),
            Quaternion.Euler(0, 90, 0),
            darkMat,
            furniture.transform,
            "Room01_Window"
        );

        // ---------- ROOM 2: FEAR / PARANOIA ----------

        CreateCube(
            "Room02_ChairSeat",
            new Vector3(-2.5f, 0.65f, 16),
            new Vector3(1.1f, 0.15f, 1.1f),
            tableMat,
            furniture.transform
        );

        CreateCube(
            "Room02_ChairBack",
            new Vector3(-2.5f, 1.25f, 16.45f),
            new Vector3(1.1f, 1.2f, 0.15f),
            tableMat,
            furniture.transform
        );

        CreateCube(
            "Room02_Shadow",
            new Vector3(3.8f, 1.2f, 17.8f),
            new Vector3(0.5f, 2.4f, 0.5f),
            darkMat,
            furniture.transform
        );

        // ---------- ROOM 3: ISOLATION ----------

        CreateBed(
            new Vector3(-2.4f, 0.35f, 32),
            bedMat,
            mattressMat,
            pillowMat,
            furniture.transform,
            "Room03_Bed"
        );

        CreateTable(
            new Vector3(2.8f, 0, 32.8f),
            tableMat,
            furniture.transform,
            "Room03_Table"
        );

        CreateDoor(
            new Vector3(3.8f, 1.35f, 36.72f),
            Quaternion.identity,
            doorMat,
            furniture.transform,
            "Final_Closed_Door"
        );

        // ---------- Additional atmosphere ----------

        // ---------- Additional atmosphere ----------

        CreateRedLight(
            "FearLight",
            new Vector3(3.3f, 2.2f, 17.5f),
            1.8f,
            7f,
            atmosphere.transform
        );

        CreateColdLight(
            "IsolationLight",
            new Vector3(-2.0f, 2.3f, 32),
            1.6f,
            8f,
            atmosphere.transform
        );

        // ---------- Save V2 ----------

        EditorSceneManager.SaveScene(
            scene,
            targetScene
        );

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log(
            "HAIKAI V2 SUCCESS: Assets/Scenes/HaikaiVR_V2.unity"
        );
    }

    static Material CreateMaterial(string name, Color color)
    {
        string path = "Assets/Materials/" + name + ".mat";

        Material existing =
            AssetDatabase.LoadAssetAtPath<Material>(path);

        if (existing != null)
            return existing;

        Shader shader =
            Shader.Find("Universal Render Pipeline/Lit");

        if (shader == null)
            shader = Shader.Find("Standard");

        Material material = new Material(shader);
        material.color = color;

        AssetDatabase.CreateAsset(material, path);

        return material;
    }

    static void CreateCube(
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

        obj.GetComponent<Renderer>().sharedMaterial = material;
    }

    static void CreateBed(
        Vector3 position,
        Material frame,
        Material mattress,
        Material pillow,
        Transform parent,
        string prefix
    )
    {
        CreateCube(
            prefix + "_Frame",
            position,
            new Vector3(2.2f, 0.35f, 4.0f),
            frame,
            parent
        );

        CreateCube(
            prefix + "_Mattress",
            position + new Vector3(0, 0.32f, 0),
            new Vector3(2.0f, 0.32f, 3.8f),
            mattress,
            parent
        );

        CreateCube(
            prefix + "_Pillow",
            position + new Vector3(0, 0.58f, 1.35f),
            new Vector3(1.45f, 0.22f, 0.65f),
            pillow,
            parent
        );

        CreateCube(
            prefix + "_Headboard",
            position + new Vector3(0, 0.8f, 1.95f),
            new Vector3(2.2f, 1.3f, 0.18f),
            frame,
            parent
        );
    }

    static void CreateTable(
        Vector3 position,
        Material material,
        Transform parent,
        string prefix
    )
    {
        CreateCube(
            prefix + "_Top",
            position + new Vector3(0, 0.85f, 0),
            new Vector3(1.5f, 0.15f, 1.1f),
            material,
            parent
        );

        float x = 0.6f;
        float z = 0.4f;

        CreateCube(
            prefix + "_Leg1",
            position + new Vector3(-x, 0.4f, -z),
            new Vector3(0.12f, 0.8f, 0.12f),
            material,
            parent
        );

        CreateCube(
            prefix + "_Leg2",
            position + new Vector3(x, 0.4f, -z),
            new Vector3(0.12f, 0.8f, 0.12f),
            material,
            parent
        );

        CreateCube(
            prefix + "_Leg3",
            position + new Vector3(-x, 0.4f, z),
            new Vector3(0.12f, 0.8f, 0.12f),
            material,
            parent
        );

        CreateCube(
            prefix + "_Leg4",
            position + new Vector3(x, 0.4f, z),
            new Vector3(0.12f, 0.8f, 0.12f),
            material,
            parent
        );
    }

    static void CreateDoor(
        Vector3 position,
        Quaternion rotation,
        Material material,
        Transform parent,
        string name
    )
    {
        CreateCube(
            name,
            position,
            new Vector3(2.0f, 2.7f, 0.16f),
            material,
            parent
        );

        GameObject knob =
            GameObject.CreatePrimitive(PrimitiveType.Sphere);

        knob.name = name + "_Knob";
        knob.transform.position =
            position + new Vector3(0.65f, 0, -0.13f);

        knob.transform.localScale =
            new Vector3(0.13f, 0.13f, 0.13f);

        knob.transform.parent = parent;
    }

    static void CreateWindow(
        Vector3 position,
        Quaternion rotation,
        Material material,
        Transform parent,
        string name
    )
    {
        GameObject window =
            GameObject.CreatePrimitive(PrimitiveType.Quad);

        window.name = name;
        window.transform.position = position;
        window.transform.rotation = rotation;
        window.transform.localScale =
            new Vector3(2.3f, 1.6f, 1);

        window.transform.parent = parent;

        window.GetComponent<Renderer>().sharedMaterial =
            material;
    }

    static void CreateWorldText(
        string name,
        string content,
        Vector3 position,
        Quaternion rotation,
        float characterSize,
        TextAnchor anchor,
        Transform parent
    )
    {
        GameObject obj = new GameObject(name);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.transform.parent = parent;

        TextMesh text = obj.AddComponent<TextMesh>();

        text.text = content;
        text.characterSize = characterSize;
        text.fontSize = 64;
        text.anchor = anchor;
        text.alignment = TextAlignment.Center;
        text.color = new Color(0.88f, 0.88f, 0.88f);
    }

    static void CreateRedLight(
        string name,
        Vector3 position,
        float intensity,
        float range,
        Transform parent
    )
    {
        GameObject obj = new GameObject(name);
        obj.transform.position = position;
        obj.transform.parent = parent;

        Light light = obj.AddComponent<Light>();
        light.type = LightType.Point;
        light.color = new Color(0.55f, 0.08f, 0.06f);
        light.intensity = intensity;
        light.range = range;
        light.shadows = LightShadows.Soft;
    }

    static void CreateColdLight(
        string name,
        Vector3 position,
        float intensity,
        float range,
        Transform parent
    )
    {
        GameObject obj = new GameObject(name);
        obj.transform.position = position;
        obj.transform.parent = parent;

        Light light = obj.AddComponent<Light>();
        light.type = LightType.Point;
        light.color = new Color(0.25f, 0.35f, 0.55f);
        light.intensity = intensity;
        light.range = range;
        light.shadows = LightShadows.Soft;
    }
}



