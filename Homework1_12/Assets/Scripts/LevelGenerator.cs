using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] Platform_Prefab;
    public GameObject StartPlatform_Prefab; // стартовая платформа (платформа всегда создается первой, под игроком)
    public int minPlatformsQuantity;    // минимальное количество платформ
    public int maxPlatformsQuantity;    // максимальное количество платформ
    public float DistanceBetweenPlatforms;  // расстояние между платформами
    public Transform FinishPlatform;    // финальная платформа
    public Transform CylinderRoot;  // цилиндр (ось)
    public float AdditionalCylinderScale = 1f;  // увеличение размера цилиндра
    public GameState GameState; // игровое состояние (PLAY, WIN, LOSE)

    private void Awake()
    {
        int levelIndex = GameState.LevelIndex;
        Random random = new Random(levelIndex);
        int platformsCount = RandomRange(random,minPlatformsQuantity, maxPlatformsQuantity + 1 * levelIndex);

        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, Platform_Prefab.Length);
            GameObject platformPrefab = i == 0 ? StartPlatform_Prefab : Platform_Prefab[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);

        }
        
        FinishPlatform.transform.localPosition = CalculatePlatformPosition(platformsCount);
        CylinderRoot.localScale = new Vector3(1, platformsCount * DistanceBetweenPlatforms + AdditionalCylinderScale, 1);
    }
    private int RandomRange(Random random,int min, int maxExclusive) 
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }

    private float RandomRange(Random random, float min, float max) 
    {
        float t = (float) random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatforms * platformIndex, 0);
    }
}
